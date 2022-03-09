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
    static class BresenhamAlgorithm
    {
        public static void Draw(PaintEventArgs e, Point s, Point f, Brush brush)
        {
            int dx = f.X - s.X;
            int dy = f.Y - s.Y;
            int x = s.X;
            int y = s.Y;
            e.Graphics.FillRectangle(brush, x, y, 1, 1);

            if (f.X - s.X >= 0 && f.Y - s.Y >= 0 && Math.Abs(f.Y - s.Y) < Math.Abs(f.X - s.X))
            {
                int d = 2 * dy - dx;
                int incrE = 2 * dy;
                int incrSE = 2 * (dy - dx);
                while (x < f.X)
                {
                    if (d < 0)
                    {
                        d += incrE;
                        x++;
                    }
                    else
                    {
                        d += incrSE;
                        x++;
                        y++;
                    }
                    e.Graphics.FillRectangle(brush, x, y, 1, 1);
                }
            }

            else if (f.X - s.X >= 0 && f.Y - s.Y >= 0 && Math.Abs(f.Y - s.Y) >= Math.Abs(f.X - s.X))
            {
                int d = 2 * dx - dy;
                int incrS = 2 * dx;
                int incrSE = 2 * (dx - dy);
                while (y < f.Y)
                {
                    if (d < 0)
                    {
                        d += incrS;
                        y++;
                    }
                    else
                    {
                        d += incrSE;
                        x++;
                        y++;
                    }
                    e.Graphics.FillRectangle(brush, x, y, 1, 1);
                }
            }

            else if (f.X - s.X < 0 && f.Y - s.Y >= 0 && Math.Abs(f.Y - s.Y) >= Math.Abs(f.X - s.X))
            {
                int d = -(2 * dx + dy);
                int incrS = -2 * dx;
                int incrSW = -2 * (dx + dy);
                while (y < f.Y)
                {
                    if (d < 0)
                    {
                        d += incrS;
                        y++;
                    }
                    else
                    {
                        d += incrSW;
                        x--;
                        y++;
                    }
                    e.Graphics.FillRectangle(brush, x, y, 1, 1);
                }
            }

            else if (f.X - s.X < 0 && f.Y - s.Y >= 0 && Math.Abs(f.Y - s.Y) < Math.Abs(f.X - s.X))
            {
                int d = 2 * dy + dx;
                int incrW = 2 * dy;
                int incrSW = 2 * (dy + dx);
                while (x > f.X)
                {
                    if (d < 0)
                    {
                        d += incrW;
                        x--;
                    }
                    else
                    {
                        d += incrSW;
                        x--;
                        y++;
                    }
                    e.Graphics.FillRectangle(brush, x, y, 1, 1);
                }
            }

            else if (f.X - s.X < 0 && f.Y - s.Y < 0 && Math.Abs(f.Y - s.Y) < Math.Abs(f.X - s.X))
            {
                int d = 2 * (-dy) + dx;
                int incrW = 2 * (-dy);
                int incrNW = 2 * (-dy + dx);
                while (x > f.X)
                {
                    if (d < 0)
                    {
                        d += incrW;
                        x--;
                    }
                    else
                    {
                        d += incrNW;
                        x--;
                        y--;
                    }
                    e.Graphics.FillRectangle(brush, x, y, 1, 1);
                }
            }

            else if (f.X - s.X < 0 && f.Y - s.Y < 0 && Math.Abs(f.Y - s.Y) >= Math.Abs(f.X - s.X))
            {
                int d = -(2 * dx - dy);
                int incrN = -2 * dx;
                int incrNW = -2 * (dx - dy);
                while (y > f.Y)
                {
                    if (d < 0)
                    {
                        d += incrN;
                        y--;
                    }
                    else
                    {
                        d += incrNW;
                        x--;
                        y--;
                    }
                    e.Graphics.FillRectangle(brush, x, y, 1, 1);
                }
            }

            else if (f.X - s.X >= 0 && f.Y - s.Y < 0 && Math.Abs(f.Y - s.Y) >= Math.Abs(f.X - s.X))
            {
                int d = 2 * dx + dy;
                int incrN = 2 * dx;
                int incrNE = 2 * (dx + dy);
                while (y > f.Y)
                {
                    if (d < 0)
                    {
                        d += incrN;
                        y--;
                    }
                    else
                    {
                        d += incrNE;
                        x++;
                        y--;
                    }
                    e.Graphics.FillRectangle(brush, x, y, 1, 1);
                }
            }

            else if (f.X - s.X >= 0 && f.Y - s.Y < 0 && Math.Abs(f.Y - s.Y) < Math.Abs(f.X - s.X))
            {
                int d = -(2 * dy + dx);
                int incrE = -2 * dy;
                int incrNE = -2 * (dx + dy);
                while (x < f.X)
                {
                    if (d < 0)
                    {
                        d += incrE;
                        x++;
                    }
                    else
                    {
                        d += incrNE;
                        x++;
                        y--;
                    }
                    e.Graphics.FillRectangle(brush, x, y, 1, 1);
                }
            }
        }
    }
}
