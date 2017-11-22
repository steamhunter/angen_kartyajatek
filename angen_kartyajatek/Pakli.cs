using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angen_kartyajatek
{
    class Pakli
    {
        Card[] pakli = new Card[32];
        public int reallenght = 32;
        Symbol[] symbols = { Symbol.Ász, Symbol.Király, Symbol.Felső, Symbol.Alsó, Symbol.X, Symbol.IX, Symbol.VIII, Symbol.VII };
        Color[] colors = { Color.Piros, Color.Tök, Color.Zöld, Color.Makk };
        public Pakli()
        {
            int i = 0;
            foreach (var color in colors)
            {
                foreach (var symbol in symbols)
                {
                    pakli[i] = new Card(symbol, color);
                    i++;
                }
               
            }
        }
        public Pakli(bool isemptyneedeed)
        {
            pakli = new Card[0];
            reallenght = 0;

        }

        public void AddCard(Card card)
        {
            if (reallenght + 1 < pakli.Length)
            {
                pakli[reallenght] = card;
                reallenght++;
            }
            else
            {
                Card[] newpakli = new Card[pakli.Length > 0 ? pakli.Length * 2: 1];
                for (int i = 0; i < reallenght; i++)
                {
                    newpakli[i] = pakli[i];
                }
                newpakli[reallenght] = card;
                reallenght++;
                pakli = newpakli;
            }
        }
        public Card PullRandomCard(Random r)
        {
            int index = r.Next(reallenght);
            Card card = pakli[index];
            RemoveAtIndex(index);

            return card;
        }

        void RemoveAtIndex(int index)
        {
            for (int i = index; i < reallenght-1; i++)
            {
                pakli[i] = pakli[i + 1];
            }
            reallenght--;
        }
        public Card Adu {
            get {
                Card card = pakli[17 - 8];
                RemoveAtIndex(17 - 8);
                return card;
            }
        }

        public Card GetCard(int index)
        {
            
            return pakli[index];

        }

        public Card PullCard(int index)
        {
            Card card = pakli[index];
            RemoveAtIndex(index);
            return card;
        }
    }
}
