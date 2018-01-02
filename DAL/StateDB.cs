using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySql.Data.MySqlClient;
using System.IO;

namespace DAL
{
    public class StateDB
    {
        static string link = String.Format("Server={0};User ID={1};Password={2};Database={3};CharSet=gbk;",
                 getLine(4), getLine(6), getLine(7), getLine(5));
        MySqlConnection con = new MySqlConnection(link);

        public int AddState(StateInfo si)
        {
            string level = GetLevel(si);
            con.Open();
            string sql = String.Format("INSERT INTO state VALUES('{0}','{1}','{2}')",si.Id,si.State,level);
            Console.WriteLine(sql);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            int iRet = cmd.ExecuteNonQuery();//这里返回的是受影响的行数，为int值。可以根据返回的值进行判断是否插入成功。
            con.Close();
            return iRet;
        }
        public string GetLevel(StateInfo si)
        {
            string level = null;
            if (si.Level.Equals("没有查询到"))
            {
                level = "1";
            }
            else
            {
                con.Open();
                string sql = String.Format("select level from state where name='{0}'", si.Level);
                Console.WriteLine(sql);
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
                int i = Convert.ToInt32(result) + 1;
                level = Convert.ToString(i);
                con.Close();
            }
            return level;
        }
        public int DelState(StateInfo si)
        {
            con.Open();
            string sql = String.Format("delete from state where name='{0}'",si.State);
            Console.WriteLine(sql);
            string[] s = {sql};
            File.WriteAllLines(@"c:\xinyutian\DB.data", s);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            int iRet = cmd.ExecuteNonQuery();//这里返回的是受影响的行数，为int值。可以根据返回的值进行判断是否插入成功。
            con.Close();
            return iRet;
        }

        public string GetStateName(StateInfo si)
        {
            string name = "没有查询到";
            string sql =String.Format("select name from state where id=(select min(id) from state where id like '{0}%')", si.Id);
            Console.WriteLine(sql);
            con.Open();//开启连接
            MySqlCommand cmd = new MySqlCommand(sql,con);
            MySqlDataReader msrd;
            msrd = cmd.ExecuteReader();
            //if (!msrd.Read())
            //{
            //    name = "没有查询到包含" + si.Id + "的地区编号";
            //}
            while (msrd.Read())
            {
                Console.WriteLine("MS::::::::::::"+msrd.FieldCount);
                
                for (int ct = 0; ct < msrd.FieldCount; ct++)
                {
                        name = Convert.ToString(msrd[ct]);
                        Console.WriteLine("NAME:::::::::::" + name);
                }
            }
            con.Close();//关闭连接
            
            return name;
        }

        public bool IsEquals(StateInfo si)
        {
            bool have = false;
            con.Open();
            string sql = String.Format("select name from state where name='{0}'", si.State);
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
    }
}
