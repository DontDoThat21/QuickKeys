using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;

namespace GameVolumeHandler
{
    public partial class frmMain : Form
    {

        string connectionString = @"Data Source=GameVolumeHandler.db;Version=3;";

        public frmMain()
        {
            InitializeComponent();

            using(var connection = new SQLiteConnection(connectionString))
            {

                connection.Open();

                // Creating a table if it doesn't exist
                string createTableQuery = @"CREATE TABLE IF NOT EXISTS GamesToMonitorVolume (
                                          Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                          ExeName TEXT,
                                          IsActive INTEGER
                                        );";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                string insertTableQuery = @"INSERT INTO GamesToMonitorVolume VALUES (0, 'Gears5.exe', 1);";
                using (var command = new SQLiteCommand(insertTableQuery, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch // ignore dupe entry
                    {
                    }
                    
                }

                LoadDBValuesToGrid();
            }
            
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            string fileName;

            using (var selectFileDialog = new OpenFileDialog())
            {

                selectFileDialog.Filter = "Exe files(*.exe)| *.exe";

                if (selectFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = selectFileDialog.SafeFileName;
                    InsertExeIntoDB(fileName);
                    LoadDBValuesToGrid();
                }
            }
        }

        private void LoadDBValuesToGrid()
        {
            dgvMain.Rows.Clear();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM GamesToMonitorVolume;";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow row = new DataGridViewRow();

                            DataGridViewTextBoxCell cellExe = new DataGridViewTextBoxCell();
                            cellExe.Value = reader["ExeName"].ToString();
                            row.Cells.Add(cellExe);

                            DataGridViewTextBoxCell cellActiveStatus = new DataGridViewTextBoxCell();
                            cellActiveStatus.Value = reader["IsActive"].ToString();
                            row.Cells.Add(cellActiveStatus);

                            DataGridViewTextBoxCell cellDelete = new DataGridViewTextBoxCell();
                            cellDelete.Value = "X";
                            row.Cells.Add(cellDelete);

                            dgvMain.Rows.Add(row);
                            //Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
                        }
                    }
                }
            }
        }

        private void InsertExeIntoDB(string ExeName)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string insertQuery = $@"INSERT INTO GamesToMonitorVolume (ExeName, IsActive) VALUES ('{ExeName}', 1);";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
