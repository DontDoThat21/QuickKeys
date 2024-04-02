using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace GameVolumeHandler
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(@"Data Source=C:MySQLiteDB.s3db0");
            conn.Open();

            SqliteCommand cmd = new SqliteCommand();
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            string fileName;

            using (var selectFileDialog = new OpenFileDialog())
            {
                if (selectFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = selectFileDialog.FileName;
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
