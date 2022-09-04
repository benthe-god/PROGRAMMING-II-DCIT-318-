using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                passwordTb.UseSystemPasswordChar = true;
            else 
                passwordTb.UseSystemPasswordChar = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            unameTb.Text = "";
            passwordTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageUser man = new ManageUser();
            man.Show();
            this.Hide();
        }
    }
}
