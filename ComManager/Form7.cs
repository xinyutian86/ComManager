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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        ActiveUser au = new ActiveUser();
        AuManager am = new AuManager();

        private void button1_Click(object sender, EventArgs e)
        {
            au = new ActiveUser
            {
                Password = opass.Text,
                Login_name=name.Text,
                Newpass=npass2.Text
            };
            string messageStr = null;

            if (am.ChangePass(au, out messageStr))
            {
                MessageBox.Show("登录成功");
                //Form2 fm2 = new Form2();
                //fm2.Show();
                //this.Hide();
            }
            else
            {
                MessageBox.Show(messageStr);
            }
        }
    }
}
