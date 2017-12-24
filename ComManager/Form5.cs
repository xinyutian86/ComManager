using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using BLL;

namespace ComManager
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        AuManager am = new AuManager();
        ActiveUser au = new ActiveUser();
        private void button1_Click(object sender, EventArgs e)
        {
            au = new ActiveUser()
            {
                Login_name = lname.Text,
                Username = uname.Text,
                Password=upass.Text
            };
            string messageStr = null;

            if (am.Add(au, out messageStr))
            {
                MessageBox.Show("添加操作员成功");
                //Form2 fm2 = new Form2();
                //fm2.Show();
                //this.Hide();
                this.Close();
            }
            else
            {
                MessageBox.Show(messageStr);
                uname.Focus();
            }
        }
    }
}
