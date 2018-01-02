using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StateInfo
    {
        private string id;
        private string state;
        private string level;

        

        public string State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }

        

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }
    }
}
