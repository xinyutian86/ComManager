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
using BLL;
using Model;


namespace ComManager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            init();
        }
        ServerInfo serverinfo;
        ConfigManager cm=new ConfigManager();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] strs = { "Server="+host.Text, "DataBase="+dname.Text, "User ID="+uname.Text,"Password="+upass.Text,
                                host.Text,dname.Text,uname.Text,upass.Text,
                                "Server="+host.Text+";User ID="+dname.Text+";Password="+uname.Text+";Database="+upass.Text+";CharSet=gbk;"};
            File.WriteAllLines(@"c:\xinyutian\DataConfig.txt", strs);
            MessageBox.Show("保存成功!");
            Form3 fm3 = new Form3();
            fm3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serverinfo = new ServerInfo()
            {
                Server1 = host.Text,
                DataBase1 = dname.Text,
                User_ID1 = uname.Text,
                Password1=upass.Text
            };
            string messageStr = null;
            if (cm.Test(serverinfo, out messageStr))
            {
                MessageBox.Show("测试通过，连接成功");
                
            }
            else
            {
                MessageBox.Show(messageStr);
            }

        }
        public void init()
        {
            if (File.Exists(@"c:\xinyutian\DataConfig.txt"))
            {
                //存在 
                host.Text = getLine(4);
                dname.Text = getLine(5);
                uname.Text = getLine(6);
                upass.Text = getLine(7);
            }
            else
            {
                //不存在 
                MessageBox.Show("配置文件不存在!");
            }
            
        }
        public string getLine(int ii)
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
                MessageBox.Show("配置文件不存在!");
            }
            return line;
        }
    }
}
