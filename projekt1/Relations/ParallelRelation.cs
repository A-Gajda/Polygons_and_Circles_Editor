using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt1.Relations
{
    class ParallelRelation : IRelation
    {
        public Polygon p;
        public Point s1;
        public Point f1;
        public Point s2;
        public Point f2;

        public ParallelRelation(Polygon p, Point s1, Point f1, Point s2, Point f2)
        {
            this.p = p;
            this.s1 = s1;
            this.f1 = f1;
            this.s2 = s2;
            this.f2 = f2;
        }

        public string GetName()
        {
            return "Równoległość dwóch krawędzi";
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
            return ((f1.X - s1.X) * (f2.Y - s2.Y) > (f2.X - s2.X) * (f1.Y - s1.Y) - 2 &&
                (f1.X - s1.X) * (f2.Y - s2.Y) < (f2.X - s2.X) * (f1.Y - s1.Y) + 2);
        }

        public bool ForceChange()
        {
            if (IfIsOK()) return true;
            if (((s1 == p.fixedPoint1 || s1 == p.originalFixedPoint1 || s1 == p.fixedPoint2 || s1 == p.originalFixedPoint2) ||
               (f1 == p.fixedPoint2 || f1 == p.originalFixedPoint2 || f1 == p.fixedPoint1 || f1 == p.originalFixedPoint1)))
            {
                if (f2 == p.fixedPoint2 || f2 == p.originalFixedPoint2 || f2 == p.fixedPoint1 || f2 == p.originalFixedPoint1)
                {
                    if (s1.X == f1.X)
                    {
                        s2.X = f2.X;
                        if (s2.Y == f2.Y) s2.Y = f2.Y + 100;
                    }
                    else if (s1.Y == f1.Y) 
                    {
                        s2.Y = f2.Y;
                        if (s2.X == f2.X) s2.X = f2.X + 100;
                    }
                    else s2.Y = f2.Y + (int)((s2.X - f2.X) * (s1.Y - f1.Y) / (s1.X - f1.X));
                }
                else
                {
                    if (s1.X == f1.X)
                    {
                        f2.X = s2.X;
                        if (s2.Y == f2.Y) f2.Y = s2.Y + 100;
                    }
                    else if (s1.Y == f1.Y)
                    {
                        f2.Y = s2.Y;
                        if (s2.X == f2.X) f2.X = s2.X + 100;
                    }
                    else f2.Y = s2.Y + (int)((f2.X - s2.X) * (f1.Y - s1.Y) / (f1.X - s1.X));
                }
            }
            else if (((s2 == p.fixedPoint1 || s2 == p.originalFixedPoint1 || s2 == p.fixedPoint2 || s2 == p.originalFixedPoint2) ||
               (f2 == p.fixedPoint2 || f2 == p.originalFixedPoint2 || f2 == p.fixedPoint1 || f2 == p.originalFixedPoint1)))
            {
                if (f1 == p.fixedPoint2 || f1 == p.originalFixedPoint2 || f1 == p.fixedPoint1 || f1 == p.originalFixedPoint1)
                {
                    if (s2.X == f2.X)
                    {
                        s1.X = f1.X;
                        if (s1.Y == f1.Y) s1.Y = f1.Y + 100;
                    }
                    else if (s2.Y == f2.Y) 
                    {
                        s1.Y = f1.Y;
                        if (s1.X == f1.X) s1.X = f1.X + 100;
                    }
                    else s1.Y = f1.Y + (int)((s1.X - f1.X) * (s2.Y - f2.Y) / (s2.X - f2.X));
                }
                else
                {
                    if (s2.X == f2.X)
                    {
                        f1.X = s1.X;
                        if (s1.Y == f1.Y) f1.Y = s1.Y + 100;
                    }
                    else if (s2.Y == f2.Y)
                    {
                        f1.Y = s1.Y;
                        if (s1.X == f1.X) f1.X = s1.X + 100;
                    }
                    else f1.Y = s1.Y + (int)((f1.X - s1.X) * (f2.Y - s2.Y) / (f2.X - s2.X));
                }
            }
            else
            {
                if (s1.X == f1.X)
                {
                    s2.X = f2.X;
                    if (s2.Y == f2.Y) s2.Y = f2.Y + 100;
                }
                else if (s1.Y == f1.Y)
                {
                    s2.Y = f2.Y;
                    if (s2.X == f2.X) s2.X = f2.X + 100;
                }
                else s2.Y = f2.Y + (int)((s2.X - f2.X) * (s1.Y - f1.Y) / (s1.X - f1.X));
            }
            return IfIsOK();
        }

        public void ForMixedRelation(bool i) { }
    }
}
