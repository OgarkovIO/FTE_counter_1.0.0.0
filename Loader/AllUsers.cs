using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loader
{
    public class AllUsers
    {
        private string _index;

        public string SM_ZNO { get; set; }
        public string SM_INC { get; set; }
        public string SD_ZNO { get; set; }
        public string SD_ZNR { get; set; }

        public string index
        {
            get { return _index; }
            set { _index = value; }
        }
    }
}
