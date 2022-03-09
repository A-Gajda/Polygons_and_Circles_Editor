using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt1
{
    class Edge
    {
        private Point s;
        private Point f;

        public Edge(Point ss, Point ff)
        {
            s = ss;
            f = ff;
        }

        public Point S
        {
            get => s;
            set
            {
                s.X = value.X;
                s.Y = value.Y;
            }
        }

        public Point F
        {
            get => f;
            set
            {
                f.X = value.X;
                f.Y = value.Y;
            }
        }
    }
}
