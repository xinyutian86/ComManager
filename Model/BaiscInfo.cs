using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BaiscInfo
    {
        private string typename;
        private string db;

        public string Typename
        {
            get
            {
                return typename;
            }

            set
            {
                typename = value;
            }
        }

        public string Db
        {
            get
            {
                return db;
            }

            set
            {
                db = value;
            }
        }
    }
}
