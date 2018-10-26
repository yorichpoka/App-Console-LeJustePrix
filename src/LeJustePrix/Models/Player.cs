using LeJustePrix.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeJustePrix.Models
{
    public class Player
    {
        private static int _id { get; set; }
        public int id { get; }
        public string name { get; set; }
        public int score { get; set; }
        public Dictionary<DateTime, int> moves { get; set; }

        public Player()
        {
            this.moves = new Dictionary<DateTime, int>();
            this.id = ++_id;
        }

        public void Init()
        {
            Console.Write(
                string.Empty.NextLine().TabLine() + $" -> Nom du joueur N° {this.id}: "
            );

            this.name = Console.ReadLine();
        }
    }
}
