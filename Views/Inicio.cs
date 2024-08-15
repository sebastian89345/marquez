using System;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Inventario_Click(object sender, EventArgs e)
        {
            InventoryDs inventory = new InventoryDs();
            inventory.Show();
        }

        private void BtnDetailInventary_Click(object sender, EventArgs e)
        {
            DetailInventoryDs detailInventory = new DetailInventoryDs();
            detailInventory.Show();
        }

        private void BtnSales_Click(object sender, EventArgs e)
        {
            SalesDs sales = new SalesDs();
            sales.Show();
        }

        private void BtnCopyDb_Click(object sender, EventArgs e)
        {
            try
            {
                //string connectionString = "data source=LENOVO-PROJECT\\SQLEXPRESS04;initial catalog=MarquezaDB;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True";
                string connectionString = "data source=PERSONA\\SQLEXPRESS01;initial catalog=MarquezaDB;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True";
                string backupDirectory = @"C:\Users\cvta_\Desktop\aplicacion marqueza\DB\";
                //string backupDirectory = @"C:\Users\jquir\OneDrive\Escritorio\mis cosas\";
                string databaseName = "MarquezaDB";
                string backupFileName = $"{backupDirectory}{databaseName}_{DateTime.Now:yyyyMMddHHmmss}.bak";

                BackupDatabase(connectionString, databaseName, backupFileName);

                MessageBox.Show("Backup completed successfully.");
            }
            catch (Exception error)
            {
                MessageBox.Show($"A ocurrido un problema {error}");
                throw;
            }
        }

        static void BackupDatabase(string connectionString, string databaseName, string backupFileName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string backupQuery = $@"
                BACKUP DATABASE [{databaseName}]
                TO DISK = '{backupFileName}'
                WITH FORMAT,
                MEDIANAME = 'SQLServerBackups',
                NAME = 'Full Backup of {databaseName}';";

                using (SqlCommand command = new SqlCommand(backupQuery, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
