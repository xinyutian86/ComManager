using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class StateManager
    {
        private StateDB sdb = new StateDB();
        public bool Add(StateInfo si,out string msg)
        {
            msg = null;
            bool isSuccess = false;
            if (si.Id.ToString().Trim().Length != 0||si.State.Trim().Length!=0||si.Level.ToString().Trim().Length!=0)//判断从传递来的username是否为空
            {

                if (!sdb.IsEquals(si))//传给DALl操作判断数据库中是否有重复值
                {
                    sdb.AddState(si);//传给DAL操作增加一个新用户
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

        public bool Del(StateInfo si, out string msg)
        {
            msg = null;
            bool isSuccess = false;
            if (si.State.Trim().Length != 0)//判断从传递来的username是否为空
            {
                sdb.DelState(si);//传给DAL操作增加一个新用户
                isSuccess = true;
            }
            else
            {
                msg = "不能为空";
            }
            return isSuccess;//返回界面层是否添加成功
        }
        public string Get(StateInfo si)
        {
            return sdb.GetStateName(si);
        }
    }
}
