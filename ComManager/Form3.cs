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
            usertool.Text += App.user;
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

        private void 密码更改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 fm7 = new Form7();
            fm7.Show();
        }

        private void 行政区划管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 fm8 = new Form8();
            fm8.Show();
        }

        private void 地域管理管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 fm10 = new Form10();
            fm10.Show();
        }

        private void 客户类别管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form12 fm12 = new Form12();
            fm12.Show();
        }

        private void 基本资料管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form14 fm14 = new Form14();
            fm14.Show();
        }

        private void 汇率管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 fm16 = new Form16();
            fm16.Show();
        }

        private void 数据备份恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form18 fm18 = new Form18();
            fm18.Show();
        }

        private void 项目洽谈情况库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form19 fm19 = new Form19();
            fm19.Show();
        }

        private void 企业资料库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form28 fm28 = new Form28();
            fm28.Show();
        }
    }
}
