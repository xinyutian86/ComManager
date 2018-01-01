using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace ComManager
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
            init0();
        }
        static string link = String.Format("Server={0};User ID={1};Password={2};Database={3};CharSet=gbk;",
                getLine(4), getLine(6), getLine(7), getLine(5));
        MySqlConnection con = new MySqlConnection(link);
        public static string getLine(int ii)
        {
            string line = null;
            string file = "DataConfig.txt";
            if (File.Exists(@"c:\xinyutian\DataConfig.txt"))
            {
                //存在 
                string[] lines = File.ReadAllLines("c:\\xinyutian\\" + file);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i == ii)
                    {
                        line = lines[i];
                    }
                }
            }
            else
            {
                //不存在 

            }
            return line;
        }
        public void init0()
        {
            con.Open();//开启连接
            string strcmd = "select * from Rate";
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();//关闭连接
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form17 fm17 = new Form17();
            fm17.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            init0();
        }

        private int id;
        private int nid;
        private int rowindex;
        private int colindex;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.ReadOnly = false;
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
            id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            rowindex = e.RowIndex;
            colindex = e.ColumnIndex;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = string.Format("update Rate set {2}='{1}' where id={0} ", id, dataGridView1.Rows[rowindex].Cells[colindex].Value, dataGridView1.Columns[colindex].HeaderText);
            //MessageBox.Show(sql);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("修改成功!");
            init0();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.ReadOnly = false;
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
            nid = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            id = nid;
            rowindex = e.RowIndex;
            colindex = e.ColumnIndex;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除此记录？", "重要提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //delete
                con.Open();
                string sql = string.Format("delete from Rate where id={0}", id);
                MessageBox.Show(sql);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("删除成功!");
                init0();
            }
        }
    }
}
