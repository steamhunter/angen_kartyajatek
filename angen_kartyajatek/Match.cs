using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace angen_kartyajatek
{
    enum Winner
    {
        caller,
        called
    }
    class Match
    {
        Pakli pakli = new Pakli();
        Random r = new Random();
        Player playerOne;
        Player playerTwo;

        Card adu;
        Card called;
        public bool isplayeroneactive = true;
        bool isRoundStart = true;
        public bool IsOver { get; set; }
        public string OverText;
        public Winner winner;
        //Pakli calledstack = new Pakli(true);

        public Match(Player playerOne,Player playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
          /*  int seed = r.Next(10000000,9999999+1);
            Console.WriteLine(seed);
            r = new Random(seed);*/
        }
        public void StartMatch()
        {
            for (int i = 0; i < 4; i++)
            {
                playerOne.Hand.AddCard(pakli.PullRandomCard(r));
               playerTwo.Hand.AddCard( pakli.PullRandomCard(r));
            }
           
            adu = pakli.Adu;
            called = new Card(Symbol.kártya,Color.nincs);
        }

        public string ActualState()
        {
            string sv = "";

            sv += $"Az adu: {adu.ToString()}\nHívott lap: {called.ToString()}";
            return sv;
        }

        public string ShowPlayerOneHand()
        {
            string sv = "";
            for (int i = 0; i < playerOne.HandSize; i++)
            {
                sv += $"({playerOne.Hand.GetCard(i).ToString()}) ";
            }
            sv += "\n";
            return sv;
        }
        public string ShowPlayerTwoHand()
        {
            string sv = "";
            for (int i = 0; i < playerTwo.HandSize; i++)
            {
                sv += $"({playerTwo.Hand.GetCard(i).ToString()}) ";
            }
            sv += "\n";
            return sv;
        }

        public string RoundText()
        {
            string sv = "";
            if (isplayeroneactive)
            {
                sv += $"{ActualState()}\n{playerOne.Name} jön \n{ShowPlayerOneHand()}";

            }
            else
            {
                sv += $"{ActualState()}\n{playerTwo.Name} jön \n{ShowPlayerTwoHand()}";
            }
            sv += "adjon meg egy kártyát ütéshez(hanyadik lap) vagy egy érvényes utasítást(felad,csere)";


            return sv;
        }
        public void RoundProcess(string input,Player player)
        {
            switch (input)
            {
                case "felad":IsOver = true;
                    
                    break;
                
                default:
                    if (int.Parse(input)-1>=0&&int.Parse(input)-1<player.HandSize)
                    {
                        Card selected = player.Hand.PullCard(int.Parse(input)-1);
                        if (isRoundStart)
                        {
                            called = selected;
                         
                           
                        }
                        else
                        {
                          
                            if (selected.Color != called.Color && selected.Color != adu.Color)
                            {
                               OverText=$" nem egyezö szimbolum vagy szín a hívott lappal {playerOne.Name} nyert";
                                winner = Winner.caller;
                                IsOver = true;
                            }else
                            if (called.Symbol<selected.Symbol)
                            {
                                IsOver = true;
                                winner = Winner.caller;
                               OverText=$"{playerOne.Name} nyert";
                            }
                            else
                            {
                                IsOver = true;
                                winner = Winner.called;
                                OverText=$"{playerTwo.Name} nyert";
                            }
                        }
                       
                        isplayeroneactive = !isplayeroneactive;
                        if (isRoundStart)
                            isRoundStart = false;
                    }
                    break;
            }
        }

       
    }
}
