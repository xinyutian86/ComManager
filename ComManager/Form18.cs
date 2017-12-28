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

namespace ComManager
{
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
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
                string strLuJing = myFolderBrowserDialog.SelectedPath;//获取路径
                textBox1.Text = strLuJing;//赋值给文本显示
            }

        }
     
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否备份数据", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (textBox1.Text.ToString() != "")
                {
                    string strRiQi = DateTime.Now.Year.ToString() + (DateTime.Now.Month.ToString().Length < 2 ? 0 + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString()) + (DateTime.Now.Day.ToString().Length < 2 ? 0 + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString()) + (DateTime.Now.Hour.ToString().Length < 2 ? 0 + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                    try
                    {
                        CopyDir("C:\\ProgramData\\MySQL\\MySQL Server 5.7\\Data\\sharp", textBox1.Text+"\\DataBaseBackUp"+strRiQi);
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


    }
}
