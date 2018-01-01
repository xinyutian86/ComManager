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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
            init();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form13 fm13 = new Form13();
            fm13.Show();
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
        private void init()
        {
            treeView1.Nodes.Clear();
            string findone = "select TypeName from CustomerType where level=1";
            //treeView2.Nodes.Add("Hello");
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(findone, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            while (msrd.Read())
            {

                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    treeView1.Nodes.Add(Convert.ToString(msrd[ct]));

                }
            }
            con.Close();//关闭连接
            foreach (TreeNode node in treeView1.Nodes)
            {
                add2(node.Text);
                node.ExpandAll();
            }
            get3();
        }
        private void add2(string ms)
        {
            string findoneid = String.Format("select TypeId from CustomerType where level=1 and TypeName='{0}'", ms);
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(findoneid, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;
            while (msrd.Read())
            {
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result += msrd[ct].ToString();
                }
                result = result.Substring(0, 2);
            }
            con.Close();
            insert(ms, result);
        }
        private void insert(string msg, string s)
        {
            TreeNode tn = new TreeNode();
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node.Text == msg)
                {
                    string findtwo = String.Format("select TypeName from CustomerType where TypeID like '{0}____' and level=2;", s);
                    con.Open();//开启连接
                    MySqlCommand cmd = new MySqlCommand(findtwo, con);
                    MySqlDataReader msrd;
                    msrd = cmd.ExecuteReader();
                    while (msrd.Read())
                    {
                        for (int ct = 0; ct < msrd.FieldCount; ct++)
                        {
                            node.Nodes.Add(msrd[ct].ToString());
                        }
                    }
                    con.Close();
                    break;
                }
            }
        }
        private void add3(string ms)
        {
            string findoneid = String.Format("select TypeId from CustomerType where level=2 and TypeName='{0}'", ms);
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(findoneid, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;
            while (msrd.Read())
            {
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result += msrd[ct].ToString();
                }
                result = result.Substring(0, 4);
            }
            con.Close();
            insert2(ms, result);
        }
        private void insert2(string msg, string s)
        {
            TreeNode tn = new TreeNode();
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                GetNodeText2(treeView1.Nodes[i], msg, s);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                GetNodeText(treeView1.Nodes[i]);
            }
        }
        private void get3()
        {
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                GetNodeText(treeView1.Nodes[i]);
            }
        }
        void GetNodeText(TreeNode node)
        {
            if (node.Nodes.Count != 0)
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    GetNodeText(node.Nodes[i]);
                }
            add3(node.Text);
        }
        void GetNodeText2(TreeNode node, string msg, string s)
        {
            if (node.Nodes.Count != 0)
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    GetNodeText2(node.Nodes[i], msg, s);
                }
            if (node.Text == msg)
            {
                string findthree = String.Format("select TypeName from CustomerType where TypeID like '{0}__' and level=3;", s);
                con.Open();//开启连接
                MySqlCommand cmd = new MySqlCommand(findthree, con);
                MySqlDataReader msrd;
                msrd = cmd.ExecuteReader();
                while (msrd.Read())
                {
                    for (int ct = 0; ct < msrd.FieldCount; ct++)
                    {
                        node.Nodes.Add(msrd[ct].ToString());
                    }
                }
                con.Close();
            }
        }
        
       
        private void changeName(string OldName, string NewName)
        {
            con.Open();
            string sql = String.Format("update CustomerType set TypeName='{0}' where TypeName='{1}'", NewName, OldName);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            int iRet = cmd.ExecuteNonQuery();//这里返回的是受影响的行数，为int值。可以根据返回的值进行判断是否插入成功。
            if (iRet > 0)
            {

                MessageBox.Show("修改成功");
                textBox1.Visible = false;
                button1.Visible = false;

            }
            else
            {

                MessageBox.Show("修改失败");

            }
            con.Close();
            init();
        }
        private void delectNode(string name)
        {
            con.Open();
            string sql = String.Format("delete from CustomerType where TypeName='{0}'", name);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            int iRet = cmd.ExecuteNonQuery();//这里返回的是受影响的行数，为int值。可以根据返回的值进行判断是否插入成功。
            if (iRet > 0)
            {

                MessageBox.Show("删除成功");


            }
            else
            {

                MessageBox.Show("删除失败");

            }
            con.Close();
            init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeName(treeView1.SelectedNode.Text, textBox1.Text);
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择要修改的节点！");
                return;
            }
            //treeView2.SelectedNode.Text;
            textBox1.Visible = true;
            textBox1.Text = treeView1.SelectedNode.Text;
            button1.Visible = true;
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择要删除的节点！");
                return;
            }
            delectNode(treeView1.SelectedNode.Text);
        }
    }
}
