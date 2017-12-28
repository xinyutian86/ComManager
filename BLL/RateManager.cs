using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class RateManager
    {
        private RateDB rdb = new RateDB();
        public bool Add(RateInfo ri,out string msg)
        {
            msg = null;
            bool isSuccess = false;
            if (ri.Startdate.Trim().Length != 0|| ri.Enddate.Trim().Length != 0|| ri.Exchange.Trim().Length != 0|| ri.Remark.Trim().Length != 0)//判断从传递来的username是否为空
            {
                    rdb.AddRate(ri);//传给DAL操作增加一个新用户
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
