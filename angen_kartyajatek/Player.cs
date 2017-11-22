using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angen_kartyajatek
{
    class Player
    {
        public Pakli Hand = new Pakli(true);
        // public Card[] Hand = new Card[32];
        public string Name;
        public int[] WinnedRounds = new int[50];
        int WinnedRoundCount = 0;
        public int HandSize { get { return Hand.reallenght; } }

        public Player(string plyerName)
        {
            Name = plyerName;
        }

        public void ClearPakli()
        {
            Hand = new Pakli(true);
        }

        public void AddWinnedRound(int roundNum)
        {
            WinnedRounds[WinnedRoundCount] = roundNum;
            roundNum++;
        }

    }
}
