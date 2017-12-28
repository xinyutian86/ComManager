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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }
        BaiscInfo bi = new BaiscInfo();
        BasicManager bm = new BasicManager();
        private void button1_Click(object sender, EventArgs e)
        {
            string which = App.value;
            //MessageBox.Show(which);
            bi = new BaiscInfo()
            {
                Db = which,
                Typename=textBox1.Text
            };
            string messageStr = null;

            if (bm.Add(bi, out messageStr))
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
