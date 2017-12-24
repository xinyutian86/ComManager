using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class LoginManager
    {
        private UserDB userDB = new UserDB();
        public bool Add(UserInfo userInfo,out string msg)
        {
            msg = null;
            bool isSuccess = false;
            if (userInfo.Username.Trim().Length != 0)//判断从传递来的username是否为空
            {

                if (!userDB.IsEquals(userInfo))//传给DALl操作判断数据库中是否有重复值
                {
                    userDB.AddUser(userInfo);//传给DAL操作增加一个新用户
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

        public bool Login(UserInfo userInfo, out string msg)
        {
            msg = null;
            bool isSuccess = false;
            if (userInfo.Username.Trim().Length != 0 || userInfo.Password.Trim().Length != 0)//判断从传递来的username是否为空
            {

                if (userDB.IsEquals(userInfo))//传给DALl操作判断数据库中是否有重复值
                {
                    string pass = userDB.getpass(userInfo);
                    if (userInfo.Password.Equals(pass))
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
