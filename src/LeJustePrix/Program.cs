using LeJustePrix.Models;
using LeJustePrix.Models.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeJustePrix
{
    class Program
    {
        public static Player[] players { get; set; }

        static void Main(string[] args)
        {
            #region #.1. Init
            Init();
            #endregion

            #region #.2. Head
            Console.WriteLine(
                string.Empty.NextLine().TabLine().TabLine() +
                "*********************".NextLine().TabLine().TabLine() + 
                "**  Le Juste Prix  **".NextLine().TabLine().TabLine() + 
                "*********************"
            );

            // -- Afficharge de la version de l'application -- //
            Console.WriteLine(
                string.Empty.NextLine().TabLine().TabLine() +
                "   V: " + AppSettings.APP_VERSION_BUILD.NextLine().TabLine().TabLine() + 
                "   -------------"
            );

            // -- Log -- //
            AppClass.Log.Info("Démarrage de l'application " + DateTime.Now.ToString());
            #endregion

            #region Init game
            InitCountOfPlayers();

            InitAllPlayers();
            #endregion

            Console.ReadLine();
        }

        static void Init()
        {
            Console.ForegroundColor = ConsoleColor.White;

            log4net.Config.XmlConfigurator.Configure();
        }

        static void InitCountOfPlayers()
        {
            Boolean error = false;

            do
            {
                try {
                    Console.Write(
                        string.Empty.NextLine().TabLine() + " -> Nombre de joueurs : "
                    );

                    var value = Console.ReadLine();

                    players = new Player[int.Parse(value)];

                    error = false;
                }
                catch (Exception ex)
                {
                    // -- Log -- //
                    AppClass.Log.Error(ex);

                    error = true;

                    IncorectValue();
                }

            } while (error);

        }

        static void InitAllPlayers()
        {
            for(var i = 0; i < players.Length; i++)
            {
                players[i] = new Player();

                players[i].Init();
            }
            
        }

        static void IncorectValue()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(
                string.Empty.NextLine().TabLine() + " !-> La valeur entrée est incorrect <-!"
            );

            Console.ForegroundColor = ConsoleColor.White;
        }

        static void GenerateJustePrix()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(
                string.Empty.NextLine().TabLine() + $" !!-> Le juste prix est dans la plage [{0}, {0}] <-!!"
            );

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
