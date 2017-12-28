using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Model;

namespace ComManager
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        RateInfo ri = new RateInfo();
        RateManager rm = new RateManager();
        private void button1_Click(object sender, EventArgs e)
        {
            ri = new RateInfo()
            {
                Startdate = dateTimePicker1.Text,
                Enddate=dateTimePicker2.Text,
                Exchange=textBox1.Text,
                Remark=textBox2.Text
            };
            string messageStr = null;

            if (rm.Add(ri, out messageStr))
            {
                MessageBox.Show("添加成功");
                this.Hide();
            }
            else
            {
                MessageBox.Show(messageStr);
            }
        }
    }
}
