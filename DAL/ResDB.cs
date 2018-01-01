using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.IO;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ResDB
    {
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
        public int AddRes(ResInfo ri)
        {
            con.Open();
            string sql = String.Format("INSERT INTO qtqk VALUES ('{0}', '{1}', '{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')",
                null, ri.Nd,ri.Xmlx,ri.Xmmc,ri.Khlb,ri.Dy,ri.Ywlx,ri.Zblx,ri.Ssqx,ri.Ywnr,ri.Rmb,ri.My,ri.Xj,ri.Qtsj,ri.Bz);
            Console.WriteLine(sql);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            int iRet = cmd.ExecuteNonQuery();//这里返回的是受影响的行数，为int值。可以根据返回的值进行判断是否插入成功。
            con.Close();
            return iRet;
        }

    }
}
