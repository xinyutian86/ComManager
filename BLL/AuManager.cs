using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class AuManager
    {
        private AuDB audb = new AuDB();
        public bool Add(ActiveUser au,out string msg)
        {

            msg = null;
            bool isSuccess = false;
            if (au.Login_name.Trim().Length != 0 || au.Password.Trim().Length != 0 || au.Username.Trim().Length != 0)//判断从传递来的username是否为空
            {

                if (!audb.IsEquals(au))//传给DALl操作判断数据库中是否有重复值
                {
                    audb.addAu(au);//传给DAL操作增加一个新用户
                    isSuccess = true;
                }
                else
                    msg = "有相同的值";
            }
            else
            {
                msg = "不能为空";

            }
            return isSuccess;//返回界面层是否添加成功
        }

        public bool Login(ActiveUser au, out string msg)
        {
            msg = null;
            bool isSuccess = false;
            if (au.Login_name.Trim().Length != 0 || au.Password.Trim().Length != 0)//判断从传递来的username是否为空
            {

                if (audb.IsEquals(au))//传给DALl操作判断数据库中是否有重复值
                {
                    string pass = audb.getpass(au);
                    if (au.Password.Equals(pass))
                    {
                        isSuccess = true;
                    }
                    else
                    {
                        msg = "密码错误";
                    }
                }
                else
                    msg = "没有此用户";
            }
            else
            {
                msg = "不能为空";

            }
            return isSuccess;
        }
    }
}
