using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeJustePrix.Models.Static
{
    public static class AppClass
    {
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static readonly Random random = new Random();

        #region string
        public static string NextLine(this string value)
        {
            return
                value += "\n";
        }

        public static string TabLine(this string value)
        {
            return
                value += "\t";
        }
        #endregion
    }
}
