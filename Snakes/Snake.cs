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
        private int score;
        private Arena arena;
        private int speed;
        private DateTime lastMove;

        public Snake(char cellChar, int startX, int startY, int startSize, Direction startDirection, Arena arena)
        {
            this.cellChar = cellChar;
            size = startSize;
            x = startX;
            y = startY;
            grow = startSize;
            Direction = startDirection;
            Arena = arena;
            Speed = 10;
            this.score = 0;
            lastMove = DateTime.Now;

            Console.SetCursorPosition(x, y);
            cells = new List<Cell>();
            cells.Add(new Cell(CellChar, x, y));
        }

        public char CellChar { get => cellChar; }
        public int Size { get => size; }
        public ConsoleColor Color { get => color; set => color = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Score { get => score; }
        internal Direction Direction { get => direction; set => direction = value; }
        internal Arena Arena { get => arena; set => arena = value; }
        internal List<Cell> Cells { get => cells; }

        public bool Move(bool forceMove=false)
        {
            int headX, headY;
            bool move;

            if ((DateTime.Now - lastMove).Milliseconds > 200 - Speed) move = true;
            else if (forceMove) move = true;
            else move = false;

            Cell tail;
            if (move)
            {
                lastMove = DateTime.Now;

                switch (Direction)
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

                if (arena.HasObstacleAt(x, y))
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('X');
                    return false;
                }
                else
                {
                    if (arena.HasTargetAt(x, y))
                    {
                        grow = 4;
                        score++;
                        speed += 10;
                        arena.NewTarget();
                    }
                    cells.Add(new Cell(CellChar, x, y));
                    size = cells.Count;
                    headX = cells.Last().X;
                    headY = cells.Last().Y;
                    Console.ForegroundColor = Color;
                    Console.SetCursorPosition(headX, headY);
                    Console.Write(CellChar);

                    if (grow > 1)
                    {
                        grow--;
                    }
                    else
                    {
                        tail = cells[0];
                        Console.SetCursorPosition(tail.X, tail.Y);
                        Console.Write(' ');
                        cells.Remove(tail);
                    }
                    return true;
                }
            }
            else return true;
        }
    }
}
