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
        public Stack<KeyValuePair<DateTime, int>> moves { get; set; }

        public Player()
        {
            this.moves = new Stack<KeyValuePair<DateTime, int>>();
            this.id = ++_id;
        }

        public void Init()
        {
            AppClass.ConsoleForegroundColor(ConsoleColor.Yellow);

            Console.Write(
                $" -> Nom du joueur N° {this.id} : ".AppTabLineBefore().AppNextLineBefore()
            );

            AppClass.ConsoleForegroundColor();

            this.name = AppClass.ConsoleReadLine();
        }

        public KeyValuePair<AppState, AppPlusMoins?> Play()
        {
            Boolean error = false;
            KeyValuePair<AppState, AppPlusMoins?> appState = new KeyValuePair<AppState, AppPlusMoins?>(AppState.Echec, null);

            do
            {

                try
                {
                    AppClass.ConsoleForegroundColor(ConsoleColor.Yellow);

                    Console.Write(
                        $" -> Joueur N° {this.id} Estimation de {this.name} (Tentative N° {this.moves.Count + 1}): ".AppTabLineBefore().AppNextLineBefore()
                    );

                    AppClass.ConsoleForegroundColor();

                    this.moves.Push(
                        new KeyValuePair<DateTime, int>(
                            DateTime.Now, Convert.ToInt32(AppClass.ConsoleReadLine())
                        )
                    );

                    error = false;

                    if (this.moves.Peek().Value == Program.justePrix.Peek().value)
                    {
                        appState = new KeyValuePair<AppState, AppPlusMoins?>(AppState.Win, null);
                    }
                    else if (Program.players.Sum(l => l.moves.Count) == JustePrix.TENTATIVE)
                    {
                        appState = new KeyValuePair<AppState, AppPlusMoins?>(AppState.ReloadJustePrix, null);
                    }
                    else
                    {
                        appState = new KeyValuePair<AppState, AppPlusMoins?>(AppState.Echec, (this.moves.Peek().Value > Program.justePrix.Peek().value) ? AppPlusMoins.Moins 
                                                                                                                                                                 : AppPlusMoins.Plus);
                    }
                }
                catch (Exception ex)
                {
                    // -- Log -- //
                    AppClass.Log.Error(ex);

                    error = true;

                    Program.IncorectValue();
                }

            } while (error);

            return appState;
        }

        public void Win()
        {
            Console.WriteLine(
                "*********************".AppTabLineBefore(2).AppNextLineBefore()
            );

            AppClass.ConsoleForegroundColor();

            Console.WriteLine(
                $"** !!->  La partie est terminé, {this.name} a gagné en {this.moves.Count} coup(s)  <-!! **".AppIncrementBefore(" ", 4)
            );

            AppClass.ConsoleForegroundColor();

            Console.WriteLine(
                "*********************".AppTabLineBefore(2)
            );
        }
    }
}
