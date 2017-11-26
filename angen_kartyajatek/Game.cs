using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angen_kartyajatek
{
    static class Game
    {
        static public Player playerOne;
        static public Player playerTwo;
        static public int actualRoundNum = 0;
        static string gamename;
       public static StreamWriter streamWriter;

        public  static void Jatek()
        {
            Console.WriteLine("kérem nevezze el a játékot");
            gamename = Console.ReadLine();
            streamWriter = new StreamWriter(gamename + ".game");
            Console.WriteLine("első játékos neve");
            playerOne = new Player(Console.ReadLine());
            Console.WriteLine("második játékos neve");
            playerTwo = new Player(Console.ReadLine());
            //streamWriter.WriteLine(playerOne.Name);
            //streamWriter.WriteLine(playerTwo.Name);
            bool end = false;
            while (!end)
            {
                Console.Clear();
                Match match = new Match(playerOne, playerTwo);
                match.StartMatch();
                do
                {
                    //  Console.Clear();
                    Console.WriteLine(match.RoundText());
                    if (match.isplayeroneactive)
                    {
                        match.RoundProcess(Console.ReadLine(), playerOne);
                    }
                    else
                    {
                        match.RoundProcess(Console.ReadLine(), playerTwo);
                    }

                } while (!match.IsOver);

                if (match.winner == Winner.caller)
                {
                    playerOne.AddWinnedRound(actualRoundNum);
                }
                else
                {
                    playerTwo.AddWinnedRound(actualRoundNum);
                    Player temp = playerOne;
                    playerOne = playerTwo;
                    playerOne = temp;
                }
                playerOne.ClearPakli();
                playerTwo.ClearPakli();
                Console.WriteLine(match.OverText);
                Console.WriteLine("ENTER a következö körhöz vagy (kilep) a kilépéshez");
                string endtext=Console.ReadLine();
                if (endtext=="kilep")
                {
                    end = true;
                }
            }
            streamWriter.Close();
        }
        public static void Replay()
        {
            Console.WriteLine("adja meg a megnézendö játékot");
            string gamename = Console.ReadLine();
            StreamReader streamReader = new StreamReader(gamename + ".game");
            string sor = null;
            while (!streamReader.EndOfStream)
            {
                Console.Clear();
                do
                {
                    sor = streamReader.ReadLine();
                    Console.WriteLine(sor);
                } while (sor != "");
                Console.WriteLine("ENTER a letett laphoz");
                Console.ReadLine();
                int sorc = 0;
                do
                {
                    sorc++;
                    sor = streamReader.ReadLine();
                    Console.WriteLine(sor);
                } while (sor!="");
                if (sorc<3)
                {
                    Console.WriteLine("ENTER a másik játékoshoz");

                }
                else
                {
                    Console.WriteLine("ENTER a következö körhöz");
                }
                Console.ReadLine();
                Console.Clear();
            }
           
        }
    }
}
