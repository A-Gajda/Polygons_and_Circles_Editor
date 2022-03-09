using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt1.Relations
{
    class FixedRadiusRelation : IRelation
    {
        public Circle c;
        public int radius;

        public FixedRadiusRelation(Circle c)
        {
            this.c = c;
            this.radius = c.radius;
        }

        public string GetName()
        {
            return "Ustalona długość promienia";
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
            return false;
        }
        public bool IsThisCircleEdgeMine(Circle c)
        {
            return (IsThisCircleMine(c));
        }

        public bool IfIsOK()
        {
            if (this.c.radius == radius) return true;
            return false;
        }

        public bool ForceChange()
        {
            this.c.radius = radius;
            return this.IfIsOK();
        }

        public void ForMixedRelation(bool i) { }
    }
}
