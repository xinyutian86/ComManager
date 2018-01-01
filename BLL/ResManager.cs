using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class ResManager
    {
        private ResDB rsdb = new ResDB();
        public bool Add(ResInfo ri, out string msg)
        {
            msg = null;
            bool isSuccess = false;
            if (ri.Bz.Trim().Length != 0 || ri.Dy.Trim().Length != 0 || ri.Khlb.Trim().Length != 0 || ri.My.Trim().Length != 0)//判断从传递来的username是否为空
            {
                rsdb.AddRes(ri);//传给DAL操作增加一个新用户
                isSuccess = true;
            }
            else
            {
                msg = "不能为空";
            }
            return isSuccess;//返回界面层是否添加成功
        }
    }
}
