using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt1.Relations
{
    class FixedLenghtRelation : IRelation
    {
        public Polygon p;
        public Point s;
        public Point f;
        public int length;

        public FixedLenghtRelation(Polygon p, Point s, Point f)
        {
            this.p = p;
            this.s = s;
            this.f = f;
            this.length = (int)Math.Sqrt((s.X - f.X) * (s.X - f.X) + (s.Y - f.Y) * (s.Y - f.Y));
        }

        public string GetName()
        {
            return "Ustalona długość krawędzi";
        }

        public bool IsThisPolygonMine(Polygon p)
        {
            if (p.id == this.p.id) return true;
            return false;
        }
        public bool IsThisEdgeMine(Point s, Point f)
        {
            if ((s == this.s && f == this.f) || (s == this.f && f == this.s)) return true;
            return false;
        }
        public bool IsThisPointMine(Point s)
        {
            if (s == this.s || s == this.f) return true;
            return false;
        }
        public bool IsThisCircleMine(Circle c)
        {
            return false;
        }
        public bool IsThisCircleCenterMine(Circle c)
        {
            return false;
        }
        public bool IsThisCircleEdgeMine(Circle c)
        {
            return false;
        }

        public bool IfIsOK()
        {
            return ((int)Math.Sqrt((s.X - f.X) * (s.X - f.X) + (s.Y - f.Y) * (s.Y - f.Y)) > length - 2
                && (int)Math.Sqrt((s.X - f.X) * (s.X - f.X) + (s.Y - f.Y) * (s.Y - f.Y)) < length + 2);
        }

        public bool ForceChange()
        {
            double sqrt = Math.Sqrt((s.X - f.X) * (s.X - f.X) + (s.Y - f.Y) * (s.Y - f.Y));
            if (((s == p.fixedPoint1 || s==p.originalFixedPoint1 || s == p.fixedPoint2 || s == p.originalFixedPoint2) && 
                (f == p.fixedPoint2 || f==p.originalFixedPoint2 || f == p.fixedPoint1 || f == p.originalFixedPoint1))) { }
            else if (s == p.fixedPoint1 || s == p.originalFixedPoint1)
            {
                f.Y = s.Y + (int)(length * (f.Y - s.Y) / sqrt);
                f.X = s.X + (int)(length * (f.X - s.X) / sqrt);
                p.fixedPoint1 = f;
            }
            else if (s == p.fixedPoint2 || s == p.originalFixedPoint2)
            {
                f.Y = s.Y + (int)(length * (f.Y - s.Y) / sqrt);
                f.X = s.X + (int)(length * (f.X - s.X) / sqrt);
                p.fixedPoint2 = f;
            }
            else if (f == p.fixedPoint1 || f == p.originalFixedPoint1)
            {
                s.Y = f.Y + (int)(length * (s.Y - f.Y) / sqrt);
                s.X = f.X + (int)(length * (s.X - f.X) / sqrt);
                p.fixedPoint1 = s;
            }
            else if (f == p.fixedPoint2 || f == p.originalFixedPoint2)
            {
                s.Y = f.Y + (int)(length * (s.Y - f.Y) / sqrt);
                s.X = f.X + (int)(length * (s.X - f.X) / sqrt);
                p.fixedPoint2 = s;
            }
            if (!IfIsOK())
            {
                s.Y = f.Y + (int)(length * (s.Y - f.Y) / sqrt);
                s.X = f.X + (int)(length * (s.X - f.X) / sqrt);
            }
            return IfIsOK();
        }

        public void ForMixedRelation(bool i) { }
    }
}
