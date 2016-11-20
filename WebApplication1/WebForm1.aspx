<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/Pages/Default.js"></script>
    <title>Calc</title>
</head>
<body>
    <form runat="server">
        <asp:scriptmanager runat="server"></asp:scriptmanager>
        <div style="position: absolute; top: 315px; left: 824px;">
        <asp:Label ID="Label1" runat="server">Text</asp:Label>
            </div>
        <div style="position: absolute; top: 364px; left: 825px;">
            <asp:ListBox ID="ListBox1" runat="server" Height="277px" Width="198px"></asp:ListBox>
            <asp:Button ID="button" runat="server" />
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
        <div style="position: absolute; top: 150px; left: 825px;">
        <asp:Table ID="FigureShow" runat="server"  CssClass="table-bordered" >
        </asp:Table>
            </div>
    </form>
</body>
</html>
