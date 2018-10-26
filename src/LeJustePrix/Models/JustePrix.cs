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
        public int min { get; }
        public int max { get; }
        public int value { get; }

        public JustePrix() { }

        public JustePrix(int min, int max)
        {
            this.min = min;
            this.max = max;
            this.value = AppClass.random.Next(min, max);
        }
    }
}
