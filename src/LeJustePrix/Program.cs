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
        public static Stack<JustePrix> justePrix { get; set; }

        static void Main(string[] args)
        {
            #region #.1. Init
            Init();
            #endregion

            #region #.2. Head
            Head();
            #endregion

            #region #.3. Body
            InitCountOfPlayers();

            InitAllPlayers();

            GenerateJustePrix();

            Body();
            #endregion

            #region #.4. Footer
            Footer();
            #endregion

            AppClass.ConsoleReadLine();
        }

        private static void Footer()
        {
            AppClass.ConsoleForegroundColor();

            Console.WriteLine(
                $"Fin du programme".AppIncrementBefore(" ", 4).AppNextLineBefore(2)
            );

            Console.WriteLine(
                "----------------".AppIncrementBefore(" ", 4)
            );
        }

        static void Head()
        {
            Console.WriteLine(
                "*********************".AppTabLineBefore(2).AppNextLineBefore().AppNextLineAfter() +
                "**  Le Juste Prix  **".AppTabLineBefore(2).AppNextLineAfter() +
                "*********************".AppTabLineBefore(2)
            );

            // -- Afficharge de la version de l'application -- //
            Console.WriteLine(
                "V: ".AppIncrementBefore(" ", 3).AppTabLineBefore(2).AppNextLineBefore() +
                AppSettings.APP_VERSION_BUILD +
                "-------------".AppIncrementBefore(" ", 3).AppTabLineBefore(2).AppNextLineBefore()
            );

            // -- Describe somes informations about the application -- //
            Console.WriteLine(
                "Informations".AppIncrementBefore(" ", 3).AppTabLineBefore(2).AppNextLineBefore() +
                "------------".AppIncrementBefore(" ", 3).AppTabLineBefore(2).AppNextLineBefore()

            );

            foreach (var line in System.IO.File.ReadAllLines("Readme.txt"))
            {
                Console.WriteLine(line.AppIncrementBefore(" ", 3));
            }

            Console.WriteLine(
                "------------".AppIncrementBefore(" ", 3).AppTabLineBefore(2)
            );

            // -- Log -- //
            AppClass.Log.Info("Démarrage de l'application " + DateTime.Now.ToString());
        }

        static void Body()
        {
            int index = 0;
            Boolean isWinner = false;

            do
            {
                for (index = 0; index < players.Length; index ++)
                {
                    KeyValuePair<AppState, AppPlusMoins?> appState = players[index].Play();

                    if (appState.Key == AppState.Echec)
                    {
                        PlusMoinsValue(appState.Value.Value);
                    }
                    else if (appState.Key == AppState.ReloadJustePrix)
                    {
                        GenerateJustePrix(true);
                    }
                    else
                    {
                        players[index].Win();

                        isWinner = true;
                        break;
                    }
                }

                index = 0;
            } while (!isWinner);
        }

        static void Init()
        {
            AppClass.ConsoleForegroundColor();

            log4net.Config.XmlConfigurator.Configure();
            
            justePrix = new Stack<JustePrix>();
        }

        static void InitCountOfPlayers()
        {
            Boolean error = false;

            do
            {

                try
                {
                    AppClass.ConsoleForegroundColor(ConsoleColor.Yellow);

                    Console.Write(
                        " -> Nombre de joueurs : ".AppTabLineBefore().AppNextLineBefore()
                    );

                    AppClass.ConsoleForegroundColor();

                    var value = AppClass.ConsoleReadLine();

                    players = new Player[int.Parse(value)];

                    if (int.Parse(value) <= 0)
                    {
                        throw new ArgumentException("Increment must be grant thant 0.");
                    }

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

        public static void IncorectValue()
        {
            AppClass.ConsoleForegroundColor(ConsoleColor.Red);

            Console.WriteLine(
                "!-> La valeur entrée est incorrect <-!".AppIncrementBefore(" ", 6).AppTabLineBefore().AppNextLineBefore()
            );

            AppClass.ConsoleForegroundColor();
        }

        public static void PlusMoinsValue(AppPlusMoins value)
        {
            AppClass.ConsoleForegroundColor(ConsoleColor.Cyan);

            Console.WriteLine(
                $"!-> Faux, le juste prix est {value.ToString()} <-!".AppIncrementBefore(" ", 6).AppTabLineBefore().AppNextLineBefore()
            );

            AppClass.ConsoleForegroundColor();
        }

        static void GenerateJustePrix(Boolean reset = false)
        {
            Console.WriteLine(
                "-------------".AppIncrementBefore(" ", 3).AppTabLineBefore(2).AppNextLineBefore()
            );

            AppClass.ConsoleForegroundColor(ConsoleColor.Green);

            if (!reset)
            {
                justePrix.Push(new JustePrix());

                Console.WriteLine(
                    $"!!-> Le juste prix est dans la plage [{justePrix.Peek().min}, {justePrix.Peek().max}] <-!!".AppIncrementBefore(" ", 1).AppTabLineBefore()
                );
            }
            else
            {
                justePrix.Push(new JustePrix(justePrix.Peek().min, justePrix.Peek().value));

                Console.WriteLine(
                    $"!!-> Le juste prix a changé, il est désormais est dans la plage [{justePrix.Peek().min}, {justePrix.Peek().max}] <-!!".AppIncrementBefore(" ", 1)
                );
            }

            AppClass.ConsoleForegroundColor();

            Console.WriteLine(
                "-------------".AppIncrementBefore(" ", 3).AppTabLineBefore(2)
            );
        }
    }
}
