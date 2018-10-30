using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeJustePrix.Models.Static
{
    public enum AppState
    {
        Echec = 0,
        Win = 1,
        //InProgress = 2,
        ReloadJustePrix = 2
    }

    public enum AppPlusMoins
    {
        Plus = 0,
        Moins = 1,
    }
}
