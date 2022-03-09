using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt1
{
    class Polygon
    {
        public List<Point> vertices;
        public int id;
        static int count = 0;
        public Point fixedPoint1 = null;
        public Point fixedPoint2 = null;
        public Point originalFixedPoint1 = null;
        public Point originalFixedPoint2 = null;

        public Polygon()
        {
            vertices = new List<Point>();
            id = count;
            count++;
        }

        public void Add(Point p)
        {
            vertices.Add(p);
        }

        public (bool, int) IsItMyEdge(int x, int y)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].IsItMe(x, y)) continue;
                Point s = vertices[i];
                Point f = vertices[(i + 1) % vertices.Count];
                Point m = new Point((s.X + f.X) / 2, (s.Y + f.Y) / 2);
                if ((x - m.X) * (x - m.X) + (y - m.Y) * (y - m.Y) > (f.X - m.X) * (f.X - m.X) + (f.Y - m.Y) * (f.Y - m.Y) + 10) continue;
                if (25 * ((s.Y - f.Y) * (s.Y - f.Y) + (f.X - s.X) * (f.X - s.X)) >
                    ((s.Y - f.Y) * x + (f.X - s.X) * y + s.X * f.Y - s.Y * f.X) * 
                    ((s.Y - f.Y) * x + (f.X - s.X) * y + s.X * f.Y - s.Y * f.X))
                {
                    return (true, i);
                }    
            }
            return (false, -1);
        }

        public bool IsItMe(int x, int y)
        {
            if (IsItMyEdge(x, y).Item1) return true;
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].IsItMe(x, y)) return true;
            }
            return false;
        }

        public void Draw(PaintEventArgs e, Pen pen = null, Brush brush = null)
        {
            if (vertices.Count == 0) return;
            if (pen == null) pen = new Pen(Color.Black);
            if (brush == null) brush = new SolidBrush(Color.Gray);
            int n = vertices.Count;
            for (int i = 0; i < n; i++)
            {
                e.Graphics.DrawLine(pen, new System.Drawing.Point(vertices[i].X, vertices[i].Y),
                    new System.Drawing.Point(vertices[(i + 1) % n].X, vertices[(i + 1) % n].Y));
                e.Graphics.FillEllipse(brush, vertices[i].X - 4, vertices[i].Y - 4, 8, 8);
            }
            e.Graphics.FillEllipse(brush, vertices[0].X - 4, vertices[0].Y - 4, 8, 8);
        }

        public void DrawBresenham(PaintEventArgs e, Pen pen = null, Brush brush = null)
        {
            if (vertices.Count == 0) return;
            if (pen == null) pen = new Pen(Color.Black);
            if (brush == null) brush = new SolidBrush(Color.Gray);
            int n = vertices.Count;
            for (int i = 0; i < n; i++)
            {
                BresenhamAlgorithm.Draw(e, vertices[i], vertices[(i + 1) % n], new SolidBrush(pen.Color));
                e.Graphics.FillEllipse(brush, vertices[i].X-4, vertices[i].Y-4, 8, 8);
            }
            e.Graphics.FillEllipse(brush, vertices[0].X - 4, vertices[0].Y - 4, 8, 8);
        }

        public void Clone(Polygon p)
        {
            this.vertices = new List<Point>();
            foreach (Point v in p.vertices)
                this.Add(new Point(v));
        }
    }
}
