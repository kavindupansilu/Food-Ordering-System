using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Order_Food : Form
    {
        private string connectionString = @"Data Source=DESKTOP-EQ55Q8H\SQLEXPRESS;Initial Catalog=foodorderingDb;Integrated Security=True";

        public Order_Food()
        {
            InitializeComponent();
        }

        private void Order_Food_Load(object sender, EventArgs e)
        {
            LoadFoodTable();
            LoadOrderTable();
        }

        private void LoadFoodTable()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter foodAdapter = new SqlDataAdapter("SELECT * FROM foodtab", conn);
                    DataTable foodTable = new DataTable();
                    foodAdapter.Fill(foodTable);
                    if (foodTable.Rows.Count > 0)
                    {
                        foodGridView.DataSource = foodTable;
                    }
                    else
                    {
                        MessageBox.Show("No data found in food table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        foodGridView.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading food table: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrderTable()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter orderAdapter = new SqlDataAdapter("SELECT * FROM ordertab", conn);
                    DataTable orderTable = new DataTable();
                    orderAdapter.Fill(orderTable);
                    if (orderTable.Rows.Count > 0)
                    {
                        orderGridView.DataSource = orderTable;
                    }
                    else
                    {
                        MessageBox.Show("No data found in order table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        orderGridView.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order table: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadFoodTable();
            LoadOrderTable();
        }

        private void foodGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event if needed
        }
    }
}
