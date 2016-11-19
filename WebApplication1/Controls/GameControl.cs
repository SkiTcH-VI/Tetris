using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class GameControl
    {
        public void CheckGame()
        {
            FigureControl fControl = new FigureControl();
            for (int i = 0; i < VariableData.figures[VariableData.figures.Count - 1].coord.Count; i++)
            {
                if (VariableData.figures[VariableData.figures.Count - 1].coord[i].Y == 0 && VariableData.pause == false)
                {
                    VariableData.pause = true;
                    string script = "confirm(Game over\nContinue ?);";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ConfirmScript", script, true);
                    //MessageBoxResult result = MessageBox.Show("Game over\nContinue?", "Game over", MessageBoxButton.YesNo, MessageBoxImage.None);
                    //if (result == System.Windows.MessageBoxResult.Yes)
                    //{
                    //    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    //}
                    //Application.Current.Shutdown();
                }
            }
            fControl.DestroyFigure();
            fControl.CreateFigure();
        }
        public void Fall(int r)
        {
            FigureControl fControl = new FigureControl();
            int count = 0;
            foreach (Point c in VariableData.figures[r].coord)
            {
                if (c.Y >= 24 || VariableData.figures[r].coord.Count == 0 || fControl.CheckDown(3, count, VariableData.figures[r]))
                { return; }
                else
                    count++;
            }
            if (count == VariableData.figures[r].coord.Count && VariableData.figures[r].coord.Count != 0)
            {
                if (fControl.MoveDown(VariableData.figures[r]))
                {
                    Fall(r);
                }
            }

        }
    }
}