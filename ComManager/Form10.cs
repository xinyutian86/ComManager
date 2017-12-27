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
using BLL;
using Model;

namespace ComManager
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            init();
        }
        StateInfo si = new StateInfo();
        StateManager sm = new StateManager();
        static string link = String.Format("Server={0};User ID={1};Password={2};Database={3};CharSet=gbk;",
                getLine(4), getLine(6), getLine(7), getLine(5));
        MySqlConnection con = new MySqlConnection(link);
        public void init()
        {
            treeView1.Nodes.Clear();
            string findone = "select name from continent where level=1";
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
            //foreach (TreeNode node in treeView1.Nodes)
            //{
            //    add2(node.Text);
            //    node.ExpandAll();
            //}
            //get3();
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
    }
}
