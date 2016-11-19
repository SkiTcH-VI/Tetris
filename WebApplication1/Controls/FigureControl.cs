using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public class FigureControl
    {
        public Table FigureShow;
        public Table GameField;
        public Label Label1;

        GameControl gControl = new GameControl();
        public void Show(Figure x)
        {
            for (int i = 0; i < x.rects.Count; i++)
            {
                GameField.Rows[x.coord[i].Y].Cells[x.coord[i].X].BackColor = x.color;
            }
        }
        public void Hide(Figure x)
        {
            for (int i = 0; i < x.rects.Count; i++)
            {
                GameField.Rows[x.coord[i].Y].Cells[x.coord[i].X].BackColor = Color.White;
            }
        }
        public void Move(int x, Figure f)
        {
            if (1 <= x && x <= 3 && CheckFigure(x, f))
            {
                AddRectangle(f);
                Hide(f);
                f.MoveBlock(x);
                Show(f);
                RemoveRectangle(f);
            }
            else if (x == 4 && CheckFigure(x, f))
            {
                AddRectangle(f);
                Hide(f);
                f.TurnBlock();
                Show(f);
                RemoveRectangle(f);
            }

            for (int i = 0; i < 10; i++)
            {
                //MessageBox.Show(coordsY[i].FindAll(y => y.Equals(true)).Count.ToString());
            }
        }
        public void AddRectangle(Figure f)
        {
            for (int i = 0; i < f.rects.Count; i++)
            {
                //MessageBox.Show(String.Format("{0}, {1} : {2} ", (int)figures[figures.Count - 1].coord[i].Y, (int)figures[figures.Count - 1].coord[i].X, coordsY[(int)figures[figures.Count - 1].coord[i].Y][(int)figures[figures.Count - 1].coord[i].X].ToString()));
                VariableData.coords[(int)f.coord[i].Y].RemoveAt((int)f.coord[i].X);
                VariableData.coords[(int)f.coord[i].Y].Insert((int)f.coord[i].X, null);
                //MessageBox.Show(String.Format("{0}, {1} : {2} ", (int)figures[figures.Count - 1].coord[i].Y, (int)figures[figures.Count - 1].coord[i].X, coordsY[(int)figures[figures.Count - 1].coord[i].Y][(int)figures[figures.Count - 1].coord[i].X].ToString()));
            }
        }
        public void RemoveRectangle(Figure f)
        {
            for (int i = 0; i < f.rects.Count; i++)
            {
                //MessageBox.Show(String.Format("{0}, {1} : {2} ", (int)figures[figures.Count - 1].coord[i].Y, (int)figures[figures.Count - 1].coord[i].X, coordsY[(int)figures[figures.Count - 1].coord[i].Y][(int)figures[figures.Count - 1].coord[i].X].ToString()));
                VariableData.coords[(int)f.coord[i].Y].RemoveAt((int)f.coord[i].X);
                VariableData.coords[(int)f.coord[i].Y].Insert((int)f.coord[i].X, f.id);
                //MessageBox.Show(String.Format("{0}, {1} : {2} ", (int)figures[figures.Count - 1].coord[i].Y, (int)figures[figures.Count - 1].coord[i].X, coordsY[(int)figures[figures.Count - 1].coord[i].Y][(int)figures[figures.Count - 1].coord[i].X].ToString()));
            }
        }
        public bool CheckFigure(int p, Figure f)
        {
            int i = 0;
            foreach (Point c in VariableData.figures[VariableData.figures.Count - 1].coord)
            {
                if (p == 3)
                {
                    if (c.Y >= 24)
                    {
                        gControl.CheckGame();
                        return false;
                    }
                    else if (CheckDown(p, i, f))
                    {
                        gControl.CheckGame();
                        return false;
                    }
                }
                else if (p == 1)
                {
                    if (c.X >= 14)
                    {
                        return false;
                    }
                    else if (CheckDown(p, i, f))
                    {
                        return false;
                    }
                }
                else if (p == 2)
                {
                    if (c.X <= 0)
                        return false;
                    else if (CheckDown(p, i, f))
                    {
                        return false;
                    }
                }
                else if (p == 4)
                {

                    if (c.Y < 0 || CheckDown(1, i, f) || CheckDown(2, i, f) || CheckDown(3, i, f))
                        return false;
                }
                i++;
            }
            return true;
        }
        public bool CheckDown(int p, int i, Figure f)
        {
            if (p == 2 && (f.coord[i].X - 1) >= 0)
            {
                if (VariableData.coords[(int)f.coord[i].Y][(int)f.coord[i].X - 1] == null || VariableData.coords[(int)f.coord[i].Y][(int)f.coord[i].X - 1] == VariableData.figures[VariableData.figures.Count - 1].id)
                {
                    return false;
                }
            }
            else if (p == 1 && VariableData.coords[(int)f.coord[i].Y].Count > ((int)f.coord[i].X + 1))
            {
                if (VariableData.coords[(int)f.coord[i].Y][(int)f.coord[i].X + 1] == null || VariableData.coords[(int)f.coord[i].Y][(int)f.coord[i].X + 1] == f.id)
                {
                    return false;
                }
            }
            else if (p == 3 && VariableData.coords.Count > ((int)f.coord[i].Y + 1))
            {
                if (VariableData.coords[(int)f.coord[i].Y + 1][(int)f.coord[i].X] == null || VariableData.coords[(int)f.coord[i].Y + 1][(int)f.coord[i].X] == f.id)
                {
                    return false;
                }
            }
            //if (p == 4)
            //{
            //    if (coords[(int)figures[figures.Count - 1].coord[i].Y - 1][(int)figures[figures.Count - 1].coord[i].X] == null || coords[(int)figures[figures.Count - 1].coord[i].Y - 1][(int)figures[figures.Count - 1].coord[i].X] == figures[figures.Count - 1].id)
            //    {
            //        return false;
            //    }
            //}
            return true;
        }
        public void CreateFigure()
        {
            Figure s = new Figure();
            Figure n = new Figure();
            VariableData.figures.Add(s);
            if (VariableData.figures.Count > 1)
            {
                for (int i = 0; i < VariableData.figures[VariableData.figures.Count - 2].rects.Count; i++)
                {
                    FigureShow.Rows[VariableData.figures[VariableData.figures.Count - 2].coord[i].Y].Cells[VariableData.figures[VariableData.figures.Count - 2].coord[i].X].BackColor = Color.White;
                }
            }
            for (int i = 0; i < s.rects.Count; i++)
            {
                FigureShow.Rows[n.coord[i].Y].Cells[n.coord[i].X].BackColor = n.color;
            }
            Random rand = new Random();
            int answer = rand.Next(0, 11);
            for (int i = 0; i < VariableData.figures[VariableData.figures.Count - 1].rects.Count; i++)
            {
                VariableData.figures[VariableData.figures.Count - 1].coord[i] = new Point(VariableData.figures[VariableData.figures.Count - 1].coord[i].X + answer, VariableData.figures[VariableData.figures.Count - 1].coord[i].Y);
            }
        }
        public void DestroyFigure()
        {
            int find;
            for (int i = 0; i < 25; i++)
            {
                //MessageBox.Show(coords[i].FindAll(x => x.Equals(true)).Count.ToString());
                if (VariableData.coords[i].FindAll(x => x != null).Count == 15)
                {
                    find = i;
                    for (int t = 0; t < 15; t++)
                    {
                        for (int r = 0; r < VariableData.figures.Count; r++)
                        {
                            for (int j = 0; j < VariableData.figures[r].rects.Count; j++)
                            {
                                if (i == VariableData.figures[r].coord[j].Y && t == VariableData.figures[r].coord[j].X)
                                {
                                    GameField.Rows[VariableData.figures[r].coord[j].Y].Cells[VariableData.figures[r].coord[j].X].BackColor = Color.White;
                                    VariableData.figures[r].rects.RemoveAt(j);
                                    VariableData.figures[r].coord.RemoveAt(j);
                                }
                            }
                        }
                    }
                    for (int r = 0; r < VariableData.figures.Count; r++)
                    {
                        for (int j = 0; j < VariableData.figures[r].rects.Count; j++)
                        {
                            if (VariableData.figures[r].coord[j].Y != find)
                            {
                                Hide(VariableData.figures[r]);
                                VariableData.figures[r].coord[j] = new Point(VariableData.figures[r].coord[j].X, VariableData.figures[r].coord[j].Y + 1);
                                Show(VariableData.figures[r]);
                                if (VariableData.figures[r].coord.Count == 0)
                                {
                                    VariableData.figures.RemoveAt(r);
                                }
                            }
                        }
                    }
                    VariableData.coords.RemoveAt(i);
                    List<string> cord = new List<string>();
                    for (int y = 0; y < 15; y++)
                    {
                        cord.Add(null);
                    }
                    VariableData.coords.Insert(0, cord);
                    for (int k = 0; k < VariableData.figures.Count; k++)
                    {
                        Hide(VariableData.figures[k]);
                        Show(VariableData.figures[k]);
                    }
                    VariableData.points += 100;
                    Label1.Text = VariableData.points.ToString();
                    if (VariableData.speed > 0.10)
                    {
                        VariableData.speed -= 50;
                    }
                    gControl.CheckGame();
                    for (int r = 0; r < VariableData.figures.Count; r++)
                    {
                        gControl.Fall(r);
                    }
                }
            }
        }
        public bool MoveDown(Figure f)
        {
            bool s = false;
            for (int i = 0; i < f.coord.Count; i++)
            {
                if (f.coord[i].Y != 24 && CheckDown(3, i, f) == false && i == (f.coord.Count - 1))
                {
                    AddRectangle(f);
                    Hide(f);
                    f.MoveBlock(3);
                    Show(f);
                    RemoveRectangle(f);
                    s = true;
                    return s;
                }
            }
            return s;
        }
    }
}