using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ServerInfo
    {
        private string Server;
        private string DataBase;
        private string User_ID;
        private string Password;

        public string Server1
        {
            get
            {
                return Server;
            }

            set
            {
                Server = value;
            }
        }

        public string DataBase1
        {
            get
            {
                return DataBase;
            }

            set
            {
                DataBase = value;
            }
        }

        public string User_ID1
        {
            get
            {
                return User_ID;
            }

            set
            {
                User_ID = value;
            }
        }

        public string Password1
        {
            get
            {
                return Password;
            }

            set
            {
                Password = value;
            }
        }
    }
}
