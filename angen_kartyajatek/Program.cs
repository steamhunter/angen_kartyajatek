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

           
            string mode;
            do
            {
                Console.WriteLine("Kérem válasza ki az indítás módját (jatek,visszanez)");
                mode = Console.ReadLine();
                
            } while (mode!="jatek"&&mode!="visszanez");
           
            switch (mode)
            {
                case "jatek": Game.Jatek(); break;
                case "visszanez": Game.Replay(); break;
            }


        }

        
    }
}
