using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class ContactsManager
    {
        private ContactsDB cd = new ContactsDB();
        public bool Add(ContactsInfo ci,out string msg)
        {
            msg = null;
            bool isSuccess = false;
            if (ci.Contacts.Trim().Length != 0 || ci.Email.Trim().Length != 0 || ci.English_name.Trim().Length != 0||ci.Fax.Trim().Length!=0||ci.Job.Trim().Length!=0||ci.Mophone.Trim().Length!=0||ci.Phone.Trim().Length!=0)//判断从传递来的username是否为空
            {

                if (!cd.IsEquals(ci))//传给DALl操作判断数据库中是否有重复值
                {
                    cd.AddCt(ci);//传给DAL操作增加一个新用户
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
