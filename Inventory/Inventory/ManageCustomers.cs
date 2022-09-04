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
namespace Inventory
{
    public partial class ManageCustomers : Form
    {
        public ManageCustomers()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Documents\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");
        void populate()
        {
            try
            {
                connection.Open();
                String Myquery = "select * from CustomerTbl";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                CustomersGV.DataSource = ds.Tables[0];
                connection.Close();

            }
            catch
            {

            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into CustomerTbl values(" + customerid.Text + ", '" + customerNameTb.Text + "', '" + customerPhoneTb.Text + "')", connection);
            {

            }
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Successfully Added ");
                connection.Close();
                populate();
            }
            catch
            {

            }
        }

        private void cutomerNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void ManageCustomers_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (customerid.Text == "")
            {
                MessageBox.Show("Enter The Customer id Number");
            }
            else
            {
                connection.Open();
                string myquery = "delete from CustomerTbl where Custid = '" + customerid.Text + "';";
                SqlCommand cmd = new SqlCommand(myquery, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Successfully Deleted");
                connection.Close();
                populate();

            }
        }

        private void CustomersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            customerid.Text = CustomersGV.SelectedRows[0].Cells[0].Value.ToString();
            customerNameTb.Text = CustomersGV.SelectedRows[0].Cells[1].Value.ToString();
            customerPhoneTb.Text = CustomersGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("update CustomerTbl set CustName = '" + customerNameTb.Text + "',CustPhone='" + customerPhoneTb + "', where Custid = '" + customerid.Text + "',", connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Successfully Updated");
                connection.Close();
                populate();
            }
            catch
            {

            }
        }
    }
}
