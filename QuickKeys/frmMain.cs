﻿using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuickKeys.Tools.KeysEnum;

namespace QuickKeys
{
    public partial class frmMain : Form
    {

        private IntPtr _hook;

        string connectionString = @"Data Source=QuickKeys.db;Version=3;";

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int currentHotkeyId = 1;

        private List<Tuple<int, string>> savedHoteys; // probably change this to a diction type is performance issues arise

        public frmMain()
        {
            InitializeComponent();

            // DataGridView styling

            dgvMain.ForeColor = Color.GhostWhite;
            dgvMain.BackgroundColor = Color.Black;

            dgvMain.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(31, 31, 31);
            dgvMain.RowsDefaultCellStyle.BackColor = Color.FromArgb(13, 13, 13);

            dgvMain.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(61, 61, 61);
            dgvMain.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvMain.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvMain.DefaultCellStyle.Font = new Font("Arial", 10);

            dgvMain.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(61, 61, 61);
            dgvMain.RowHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMain.DefaultCellStyle.SelectionBackColor = Color.FromArgb(50, 81, 82);
            dgvMain.EnableHeadersVisualStyles = false;

            dgvMain.CellEndEdit += DgvMain_CellEndEdit;

            //HookFocusChange();
            RegisterGlobalHotkey();

            using (var connection = new SQLiteConnection(connectionString))
            {

                connection.Open();
                PerformInitialSetup(connection);
                LoadDBValuesToGrid();
                connection.Close(); // using should handle this but old habits die hard i guess
                //StartProcessMonitoring();
            }
            
        }

        private void PerformInitialSetup(SQLiteConnection connection)
        {
            // Creating a table if it doesn't exist
            string createAppsTableQuery = @"CREATE TABLE IF NOT EXISTS AppsToMonitorVolume (
                                          Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                          ExeName TEXT,
                                          IsActive INTEGER,
                                          ToggleHotkey TEXT
                                        );";
            using (var command = new SQLiteCommand(createAppsTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            // Creating global settings table if it doesn't exist
            string createAppSettingsTableQuery = @"CREATE TABLE IF NOT EXISTS AppSettings (
                                          SettingName TEXT PRIMARY KEY,
                                          IsActive INTEGER,
                                          SettingHotkey TEXT
                                        );";
            using (var command = new SQLiteCommand(createAppSettingsTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            string insertAppTableQuery = @"INSERT INTO AppsToMonitorVolume VALUES (0, 'chrome.exe', 1, 'UNBOUND');";
            using (var command = new SQLiteCommand(insertAppTableQuery, connection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch // ignore dupe entry
                {
                }

            }

            string insertSetting1TableQuery = @"INSERT INTO AppSettings VALUES ('Mute all Active Status Exes', 1, 'Keys.L')";
            using (var command = new SQLiteCommand(insertSetting1TableQuery, connection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                }

            }
            string insertSetting2TableQuery = @"INSERT INTO AppSettings VALUES ('Display over other windows', 1, 'Keys.P')";
            using (var command = new SQLiteCommand(insertSetting2TableQuery, connection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                }

            }
            string insertSetting3TableQuery = @"INSERT INTO AppSettings VALUES ('Bring app to front', 1, 'Keys.O')";
            using (var command = new SQLiteCommand(insertSetting3TableQuery, connection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                }

            }
        }

        private void DgvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Get the value entered in the cell
            string keybind = dgvMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

            if (!string.IsNullOrEmpty(keybind))
            {
                // Parse keybind into modifiers and key using the USKeys enum
                if (TryParseKeybind(keybind, out int modifiers, out USKeys key))
                {
                    // Unregister the previous hotkey if needed
                    UnregisterHotKey(this.Handle, currentHotkeyId);

                    // Register the new hotkey
                    if (RegisterHotKey(this.Handle, currentHotkeyId, modifiers, (int)key))
                    {
                        savedHoteys.Add(new Tuple<int, string>(currentHotkeyId, key.ToString()));
                        MessageBox.Show($"Hotkey '{keybind}' registered successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to register the hotkey.");
                    }

                    currentHotkeyId++; // Increment the hotkey ID for uniqueness
                }
                else
                {
                    MessageBox.Show("Invalid keybind format. Use something like 'Ctrl+Alt+D1'.");
                }
            }
        }

        //private void HookFocusChange()
        //{
        //    // set up a hook to detect foreground window changes
        //    WinEventHook.WinEventDelegate procDelegate = new WinEventHook.WinEventDelegate(WinEventCallback);
        //    _hook = WinEventHook.SetWinEventHook(WinEventHook.EVENT_SYSTEM_FOREGROUND, WinEventHook.EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, procDelegate, 0, 0, WinEventHook.WINEVENT_OUTOFCONTEXT);
        //}
        //
        //private void UnhookFocusChange()
        //{
        //    try
        //    {
        //        this.Dispose();
        //        WinEventHook.UnhookWinEvent(_hook);
        //    }
        //    catch (Exception)
        //    {
        //        this.Dispose();
        //    }
        //    // unhook the event
        //}

        private void WinEventCallback(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            try
            {
                // Check if the foreground window is a executable or any specific process
                Process foregroundProcess = Process.GetProcessById((int)hwnd);
                if (foregroundProcess != null && foregroundProcess.MainModule != null)
                {
                    string foregroundProcessName = foregroundProcess.MainModule.ModuleName;
                    // Check if the process name matches your executable
                    if (foregroundProcessName == "chrome.exe")
                    {
                        // exe has gained focus
                        MessageBox.Show("chrome.exe focused");
                    }
                    else
                    {
                        // exe has lost focus
                        Console.WriteLine("chrome.exe focused");
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
            
        }

        private async void btnFileSelect_Click(object sender, EventArgs e)
        {
            string fileName;

            using (var selectFileDialog = new OpenFileDialog())
            {

                selectFileDialog.Filter = "Exe files(*.exe)| *.exe";

                if (selectFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = selectFileDialog.SafeFileName;
                    await InsertAndRefreshValues(fileName);
                }
            }
        }

        private async Task LoadDBValuesToGrid()
        {
            dgvMain.Rows.Clear();

            string[] runningProcesses = GetProcesses();
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                string selectQuery = "SELECT * FROM AppsToMonitorVolume;";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            DataGridViewRow row = new DataGridViewRow();

                            DataGridViewTextBoxCell cellExeRunning = new DataGridViewTextBoxCell();
                            cellExeRunning.Value = runningProcesses.Contains(reader["ExeName"].ToString().ToLower().Replace(".exe", "")) ? "Yes" : "No";
                            cellExeRunning.Tag = "Yes";
                            row.Cells.Add(cellExeRunning);

                            DataGridViewTextBoxCell cellExeName = new DataGridViewTextBoxCell();
                            cellExeName.Value = reader["ExeName"].ToString();
                            cellExeName.Tag = reader["Id"].ToString();
                            row.Cells.Add(cellExeName);

                            DataGridViewTextBoxCell cellActiveStatus = new DataGridViewTextBoxCell();
                            cellActiveStatus.Value = Convert.ToBoolean(reader["IsActive"]);
                            cellActiveStatus.Tag = reader["IsActive"].ToString();
                            row.Cells.Add(cellActiveStatus);

                            DataGridViewTextBoxCell cellToggleHotkey = new DataGridViewTextBoxCell();
                            cellToggleHotkey.Value = reader["ToggleHotkey"].ToString();
                            row.Cells.Add(cellToggleHotkey);

                            DataGridViewTextBoxCell cellDelete = new DataGridViewTextBoxCell();
                            cellDelete.Value = "X";
                            row.Cells.Add(cellDelete);

                            dgvMain.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private string[] GetProcesses()
        {
            List<string> processNames = new List<string>();

            Process[] runningProcesses = Process.GetProcesses();

            foreach (Process process in runningProcesses)
            {
                try
                {
                    processNames.Add(process.ProcessName.ToLower());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not access process {process.Id}: {ex.Message}", "Could not access process.");
                }
            }

            return processNames.ToArray();
        }

        private async Task InsertExeIntoDB(string exeName)
        {
            string tempValidatedExeName = exeName.ToLower().Replace(".exe", "");
            if (exeName == tempValidatedExeName)
            {
                tempValidatedExeName += ".exe";
                exeName = tempValidatedExeName;
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                string insertQuery = "INSERT INTO AppsToMonitorVolume (ExeName, IsActive) VALUES (@ExeName, 1);";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@ExeName", exeName);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private async Task DeleteExeFromDB(int Id)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                string deleteQuery = $@"DELETE FROM AppsToMonitorVolume WHERE Id = {Id}";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e) {}        

        private async void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowIndex = dgvMain.SelectedCells[0].RowIndex;
            int selectedColumnIndex = dgvMain.SelectedCells[0].ColumnIndex;

            object selectedCellValue = dgvMain[selectedColumnIndex, selectedRowIndex].Value;

            try
            {
                if (dgvMain.Columns[selectedColumnIndex].HeaderText == "Delete")
                {
                    // delete option
                    DialogResult mBoxResult = MessageBox.Show($"Remove {dgvMain[1, selectedRowIndex].Value.ToString().Replace(".exe", "") + "?"}", "Really remove this Exe?", MessageBoxButtons.YesNo);
                    if (mBoxResult == DialogResult.Yes)
                    {
                        int id = int.Parse(dgvMain[1, selectedRowIndex].Tag.ToString());
                        await DeleteExeFromDB(id);
                        await LoadDBValuesToGrid();
                    }
                }

                if (dgvMain.Columns[selectedColumnIndex].HeaderText == "Active")
                {
                    int status = int.Parse(dgvMain[selectedColumnIndex, selectedRowIndex].Tag.ToString());
                    int id = int.Parse(dgvMain[1, selectedRowIndex].Tag.ToString());

                    await ToggleExeStatus(id, status);
                    await LoadDBValuesToGrid();
                }
            }
            catch
            {
            }
            
        }

        private async Task ToggleExeStatus(int id, int status)
        {
            if (status == 1)
            {
                status = 0;
            }
            else
            {
                status = 1;
            }
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                string updateQuery = $@"UPDATE AppsToMonitorVolume SET IsActive = {status} WHERE
                                        ID = {id};";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //UnhookFocusChange();
            base.OnFormClosing(e);
        }

        private async void btnAddToList_Click(object sender, EventArgs e)
        {
            string fileName = txtExeName.Text.Replace(" ", "");
            await InsertAndRefreshValues(fileName);
        }

        private async Task InsertAndRefreshValues(string fileName)
        {
            if (await CheckIfExeExists(fileName)) return;
            await InsertExeIntoDB(fileName);
            await LoadDBValuesToGrid();
        }

        private async Task<bool> CheckIfExeExists(string exeName)
        {
            string tempValidatedExeName = exeName.ToLower().Replace(".exe", "");
            if (exeName == tempValidatedExeName)
            {
                tempValidatedExeName += ".exe";
                exeName = tempValidatedExeName;
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                string checkQuery = "SELECT COUNT(1) FROM AppsToMonitorVolume WHERE ExeName = @ExeName;";
                using (var command = new SQLiteCommand(checkQuery, connection))
                {
                    command.Parameters.AddWithValue("@ExeName", exeName);
                    return Convert.ToInt32(await command.ExecuteScalarAsync()) > 0;
                }
            }
        }

        private void RegisterGlobalHotkey()
        {
            const int MOD_ALT = 0x0001; // Alt key modifier
            const int MOD_CONTROL = 0x0002; // Control key modifier
            const int VK_M = 0x4D; // M key
            const int HOTKEY_ID = 1; // Identifier for the hotkey

            bool success = RegisterHotKey(this.Handle, HOTKEY_ID, MOD_CONTROL | MOD_ALT, VK_M);

            if (!success)
            {
                MessageBox.Show("Failed to register global Hotkey.");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            for (int i = 1; i <= currentHotkeyId; i++)
            {
                UnregisterHotKey(this.Handle, i);
            }
            base.OnFormClosing(e);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (savedHoteys == null)
            {
                savedHoteys = new List<Tuple<int, string>>();
            }

            if (m.Msg == WM_HOTKEY)
            {
                int hotkeyId = m.WParam.ToInt32();

                if (hotkeyId == 1) // HOTKEY_ID
                {
                    _ = ToggleExeMute();
                }
                else if(hotkeyId>1) // must be a custom users hotkey?
                {
                    string hotkey = savedHoteys.Where(x => x.Item1 == hotkeyId)
                        .Select(x => x.Item2)
                        .ToList().FirstOrDefault();

                    _ = ToggleExeMuteByHotkey(hotkey);
                }
            }

            base.WndProc(ref m);
        }

        private async void txtExeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string fileName = txtExeName.Text.Replace(" ", "");
                await InsertAndRefreshValues(fileName);
            }
        }

        private async void btnAppSettings_Click(object sender, EventArgs e)
        {
            frmAppSettings frmAppSettings = new frmAppSettings();
            frmAppSettings.ShowDialog();
            // this used to be the btnAppSettings_Click temp event handler
            // await ToggleExeMute();
        }

        private async Task ToggleExeMute()
        {
            var connection = new SQLiteConnection(connectionString);
            await connection.OpenAsync();

            string selectQuery = "SELECT ExeName, IsActive FROM AppsToMonitorVolume;";
            var command = new SQLiteCommand(selectQuery, connection);
            var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                string exeName = reader["ExeName"].ToString();
                bool isActive = Convert.ToBoolean(reader["IsActive"]);

                await SetApplicationMute(exeName, isActive);           
            }
        }

        private async Task ToggleExeMuteByHotkey(string hotkey)
        {
            await SetApplicationMuteIndividual(hotkey);
        }

        private SessionCollection GetAudioSessionsList()
        {
            var enumerator = new MMDeviceEnumerator();
            var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            return device.AudioSessionManager.Sessions;

        }

        private async Task SetApplicationMuteIndividual(string hotkey)
        {
            string exeName = "";
            for (int i = 0; i < dgvMain.Rows.Count; i++)
            {
                if (dgvMain.Rows[i].Cells[3].Value.ToString().ToLower() == hotkey.ToLower())
                {
                    exeName = dgvMain.Rows[i].Cells[1].Value.ToString().ToLower();
                    break;
                }
                
            }
            AudioSessionControl session = await GetAudioSession(exeName, GetAudioSessionsList());
            session.SimpleAudioVolume.Mute = !session.SimpleAudioVolume.Mute;
        }

        private async Task<AudioSessionControl> GetAudioSession(string exeName, SessionCollection sessions)
        {
            for (int i = 0; i < sessions.Count; i++)
            {
                var session = sessions[i];
                if (session.GetProcessID != 0) // Excludes system sounds
                {
                    var process = Process.GetProcessById((int)session.GetProcessID);
                    if (process.ProcessName.ToLower().Replace(".exe", "")
                            .Equals(
                            exeName.ToLower().Replace(".exe", ""),
                            StringComparison.OrdinalIgnoreCase
                            )
                       )
                    {
                        return session;
                    }
                }
            }
            return null;
        }

        private async Task SetApplicationMute(string exeName, bool mute)
        {
            var sessions = GetAudioSessionsList();
            for (int i = 0; i < sessions.Count; i++)
            {
                var session = sessions[i];
                if (session.GetProcessID != 0) // Excludes system sounds
                {
                    var process = Process.GetProcessById((int)session.GetProcessID);
                    if (process.ProcessName.ToLower().Replace(".exe", "")
                            .Equals(
                            exeName.ToLower().Replace(".exe", ""),
                            StringComparison.OrdinalIgnoreCase
                            )
                       )
                    {
                        session.SimpleAudioVolume.Mute = mute;
                    }
                }
            }
        }

        private bool TryParseKeybind(string keybind, out int modifiers, out USKeys key)
        {
            modifiers = 0;
            key = USKeys.None;

            string[] parts = keybind.Split('+');
            foreach (string part in parts)
            {
                string trimmedPart = part.Trim();

                // Check for modifiers
                if (trimmedPart.Equals("Ctrl", StringComparison.OrdinalIgnoreCase))
                {
                    modifiers |= 0x0002; // MOD_CONTROL
                }
                else if (trimmedPart.Equals("Alt", StringComparison.OrdinalIgnoreCase))
                {
                    modifiers |= 0x0001; // MOD_ALT
                }
                else if (trimmedPart.Equals("Shift", StringComparison.OrdinalIgnoreCase))
                {
                    modifiers |= 0x0004; // MOD_SHIFT
                }
                else if (trimmedPart.Equals("Win", StringComparison.OrdinalIgnoreCase))
                {
                    modifiers |= 0x0008; // MOD_WIN
                }
                else
                {
                    // match the key using Keys enum
                    if (Enum.TryParse(trimmedPart, true, out USKeys parsedKey))
                    {
                        key = parsedKey;
                    }
                    else
                    {
                        return false; // Invalid keybind
                    }
                }
            }

            // Ensure have at least one key and potential modifiers
            return key != USKeys.None;
        }

        private void dgvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string keyPressed = dgvMain[e.ColumnIndex, e.RowIndex].Value.ToString();
            //SaveKeybind(keyPressed); todo
        }
    }    
}
