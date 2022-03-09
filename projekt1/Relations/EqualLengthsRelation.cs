using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt1.Relations
{
    class EqualLengthsRelation : IRelation
    {
        public Polygon p;
        public Point s1;
        public Point f1;
        public Point s2;
        public Point f2;

        public EqualLengthsRelation(Polygon p, Point s1, Point f1, Point s2, Point f2)
        {
            this.p = p;
            this.s1 = s1;
            this.f1 = f1;
            this.s2 = s2;
            this.f2 = f2;
        }

        public string GetName()
        {
            return "Równa długość dwóch krawędzi";
        }

        public bool IsThisPolygonMine(Polygon p)
        {
            return (p.id == this.p.id);
        }
        public bool IsThisEdgeMine(Point s, Point f)
        {
            if ((s == this.s1 && f == this.f1) || (s == this.f1 && f == this.s1)) return true;
            if ((s == this.s2 && f == this.f2) || (s == this.f2 && f == this.s2)) return true;
            return false;
        }
        public bool IsThisPointMine(Point s)
        {
            if (s == this.s1 || s == this.f1) return true;
            if (s == this.s2 || s == this.f2) return true;
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
            return ((int)Math.Sqrt((s1.X - f1.X) * (s1.X - f1.X) + (s1.Y - f1.Y) * (s1.Y - f1.Y)) >
                (int)Math.Sqrt((s2.X - f2.X) * (s2.X - f2.X) + (s2.Y - f2.Y) * (s2.Y - f2.Y)) - 2
                && (int)Math.Sqrt((s1.X - f1.X) * (s1.X - f1.X) + (s1.Y - f1.Y) * (s1.Y - f1.Y)) <
                (int)Math.Sqrt((s2.X - f2.X) * (s2.X - f2.X) + (s2.Y - f2.Y) * (s2.Y - f2.Y)) + 2);
        }

        public bool ForceChange()
        {
            if (IfIsOK()) return true;
            if (((s1 == p.fixedPoint1 || s1 == p.originalFixedPoint1 || s1 == p.fixedPoint2 || s1 == p.originalFixedPoint2) ||
               (f1 == p.fixedPoint2 || f1 == p.originalFixedPoint2 || f1 == p.fixedPoint1 || f1 == p.originalFixedPoint1)))
            {
                double length = Math.Sqrt((s1.X - f1.X) * (s1.X - f1.X) + (s1.Y - f1.Y) * (s1.Y - f1.Y));
                if(f2 == p.fixedPoint2 || f2 == p.originalFixedPoint2 || f2 == p.fixedPoint1 || f2 == p.originalFixedPoint1)
                {
                    double sqrt = Math.Sqrt((s2.X - f2.X) * (s2.X - f2.X) + (s2.Y - f2.Y) * (s2.Y - f2.Y));
                    s2.Y = f2.Y + (int)(length * (s2.Y - f2.Y) / sqrt);
                    s2.X = f2.X + (int)(length * (s2.X - f2.X) / sqrt);
                }
                else
                {
                    double sqrt = Math.Sqrt((s2.X - f2.X) * (s2.X - f2.X) + (s2.Y - f2.Y) * (s2.Y - f2.Y));
                    f2.Y = s2.Y + (int)(length * (f2.Y - s2.Y) / sqrt);
                    f2.X = s2.X + (int)(length * (f2.X - s2.X) / sqrt);
                }    
            }
            else if (((s2 == p.fixedPoint1 || s2 == p.originalFixedPoint1 || s2 == p.fixedPoint2 || s2 == p.originalFixedPoint2) ||
               (f2 == p.fixedPoint2 || f2 == p.originalFixedPoint2 || f2 == p.fixedPoint1 || f2 == p.originalFixedPoint1)))
            {
                double length = Math.Sqrt((s2.X - f2.X) * (s2.X - f2.X) + (s2.Y - f2.Y) * (s2.Y - f2.Y));
                if (f1 == p.fixedPoint2 || f1 == p.originalFixedPoint2 || f1 == p.fixedPoint1 || f1 == p.originalFixedPoint1)
                {
                    double sqrt = Math.Sqrt((s1.X - f1.X) * (s1.X - f1.X) + (s1.Y - f1.Y) * (s1.Y - f1.Y));
                    s1.Y = f1.Y + (int)(length * (s1.Y - f1.Y) / sqrt);
                    s1.X = f1.X + (int)(length * (s1.X - f1.X) / sqrt);
                }
                else
                {
                    double sqrt = Math.Sqrt((s1.X - f1.X) * (s1.X - f1.X) + (s1.Y - f1.Y) * (s1.Y - f1.Y));
                    f1.Y = s1.Y + (int)(length * (f1.Y - s1.Y) / sqrt);
                    f1.X = s1.X + (int)(length * (f1.X - s1.X) / sqrt);
                }
            }
            else
            {
                int length = (int)Math.Sqrt((s1.X - f1.X) * (s1.X - f1.X) + (s1.Y - f1.Y) * (s1.Y - f1.Y));
                double sqrt = Math.Sqrt((s2.X - f2.X) * (s2.X - f2.X) + (s2.Y - f2.Y) * (s2.Y - f2.Y));
                s2.Y = f2.Y + (int)(length * (s2.Y - f2.Y) / sqrt);
                s2.X = f2.X + (int)(length * (s2.X - f2.X) / sqrt);
            }
            return IfIsOK();
        }

        public void ForMixedRelation(bool i) { }
    }
}
