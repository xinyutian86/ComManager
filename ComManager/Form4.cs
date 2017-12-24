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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            init0();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form5 fm5 = new Form5();
            fm5.Show();
        }
        static string link = String.Format("Server={0};User ID={1};Password={2};Database={3};CharSet=gbk;",
                getLine(4), getLine(6), getLine(7), getLine(5));
        MySqlConnection con = new MySqlConnection(link);
        public void init0()
        {
            con.Open();//开启连接
            string strcmd = "select id,LoginName,UserName from ActiveUser";
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();//关闭连接
        }
        private int id;
        private int nid;
        private int rowindex;
        private int colindex;
        //双击让控件可修改 取得主键和行号（为更新做准备）
        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.ReadOnly = false;
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
            id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            rowindex = e.RowIndex;
            colindex = e.ColumnIndex;
        }


        //更新 更具上边的行号取得需要更新的数据
        //跟新后重新绑定数据
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = string.Format("update  ActiveUser set {2}='{1}' where id={0} ", id, dataGridView1.Rows[rowindex].Cells[colindex].Value, dataGridView1.Columns[colindex].HeaderText);
            //MessageBox.Show(sql);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("修改成功!");
            init0();
        }


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

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            init0();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(Convert.ToString(nid));
            this.dataGridView1.ReadOnly = true;
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
            nid = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            rowindex = e.RowIndex;
            colindex = e.ColumnIndex;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除此操作员的记录？", "重要提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //delete
                con.Open();
                string sql = string.Format("delete from ActiveUser where id={0}", id);
                //MessageBox.Show(sql);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("删除成功!");
                init0();
            }
        }
    }
}
