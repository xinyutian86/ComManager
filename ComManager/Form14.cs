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
    }
}
