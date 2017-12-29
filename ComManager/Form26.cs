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
    public partial class Form26 : Form
    {
        public Form26()
        {
            InitializeComponent();
        }
        private ContactsInfo ci = new ContactsInfo();
        private ContactsManager cm = new ContactsManager();
        private void button1_Click(object sender, EventArgs e)
        {
            ci = new ContactsInfo()
            {
                Contacts = name.Text,
                English_name = engname.Text,
                Job = job.Text,
                Phone = phone.Text,
                Mophone=mophone.Text,
                Email=email.Text,
                Fax=fax.Text
            };
            string messageStr = null;

            if (cm.Add(ci, out messageStr))
            {
                MessageBox.Show("添加联系人成功");
                this.Hide();
            }
            else
            {
                MessageBox.Show(messageStr);
            }

        }
        
    }
}
