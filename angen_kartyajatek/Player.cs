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
        public int HandSize { get { return Hand.reallenght; } }
    }
}
