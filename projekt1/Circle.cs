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
    class Circle
    {
        private Point s;
        private int r;
        public int id;
        static int count = 0;

        public Circle(Point ss = null, int r = 0)
        {
            if (ss == null) this.s = new Point();
            else this.s = new Point(ss);
            radius = r;
            id = count;
            count++;
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

        public int radius
        {
            get => r;
            set => r = value;
        }

        public bool IsItMyCenter(int x, int y)
        {
            return S.IsItMe(x, y);
        }

        public bool IsItMyOrb(int x, int y)
        {
            return ((x - S.X) * (x - S.X) + (y - S.Y) * (y - S.Y) > (radius - 5) * (radius - 5) &&
                (x - S.X) * (x - S.X) + (y - S.Y) * (y - S.Y) < (radius + 5) * (radius + 5));
        }

        public bool IsItMe(int x, int y)
        {
            return (IsItMyCenter(x, y) || IsItMyOrb(x, y));
        }

        public void Draw(PaintEventArgs e, Pen pen = null, Brush brush = null)
        {
            if (pen == null) pen = new Pen(Color.Black);
            if (brush == null) brush = new SolidBrush(Color.Gray);
            e.Graphics.DrawEllipse(pen, S.X - radius, S.Y - radius, 2 * radius, 2 * radius);
            e.Graphics.FillEllipse(brush, S.X - 4, S.Y - 4, 8, 8);
        }

        public void Clone(Circle c)
        {
            this.S = new Point(c.S);
            this.radius = c.radius;
        }
    }
}
