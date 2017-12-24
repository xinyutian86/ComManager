using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using Model;
using System.Configuration;

namespace DAL
{
    public class UserDB
    {
        //static string link = "Server=120.24.61.173;User ID=xinyutian;Password=woaixinke;Database=xinyutian;CharSet=gbk;";
        static string link = "Server=127.0.0.01;User ID=root;Password=woaixinke;Database=sharp;CharSet=gbk;";
        MySqlConnection con = new MySqlConnection(link);
        
        public int AddUser(UserInfo userinfo)
        {
            con.Open();
            string sql = String.Format("INSERT INTO sharp VALUES('{0}','{1}','{2}')", null, userinfo.Username, userinfo.Password);
            //string sql = "insert into sharp values (null,@username,@password)";

            MySqlCommand cmd = new MySqlCommand(sql, con);
            int iRet = cmd.ExecuteNonQuery();//这里返回的是受影响的行数，为int值。可以根据返回的值进行判断是否插入成功。
            con.Close();
            return iRet;
        }
        public bool IsEquals(UserInfo userinfo)
        {
            bool have = false;
            con.Open();
            string sql = String.Format("select username from sharp where username='{0}'",userinfo.Username);
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

        public string getpass(UserInfo userinfo)
        {
            string pass = null;
            con.Open();
            string sql = String.Format("select password from sharp where username='{0}'", userinfo.Username);
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
                pass=result;
            }
            con.Close();
            return pass;
        }
    }
}
