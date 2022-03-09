using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projekt1.Relations;

namespace projekt1
{
    public partial class Form1 : Form
    {
        List<Polygon> polygons = new List<Polygon>();
        int whichButton = 0;
        bool isEditedP = false;
        bool isEditedC = false;
        (int, int) chosenVertex = (-1, -1); //pierwszy int to index w polygons
        (int, int) chosenEdge = (-1, -1); // pierwszy int to index w polygons
        int chosenPolygon = -1;
        List<Circle> circles = new List<Circle>();
        (int, int) chosenCircle = (-1, -1); //drugi int to 0 - wybrana całość, 1 - środek, 2 - brzeg
        Point editedVertex;
        List<IRelation> relations = new List<IRelation>();
        bool isVertexMoving = false;
        bool isEdgeMoving = false;
        Edge editedEdge;
        Polygon beforeMovingPolygon;
        Circle editedCircle;
        bool isCircleMoving;
        bool isRadiusChanging;
        Circle beforeMovingCircle = new Circle();
        Point movingPoint;
        bool is_ELR_BeingAdded = false;
        Edge first_ELR_Edge;
        bool is_PR_BeingAdded = false;
        Edge first_PR_Edge;
        bool isPolygonMoving = false;
        Polygon editedPolygon;
        bool is_MR_BeingAdded = false;
        bool isPolygonFirstInMR = false;
        Edge MR_Edge;
        Polygon MR_Polygon;
        Circle MR_Circle;
        Polygon relationPolygon;

        public Form1()
        {
            InitializeComponent();
            Polygon p = new Polygon();
            p.vertices.Add(new Point(400, 100));
            p.vertices.Add(new Point(600, 200));
            p.vertices.Add(new Point(650, 400));
            p.vertices.Add(new Point(550, 600));
            p.vertices.Add(new Point(350, 650));
            p.vertices.Add(new Point(200, 550));
            p.vertices.Add(new Point(100, 300));
            p.vertices.Add(new Point(150, 200));
            p.vertices.Add(new Point(350, 100));
            polygons.Add(p);
            Polygon r = new Polygon();
            r.vertices.Add(new Point(200, 200));
            r.vertices.Add(new Point(300, 400));
            r.vertices.Add(new Point(300, 180));
            polygons.Add(r);
            Circle c = new Circle(new Point(475, 325), 100);
            circles.Add(c);
            Circle s = new Circle(new Point(800, 400), 200);
            circles.Add(s);
            relations.Add(new MixedRelation(p, p.vertices[1], p.vertices[2], c, true));
            relations.Add(new FixedLenghtRelation(p, p.vertices[3], p.vertices[4]));
            relations.Add(new FixedRadiusRelation(s));
        }

        private void canva_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < polygons.Count; i++)
            {
                if (chosenPolygon == i) polygons[i].DrawBresenham(e, new Pen(Color.Red), new SolidBrush(Color.Red));
                else polygons[i].Draw(e);
                for (int j = 0; j < polygons[i].vertices.Count; j++)
                {
                    for (int r = 0; r < relations.Count; r++)
                    {
                        if (relations[r].IsThisEdgeMine(polygons[i].vertices[j],
                            polygons[i].vertices[(j + 1) % polygons[i].vertices.Count]))
                        {
                            if (relations[r].GetName() == "Ustalona długość krawędzi")
                            {
                                e.Graphics.DrawLine(new Pen(Color.Blue, 2),
                                    new System.Drawing.Point(polygons[i].vertices[j].X, polygons[i].vertices[j].Y),
                                    new System.Drawing.Point(polygons[i].vertices[(j + 1) % polygons[i].vertices.Count].X,
                                polygons[i].vertices[(j + 1) % polygons[i].vertices.Count].Y));
                            }
                            else if (relations[r].GetName() == "Równa długość dwóch krawędzi")
                            {
                                e.Graphics.DrawLine(new Pen(Color.DarkViolet, 2),
                                    new System.Drawing.Point(polygons[i].vertices[j].X, polygons[i].vertices[j].Y),
                                    new System.Drawing.Point(polygons[i].vertices[(j + 1) % polygons[i].vertices.Count].X,
                                polygons[i].vertices[(j + 1) % polygons[i].vertices.Count].Y));
                            }
                            else if (relations[r].GetName() == "Równoległość dwóch krawędzi")
                            {
                                e.Graphics.DrawLine(new Pen(Color.DarkRed, 2),
                                    new System.Drawing.Point(polygons[i].vertices[j].X, polygons[i].vertices[j].Y),
                                    new System.Drawing.Point(polygons[i].vertices[(j + 1) % polygons[i].vertices.Count].X,
                                polygons[i].vertices[(j + 1) % polygons[i].vertices.Count].Y));
                            }
                            else if (relations[r].GetName() == "Styczność krawędzi i okręgu")
                            {
                                e.Graphics.DrawLine(new Pen(Color.DarkGreen, 2),
                                    new System.Drawing.Point(polygons[i].vertices[j].X, polygons[i].vertices[j].Y),
                                    new System.Drawing.Point(polygons[i].vertices[(j + 1) % polygons[i].vertices.Count].X,
                                polygons[i].vertices[(j + 1) % polygons[i].vertices.Count].Y));
                            }
                        }
                    }
                }
            }
            if (chosenVertex.Item1 > -1 && chosenVertex.Item2 > -1)
            {
                Brush brush = new SolidBrush(Color.Red);
                e.Graphics.FillEllipse(brush, polygons[chosenVertex.Item1].vertices[chosenVertex.Item2].X - 4, 
                    polygons[chosenVertex.Item1].vertices[chosenVertex.Item2].Y - 4, 8, 8);
            }
            if (chosenEdge.Item1 > -1 && chosenEdge.Item2 > -1)
            {
                Pen pen = new Pen(Color.Red, 2);
                int idxp = chosenEdge.Item1;
                int idxv = chosenEdge.Item2;
                e.Graphics.DrawLine(pen,
                    new System.Drawing.Point(polygons[idxp].vertices[idxv].X, polygons[idxp].vertices[idxv].Y),
                    new System.Drawing.Point(polygons[idxp].vertices[(idxv + 1) % polygons[idxp].vertices.Count].X,
                    polygons[idxp].vertices[(idxv + 1) % polygons[idxp].vertices.Count].Y));
            }
            for (int i = 0; i < circles.Count; i++)
            {
                if (chosenCircle == (i, 0)) circles[i].Draw(e, new Pen(Color.Red), new SolidBrush(Color.Red));
                else if (chosenCircle == (i, 1)) circles[i].Draw(e, new Pen(Color.Black), new SolidBrush(Color.Red));
                else if (chosenCircle == (i, 2)) circles[i].Draw(e, new Pen(Color.Red, 2));
                else circles[i].Draw(e);
                foreach(IRelation r in relations)
                {
                    if (r.IsThisCircleCenterMine(circles[i]))
                    {
                        Brush brush = new SolidBrush(Color.Blue);
                        e.Graphics.FillEllipse(brush, circles[i].S.X - 4, circles[i].S.Y - 4, 8, 8);
                    }
                    if (r.IsThisCircleEdgeMine(circles[i]))
                    {
                        circles[i].Draw(e, new Pen(Color.Blue, 2));
                        e.Graphics.DrawEllipse(new Pen(Color.Blue, 2), circles[i].S.X - circles[i].radius,
                            circles[i].S.Y - circles[i].radius, 2 * circles[i].radius, 2 * circles[i].radius);
                    }
                    if (r.IsThisCircleMine(circles[i]) && r.GetName() == "Styczność krawędzi i okręgu")
                    {
                        circles[i].Draw(e, new Pen(Color.DarkGreen, 2));
                        e.Graphics.DrawEllipse(new Pen(Color.DarkGreen, 2), circles[i].S.X - circles[i].radius,
                            circles[i].S.Y - circles[i].radius, 2 * circles[i].radius, 2 * circles[i].radius);
                    }
                }
            }
        }

        private void buttonDodajWielokat_Click(object sender, EventArgs e)
        {
            buttonStop_Click(sender, e);
            whichButton = 1;
        }

        private void buttonDodajOkrag_Click(object sender, EventArgs e)
        {
            buttonStop_Click(sender, e);
            whichButton = 3;
        }

        private void buttonUsun_Click(object sender, EventArgs e)
        {
            buttonStop_Click(sender, e);
            whichButton = 2;
        }

        private void buttonZablokujDlugosc_Click(object sender, EventArgs e)
        {
            buttonStop_Click(sender, e);
            whichButton = 4;
        }

        private void buttonZablokujSrodekOkregu_Click(object sender, EventArgs e)
        {
            buttonStop_Click(sender, e);
            whichButton = 5;
        }

        private void buttonZablokujPromienOkregu_Click(object sender, EventArgs e)
        {
            buttonStop_Click(sender, e);
            whichButton = 6;
        }

        private void buttonWyrownajDwieKrawedzie_Click(object sender, EventArgs e)
        {
            buttonStop_Click(sender, e);
            whichButton = 7;
        }

        private void buttonDodajRownolegloscDwochKrawedzi_Click(object sender, EventArgs e)
        {
            buttonStop_Click(sender, e);
            whichButton = 8;
        }

        private void buttonDodajWierzcholek_Click(object sender, EventArgs e)
        {
            buttonStop_Click(sender, e);
            whichButton = 9;
        }

        private void buttonUsunWierzcholek_Click(object sender, EventArgs e)
        {
            buttonStop_Click(sender, e);
            whichButton = 10;
        }

        private void buttonPrzesunWielokat_Click(object sender, EventArgs e)
        {
            buttonStop_Click(sender, e);
            whichButton = 11;
        }

        private void buttonDodajRelacjeStycznosci_Click(object sender, EventArgs e)
        {
            buttonStop_Click(sender, e);
            whichButton = 12;
        }

        private void buttonUsunRelacje_Click(object sender, EventArgs e)
        {
            buttonStop_Click(sender, e);
            whichButton = 13;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (isVertexMoving)
            {
                isVertexMoving = false;
                int idx = chosenVertex.Item1;
                for (int i = 0; i < polygons[idx].vertices.Count; i++) 
                {
                    polygons[idx].vertices[i].X = beforeMovingPolygon.vertices[i].X;
                    polygons[idx].vertices[i].Y = beforeMovingPolygon.vertices[i].Y;
                }
                Refresh();
                return;
            }
            if (isCircleMoving)
            {
                isCircleMoving = false;
                editedCircle.S.X = beforeMovingCircle.S.X;
                editedCircle.S.Y = beforeMovingCircle.S.Y;
                Refresh();
                return;
            }
            if (isRadiusChanging)
            {
                isRadiusChanging = false;
                editedCircle.radius = beforeMovingCircle.radius;
                Refresh();
                return;
            }
            if (isEdgeMoving)
            {
                isEdgeMoving = false;
                int idx = chosenEdge.Item1;
                for (int i = 0; i < polygons[idx].vertices.Count; i++)
                {
                    polygons[idx].vertices[i].X = beforeMovingPolygon.vertices[i].X;
                    polygons[idx].vertices[i].Y = beforeMovingPolygon.vertices[i].Y;
                }
                Refresh();
                return;
            }
            if (is_ELR_BeingAdded)
            {
                is_ELR_BeingAdded = false;
                first_ELR_Edge = null;
            }
            if (is_PR_BeingAdded)
            {
                is_PR_BeingAdded = false;
                first_ELR_Edge = null;
            }
            if (isPolygonMoving)
            {
                isPolygonMoving = false;
                for (int i = 0; i < editedPolygon.vertices.Count; i++)
                {
                    editedPolygon.vertices[i].X = beforeMovingPolygon.vertices[i].X;
                    editedPolygon.vertices[i].Y = beforeMovingPolygon.vertices[i].Y;
                }
                Refresh();
                return;
            }
            if (is_MR_BeingAdded)
            {
                is_MR_BeingAdded = false;
                DialogResult res = MessageBox.Show("Nie dodano relacji.",
                    "Przerwałeś.", MessageBoxButtons.OK);
            }

            chosenPolygon = -1;
            chosenVertex = (-1, -1);
            chosenEdge = (-1, -1);
            chosenCircle = (-1, -1);

            if (whichButton == 1 && isEditedP)
            {
                isEditedP = false;
                if (polygons.Count > 0 && polygons[polygons.Count - 1].vertices.Count > 0)
                {
                    polygons[polygons.Count - 1].vertices.RemoveAt(polygons[polygons.Count - 1].vertices.Count - 1);
                }
                editedVertex = null;
                if (polygons.Count > 0 && polygons[polygons.Count - 1].vertices.Count < 3)
                {
                    DialogResult res = MessageBox.Show("Nie utworzono wielokąta, zbyt mało wierzchołków.",
                        "Wielokąt to co najmniej trójkąt.", MessageBoxButtons.OK);
                    polygons.RemoveAt(polygons.Count - 1);
                }
            }
            else if (whichButton == 3)
            {
                if (isEditedC)
                {
                    DialogResult res = MessageBox.Show("Nie utworzono okręgu, nie ustalono promienia.",
                        "Na przyszłość zaznacz promień.", MessageBoxButtons.OK);
                    circles.RemoveAt(circles.Count - 1);
                    isEditedC = false;
                }
            }
            whichButton = 0;
            Refresh();
        }

        private void canva_MouseClick(object sender, MouseEventArgs e)
        {
            if (isVertexMoving)
            {
                isVertexMoving = false;
                chosenVertex = (-1, -1);
                Refresh();
                return;
            }
            if (isCircleMoving)
            {
                isCircleMoving = false;
                chosenCircle = (-1, -1);
                Refresh();
                return;
            }
            if (isRadiusChanging)
            {
                isRadiusChanging = false;
                foreach (IRelation r in relations)
                {
                    if (r.IsThisCircleMine(editedCircle)) r.ForMixedRelation(true);
                }
                chosenCircle = (-1, -1);
                Refresh();
                return;
            }
            if (isEdgeMoving)
            {
                isEdgeMoving = false;
                chosenEdge = (-1, -1);
                Refresh();
                return;
            }
            if (isPolygonMoving)
            {
                isPolygonMoving = false;
                chosenPolygon = -1;
                Refresh();
                return;
            }

            if (whichButton == 1) //dodawanie wielokata
            {
                if (!isEditedP)
                {
                    Polygon p = new Polygon();
                    p.Add(new Point(e.X, e.Y));
                    polygons.Add(p);
                    isEditedP = true;
                    polygons[polygons.Count - 1].Add(new Point(e.X, e.Y));
                    editedVertex = polygons[polygons.Count - 1].vertices[polygons[polygons.Count - 1].vertices.Count - 1];
                }
                else
                {
                    polygons[polygons.Count - 1].Add(new Point(e.X, e.Y));
                    editedVertex = polygons[polygons.Count - 1].vertices[polygons[polygons.Count - 1].vertices.Count - 1];
                }
            }

            else if (whichButton == 2) //usuwanie figury
            {
                bool ifCircles = true;
                for (int i = 0; i < polygons.Count; i++)
                {
                    if (polygons[i].IsItMe(e.X, e.Y))
                    {
                        if (chosenPolygon == i)
                        {
                            if (polygons[i].vertices.Count == 3)
                            {
                                DialogResult res = MessageBox.Show("Nie usunięto wierzchołka.",
                                    "Ten wielokąt już jest trójkątem.", MessageBoxButtons.OK);
                                break;
                            }
                            bool end = true;
                            while (end)
                            {
                                end = false;
                                foreach (IRelation r in relations)
                                {
                                    if (r.IsThisPolygonMine(polygons[i]))
                                    {
                                        end = true;
                                        relations.Remove(r);
                                        break;
                                    }
                                }
                            }
                            polygons.RemoveAt(i);
                            chosenPolygon = -1;
                        }
                        else
                        {
                            chosenPolygon = i;
                            chosenCircle = (-1, 0);
                        }
                        chosenEdge = (-1, -1);
                        chosenVertex = (-1, -1);
                        ifCircles = false;
                        break;
                    }
                }
                if (ifCircles)
                {
                    for (int i = 0; i < circles.Count; i++)
                    {
                        if (circles[i].IsItMe(e.X, e.Y))
                        {
                            if (chosenCircle == (i, 0))
                            {
                                circles.RemoveAt(i);
                                chosenCircle = (-1, -1);
                            }
                            else
                            {
                                chosenCircle = (i, 0);
                                chosenPolygon = -1;
                            }
                            break;
                        }
                    }
                }
            }

            else if (whichButton == 3) //dodawanie okregu
            {
                if (!isEditedC)
                {
                    Circle c = new Circle(new Point(e.X, e.Y));
                    circles.Add(c);
                    isEditedC = true;
                }
                else
                {
                    int idx = circles.Count - 1;
                    int r2 = (circles[idx].S.X - e.X) * (circles[idx].S.X - e.X) + (circles[idx].S.Y - e.Y) * (circles[idx].S.Y - e.Y);
                    int r = (int)(Math.Sqrt(r2));
                    circles[idx].radius = r;
                    isEditedC = false;
                }
            }

            else if (whichButton == 4) //zablokowanie dlugosci krawedzi
            {
                for (int i = 0; i < polygons.Count; i++)
                {
                    var (ifIs, which) = polygons[i].IsItMyEdge(e.X, e.Y);
                    if (ifIs)
                    {
                        bool iff = true;
                        foreach (IRelation r in relations)
                        {
                            if (r.IsThisEdgeMine(polygons[i].vertices[which],
                                polygons[i].vertices[(which + 1) % polygons[i].vertices.Count]))
                            {
                                DialogResult res = MessageBox.Show("Ta krawędź ma już relację.",
                                    "Nie dodano relacji.", MessageBoxButtons.OK);
                                iff = false;
                                break;
                            }
                        }
                        if (iff)
                        {
                            relations.Add(new FixedLenghtRelation(polygons[i], polygons[i].vertices[which],
                                polygons[i].vertices[(which + 1) % polygons[i].vertices.Count]));
                            break;
                        }
                    }
                }
            }

            else if (whichButton == 5) //zablokowanie srodka okregu
            {
                for (int i = 0; i < circles.Count; i++)
                {
                    if (circles[i].IsItMyCenter(e.X, e.Y))
                    {
                        bool iff = true;
                        foreach (IRelation r in relations)
                        {
                            if (r.IsThisCircleMine(circles[i]) && r.GetName() != "Styczność krawędzi i okręgu")
                            {
                                DialogResult res = MessageBox.Show("Ten okrąg ma już relację.",
                                    "Nie dodano relacji.", MessageBoxButtons.OK);
                                iff = false;
                                break;
                            }
                        }
                        if (iff)
                        {
                            relations.Add(new FixedCenterRelation(circles[i]));
                            break;
                        }
                    }
                }
            }

            else if (whichButton == 6) //zablokowanie promienia okregu
            {
                for (int i = 0; i < circles.Count; i++)
                {
                    if (circles[i].IsItMe(e.X, e.Y))
                    {
                        bool iff = true;
                        foreach (IRelation r in relations)
                        {
                            if (r.IsThisCircleMine(circles[i]) && r.GetName() != "Styczność krawędzi i okręgu")
                            {
                                DialogResult res = MessageBox.Show("Ten okrąg ma już relację.",
                                    "Nie dodano relacji.", MessageBoxButtons.OK);
                                iff = false;
                                break;
                            }
                        }
                        if (iff)
                        {
                            relations.Add(new FixedRadiusRelation(circles[i]));
                            foreach (IRelation r in relations)
                            {
                                if (r.IsThisCircleMine(circles[i]) && r.GetName() == "Styczność krawędzi i okręgu")
                                {
                                    r.ForMixedRelation(false);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }

            else if (whichButton == 7) //wyrownanie dlugosci dwoch krawedzi
            {
                for (int i = 0; i < polygons.Count; i++)
                {
                    var (ifIs, which) = polygons[i].IsItMyEdge(e.X, e.Y);
                    if (ifIs)
                    {
                        if (is_ELR_BeingAdded)
                        {
                            if (relationPolygon != polygons[i])
                            {
                                DialogResult res = MessageBox.Show("Wybierz inną krawędź.",
                                    "Ta relacja dotyczy innego wielokąta.", MessageBoxButtons.OK);
                                break;
                            }
                            if (first_ELR_Edge.S == polygons[i].vertices[which] &&
                                first_ELR_Edge.F == polygons[i].vertices[(which + 1) % polygons[i].vertices.Count])
                                break;
                            bool iff = true;
                            foreach (IRelation r in relations)
                            {
                                if (r.IsThisEdgeMine(polygons[i].vertices[which],
                                    polygons[i].vertices[(which + 1) % polygons[i].vertices.Count]))
                                {
                                    DialogResult res = MessageBox.Show("Ta krawędź ma już relację.",
                                        "Nie dodano relacji.", MessageBoxButtons.OK);
                                    is_ELR_BeingAdded = false;
                                    first_ELR_Edge = null;
                                    iff = false;
                                    break;
                                }
                            }
                            if (iff)
                            {
                                relations.Add(new EqualLengthsRelation(polygons[i], first_ELR_Edge.S, first_ELR_Edge.F,
                                    polygons[i].vertices[which], polygons[i].vertices[(which + 1) % polygons[i].vertices.Count]));
                                is_ELR_BeingAdded = false;
                                first_ELR_Edge = null;
                                break;
                            }
                        }
                        else
                        {
                            bool iff = true;
                            foreach (IRelation r in relations)
                            {
                                if (r.IsThisEdgeMine(polygons[i].vertices[which],
                                    polygons[i].vertices[(which + 1) % polygons[i].vertices.Count]))
                                {
                                    DialogResult res = MessageBox.Show("Ta krawędź ma już relację.",
                                        "Nie dodano relacji.", MessageBoxButtons.OK);
                                    iff = false;
                                    break;
                                }
                            }
                            if (iff)
                            {
                                is_ELR_BeingAdded = true;
                                relationPolygon = polygons[i];
                                first_ELR_Edge = new Edge(polygons[i].vertices[which],
                                    polygons[i].vertices[(which + 1) % polygons[i].vertices.Count]);
                                break;
                            }
                        }
                    }
                }
            }

            else if (whichButton == 8) //wymuszenie rownoleglosci dwoch krawedzi
            {
                for (int i = 0; i < polygons.Count; i++)
                {
                    var (ifIs, which) = polygons[i].IsItMyEdge(e.X, e.Y);
                    if (ifIs)
                    {
                        if (is_PR_BeingAdded)
                        {
                            if (relationPolygon != polygons[i])
                            {
                                DialogResult res = MessageBox.Show("Wybierz inną krawędź.",
                                    "Ta relacja dotyczy innego wielokąta.", MessageBoxButtons.OK);
                                break;
                            }
                            if (first_PR_Edge.S == polygons[i].vertices[which] &&
                                first_PR_Edge.F == polygons[i].vertices[(which + 1) % polygons[i].vertices.Count])
                                break;
                            bool iff = true;
                            foreach (IRelation r in relations)
                            {
                                if (r.IsThisEdgeMine(polygons[i].vertices[which],
                                    polygons[i].vertices[(which + 1) % polygons[i].vertices.Count]))
                                {
                                    DialogResult res = MessageBox.Show("Ta krawędź ma już relację.",
                                        "Nie dodano relacji.", MessageBoxButtons.OK);
                                    is_PR_BeingAdded = false;
                                    first_PR_Edge = null;
                                    iff = false;
                                    break;
                                }
                            }
                            if (iff)
                            {
                                relations.Add(new ParallelRelation(polygons[i], first_PR_Edge.S, first_PR_Edge.F,
                                    polygons[i].vertices[which], polygons[i].vertices[(which + 1) % polygons[i].vertices.Count]));
                                is_PR_BeingAdded = false;
                                first_PR_Edge = null;
                                break;
                            }
                        }
                        else
                        {
                            bool iff = true;
                            foreach (IRelation r in relations)
                            {
                                if (r.IsThisEdgeMine(polygons[i].vertices[which],
                                    polygons[i].vertices[(which + 1) % polygons[i].vertices.Count]))
                                {
                                    DialogResult res = MessageBox.Show("Ta krawędź ma już relację.",
                                        "Nie dodano relacji.", MessageBoxButtons.OK);
                                    iff = false;
                                    break;
                                }
                            }
                            if (iff)
                            {
                                is_PR_BeingAdded = true;
                                relationPolygon = polygons[i];
                                first_PR_Edge = new Edge(polygons[i].vertices[which],
                                    polygons[i].vertices[(which + 1) % polygons[i].vertices.Count]);
                                break;
                            }
                        }
                    }
                }
            }

            else if (whichButton == 9) //dodanie wierzcholka
            {
                for (int i = 0; i < polygons.Count; i++)
                {
                    var (ifIs, which) = polygons[i].IsItMyEdge(e.X, e.Y);
                    if (ifIs)
                    {
                        bool end = true;
                        while (end)
                        {
                            end = false;
                            foreach (IRelation r in relations)
                            {
                                if (r.IsThisEdgeMine(polygons[i].vertices[which],
                                    polygons[i].vertices[(which + 1) % polygons[i].vertices.Count]))
                                {
                                    end = true;
                                    relations.Remove(r);
                                    break;
                                }
                            }
                        }
                        polygons[i].vertices.Insert((which + 1) % polygons[i].vertices.Count,
                            new Point(
                            (polygons[i].vertices[which].X + polygons[i].vertices[(which + 1) % polygons[i].vertices.Count].X) / 2,
                            (polygons[i].vertices[which].Y + polygons[i].vertices[(which + 1) % polygons[i].vertices.Count].Y) / 2));
                    }
                }
            }

            else if (whichButton == 10) //usuniecie wierzcholka
            {
                for (int i = 0; i < polygons.Count; i++)
                {
                    for (int j = 0; j < polygons[i].vertices.Count; j++)
                    {
                        if (polygons[i].vertices[j].IsItMe(e.X, e.Y))
                        {
                            if (chosenVertex == (i, j))
                            {
                                if (polygons[i].vertices.Count == 3)
                                {
                                    DialogResult res = MessageBox.Show("Nie usunięto wierzchołka.",
                                        "Ten wielokąt już jest trójkątem.", MessageBoxButtons.OK);
                                    chosenVertex = (-1, -1);
                                    break;
                                }
                                bool end = true;
                                while (end)
                                {
                                    end = false;
                                    foreach (IRelation r in relations)
                                    {
                                        if (r.IsThisPointMine(polygons[i].vertices[j]))
                                        {
                                            end = true;
                                            relations.Remove(r);
                                            break;
                                        }
                                    }
                                }
                                polygons[i].vertices.RemoveAt(j);
                                chosenVertex = (-1, -1);
                            }
                            else
                            {
                                chosenVertex = (i, j);
                                chosenPolygon = -1;
                                chosenCircle = (-1, 0);
                            }
                            chosenEdge = (-1, -1);
                            chosenPolygon = -1;
                            break;
                        }
                    }
                }
            }

            else if (whichButton == 12) //dodanie relacji stycznosci
            {
                bool ifCircles = true;
                for (int i = 0; i < polygons.Count; i++)
                {
                    var (ifIs, which) = polygons[i].IsItMyEdge(e.X, e.Y);
                    if (ifIs)
                    {
                        foreach (IRelation r in relations)
                        {
                            if (r.IsThisEdgeMine(polygons[i].vertices[which],
                                polygons[i].vertices[(which + 1) % polygons[i].vertices.Count]))
                            {
                                DialogResult res = MessageBox.Show("Ta krawędź ma już relację.",
                                    "Wybierz inną krawędź.", MessageBoxButtons.OK);
                                break;
                            }
                        }
                        ifCircles = false;
                        if (is_MR_BeingAdded)
                        {
                            if (isPolygonFirstInMR)
                            {
                                DialogResult res = MessageBox.Show("W tej relacji już jest wielokąt.",
                                    "Wybierz okrąg.", MessageBoxButtons.OK);
                            }
                            else
                            {
                                bool canRadiusBeChanged = true;
                                foreach (IRelation r in relations)
                                {
                                    if (r.IsThisCircleEdgeMine(MR_Circle))
                                    {
                                        canRadiusBeChanged = false;
                                        break;
                                    }
                                }
                                relations.Add(new MixedRelation(polygons[i], polygons[i].vertices[which],
                                    polygons[i].vertices[(which + 1) % polygons[i].vertices.Count], MR_Circle, canRadiusBeChanged));
                                is_MR_BeingAdded = false;
                            }
                        }
                        else
                        {
                            is_MR_BeingAdded = true;
                            isPolygonFirstInMR = true;
                            MR_Edge = new Edge(polygons[i].vertices[which],
                                polygons[i].vertices[(which + 1) % polygons[i].vertices.Count]);
                            MR_Polygon = polygons[i];
                        }
                        break;
                    }
                }
                if (ifCircles)
                {
                    for (int i = 0; i < circles.Count; i++)
                    {
                        if (circles[i].IsItMe(e.X, e.Y))
                        {
                            foreach (IRelation r in relations)
                            {
                                if (r.IsThisCircleMine(circles[i]) && r.GetName() == "Styczność krawędzi i okręgu")
                                {
                                    DialogResult res = MessageBox.Show("Ten okrąg ma już relację.",
                                        "Wybierz inny okrąg.", MessageBoxButtons.OK);
                                    break;
                                }
                            }
                            if (is_MR_BeingAdded)
                            {
                                if (!isPolygonFirstInMR)
                                {
                                    DialogResult res = MessageBox.Show("W tej relacji już jest okrąg.",
                                        "Wybierz wielokąt.", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    bool canRadiusBeChanged = true;
                                    foreach (IRelation r in relations)
                                    {
                                        if (r.IsThisCircleEdgeMine(circles[i]))
                                        {
                                            canRadiusBeChanged = false;
                                            break;
                                        }
                                    }
                                    relations.Add(new MixedRelation(MR_Polygon, MR_Edge.S,
                                        MR_Edge.F, circles[i], canRadiusBeChanged));
                                    is_MR_BeingAdded = false;
                                }
                            }
                            else
                            {
                                is_MR_BeingAdded = true;
                                isPolygonFirstInMR = false;
                                MR_Circle = circles[i];
                            }
                            break;
                        }
                    }
                }
            }

            else if (whichButton == 13) //usuniecie relacji
            {
                for (int i = 0; i < polygons.Count; i++)
                {
                    var (ifIs, which) = polygons[i].IsItMyEdge(e.X, e.Y);
                    if (ifIs)
                    {
                        foreach (IRelation r in relations)
                        {
                            if (r.IsThisEdgeMine(polygons[i].vertices[which],
                                polygons[i].vertices[(which + 1) % polygons[i].vertices.Count]))
                            {
                                relations.Remove(r);
                                break;
                            }
                        }
                        break;
                    }
                }
                for (int i = 0; i < circles.Count; i++)
                {
                    if (circles[i].IsItMe(e.X, e.Y))
                    {
                        foreach (IRelation r in relations)
                        {
                            if (r.IsThisCircleMine(circles[i]))
                            {
                                relations.Remove(r);
                                break;
                            }
                        }
                        break;
                    }
                }
            }

            else
            {
                for (int i = 0; i < polygons.Count; i++)
                {
                    for (int j = 0; j < polygons[i].vertices.Count; j++)
                    {
                        if (polygons[i].vertices[j].IsItMe(e.X, e.Y))
                        {
                            chosenVertex = (i, j);
                            chosenEdge = (-1, -1);
                            chosenCircle = (-1, -1);
                            Refresh();
                            return;
                        }
                    }
                    var (ifIs, which) = polygons[i].IsItMyEdge(e.X, e.Y);
                    if (ifIs)
                    {
                        chosenEdge = (i, which);
                        chosenVertex = (-1, -1);
                        chosenCircle = (-1, -1);
                        Refresh();
                        return;
                    }
                }
                for (int i = 0; i < circles.Count; i++)
                {
                    if (!circles[i].IsItMe(e.X, e.Y)) continue;
                    if (circles[i].IsItMyCenter(e.X, e.Y))
                    {
                        chosenCircle = (i, 1);
                        chosenEdge = (-1, -1);
                        chosenVertex = (-1, -1);
                        break;
                    }
                    else
                    {
                        chosenCircle = (i, 2);
                        chosenEdge = (-1, -1);
                        chosenVertex = (-1, -1);
                        break;
                    }
                }
            }
            Refresh();
        }

        private void canva_MouseMove(object sender, MouseEventArgs e)
        {
            if (isEditedP)
            {
                editedVertex.X = e.X;
                editedVertex.Y = e.Y;
            }
            if(isEditedC)
            {
                int idx = circles.Count - 1;
                int r2 = (circles[idx].S.X - e.X) * (circles[idx].S.X - e.X) + (circles[idx].S.Y - e.Y) * (circles[idx].S.Y - e.Y);
                int r = (int)(Math.Sqrt(r2));
                circles[idx].radius = r;
            }
            if (isVertexMoving)
            {
                editedVertex.X = e.X;
                editedVertex.Y = e.Y;
                for (int i = 0; i < relations.Count; i++)
                {
                    polygons[chosenVertex.Item1].fixedPoint1 = editedVertex;
                    polygons[chosenVertex.Item1].fixedPoint2 = editedVertex;
                    foreach (IRelation r in relations)
                    {
                        if (!r.IfIsOK()) r.ForceChange();
                    }
                }
                Refresh();
                return;
            }
            if (isCircleMoving)
            {
                editedCircle.S.X = e.X;
                editedCircle.S.Y = e.Y;
            }
            if (isRadiusChanging)
            {
                editedCircle.radius = (int)Math.Sqrt((e.X - editedCircle.S.X) * (e.X - editedCircle.S.X) +
                    (e.Y - editedCircle.S.Y) * (e.Y - editedCircle.S.Y));
            }
            if (isEdgeMoving)
            {
                editedEdge.S.X += (e.X - movingPoint.X);
                editedEdge.S.Y += (e.Y - movingPoint.Y);
                editedEdge.F.X += (e.X - movingPoint.X);
                editedEdge.F.Y += (e.Y - movingPoint.Y);
                movingPoint.X = e.X;
                movingPoint.Y = e.Y;
                polygons[chosenEdge.Item1].fixedPoint1 = polygons[chosenEdge.Item1].originalFixedPoint1;
                polygons[chosenEdge.Item1].fixedPoint2 = polygons[chosenEdge.Item1].originalFixedPoint2;
            }
            if (isPolygonMoving)
            {
                foreach (Point p in editedPolygon.vertices)
                {
                    p.X += (e.X - movingPoint.X);
                    p.Y += (e.Y - movingPoint.Y);
                }
                movingPoint.X = e.X;
                movingPoint.Y = e.Y;
            }
            for (int i = 0; i < relations.Count; i++)
            {
                foreach (IRelation r in relations)
                {
                    if (!r.IfIsOK()) r.ForceChange();
                }
            }
            Refresh();
        }

        private void canva_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (whichButton == 11)
            {
                for (int i = 0; i < polygons.Count; i++)
                {
                    if (polygons[i].IsItMe(e.X, e.Y))
                    {
                        isPolygonMoving = true;
                        movingPoint = new Point(e.X, e.Y);
                        beforeMovingPolygon = new Polygon();
                        beforeMovingPolygon.Clone(polygons[i]);
                        editedPolygon = polygons[i];
                        chosenPolygon = i;
                        chosenVertex = (-1, -1);
                        chosenEdge = (-1, -1);
                        Refresh();
                        return;
                    }
                }
            }
            if (whichButton != 2 && whichButton != 10)
            {
                for (int i = 0; i < polygons.Count; i++)
                {
                    for (int j = 0; j < polygons[i].vertices.Count; j++)
                    {
                        if (polygons[i].vertices[j].IsItMe(e.X, e.Y))
                        {
                            editedVertex = polygons[i].vertices[j];
                            beforeMovingPolygon = new Polygon();
                            beforeMovingPolygon.Clone(polygons[i]);
                            isVertexMoving = true;
                            polygons[i].fixedPoint1 = editedVertex;
                            polygons[i].fixedPoint2 = editedVertex;
                            polygons[i].originalFixedPoint1 = editedVertex;
                            polygons[i].originalFixedPoint2 = editedVertex;
                            chosenVertex = (i, j);
                            chosenEdge = (-1, -1);
                            chosenCircle = (-1, -1);
                            Refresh();
                            return;
                        }
                    }
                    var (ifIs, which) = polygons[i].IsItMyEdge(e.X, e.Y);
                    if (ifIs)
                    {
                        editedEdge = new Edge(polygons[i].vertices[which],
                            polygons[i].vertices[(which + 1) % polygons[i].vertices.Count]);
                        beforeMovingPolygon = new Polygon();
                        beforeMovingPolygon.Clone(polygons[i]);
                        isEdgeMoving = true;
                        movingPoint = new Point(e.X, e.Y);
                        polygons[i].fixedPoint1 = polygons[i].vertices[which];
                        polygons[i].fixedPoint2 = polygons[i].vertices[(which + 1) % polygons[i].vertices.Count];
                        polygons[i].originalFixedPoint1 = polygons[i].vertices[which];
                        polygons[i].originalFixedPoint2 = polygons[i].vertices[(which + 1) % polygons[i].vertices.Count];
                        chosenEdge = (i, which);
                        chosenVertex = (-1, -1);
                        chosenCircle = (-1, -1);
                        Refresh();
                        return;
                    }
                }
                for (int i = 0; i < circles.Count; i++)
                {
                    if (!circles[i].IsItMe(e.X, e.Y)) continue;
                    if (circles[i].IsItMyCenter(e.X, e.Y))
                    {
                        editedCircle = circles[i];
                        isCircleMoving = true;
                        beforeMovingCircle.Clone(editedCircle);
                        chosenCircle = (i, 1);
                        chosenEdge = (-1, -1);
                        chosenVertex = (-1, -1);
                        break;
                    }
                    else
                    {
                        editedCircle = circles[i];
                        isRadiusChanging = true;
                        foreach (IRelation r in relations)
                        {
                            if (r.IsThisCircleMine(editedCircle)) r.ForMixedRelation(false);
                        }
                        beforeMovingCircle.Clone(editedCircle);
                        chosenCircle = (i, 2);
                        chosenEdge = (-1, -1);
                        chosenVertex = (-1, -1);
                        break;
                    }
                }
            }
            else if (whichButton == 2)
            {
                bool ifCircles = true;
                for (int i = 0; i < polygons.Count; i++)
                {
                    if (polygons[i].IsItMe(e.X, e.Y))
                    {
                        bool end = true;
                        while (end)
                        {
                            end = false;
                            foreach (IRelation r in relations)
                            {
                                if (r.IsThisPolygonMine(polygons[i]))
                                {
                                    end = true;
                                    relations.Remove(r);
                                    break;
                                }
                            }
                        }
                        polygons.RemoveAt(i);
                        chosenPolygon = -1;
                        chosenEdge = (-1, -1);
                        chosenVertex = (-1, -1);
                        ifCircles = false;
                        break;
                    }
                }
                if (ifCircles) for (int i = 0; i < circles.Count; i++)
                    {
                        if (circles[i].IsItMe(e.X, e.Y))
                        {
                            bool end = true;
                            while (end)
                            {
                                end = false;
                                foreach (IRelation r in relations)
                                {
                                    if (r.IsThisCircleMine(circles[i]))
                                    {
                                        end = true;
                                        relations.Remove(r);
                                        break;
                                    }
                                }
                            }
                            circles.RemoveAt(i);
                            chosenCircle = (-1, -1);
                            break;
                        }
                    }
            }
            else if (whichButton == 10)
            {
                for (int i = 0; i < polygons.Count; i++)
                {
                    for (int j = 0; j < polygons[i].vertices.Count; j++)
                    {
                        if (polygons[i].vertices[j].IsItMe(e.X, e.Y))
                        {
                            if (polygons[i].vertices.Count == 3)
                            {
                                DialogResult res = MessageBox.Show("Nie usunięto wierzchołka.",
                                    "Ten wielokąt już jest trójkątem.", MessageBoxButtons.OK);
                                chosenVertex = (-1, -1);
                                break;
                            }
                            bool end = true;
                            while (end)
                            {
                                end = false;
                                foreach (IRelation r in relations)
                                {
                                    if (r.IsThisPointMine(polygons[i].vertices[j]))
                                    {
                                        end = true;
                                        relations.Remove(r);
                                        break;
                                    }
                                }
                            }
                            polygons[i].vertices.RemoveAt(j);
                            chosenVertex = (-1, -1);
                            chosenCircle = (-1, 0);
                            chosenEdge = (-1, -1);
                            chosenPolygon = -1;
                            break;
                        }
                    }
                }
            }
            Refresh();
        }
    }
}
