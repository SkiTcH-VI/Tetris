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
using System.Web.Services;

namespace WebApplication1
{
    public partial  class WebForm1 : System.Web.UI.Page
    {
        FigureControl fControl = new FigureControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 25; i++)
            {
                TableRow row = new TableRow();
                GameField.Rows.Add(row);
                List<string> cord = new List<string>();
                for (int j = 0; j < 15; j++)
                {
                    TableCell cell = new TableCell();
                    cell.Width = 30;
                    cell.Height = 30;
                    GameField.Rows[i].Cells.Add(cell);
                    cord.Add(null);
                }
                VariableData.coords.Add(cord);
            }
            for (int i = 0; i < 4; i++)
            {
                TableRow row = new TableRow();
                FigureShow.Rows.Add(row);
                for (int j = 0; j < 4; j++)
                {
                    TableCell cell = new TableCell();
                    cell.Width = 30;
                    cell.Height = 30;
                    FigureShow.Rows[i].Cells.Add(cell);
                }
            }
            fControl.FigureShow = FigureShow;
            fControl.GameField = GameField;
            fControl.Label1 = Label1;
            fControl.CreateFigure();
        }
        [WebMethod]
        public static void Timer_Tick(Table GameField, Table FigureShow, Label Label1)
        {
            
            //if (VariableData.pause == false)
            //{
            //    FigureControl fControl = new FigureControl();
            //    fControl.FigureShow = FigureShow;
            //    fControl.GameField = GameField;
            //    fControl.Label1 = Label1;
            //    if (fControl.CheckFigure(3, VariableData.figures[VariableData.figures.Count - 1]))
            //    {
            //        fControl.Move(3, VariableData.figures[VariableData.figures.Count - 1]);
            //    }
            //}
        }
    }
}