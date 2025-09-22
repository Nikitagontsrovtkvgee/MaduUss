using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaduUss
{
    class HorizontalLine
    {
        List<Point> pList;

        public HorizontalLine(int xLeft, int xReight, int y, char sym)
        {
            pList = new List<Point>();
            for(int x = xLeft; x <= xReight; x++)
            {
                Point p = new Point( x, y, sym );
                pList.Add( p );
            }
            //Point p1 = new Point( 4, 4, '*' );
            //Point p2 = new Point( 5, 4, '*');
            //Point p3 = new Point( 6, 4, '*');
            //pList.Add( p1 );
            //pList.Add( p2 );
            //pList.Add( p3 );

        }
        public void Drow()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }
    }
}
