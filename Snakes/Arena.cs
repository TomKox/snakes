using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snakes
{
    class Arena
    {
        private char obstacleChar;
        private List<Cell> obstacles;
        private int height, width;
        private ConsoleColor color;
        private List<Snake> snakes;
        private int targetX, targetY;


        public Arena() : this('.')
        {

        }

        public Arena(char obstacleChar)
        {
            Console.Clear();
            this.ObstacleChar = obstacleChar;
            obstacles = new List<Cell>();
            this.height = Console.WindowHeight-3;
            this.width = Console.WindowWidth-1;
            Console.CursorVisible = false;
            this.color = ConsoleColor.White;
            snakes = new List<Snake>();
        }

        public char ObstacleChar { get => obstacleChar; set => obstacleChar = value; }
        public int Height { get => height;  }
        public int Width { get => width; }
        public ConsoleColor Color { get => color; set => color = value; }

        public void addBorder()
        {
            for (int i = 1; i < Width; i++)
            {
                obstacles.Add(new Cell(ObstacleChar, i, 0));
                obstacles.Add(new Cell(ObstacleChar, i, Height));
            }
            for (int i = 0; i < Height; i++)
            {
                obstacles.Add(new Cell(ObstacleChar, 1, i));
                obstacles.Add(new Cell(ObstacleChar, Width-1, i));
            }
            
        }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            foreach(Cell obstacle in obstacles)
            {
                Console.SetCursorPosition(obstacle.X, obstacle.Y);
                Console.Write(obstacle);
            }
        }

        public void AddSnake(int x, int y)
        {
            snakes.Add(new Snake('O', x, y, 3, Direction.South, this));
            snakes.Last().Color = ConsoleColor.Yellow;

            if (snakes.Count > 1) snakes.Last().Color = ConsoleColor.Cyan;
        }

        public bool Next()
        {
            bool move = false;
            foreach(Snake snake in snakes)
            {
               move = snake.Move();
                if (!move) break;
            }
            return move;
        }

        public bool HasObstacleAt(int x, int y)
        {
            bool obstacleFound = false;

            List<Cell> allObstacles = new List<Cell>();
            allObstacles.AddRange(obstacles);

            foreach(Snake snake in snakes)
            {
                allObstacles.AddRange(snake.Cells);
            }

            foreach(Cell c in allObstacles)
            {
                if(c.X == x && c.Y == y)
                {
                    obstacleFound = true;
                    break;
                }
            }
            return obstacleFound;
        }

        public void NewTarget()
        {
            int x, y;

            UpdateScore();

            do
            {
                Random rnd = new Random();
                x = rnd.Next(1, width);
                y = rnd.Next(1, height);
            }
            while (this.HasObstacleAt(x, y));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y);
            Console.Write('T');
            targetX = x;
            targetY = y;
        }

        public void UpdateScore()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string scores = String.Format("Player 1: {0} --- Player 2: {1}", snakes[0].Score, snakes[1].Score);
            ConsoleHelper.Center(scores, height + 1);
        }
        
        public bool HasTargetAt(int x, int y)
        {
            if (x == targetX && y == targetY) return true;
            else return false;
        }

        public void ReadKey()
        {
            if(Console.KeyAvailable) { 
                ConsoleKey inkey = Console.ReadKey(true).Key;
                switch(inkey)
                {
                    case ConsoleKey.UpArrow:
                        if(snakes[0].Direction != Direction.South) snakes[0].Direction = Direction.North;
                        break;
                    case ConsoleKey.RightArrow:
                        if (snakes[0].Direction != Direction.West) snakes[0].Direction = Direction.East;
                        break;
                    case ConsoleKey.DownArrow:
                        if (snakes[0].Direction != Direction.North) snakes[0].Direction = Direction.South;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (snakes[0].Direction != Direction.East) snakes[0].Direction = Direction.West;
                        break;
                    case ConsoleKey.Z:
                        if (snakes[1].Direction != Direction.South) snakes[1].Direction = Direction.North;
                        break;
                    case ConsoleKey.D:
                        if (snakes[1].Direction != Direction.West) snakes[1].Direction = Direction.East;
                        break;
                    case ConsoleKey.S:
                        if (snakes[1].Direction != Direction.North) snakes[1].Direction = Direction.South;
                        break;
                    case ConsoleKey.Q:
                        if (snakes[1].Direction != Direction.East) snakes[1].Direction = Direction.West;
                        break;
                }
                snakes[0].Move(true);
            }
        }
    }
}
