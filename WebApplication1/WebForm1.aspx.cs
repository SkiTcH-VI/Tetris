using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Compilation;
using System.Data;
using System.IO;
using System.Collections;
using System.Drawing;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 25; i++)
            {
                List<string> cord = new List<string>();
                for (int j = 0; j < 15; j++)
                {
                    cord.Add(null);
                }
                coords.Add(cord);
            }
            CreateFigure();
            Leaders();
        }
        Hashtable addresses = new Hashtable();
        public struct SaveGameData
        {
            public int points;
            public double speed;
            public List<List<string>> coords;
            public List<Figure> figures;
        }
        public bool pause = false;
        int points = 0;
        int speed = 1000;
        List<List<string>> coords = new List<List<string>>();
        public List<Figure> figures = new List<Figure>();
        List<String> leaders;
        public class Figure
        {
            public List<bool> rects;
            public Color color;
            public List<Point> coord;
            int stage;
            int figure;
            public string id;
            public Figure()
            {
                id = RandomString();
                stage = 4;
                coord = new List<Point>();
                Random r = new Random();
                color = colors[r.Next(0, 7)];
                rects = new List<bool>();
                for (int i = 0; i < 4; i++)
                {
                    rects.Add(new bool());
                }
                figure = r.Next(1, 8);
                switch (figure)
                {
                    case 1:
                        {
                            coord.Add(new Point(0, 0));
                            coord.Add(new Point(0, 1));
                            coord.Add(new Point(1, 1));
                            coord.Add(new Point(2, 1));
                            break;
                        }
                    case 2:
                        {
                            coord.Add(new Point(0, 1));
                            coord.Add(new Point(1, 1));
                            coord.Add(new Point(2, 1));
                            coord.Add(new Point(2, 0));
                            break;
                        }
                    case 3:
                        {
                            coord.Add(new Point(0, 0));
                            coord.Add(new Point(1, 0));
                            coord.Add(new Point(1, 1));
                            coord.Add(new Point(2, 1));
                            break;
                        }
                    case 4:
                        {
                            coord.Add(new Point(0, 1));
                            coord.Add(new Point(1, 1));
                            coord.Add(new Point(1, 0));
                            coord.Add(new Point(2, 0));
                            break;
                        }
                    case 5:
                        {
                            coord.Add(new Point(0, 0));
                            coord.Add(new Point(0, 1));
                            coord.Add(new Point(1, 1));
                            coord.Add(new Point(1, 0));
                            break;
                        }
                    case 6:
                        {
                            coord.Add(new Point(0, 0));
                            coord.Add(new Point(1, 0));
                            coord.Add(new Point(1, 1));
                            coord.Add(new Point(2, 0));
                            break;
                        }
                    case 7:
                        {
                            coord.Add(new Point(0, 1));
                            coord.Add(new Point(1, 1));
                            coord.Add(new Point(2, 1));
                            coord.Add(new Point(3, 1));
                            break;
                        }
                }
            }
            public void MoveBlock(int x)
            {
                if (x == 1)
                {
                    for (int i = 0; i < coord.Count; i++)
                    {
                        coord[i] = new Point(coord[i].X + 1, coord[i].Y);
                    }
                }
                if (x == 2)
                {
                    for (int i = 0; i < coord.Count; i++)
                    {
                        coord[i] = new Point(coord[i].X - 1, coord[i].Y);
                    }
                }
                if (x == 3)
                {
                    for (int i = 0; i < coord.Count; i++)
                    {
                        coord[i] = new Point(coord[i].X, coord[i].Y + 1);
                    }
                }
            }
            public void TurnBlock()
            {
                if (figure == 1)
                {
                    if (stage == 4)
                    {
                        coord[0] = new Point(coord[0].X + 1, coord[0].Y - 1);
                        coord[1] = new Point(coord[1].X, coord[1].Y - 2);
                        coord[2] = new Point(coord[2].X - 1, coord[2].Y - 1);
                        coord[3] = new Point(coord[3].X - 2, coord[3].Y);
                        stage = 3;
                    }
                    else if (stage == 3)
                    {
                        coord[0] = new Point(coord[0].X + 1, coord[0].Y + 1);
                        coord[1] = new Point(coord[1].X + 2, coord[1].Y);
                        coord[2] = new Point(coord[2].X + 1, coord[2].Y - 1);
                        coord[3] = new Point(coord[3].X, coord[3].Y - 2);
                        stage = 2;
                    }
                    else if (stage == 2)
                    {
                        coord[0] = new Point(coord[0].X - 1, coord[0].Y + 1);
                        coord[1] = new Point(coord[1].X, coord[1].Y + 2);
                        coord[2] = new Point(coord[2].X + 1, coord[2].Y + 1);
                        coord[3] = new Point(coord[3].X + 2, coord[3].Y);
                        stage = 1;
                    }
                    else if (stage == 1)
                    {
                        coord[0] = new Point(coord[0].X - 1, coord[0].Y - 1);
                        coord[1] = new Point(coord[1].X - 2, coord[1].Y);
                        coord[2] = new Point(coord[2].X - 1, coord[2].Y + 1);
                        coord[3] = new Point(coord[3].X, coord[3].Y + 2);
                        stage = 4;
                    }
                }
                else if (figure == 2)
                {
                    if (stage == 4)
                    {
                        coord[0] = new Point(coord[0].X, coord[0].Y - 2);
                        coord[1] = new Point(coord[1].X - 1, coord[1].Y - 1);
                        coord[2] = new Point(coord[2].X - 2, coord[2].Y);
                        coord[3] = new Point(coord[3].X - 1, coord[3].Y + 1);
                        stage = 3;
                    }
                    else if (stage == 3)
                    {
                        coord[0] = new Point(coord[0].X + 2, coord[0].Y);
                        coord[1] = new Point(coord[1].X + 1, coord[1].Y - 1);
                        coord[2] = new Point(coord[2].X, coord[2].Y - 2);
                        coord[3] = new Point(coord[3].X - 1, coord[3].Y - 1);
                        stage = 2;
                    }
                    else if (stage == 2)
                    {
                        coord[0] = new Point(coord[0].X, coord[0].Y + 2);
                        coord[1] = new Point(coord[1].X + 1, coord[1].Y + 1);
                        coord[2] = new Point(coord[2].X + 2, coord[2].Y);
                        coord[3] = new Point(coord[3].X + 1, coord[3].Y - 1);
                        stage = 1;
                    }
                    else if (stage == 1)
                    {
                        coord[0] = new Point(coord[0].X - 2, coord[0].Y);
                        coord[1] = new Point(coord[1].X - 1, coord[1].Y + 1);
                        coord[2] = new Point(coord[2].X, coord[2].Y + 2);
                        coord[3] = new Point(coord[3].X + 1, coord[3].Y + 1);
                        stage = 4;
                    }
                }
                else if (figure == 3)
                {
                    if (stage == 4)
                    {
                        coord[0] = new Point(coord[0].X + 1, coord[0].Y - 1);
                        coord[1] = new Point(coord[1].X, coord[1].Y);
                        coord[2] = new Point(coord[2].X - 1, coord[2].Y - 1);
                        coord[3] = new Point(coord[3].X - 2, coord[3].Y);
                        stage = 3;
                    }
                    else if (stage == 3)
                    {
                        coord[0] = new Point(coord[0].X - 1, coord[0].Y + 1);
                        coord[1] = new Point(coord[1].X, coord[1].Y);
                        coord[2] = new Point(coord[2].X + 1, coord[2].Y + 1);
                        coord[3] = new Point(coord[3].X + 2, coord[3].Y);
                        stage = 4;
                    }
                }
                else if (figure == 4)
                {
                    if (stage == 4)
                    {
                        coord[0] = new Point(coord[0].X + 2, coord[0].Y);
                        coord[1] = new Point(coord[1].X + 1, coord[1].Y - 1);
                        coord[2] = new Point(coord[2].X, coord[2].Y);
                        coord[3] = new Point(coord[3].X - 1, coord[3].Y - 1);
                        stage = 3;
                    }
                    else if (stage == 3)
                    {
                        coord[0] = new Point(coord[0].X - 2, coord[0].Y);
                        coord[1] = new Point(coord[1].X - 1, coord[1].Y + 1);
                        coord[2] = new Point(coord[2].X, coord[2].Y);
                        coord[3] = new Point(coord[3].X + 1, coord[3].Y + 1);
                        stage = 4;
                    }
                }
                else if (figure == 6)
                {
                    if (stage == 4)
                    {
                        coord[0] = new Point(coord[0].X + 1, coord[0].Y - 1);
                        coord[1] = new Point(coord[1].X, coord[1].Y);
                        coord[2] = new Point(coord[2].X - 1, coord[2].Y - 1);
                        coord[3] = new Point(coord[3].X - 1, coord[3].Y + 1);
                        stage = 3;
                    }
                    else if (stage == 3)
                    {
                        coord[0] = new Point(coord[0].X + 1, coord[0].Y + 1);
                        coord[1] = new Point(coord[1].X, coord[1].Y);
                        coord[2] = new Point(coord[2].X + 1, coord[2].Y - 1);
                        coord[3] = new Point(coord[3].X - 1, coord[3].Y - 1);
                        stage = 2;
                    }
                    else if (stage == 2)
                    {
                        coord[0] = new Point(coord[0].X - 1, coord[0].Y + 1);
                        coord[1] = new Point(coord[1].X, coord[1].Y);
                        coord[2] = new Point(coord[2].X + 1, coord[2].Y + 1);
                        coord[3] = new Point(coord[3].X + 1, coord[3].Y - 1);
                        stage = 1;
                    }
                    else if (stage == 1)
                    {
                        coord[0] = new Point(coord[0].X - 1, coord[0].Y - 1);
                        coord[1] = new Point(coord[1].X, coord[1].Y);
                        coord[2] = new Point(coord[2].X - 1, coord[2].Y + 1);
                        coord[3] = new Point(coord[3].X + 1, coord[3].Y + 1);
                        stage = 4;
                    }
                }
                else if (figure == 7)
                {
                    if (stage == 4)
                    {
                        coord[0] = new Point(coord[0].X, coord[0].Y - 2);
                        coord[1] = new Point(coord[1].X - 1, coord[1].Y - 1);
                        coord[2] = new Point(coord[2].X - 2, coord[2].Y);
                        coord[3] = new Point(coord[3].X - 3, coord[3].Y + 1);
                        stage = 3;
                    }
                    else if (stage == 3)
                    {
                        coord[0] = new Point(coord[0].X, coord[0].Y + 2);
                        coord[1] = new Point(coord[1].X + 1, coord[1].Y + 1);
                        coord[2] = new Point(coord[2].X + 2, coord[2].Y);
                        coord[3] = new Point(coord[3].X + 3, coord[3].Y - 1);
                        stage = 4;
                    }
                }
            }
        }

        public static string RandomString()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        static List<Color> colors = new List<Color> { Color.Green, Color.Red, Color.DeepPink, Color.Gold, Color.Green, Color.Orange, Color.Chocolate };
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
                coords[(int)f.coord[i].Y].RemoveAt((int)f.coord[i].X);
                coords[(int)f.coord[i].Y].Insert((int)f.coord[i].X, null);
                //MessageBox.Show(String.Format("{0}, {1} : {2} ", (int)figures[figures.Count - 1].coord[i].Y, (int)figures[figures.Count - 1].coord[i].X, coordsY[(int)figures[figures.Count - 1].coord[i].Y][(int)figures[figures.Count - 1].coord[i].X].ToString()));
            }
        }
        public void RemoveRectangle(Figure f)
        {
            for (int i = 0; i < f.rects.Count; i++)
            {
                //MessageBox.Show(String.Format("{0}, {1} : {2} ", (int)figures[figures.Count - 1].coord[i].Y, (int)figures[figures.Count - 1].coord[i].X, coordsY[(int)figures[figures.Count - 1].coord[i].Y][(int)figures[figures.Count - 1].coord[i].X].ToString()));
                coords[(int)f.coord[i].Y].RemoveAt((int)f.coord[i].X);
                coords[(int)f.coord[i].Y].Insert((int)f.coord[i].X, f.id);
                //MessageBox.Show(String.Format("{0}, {1} : {2} ", (int)figures[figures.Count - 1].coord[i].Y, (int)figures[figures.Count - 1].coord[i].X, coordsY[(int)figures[figures.Count - 1].coord[i].Y][(int)figures[figures.Count - 1].coord[i].X].ToString()));
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (pause == false)
            {
                if (CheckFigure(3, figures[figures.Count - 1]))
                {
                    Move(3, figures[figures.Count - 1]);
                }
            }
        }
        public void Leaders()
        {
            leaders = new List<string>();
            leaders.Add("1.name1: 10000");
            leaders.Add("2.name2: 9500");
            leaders.Add("3.name3: 9000");
            leaders.Add("4.name4: 8500");
            leaders.Add("5.name5: 8000");
            leaders.Add("6.name6: 7500");
            leaders.Add("7.name7: 7000");
            leaders.Add("8.name8: 6500");
            leaders.Add("9.name9: 6000");
            leaders.Add("10.name10: 5500");
            for (int i = 0; i < 10; i++)
            {
                ListBox1.Items.Add(leaders[i]);
            }
        }
        public void CheckGame()
        {
            for (int i = 0; i < figures[figures.Count - 1].coord.Count; i++)
            {
                if (figures[figures.Count - 1].coord[i].Y == 0 && pause == false)
                {
                    pause = true;
                    string script = "confirm(Game over\nContinue ?);";
                    ScriptManager.RegisterStartupScript(this, GetType(),"ConfirmScript", script, true);
                    //MessageBoxResult result = MessageBox.Show("Game over\nContinue?", "Game over", MessageBoxButton.YesNo, MessageBoxImage.None);
                    //if (result == System.Windows.MessageBoxResult.Yes)
                    //{
                    //    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    //}
                    //Application.Current.Shutdown();
                }
            }
            Destroy();
            CreateFigure();
        }
        public void Fall(int r)
        {
            int count = 0;
            foreach (Point c in figures[r].coord)
            {
                if (c.Y >= 24 || figures[r].coord.Count == 0 || CheckDown(3, count, figures[r]))
                { return; }
                else
                    count++;
            }
            if (count == figures[r].coord.Count && figures[r].coord.Count != 0)
            {
                if (MoveDown(figures[r]))
                {
                    Fall(r);
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

        public void Destroy()
        {
            int find;
            for (int i = 0; i < 25; i++)
            {
                //MessageBox.Show(coords[i].FindAll(x => x.Equals(true)).Count.ToString());
                if (coords[i].FindAll(x => x != null).Count == 15)
                {
                    find = i;
                    for (int t = 0; t < 15; t++)
                    {
                        for (int r = 0; r < figures.Count; r++)
                        {
                            for (int j = 0; j < figures[r].rects.Count; j++)
                            {
                                if (i == figures[r].coord[j].Y && t == figures[r].coord[j].X)
                                {
                                    GameField.Rows[figures[r].coord[j].Y].Cells[figures[r].coord[j].X].BackColor = Color.White;
                                    figures[r].rects.RemoveAt(j);
                                    figures[r].coord.RemoveAt(j);
                                }
                            }
                        }
                    }
                    for (int r = 0; r < figures.Count; r++)
                    {
                        for (int j = 0; j < figures[r].rects.Count; j++)
                        {
                            if (figures[r].coord[j].Y != find)
                            {
                                Hide(figures[r]);
                                figures[r].coord[j] = new Point(figures[r].coord[j].X, figures[r].coord[j].Y + 1);
                                Show(figures[r]);
                                if (figures[r].coord.Count == 0)
                                {
                                    figures.RemoveAt(r);
                                }
                            }
                        }
                    }
                    coords.RemoveAt(i);
                    List<string> cord = new List<string>();
                    for (int y = 0; y < 15; y++)
                    {
                        cord.Add(null);
                    }
                    coords.Insert(0, cord);
                    for (int k = 0; k < figures.Count; k++)
                    {
                        Hide(figures[k]);
                        Show(figures[k]);
                    }
                    points += 100;
                    Label1.Text = points.ToString();
                    if (speed > 0.10)
                    {
                        speed -= 50;
                        Timer1.Interval = speed;
                    }
                    CheckGame();
                    for (int r = 0; r < figures.Count; r++)
                    {
                        Fall(r);
                    }
                }
            }
        }
        public bool CheckFigure(int p, Figure f)
        {
            int i = 0;
            foreach (Point c in figures[figures.Count - 1].coord)
            {
                if (p == 3)
                {
                    if (c.Y >= 24)
                    {
                        CheckGame();
                        return false;
                    }
                    else if (CheckDown(p, i, f))
                    {
                        CheckGame();
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
                if (coords[(int)f.coord[i].Y][(int)f.coord[i].X - 1] == null || coords[(int)f.coord[i].Y][(int)f.coord[i].X - 1] == figures[figures.Count - 1].id)
                {
                    return false;
                }
            }
            else if (p == 1 && coords[(int)f.coord[i].Y].Count > ((int)f.coord[i].X + 1))
            {
                if (coords[(int)f.coord[i].Y][(int)f.coord[i].X + 1] == null || coords[(int)f.coord[i].Y][(int)f.coord[i].X + 1] == f.id)
                {
                    return false;
                }
            }
            else if (p == 3 && coords.Count > ((int)f.coord[i].Y + 1))
            {
                if (coords[(int)f.coord[i].Y + 1][(int)f.coord[i].X] == null || coords[(int)f.coord[i].Y + 1][(int)f.coord[i].X] == f.id)
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
            figures.Add(s);
            if (figures.Count > 1)
            {
                for (int i = 0; i < figures[figures.Count - 2].rects.Count; i++)
                {
                    FigureShow.Rows[figures[figures.Count - 2].coord[i].Y].Cells[figures[figures.Count - 2].coord[i].X].BackColor = Color.White;
                }
            }
            for (int i = 0; i < s.rects.Count; i++)
            {
                FigureShow.Rows[n.coord[i].Y].Cells[n.coord[i].X].BackColor = n.color;
            }
            Random rand = new Random();
            int answer = rand.Next(0, 11);
            for (int i = 0; i < figures[figures.Count - 1].rects.Count; i++)
            {
                figures[figures.Count - 1].coord[i] = new Point(figures[figures.Count - 1].coord[i].X + answer, figures[figures.Count - 1].coord[i].Y);
            }
        }
    }
}