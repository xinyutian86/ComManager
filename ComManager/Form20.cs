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
using System.Drawing.Printing;
using BLL;
using Model;

namespace ComManager
{
    public partial class Form20 : Form
    {
        ResInfo ri = new ResInfo();
        ResManager rm = new ResManager();
        public Form20()
        {
            InitializeComponent();
            init();
            init2();
            init3();
            init4();
            init5();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form26 fm26 = new Form26();
            fm26.Show();
        }
        private void init5()
        {
            con.Open();//开启连接
            string strcmd = "select * from Contacts";
            MySqlCommand cmd = new MySqlCommand(strcmd, con);
            MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ada.Fill(ds);//查询结果填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();//关闭连接
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            // printDocument1 为 打印控件
            //设置打印用的纸张 当设置为Custom的时候，可以自定义纸张的大小，还可以选择A4,A5等常用纸型
            this.printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 640, 300);

            this.printDocument1.PrintPage += new PrintPageEventHandler(this.MyPrintDocument_PrintPage);
            //将写好的格式给打印预览控件以便预览
            printPreviewDialog1.Document = printDocument1;
            //显示打印预览
            DialogResult result = printPreviewDialog1.ShowDialog();
        }
        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            /*如果需要改变自己 可以在new Font(new FontFamily("黑体"),11）中的“黑体”改成自己要的字体就行了，黑体 后面的数字代表字体的大小
             System.Drawing.Brushes.Blue , 170, 10 中的 System.Drawing.Brushes.Blue 为颜色，后面的为输出的位置 */
            e.Graphics.DrawString("项目洽谈情况表", new Font(new FontFamily("黑体"), 11), System.Drawing.Brushes.Black, 170, 10);
            e.Graphics.DrawString("制表人:信玉田", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Blue, 10, 12);
            //信息的名称
            e.Graphics.DrawLine(Pens.Black, 8, 30, 620, 30);
            e.Graphics.DrawString("年度", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 9, 35);
            e.Graphics.DrawString("项目名称", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 42, 35);
            e.Graphics.DrawString("客户类别", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 100, 35);
            e.Graphics.DrawString("地域", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 190, 35);
            e.Graphics.DrawString("业务类型", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 240, 35);
            e.Graphics.DrawString("资本类型", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 320, 35);
            e.Graphics.DrawString("所属区县", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 375, 35);
            e.Graphics.DrawString("业务内容", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 425, 35);
            e.Graphics.DrawString("小计（万）", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 480, 35);
            e.Graphics.DrawString("洽谈时间", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 550, 35);
            e.Graphics.DrawLine(Pens.Black, 8, 50, 620, 50);
            //产品信息
            e.Graphics.DrawString(comboBox1.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 9, 55);
            e.Graphics.DrawString(textBox1.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 42, 55);
            e.Graphics.DrawString(khlb.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 100, 55);
            e.Graphics.DrawString(dy.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 190, 55);
            e.Graphics.DrawString(ywlx.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 230, 55);
            e.Graphics.DrawString(zblx.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 325, 55);
            e.Graphics.DrawString(ssqx.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 380, 55);
            e.Graphics.DrawString(textBox2.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 425, 55);
            e.Graphics.DrawString(textBox5.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 495, 55);
            e.Graphics.DrawString(qtsj.Text, new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 540, 55);

            //e.Graphics.DrawString("2018年1月1日", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 540, 75);

            e.Graphics.DrawLine(Pens.Black, 8, 200, 480, 200);
            e.Graphics.DrawString("地址：泰安市泰山学院信息科学技术学院", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 9, 210);
            e.Graphics.DrawString("经办人:信玉田", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 220, 210);
            e.Graphics.DrawString("联系方式:18854802552", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 320, 210);
            e.Graphics.DrawString("打印时间:" + DateTime.Now.ToString(), new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 9, 230);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form27 fm27 = new Form27();
            fm27.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ri = new ResInfo()
            {
                Nd=comboBox1.Text,
                Xmlx=comboBox2.Text,
                Xmmc= textBox1.Text,
                Khlb=khlb.Text,
                Dy=dy.Text,
                Ywlx=ywlx.Text,
                Zblx=zblx.Text,
                Ssqx=ssqx.Text,
                Ywnr=textBox2.Text,
                Rmb=textBox3.Text,
                My=textBox4.Text,
                Xj=textBox5.Text,
                Qtsj=qtsj.Text,
                Bz=textBox6.Text
            };
            string messageStr = null;

            if (rm.Add(ri, out messageStr))
            {
                MessageBox.Show("添加成功");
                this.Hide();
            }
            else
            {
                MessageBox.Show(messageStr);
            }
        }
    }

}
