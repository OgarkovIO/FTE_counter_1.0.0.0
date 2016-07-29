using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loader
{
    public class UNI_FTE
    {
        private string _serch_pattern;

        public string DataToString(string FullClearedName)
        {
            string[] fields = FullClearedName.Split(' ');
            _serch_pattern = string.Format("{0} {1}", fields[0], fields[1].First());
            return _serch_pattern;
        }
    }
}
