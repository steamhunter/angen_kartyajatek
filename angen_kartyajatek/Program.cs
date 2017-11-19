using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angen_kartyajatek
{
    class Program
    {
        static void Main(string[] args)
        {
            Match match = new Match();
            match.StartMatch();
            do
            {
                Console.WriteLine(match.RoundText());
                match.RoundProcess(Console.ReadLine());
            } while (!match.IsOver);
            
        }
    }
}
