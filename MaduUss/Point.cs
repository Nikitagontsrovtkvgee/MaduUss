using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MaduUss
{
    class Point
    { 
        public int x;
        public int y;
        public char Sym;

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(Sym);
        }
    } 
}