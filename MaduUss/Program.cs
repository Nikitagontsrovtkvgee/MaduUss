using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaduUss
{
    class program
    {
        static void main(string[] args)
        {
            Point p1 = new Point();
            p1.x = 1;
            p1.y = 3;
            p1.Sym = '*';
            p1.Draw();

            Point p2 = new Point();
            p2.x = 4;
            p2.y = 5;
            p2.Sym = '#';

            p2.Draw();

            Console.ReadLine();

            /*int x1 = 1;
            int y1 = 3;
            char Sym1 = '*';

            Draw( x1, y1, Sym1 );

            int x2 = 4;
            int y2 = 5;
            char Sym2 = '#';

            Draw( x2, y2, Sym2 );*/

            Console.ReadLine();
        }
    }
}