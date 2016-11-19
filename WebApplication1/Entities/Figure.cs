using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebApplication1
{
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
            id = Indetity.RandomString();
            stage = 4;
            coord = new List<Point>();
            Random r = new Random();
            color = ConstData.colors[r.Next(0, 7)];
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
}