<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calc</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="jquery.min.js"></script> 
    <style>
    </style>
</head>
<body>
    <form runat="server">
        <asp:scriptmanager runat="server"></asp:scriptmanager>
        <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="1000"/>
        <div style="position: absolute; top: 315px; left: 824px;">
        <asp:Label ID="Label1" runat="server"></asp:Label>
            </div>
        <div style="position: absolute; top: 364px; left: 825px;">
            <asp:ListBox ID="ListBox1" runat="server" Height="277px" Width="198px"></asp:ListBox>
        </div>
        <div style="position: absolute; top: 111px; left: 829px; width: 192px;">
            <asp:Table ID="FigureShow" runat="server" CssClass="table-bordered">
            </asp:Table>
        </div>
        <asp:Table ID="GameField" runat="server" CssClass="table-bordered">
        </asp:Table>
        <script>
            $(document).keypress(function (event) {
                var code = e.keyCode || e.which;
                if (code == 87) {
                    Move(4, figures[figures.Count - 1]);
                }
                if (code == 65) {
                    Move(2, figures[figures.Count - 1])
                }
                if (code == 83) {
                    Move(3, figures[figures.Count - 1]);
                }
                if (code == 68) {
                    Move(1, figures[figures.Count - 1]);
                }
            });
        </script>
    </form>
</body>
</html>
