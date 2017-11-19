using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angen_kartyajatek
{
    class Match
    {
        Pakli pakli = new Pakli();
        Random r = new Random();
        Card[] playerOne = new Card[32];
        int playeronehandsize = 0;
        Card[] playerTwo = new Card[32];
        int playertwohandsize = 0;
        Card adu;
        Card called;
        bool isplayeroneactive = true;
        public bool IsOver { get; set; }


        public Match()
        {

        }
        public void StartMatch()
        {
            for (int i = 0; i < 4; i++)
            {
                playerOne[i] = pakli.GetRandomCard(r);
                playerTwo[i] = pakli.GetRandomCard(r);
            }
            playeronehandsize = 4;
            playertwohandsize = 4;
            adu = pakli.Adu;
            called = adu;
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
            for (int i = 0; i < playeronehandsize; i++)
            {
                sv += $"({playerOne[i].ToString()}) ";
            }
            sv += "\n";
            return sv;
        }
        public string ShowPlayerTwoHand()
        {
            string sv = "";
            for (int i = 0; i < playertwohandsize; i++)
            {
                sv += $"({playerTwo[i].ToString()}) ";
            }
            sv += "\n";
            return sv;
        }

        public string RoundText()
        {
            string sv = "";
            if (isplayeroneactive)
            {
                sv += $"{ActualState()}\naz első játékos jön \n{ShowPlayerOneHand()}";

            }
            else
            {
                sv += $"{ActualState()}\na második játékos jön \n{ShowPlayerTwoHand()}";
            }
            sv += "adjon meg egy kártyát ütéshez(hanyadik lap) vagy egy érvényes utasítást(felad,csere)";


            return sv;
        }
        public void RoundProcess(string input)
        {
            switch (input)
            {
                case "felad":IsOver = true;
                    break;
                
                default:
                    if (int.Parse(input))
                    {

                    }
                    break;
            }
        }

       
    }
}
