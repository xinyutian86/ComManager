using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ActiveUser
    {
        private string login_name;
        private string username;
        private string password;
        private string newpass;

        public string Login_name
        {
            get
            {
                return login_name;
            }

            set
            {
                login_name = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Newpass
        {
            get
            {
                return newpass;
            }

            set
            {
                newpass = value;
            }
        }
    }
}
