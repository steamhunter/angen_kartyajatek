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
        int reallenght = 32;
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

        public Card GetRandomCard(Random r)
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
    }
}
