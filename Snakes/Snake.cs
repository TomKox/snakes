using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakes
{
    enum Direction { North, East, South, West };

    class Snake
    {
        private Direction direction;
        private char cellChar;
        private int size;
        private ConsoleColor color;
        private List<Cell> cells;
        private int x, y;
        private int grow;
        private Arena arena;

        public Snake(char cellChar, int startX, int startY, int startSize, Direction startDirection, Arena arena)
        {
            this.cellChar = cellChar;
            size = startSize;
            x = startX;
            y = startY;
            grow = startSize;
            Direction = startDirection;
            Arena = arena;

            Console.SetCursorPosition(x, y);
            cells = new List<Cell>();
            cells.Add(new Cell(CellChar, x, y));


        }

        public char CellChar { get => cellChar; }
        public int Size { get => size; }
        internal Direction Direction { get => direction; set => direction = value; }
        internal Arena Arena { get => arena; set => arena = value; }
        internal List<Cell> Cells { get => cells; }

        public bool Move()
        {
            int headX, headY;
            Cell tail;
            
            switch(Direction)
            {
                case Direction.North:
                    y = y - 1;
                    break;
                case Direction.East:
                    x = x + 1;
                    break;
                case Direction.South:
                    y = y + 1;
                    break;
                case Direction.West:
                    x = x - 1;
                    break;
            }
            
            if(arena.HasObstacleAt(x,y))
            {
                Console.SetCursorPosition(x, y);
                Console.Write('X');
                return false;
            }
            else {
                if (arena.HasTargetAt(x, y))
                {
                    grow = 3;
                    arena.NewTarget();
                }
                cells.Add(new Cell(cellChar, x, y));
                size = cells.Count;
                headX = cells[size - 1].X;
                headY = cells[size - 1].Y;
                Console.SetCursorPosition(headX, headY);
                Console.Write(cells[size - 1]);

                if(grow != 0)
                {
                    grow--;
                }
                else
                {
                    tail = cells[0];
                    Console.SetCursorPosition(tail.X, tail.Y);
                    Console.Write(' ');
                    cells.Remove(tail);
                    cells.TrimExcess();
                }
                return true;
            }

        }
    }
}
