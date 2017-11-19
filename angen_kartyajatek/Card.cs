using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angen_kartyajatek
{
    class Card
    {
        public Symbol Symbol { get;private set; }
        public Color Color { get;private set; }

        public Card(Symbol symbol,Color color)
        {
            Symbol = symbol;
            Color = color;
        }

        public override string ToString()
        {
            return $"{Color} , {Symbol}";
        }
    }
}
