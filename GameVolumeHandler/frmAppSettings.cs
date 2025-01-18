using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameVolumeHandler
{
    public partial class frmAppSettings : Form
    {
        string connectionString = @"Data Source=GameVolumeHandler.db;Version=3;";
        // move ths into a app.config file lol

        public frmAppSettings()
        {
            InitializeComponent();
        }

        private async void frmAppSettings_Load(object sender, EventArgs e)
        {
            await LoadAppSettings();
        }

        private async Task LoadAppSettings()
        {
            //string[] runningProcesses = GetProcesses();
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                string selectQuery = "SELECT * FROM AppSettings;";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        int counter = 0;
                        while (await reader.ReadAsync())
                        {
                            Label settingLabel = new Label();
                            CheckBox settingLabelInput = new CheckBox();
                            settingLabel.Text = reader["SettingName"].ToString();
                            settingLabelInput.Text = Convert.ToBoolean(Convert.ToInt32(reader["IsActive"].ToString())) ? "Yes" : "No";
                            settingLabelInput.Checked = Convert.ToBoolean(Convert.ToInt32(reader["IsActive"].ToString()));
                            try
                            {
                                tableLayoutPanel1.Controls.Add(settingLabel, 0, counter);
                                counter++;
                                tableLayoutPanel1.Controls.Add(settingLabelInput, 1, counter);
                                counter++;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                throw;
                            }
                        }
                    }
                }
            }
        }
    }
}
