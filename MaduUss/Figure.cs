using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Figure
    {
        protected List<Point> pList;

        public void Draw()
        {
            foreach (var p in pList) p.Draw();
        }

        public bool IsHit(Figure figure)
        {
            foreach (var p in pList)
            {
                foreach (var fp in figure.pList)
                {
                    if (p.IsHit(fp)) return true;
                }
            }
            return false;
        }
    }
}