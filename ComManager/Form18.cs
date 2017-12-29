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
using System.Diagnostics;

namespace ComManager
{
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
            init();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog myFolderBrowserDialog = new FolderBrowserDialog();

            //设置根目录在桌面；
            myFolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.Desktop;

            //设置当前选择的路径
            myFolderBrowserDialog.SelectedPath = "C:";

            //允许在对话框中包括一个新建目录的按钮
            myFolderBrowserDialog.ShowNewFolderButton = true;

            //设置对话框的说明信息
            myFolderBrowserDialog.Description = "请选择输出目录";

            if (myFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {//确认是否保存
                string strPath = myFolderBrowserDialog.SelectedPath;//获取路径
                textBox1.Text = strPath;//赋值给文本显示
            }
        }
     
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否备份数据", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)//弹出对话框，等待用户选择
            {
                if (textBox1.Text.ToString() != "")//空值检测
                {
                    string strRiQi = DateTime.Now.Year.ToString() + (DateTime.Now.Month.ToString().Length < 2 ? 0 + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString()) + (DateTime.Now.Day.ToString().Length < 2 ? 0 + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString()) + (DateTime.Now.Hour.ToString().Length < 2 ? 0 + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();//生成日期时间
                    try
                    {
                        Process proc = null;//创建Process
                        try
                        {
                            string backup =String.Format("mysqldump -u{3} -p{1} {2} >{0}"+"\\"+ "DataBackUp"+strRiQi+".dbak",textBox1.Text,getLine2(7),getLine2(5),getLine2(6));//初始化语句
                            File.WriteAllText(@"C:\Program Files\MySQL\MySQL Server 5.7\bin\my.bat", backup);//写入文件
                            string targetDir = string.Format(@"C:\Program Files\MySQL\MySQL Server 5.7\bin\");
                            proc = new Process();
                            proc.StartInfo.WorkingDirectory = targetDir;
                            proc.StartInfo.FileName = "my.bat";
                            proc.StartInfo.Arguments = string.Format("10");
                            proc.StartInfo.CreateNoWindow = false;
                            proc.Start();
                            proc.WaitForExit();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
                        }
                        MessageBox.Show("备份成功!");
                    }
                    catch (Exception e1)
                    {
                        MessageBox.Show("备份失败");
                        Console.WriteLine(e1);
                    }
                }
                else
                {
                    MessageBox.Show("请选择保存路径！");
                }
            }
        }
        public static void CopyDir(string fromDir, string toDir)
        {
            if (!Directory.Exists(fromDir))
                return;

            if (!Directory.Exists(toDir))
            {
                Directory.CreateDirectory(toDir);
            }

            string[] files = Directory.GetFiles(fromDir);
            foreach (string formFileName in files)
            {
                string fileName = Path.GetFileName(formFileName);
                string toFileName = Path.Combine(toDir, fileName);
                File.Copy(formFileName, toFileName);
            }
            string[] fromDirs = Directory.GetDirectories(fromDir);
            foreach (string fromDirName in fromDirs)
            {
                string dirName = Path.GetFileName(fromDirName);
                string toDirName = Path.Combine(toDir, dirName);
                CopyDir(fromDirName, toDirName);
            }
        }

        public static void MoveDir(string fromDir, string toDir)
        {
            if (!Directory.Exists(fromDir))
                return;

            CopyDir(fromDir, toDir);
            Directory.Delete(fromDir, true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                
            }
            else
            {

            }
        }

        private void init()
        {
            if (File.Exists(@"c:\xinyutian\BackPath.dat"))
            {
                //存在 
                checkBox1.Checked = true;
                textBox1.Text = getLine(0);
            }
            else
            {
                //不存在 
                
            }

        }
        public static string getLine(int ii)
        {
            string line = null;
            string file = "BackPath.dat";
            if (File.Exists(@"c:\xinyutian\BackPath.dat"))
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

        public static string getLine2(int ii)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                File.WriteAllText(@"C:\xinyutian\BackPath.dat", textBox1.Text);
                //MessageBox.Show(textBox1.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "C://";
            fileDialog.Filter = "数据库备份文件 (*.dbak)|*.dbak|All files (*.*)|*.*";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                
                Process proc = null;
                try
                {
                    string str = String.Format("mysql  -u{1}  -p{2} {3} < {0}", fileDialog.FileName, getLine2(6), getLine2(7), getLine2(5));
                    File.WriteAllText(@"C:\Program Files\MySQL\MySQL Server 5.7\bin\re.bat", str);
                    string targetDir = string.Format(@"C:\Program Files\MySQL\MySQL Server 5.7\bin\");//this is where mybatch.bat lies
                    proc = new Process();
                    proc.StartInfo.WorkingDirectory = targetDir;
                    proc.StartInfo.FileName = "re.bat";
                    proc.StartInfo.Arguments = string.Format("10");//this is argument
                    proc.StartInfo.CreateNoWindow = false;
                    proc.Start();
                    proc.WaitForExit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
                }
                MessageBox.Show("恢复成功!");
            }
        }
    }
}
