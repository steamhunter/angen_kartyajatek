using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angen_kartyajatek
{
    class Program
    {
        static public Player playerOne;
        static public Player playerTwo;
        static public int actualRoundNum = 0;
        static void Main(string[] args)
        {
         
        Console.WriteLine("első játékos neve");
           playerOne =new Player(Console.ReadLine());
            Console.WriteLine("második játékos neve");
           playerTwo=new Player(Console.ReadLine());
            while (true)
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
                Console.WriteLine("ENTER a következö körhöz");
                Console.ReadLine();
            }
           
            
        }
    }
}
