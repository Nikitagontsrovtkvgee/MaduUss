using System;
using System.Collections.Generic;

namespace SnakeGame
{
    // Joonistamise alusklass – esindab suvalist kujundit
    public abstract class Figure
    {
        // Punktide loend, mis moodustavad kujundi
        protected List<Position> pList;

        public Figure()
        {
            pList = new List<Position>();
        }

        // Lisab punkti kujundisse
        public void AddPoint(Position p)
        {
            pList.Add(p);
        }

        // Tagastab kõik punktid
        public List<Position> GetPoints()
        {
            return pList;
        }

        // Joonistab kujundi ekraanile
        public virtual void Draw(char sym)
        {
            foreach (var p in pList)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sym);
            }
        }

        // Kontrollib, kas antud punkt on kujundi kohal
        public bool IsHit(Position p)
        {
            foreach (var point in pList)
            {
                if (point.Equals(p))
                    return true;
            }
            return false;
        }
    }
}
