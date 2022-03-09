using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt1
{
    interface IRelation
    {
        bool IfIsOK();
        bool ForceChange();
        bool IsThisPolygonMine(Polygon p);
        bool IsThisEdgeMine(Point s, Point f);
        bool IsThisPointMine(Point s);
        bool IsThisCircleMine(Circle c);
        bool IsThisCircleCenterMine(Circle c);
        bool IsThisCircleEdgeMine(Circle c);
        string GetName();
        void ForMixedRelation(bool i);
    }
}
