using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using BLL;
using System.IO;

namespace ComManager
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            getLine(0);
        }
        string psw = "南&%山%+-南%*/";
        ActiveUser au = new ActiveUser();
        AuManager am = new AuManager();

        private void button1_Click(object sender, EventArgs e)
        {
            au = new ActiveUser
            {
                Password = opass.Text,
                Login_name=name.Text,
                Newpass=npass2.Text
            };
            string messageStr = null;

            if (am.ChangePass(au, out messageStr))
            {
                MessageBox.Show("成功");
                this.Hide();
            }
            else
            {
                MessageBox.Show(messageStr);
            }
        }

        private string TextDecrypt(char[] data, string secretKey)
        {
            char[] key = secretKey.ToCharArray();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= key[i % key.Length];
            }
            return new string(data);
        }

        public string getLine(int ii)
        {
            string line = null;
            string file = "User.data";
            if (File.Exists(@"c:\xinyutian\User.data"))
            {
                //存在 
                string[] lines = File.ReadAllLines("c:\\xinyutian\\" + file);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i == ii)
                    {
                        line = lines[i];
                        string dstring=TextDecrypt(lines[i].ToCharArray(),psw);
                        name.Text = dstring;
                        name.Visible = false;
                        label7.Visible = false;
                        //MessageBox.Show(dstring);
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
