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
       public Player playerOne = new Player();
       public Player playerTwo = new Player();
        Card adu;
        Card called;
        bool isplayeroneactive = true;
        public bool IsOver { get; set; }
        Pakli calledstack = new Pakli(true);

        public Match()
        {

        }
        public void StartMatch()
        {
            for (int i = 0; i < 4; i++)
            {
                playerOne.Hand.AddCard(pakli.GetRandomCard(r));
               playerTwo.Hand.AddCard( pakli.GetRandomCard(r));
            }
           
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
                sv += $"{ActualState()}\naz első játékos jön \n{ShowPlayerOneHand()}";

            }
            else
            {
                sv += $"{ActualState()}\na második játékos jön \n{ShowPlayerTwoHand()}";
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
                    if (int.Parse(input)>0&&int.Parse(input)<player.HandSize)
                    {
                        Card selected = player.Hand.GetCard(int.Parse(input));
                    }
                    break;
            }
        }

       
    }
}
