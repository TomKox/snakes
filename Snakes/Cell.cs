using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakes
{
    class Cell
    {
        private int x;
        private int y;
        private char c;

        public int X { get => x;  }
        public int Y { get => y;  }

        public Cell(char c, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.c = c;
        }

        public override string ToString()
        {
            return c.ToString();
        }

    }
}
