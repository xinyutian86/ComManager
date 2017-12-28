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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
            init();
            init2();
            init3();
            init4();
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
        public void init()
        {
            string sql = String.Format("select TypeName from businesstype");
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;

            while (msrd.Read())
            {
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result += msrd[ct].ToString();
                   ywlx.Items.Add(msrd[ct]);
                }
                //MessageBox.Show(result);

            }
            con.Close();

        }
        public void init2()
        {
            string sql = String.Format("select name from state");
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;

            while (msrd.Read())
            {
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result += msrd[ct].ToString();
                    dy.Items.Add(msrd[ct]);
                    ssqx.Items.Add(msrd[ct]);
                }
                //MessageBox.Show(result);

            }
            con.Close();
        }
        public void init3()
        {
            
            string sql = String.Format("select TypeName from customertype");
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;

            while (msrd.Read())
            {
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result += msrd[ct].ToString();
                    khlb.Items.Add(msrd[ct]);
                }
                //MessageBox.Show(result);

            }
            con.Close();
        }
        public void init4()
        {
            string sql = String.Format("select TypeName from capitaltype");
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;

            while (msrd.Read())
            {
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result += msrd[ct].ToString();
                    zblx.Items.Add(msrd[ct]);
                }
                //MessageBox.Show(result);

            }
            con.Close();
        }
    }
}
