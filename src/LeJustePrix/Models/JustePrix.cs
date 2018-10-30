using LeJustePrix.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeJustePrix.Models
{
    public class JustePrix
    {
        public static int TENTATIVE => Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("TENTATIVE"));
        public int min { get; }
        public int max { get; }
        public int value { get; }

        public JustePrix()
        {
            this.min = AppSettings.MIN;
            this.max = AppSettings.MAX;
            this.value = AppClass.random.Next(this.min, this.max);
        }

        public JustePrix(int min, int max)
        {
            this.min = min;
            this.max = max;
            this.value = AppClass.random.Next(min, max);
        }
    }
}
