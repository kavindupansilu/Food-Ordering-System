using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Food : Form
    {
        public Food()
        {
            InitializeComponent();
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EQ55Q8H\SQLEXPRESS;Initial Catalog=foodorderingDb;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into foodtab (foodid, foodname, price, quantity, status) values (@FoodId, @FoodName, @Price, @Quantity, @Status)", conn);
                cmd.Parameters.AddWithValue("@FoodId", int.Parse(foodidtxt.Text));
                cmd.Parameters.AddWithValue("@FoodName", fnametxt.Text);
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(pricetxt.Text));
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(qtytxt.Text));
                cmd.Parameters.AddWithValue("@Status", statustxt.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void butadd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EQ55Q8H\SQLEXPRESS;Initial Catalog=foodorderingDb;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from foodtab", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void butnew_Click(object sender, EventArgs e)
        {
            foodidtxt.Text = "";
            fnametxt.Text = "";
            pricetxt.Text = "";
            qtytxt.Text = "";
            statustxt.Text = "";
        }

        private void butupdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EQ55Q8H\SQLEXPRESS;Initial Catalog=foodorderingDb;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update foodtab set foodname=@FoodName, price=@Price, quantity=@Quantity, status=@Status where foodid=@FoodId", conn);
                cmd.Parameters.AddWithValue("@FoodId", int.Parse(foodidtxt.Text));
                cmd.Parameters.AddWithValue("@FoodName", fnametxt.Text);
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(pricetxt.Text));
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(qtytxt.Text));
                cmd.Parameters.AddWithValue("@Status", statustxt.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void butdelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EQ55Q8H\SQLEXPRESS;Initial Catalog=foodorderingDb;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from foodtab where foodid=@FoodId", conn);
                cmd.Parameters.AddWithValue("@FoodId", int.Parse(foodidtxt.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void butdispaly_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EQ55Q8H\SQLEXPRESS;Initial Catalog=foodorderingDb;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from foodtab", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void Food_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EQ55Q8H\SQLEXPRESS;Initial Catalog=foodorderingDb;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from foodtab", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void foodidtxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
