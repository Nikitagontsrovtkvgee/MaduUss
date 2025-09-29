using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        public int x;
        public int y;
        public char sym;

        // Конструкторы
        public Point() { }
        public Point(int x, int y, char sym) { this.x = x; this.y = y; this.sym = sym; }
        public Point(Point p) { x = p.x; y = p.y; sym = p.sym; }

        // Движение точки
        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT) x += offset;
            else if (direction == Direction.LEFT) x -= offset;
            else if (direction == Direction.UP) y -= offset;
            else if (direction == Direction.DOWN) y += offset;
        }

        // Проверка столкновения с другой точкой
        public bool IsHit(Point p) => p.x == this.x && p.y == this.y;

        // Рисуем точку
        public void Draw() { Console.SetCursorPosition(x, y); Console.Write(sym); }

        // Стираем точку
        public void Clear() { sym = ' '; Draw(); }

        public override string ToString() => x + ", " + y + ", " + sym;
    }
}