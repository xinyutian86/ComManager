using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RateInfo
    {
        private string startdate;
        private string enddate;
        private string exchange;
        private string remark;

        public string Startdate
        {
            get
            {
                return startdate;
            }

            set
            {
                startdate = value;
            }
        }

        public string Enddate
        {
            get
            {
                return enddate;
            }

            set
            {
                enddate = value;
            }
        }

        public string Exchange
        {
            get
            {
                return exchange;
            }

            set
            {
                exchange = value;
            }
        }

        public string Remark
        {
            get
            {
                return remark;
            }

            set
            {
                remark = value;
            }
        }
    }
}
