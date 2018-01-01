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
    public partial class Form13 : Form
    {
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
        string findone = "select TypeName from CustomerType where level=1";
        string leavel = null;
        string id = null;
        string sendid = null;
        public Form13()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(findone, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            while (msrd.Read())
            {
                string result = null;
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result += msrd[ct].ToString();
                    comboBox1.Items.Add(msrd[ct]);
                }
                //result += Environment.NewLine;
                // MessageBox.Show(result);
            }
            con.Close();//关闭连接
            initid();
        }
        private void initid()
        {
            string finid = "select TypeId from CustomerType where level=1";
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(finid, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;
            while (msrd.Read())
            {

                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result = msrd[ct].ToString();
                }

            }
            // MessageBox.Show(result);
            if (result == null)
            {
                id = "010000";
            }
            else
            {
                id = result;
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.Text);
            comboBox2.Items.Clear();
            string onename = comboBox1.Text.ToString();
            string findoneid = String.Format("select TypeId from CustomerType where level=1 and TypeName='{0}'", onename);
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(findoneid, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;
            string result2 = null;
            while (msrd.Read())
            {

                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result = msrd[ct].ToString();
                }
                result2 = result.Substring(0, 2);
            }
            con.Close();
            id = result;
            add2(result2);
            findtwoid(result2);
        }
        private void add2(string msg)
        {

            string findtwo = String.Format("select TypeName from CustomerType where TypeID like '{0}____' and level=2;", msg);
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(findtwo, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;

            while (msrd.Read())
            {
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result += msrd[ct].ToString();
                    comboBox2.Items.Add(msrd[ct]);
                }
                //MessageBox.Show(result);

            }
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            string msg = comboBox2.Text.ToString();
            string findtwoid = String.Format("select TypeId from CustomerType where level=2 and TypeName='{0}'", msg);
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(findtwoid, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;
            string result2 = null;
            while (msrd.Read())
            {

                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result += msrd[ct].ToString();
                }
                result2 = result.Substring(0, 4);
            }
            con.Close();
            id = result;
            add3(result2);
            findthreeid(result2);
        }
        private void add3(string msg)
        {
            string findthree = String.Format("select TypeName from CustomerType where TypeID like '{0}__' and level=3;", msg);
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(findthree, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;
            while (msrd.Read())
            {
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result += msrd[ct].ToString();
                    comboBox3.Items.Add(msrd[ct]);
                }
                //MessageBox.Show(result);
            }
            con.Close();
        }
        private void findtwoid(string msg)
        {
            string findtow = String.Format("select TypeID from CustomerType where TypeID like '{0}____' and level=2;", msg);
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(findtow, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;
            while (msrd.Read())
            {
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result = msrd[ct].ToString();
                }
                //MessageBox.Show(result);
            }
            if (result == null)
            {
                id = msg + "0100";
            }
            else
            {
                id = result;
            }
            //id = msg + "0100";
            //id = result;
            //MessageBox.Show(result);
            con.Close();
        }
        private void findthreeid(string msg)
        {
            string findth = String.Format("select TypeID from CustomerType where TypeID like '{0}__' and level=3;", msg);
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(findth, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;
            while (msrd.Read())
            {
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result = msrd[ct].ToString();
                }
                //MessageBox.Show(result);
            }
            if (result == null)
            {
                id = msg + "01";
            }
            else
            {
                id = result;
            }
            //MessageBox.Show(id);
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string Tpname = typename.Text.ToString();
            string c1 = comboBox1.Text;
            string c2 = comboBox2.Text;
            string c3 = comboBox3.Text;
            if (c1 == "")
            {
                leavel = "1";
                //sendid = string.Format(Convert.ToString(sid) + "0000");
                int nid = int.Parse(id) + 10000;
                if (nid <= 100000)
                {
                    sendid = "0" + Convert.ToString(nid);
                }
                else
                {
                    sendid = Convert.ToString(nid);
                }

                //MessageBox.Show(sendid);
            }
            else if (c2 == "")
            {
                leavel = "2";
                int nid = int.Parse(id) + 100;
                if (nid <= 100000)
                {
                    sendid = "0" + Convert.ToString(nid);
                }
                else
                {
                    sendid = Convert.ToString(nid);
                }
                //MessageBox.Show(sendid);
            }
            else if (c3 == "")
            {
                leavel = "3";
                int nid = int.Parse(id) + 1;
                if (nid <= 100000)
                {
                    sendid = "0" + Convert.ToString(nid);
                }
                else
                {
                    sendid = Convert.ToString(nid);
                }
                //MessageBox.Show(sendid);
            }
            con.Open();
            string sql = String.Format("INSERT INTO CustomerType VALUES('{0}','{1}','{2}')", sendid, Tpname, leavel);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            int iRet = cmd.ExecuteNonQuery();//这里返回的是受影响的行数，为int值。可以根据返回的值进行判断是否插入成功。

            if (iRet > 0)
            {

                MessageBox.Show("插入成功");
                this.Hide();
            }
            else
            {

                MessageBox.Show("插入失败");

            }
            con.Close();
        }
    }
}
