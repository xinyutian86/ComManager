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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }
        static string link = String.Format("Server={0};User ID={1};Password={2};Database={3};CharSet=gbk;",
                getLine(4), getLine(6), getLine(7), getLine(5));
        MySqlConnection con = new MySqlConnection(link);
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // MessageBox.Show((string)listBox1.SelectedItem);
            string Type = (string)listBox1.SelectedItem;
            if (Type.Equals("业务类型"))
            {
                BType();
            }
            else
            {
                CType();
            }
        }
        private void BType()
        {
            con.Open();//开启连接
            string strcmd = "select * from BusinessType";
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();//关闭连接
        }
        private void CType()  
        {
            con.Open();//开启连接
            string strcmd = "select * from CapitalType";
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();//关闭连接
        }
        
        public void init0()
        {
            con.Open();//开启连接
            string strcmd = "select * from BusinessType";
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();//关闭连接
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string Type = (string)listBox1.SelectedItem;
            if (Type!=null)
            {
                if (Type.Equals("业务类型"))
                {
                    App.value = "BusinessType";
                    Form15 fm15 = new Form15();
                    fm15.Show();
                }
                else
                {
                    App.value = "CapitalType";
                    Form15 fm15 = new Form15();
                    fm15.Show();
                }
            }
            else
            {
                MessageBox.Show("你还没有选择要添加的类型~");
            }
            
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
            string Type = (string)listBox1.SelectedItem;
            string T = null;
            if (Type != null)
            {
                if (Type.Equals("业务类型"))
                {
                    T= "BusinessType";
                }
                else
                {
                    T = "CapitalType";
                }
            }
            else
            {
                MessageBox.Show("你还没有选择~");
            }
            string sql = string.Format("update {3} set {2}='{1}' where id={0} ", id, dataGridView1.Rows[rowindex].Cells[colindex].Value, dataGridView1.Columns[colindex].HeaderText,T);
            Console.WriteLine("SQL:::::::::::::"+sql);
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
                string Type = (string)listBox1.SelectedItem;
                string T = null;
                if (Type != null)
                {
                    if (Type.Equals("业务类型"))
                    {
                        T = "BusinessType";
                    }
                    else
                    {
                        T = "CapitalType";
                    }
                }
                else
                {
                    MessageBox.Show("你还没有选择~");
                }
                string sql = string.Format("delete from {1} where id={0}", id,T);
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
