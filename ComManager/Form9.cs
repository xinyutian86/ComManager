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
using Model;
using BLL;


namespace ComManager
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        string sid = null;
        string sendid = null;
        StateInfo si = new StateInfo();
        StateManager sm = new StateManager();
        static string link = String.Format("Server={0};User ID={1};Password={2};Database={3};CharSet=gbk;",
                getLine(4), getLine(6), getLine(7), getLine(5));
        MySqlConnection con = new MySqlConnection(link);

        private void button1_Click(object sender, EventArgs e)
        {
            si = new StateInfo()
            {
                Id = id.Text,
                State = state.Text,
                //Level = Convert.ToInt16(sendid)
                Level=1

            };
            string messageStr = null;

            if (sm.Add(si, out messageStr))
            {
                MessageBox.Show("添加成功");
                this.Hide();
            }
            else
            {
                MessageBox.Show(messageStr);
            }
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

        private void id_TextChanged(object sender, EventArgs e)
        {
            
                if (id.Text.Trim().Length != 0)
                {
                if (id.Text.Trim().Length<6)
                {
                    if (id.Text.Trim().Length < 5)
                    {
                        si = new StateInfo()
                        {
                            Id = id.Text
                        };
                    }
                    else
                    {
                        si = new StateInfo()
                        {
                            Id = id.Text.Substring(0,4)
                        };
                        
                    }
                    
                }
                else
                {
                    MessageBox.Show("编码只能是6位!");
                    id.Text = id.Text.Substring(0,6);
                }
                    
                }
                else
                {
                    si = new StateInfo()
                    {
                        Id = "1"
                    };
                }
            
            
            lv.Text = sm.Get(si);
            //MessageBox.Show(Convert.ToString(si.Id));
        }
    }
}
