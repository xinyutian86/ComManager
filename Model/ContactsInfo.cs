using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ContactsInfo
    {
        private string contacts;
        private string english_name;
        private string job;
        private string phone;
        private string mophone;
        private string email;
        private string fax;

        public string Contacts
        {
            get
            {
                return contacts;
            }

            set
            {
                contacts = value;
            }
        }

        public string English_name
        {
            get
            {
                return english_name;
            }

            set
            {
                english_name = value;
            }
        }

        public string Job
        {
            get
            {
                return job;
            }

            set
            {
                job = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string Mophone
        {
            get
            {
                return mophone;
            }

            set
            {
                mophone = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }

            set
            {
                fax = value;
            }
        }
    }
}
