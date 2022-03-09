using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt1.Relations
{
    class MixedRelation :IRelation
    {
        Polygon p;
        Point s;
        Point f;
        Circle c;
        bool canRadiusBeChanged;

        public MixedRelation(Polygon p, Point s, Point f, Circle c, bool i)
        {
            this.p = p;
            this.s = s;
            this.f = f;
            this.c = c;
            this.canRadiusBeChanged = i;
        }

        public void ForMixedRelation(bool i)
        {
            canRadiusBeChanged = i;
        }

        public string GetName()
        {
            return "Styczność krawędzi i okręgu";
        }

        public bool IsThisPolygonMine(Polygon p)
        {
            return (p.id == this.p.id);
        }
        public bool IsThisEdgeMine(Point s, Point f)
        {
            return ((s == this.s && f == this.f) || (s == this.f && f == this.s));
        }
        public bool IsThisPointMine(Point s)
        {
            return (s == this.s || s == this.f);
        }
        public bool IsThisCircleMine(Circle c)
        {
            return (c.id == this.c.id);
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
            return (((s.Y - f.Y) * c.S.X + (f.X - s.X) * c.S.Y + s.X * f.Y - s.Y * f.X) *
                ((s.Y - f.Y) * c.S.X + (f.X - s.X) * c.S.Y + s.X * f.Y - s.Y * f.X)
                > (c.radius - 2) * (c.radius - 2) * ((s.Y - f.Y) * (s.Y - f.Y) + (f.X - s.X) * (f.X - s.X))
                && ((s.Y - f.Y) * c.S.X + (f.X - s.X) * c.S.Y + s.X * f.Y - s.Y * f.X) *
                ((s.Y - f.Y) * c.S.X + (f.X - s.X) * c.S.Y + s.X * f.Y - s.Y * f.X)
                < (c.radius + 2) * (c.radius + 2) * ((s.Y - f.Y) * (s.Y - f.Y) + (f.X - s.X) * (f.X - s.X)));
        }

        public bool ForceChange()
        {
            if (IfIsOK()) return true;
            int A1 = s.Y - f.Y;
            int B1 = f.X - s.X;
            int C1 = s.X * f.Y - s.Y * f.X;
            double d = (A1 * c.S.X + B1 * c.S.Y + C1) / Math.Sqrt(A1 * A1 + B1 * B1);
            if (d == 0) d = 1;
            if (canRadiusBeChanged)
            {
                c.radius = (int)d;
            }
            else
            {
                int A2 = s.X - f.X;
                int B2 = f.Y - s.Y;
                int C2 = (-c.S.X * A2 - c.S.Y * B2);
                if (A1 * B2 - A2 * B1 == 0 || A1 * B2 - A2 * B1 == 0) return false;
                Point crossing = new Point((C2 * B1 - C1 * B2) / (A1 * B2 - A2 * B1), (A2 * C1 - A1 * C2) / (A1 * B2 - A2 * B1));
                c.S.Y = (int)(crossing.Y + (c.S.Y - crossing.Y) * c.radius / d);
                c.S.X = (int)(crossing.X + (c.S.X - crossing.X) * c.radius / d);
            }
            return IfIsOK();
        }
    }
}
