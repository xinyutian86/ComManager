using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using Model;


namespace DAL
{
    public class AuDB
    {
        static string link = String.Format("Server={0};User ID={1};Password={2};Database={3};CharSet=gbk;",
                getLine(4), getLine(6), getLine(7), getLine(5));
        MySqlConnection con = new MySqlConnection(link);

        public int addAu(ActiveUser au)
        {
            con.Open();
            string sql = String.Format("INSERT INTO ActiveUser VALUES('{0}','{1}','{2}','{3}')", null, au.Login_name,au.Username,au.Password);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            int iRet = cmd.ExecuteNonQuery();//这里返回的是受影响的行数，为int值。可以根据返回的值进行判断是否插入成功。
            con.Close();
            return iRet;
        }

        public int ChangeAuPass(ActiveUser au)
        {
            con.Open();
            string sql = String.Format("update ActiveUser set PassWord='{0}' where LoginName='{1}'",au.Newpass,au.Login_name);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            int iRet = cmd.ExecuteNonQuery();//这里返回的是受影响的行数，为int值。可以根据返回的值进行判断是否插入成功。
            con.Close();
            return iRet;
        }

        public bool IsEquals(ActiveUser au)
        {
            bool have = false;
            con.Open();
            string sql = String.Format("select LoginName from ActiveUser where LoginName='{0}'", au.Login_name);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;
            while (msrd.Read())
            {
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result = msrd[ct].ToString();
                }
            }
            if (result == null)
            {

            }
            else
            {
                have = true;
            }
            con.Close();
            return have;

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

        public string getpass(ActiveUser au)
        {
            string pass = null;
            con.Open();
            string sql = String.Format("select PassWord from ActiveUser where LoginName='{0}'", au.Login_name);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            string result = null;
            while (msrd.Read())
            {
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                    result = msrd[ct].ToString();
                }
            }
            if (result == null)
            {

            }
            else
            {
                pass = result;
            }
            con.Close();
            return pass;
        }
    }
}
