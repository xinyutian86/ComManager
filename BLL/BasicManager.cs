using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class BasicManager
    {
        private BasicDB bd = new BasicDB();
        public bool Add(BaiscInfo bi,out string msg)
        {
            msg = null;
            bool isSuccess = false;
            if (bi.Db.Trim().Length != 0 || bi.Typename.Trim().Length != 0)//判断从传递来的username是否为空
            {

                if (!bd.IsEquals(bi))//传给DALl操作判断数据库中是否有重复值
                {
                    bd.AddBI(bi);//传给DAL操作增加一个新用户
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
    }
}
