using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt1.Relations
{
    class FixedCenterRelation : IRelation
    {
        public Circle c;
        public Point s;

        public FixedCenterRelation(Circle c)
        {
            this.c = c;
            this.s = new Point(c.S);
        }

        public string GetName()
        {
            return "Ustalony środek okręgu";
        }

        public bool IsThisPolygonMine(Polygon p)
        {
            return false;
        }
        public bool IsThisEdgeMine(Point s, Point f)
        {
            return false;
        }
        public bool IsThisPointMine(Point s)
        {
            return false;
        }
        public bool IsThisCircleMine(Circle c)
        {
            if (this.c.id == c.id) return true;
            return false;
        }
        public bool IsThisCircleCenterMine(Circle c)
        {
            return (IsThisCircleMine(c));
        }
        public bool IsThisCircleEdgeMine(Circle c)
        {
            return false;
        }

        public bool IfIsOK()
        {
            if (this.c.S.X == this.s.X && this.c.S.Y == this.s.Y) return true;
            return false;
        }

        public bool ForceChange()
        {
            this.c.S.X = this.s.X;
            this.c.S.Y = this.s.Y;
            return (this.IfIsOK());
        }

        public void ForMixedRelation(bool i) { }
    }
}
