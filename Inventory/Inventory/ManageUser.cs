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
    public partial class ManageUser : Form
    {
        public ManageUser()
        {
            InitializeComponent();
        }
        SqlConnection connection= new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Documents\Inventorydb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(phoneTb.Text == "")
            {
                MessageBox.Show("Enter The Users Phone Number");
            }
            else
            {
                connection.Open();
                string myquery = "delete from UserTbl where Uphone = '" + phoneTb.Text + "';";
                SqlCommand cmd = new SqlCommand(myquery, connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Deleted");
                connection.Close();
                populate();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void populate()
        {
            try
            {
                connection.Open();
                String Myquery = "select * from UserTbl";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                UsersGV.DataSource = ds.Tables[0];
                connection.Close();
                
            }
            catch
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            populate();
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into UserTbl values('" + unameTb.Text + "', '" + fnameTb.Text + "', '" + passwordTb.Text + "', '" + phoneTb.Text + "')", connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Added ");
                connection.Close();
                populate();
            }
            catch
            {

            }
        }

        private void UsersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            unameTb.Text = UsersGV.SelectedRows[0].Cells[0].Value.ToString();
            fnameTb.Text = UsersGV.SelectedRows[0].Cells[1].Value.ToString();
            passwordTb.Text = UsersGV.SelectedRows[0].Cells[2].Value.ToString();
            phoneTb.Text = UsersGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("update UserTbl set Uname = '" + unameTb.Text + "'Ufullname='" + fnameTb.Text + "', Upassword = '" + passwordTb.Text + "', where Uphone = '" + phoneTb.Text + "',", connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully Updated");
                connection.Close();
                populate();
            }
            catch
            {

            }
        }

        private void passwordTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
