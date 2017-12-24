using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComManager
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void 操作员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 fm4 = new Form4();
            fm4.Show();
        }

        private void 权限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 fm6 = new Form6();
            fm6.Show();
        }
    }
}
