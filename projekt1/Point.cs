using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt1
{
    class Point
    {
        private int x;
        private int y;
        public int id;
        static int count = 0;

        public Point(int xx = 0, int yy = 0)
        {
            x = xx;
            y = yy;
            id = count;
            count++;
        }

        public Point(Point p)
        {
            x = p.X;
            y = p.Y;
        }

        public int X
        {
            get => x;
            set => x = value;
        }

        public int Y
        {
            get => y;
            set => y = value;
        }

        public bool IsItMe(int x, int y)
        {
            return ((x - this.x) * (x - this.x) + (y - this.y) * (y - this.y) <= 25);
        }
    }
}
