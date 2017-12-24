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
    public class DBConfig
    {
       public bool TestConn(ServerInfo serverinfo)
        {
            bool issuccess = false;
            string e = "Hello";
            string link = String.Format("Server={0};User ID={1};Password={2};Database={3};CharSet=gbk;",
                serverinfo.Server1,serverinfo.User_ID1,serverinfo.Password1,serverinfo.DataBase1);
            Console.WriteLine(link);
            MySqlConnection con = new MySqlConnection(link);
            try
            {
                con.Open();
            }
            catch(Exception e1)
            {
                e = e1.ToString();
            }
            if (e.Equals("Hello"))
            {
                issuccess = true;
            }
            else
            {
                issuccess = false;
            }
            return issuccess;
        }
    }
    
}
