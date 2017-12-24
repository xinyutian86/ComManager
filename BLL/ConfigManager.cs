using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class ConfigManager
    {
        private DBConfig dbConfig = new DBConfig();
        public bool Test(ServerInfo serverinfo,out string msg)
        {
            bool issuccess = false;
            msg = null;
            if (serverinfo.DataBase1.Trim().Length!=0||serverinfo.Password1.Trim().Length != 0 || serverinfo.Server1.Trim().Length != 0 || serverinfo.User_ID1.Trim().Length != 0)
            {
                if (dbConfig.TestConn(serverinfo))
                {
                    msg = "连接成功!";
                    issuccess = true;
                }
                else
                {
                    msg = "测试失败，请确认信息输入正确";
                }
            }
            else
            {
                msg = "不能为空!";
            }
            return issuccess;
        }
    }
}
