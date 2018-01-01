using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using Model;
using BLL;

namespace ComManager
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            init();
            tree();
        }
        ActiveUser au = new ActiveUser();
        AuManager am = new AuManager();
        char[] Newmods = { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0' };
        static string link = String.Format("Server={0};User ID={1};Password={2};Database={3};CharSet=gbk;",
                getLine(4), getLine(6), getLine(7), getLine(5));
        MySqlConnection con = new MySqlConnection(link);
        char[] mods= {'0'};
        string NumtoMod;
        int i;
        private void usercb_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("UU::::::::::"+usercb.Text);
            App.name = usercb.Text;
            getmods(usercb.Text);
            get3();
        }
        public void init()
        {
            con.Open();//开启连接
            string sql = "select UserName from ActiveUser";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            while (msrd.Read())
            {
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    usercb.Items.Add(msrd[ct]);
                }
               
            }
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
        public void tree()
        {
            treeView1.Nodes.Clear();
            string findone = "select mods from chmod where level=1";
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
            //get3();
        }
        public void getmods(string msg)
        {
            string findone = String.Format("select chmod from activeuser where UserName='{0}'",msg);
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(findone, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            while (msrd.Read())
            {

                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    mods = Convert.ToString(msrd[ct]).ToArray();
                }
            }
            con.Close();//关闭连接
        }
        private string FindNumber(int msg)
        {
            string findoneid = String.Format("select mods from chmod where number={0}", msg);
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(findoneid, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;
            while (msrd.Read())
            {
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result = msrd[ct].ToString();
                    NumtoMod = result;
                }
                
            }
            con.Close();
            return result;
        }
        private void add2(string ms)
        {
            string findoneid = String.Format("select id from chmod where level=1 and mods='{0}'", ms);
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
                    string findtwo = String.Format("select mods from chmod where id like '{0}__' and level=2;", s);
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
            {

            
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    GetNodeText(node.Nodes[i]);
                }

            }
            node.Checked = false;
            treeView1.Enabled = false;
            string mo = node.Text;
            for (int j = 0; j < mods.Length; j++)
            {
                if (!mods[j].Equals('0'))
                {
                    string dmods = Convert.ToString(FindNumber(j + 1));
                    if (dmods.Equals(mo))
                    {
                        node.Checked = true;
                    }
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                SetNodeCheckStatus(e.Node, e.Node.Checked);
                SetNodeStyle(e.Node);
            }

        }
        private void SetNodeCheckStatus(TreeNode tn, bool Checked)
        {

            if (tn == null) return;
            foreach (TreeNode tnChild in tn.Nodes)
            {

                tnChild.Checked = Checked;

                SetNodeCheckStatus(tnChild, Checked);

            }
            TreeNode tnParent = tn;
        }



        private void SetNodeStyle(TreeNode Node)
        {
            int nNodeCount = 0;
            if (Node.Nodes.Count != 0)
            {
                foreach (TreeNode tnTemp in Node.Nodes)
                {

                    if (tnTemp.Checked == true)

                        nNodeCount++;
                }

                if (nNodeCount == Node.Nodes.Count)
                {
                    Node.Checked = true;
                    Node.ExpandAll();
                    Node.ForeColor = Color.Black;
                }
                else if (nNodeCount == 0)
                {
                    Node.Checked = false;
                    Node.Collapse();
                    Node.ForeColor = Color.Black;
                }
                else
                {
                    Node.Checked = true;
                    Node.ForeColor = Color.Gray;
                }
            }
            //当前节点选择完后，判断父节点的状态，调用此方法递归。  
            if (Node.Parent != null)
                SetNodeStyle(Node.Parent);
        }

        private void usercb_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            treeView1.Enabled = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            treeView1.Enabled = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Newmods = "0000000000".ToCharArray();

            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                GetNodeText2(treeView1.Nodes[i]);
            }
           // MessageBox.Show(textBox1.Text);
            au = new ActiveUser()
            {
                Chmod = textBox1.Text,
                Username = App.name
            };
            string messageStr = null;

            if (am.Chmod(au, out messageStr))
            {
                MessageBox.Show("修改权限成功");
                this.Close();
            }
            else
            {
                MessageBox.Show(messageStr);
            }
        }
        void GetNodeText2(TreeNode node)
        {
            if (node.Nodes.Count != 0)
            {


                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    GetNodeText2(node.Nodes[i]);
                }

            }
            //node.Checked = true;
            if (node.Checked)
            {
                //MessageBox.Show(node.Text);
                //MessageBox.Show(getNum(node.Text));
                textBox1.Text = change(Newmods, getNum(node.Text), '1');
            }
        }
        public string getNum(string mods)
        {
            string num = null;
            string sql = String.Format("select number from chmod where mods='{0}' and level=2", mods);
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(sql,con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            while (msrd.Read())
            {
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    num = Convert.ToString(msrd[ct]);
                }
            }
            con.Close();//关闭连接
            return num;
        }
        public string change(char[] prechar, string where, char what)
        {
            string after = null;
            int location = Convert.ToInt32(where)-1;
            Console.WriteLine("PRE::::::::::::::::::::::::"+prechar);
            Console.WriteLine("WHERE::::::::::::::::::::::"+location);
            for (int i = 0; i < prechar.Length; i++)
            {
                if (i == location)
                {
                    prechar[i] = what;
                }
                after += prechar[i];
            }
            return after;
        }
    }
}
