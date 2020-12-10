<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication5.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div align="Center">
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server" Height="75px" Width="704px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Height="76px" OnClick="Button1_Click" Text="Добавить задачу" Width="298px" />
    <br />
    
    
        <asp:Button ID="Button2" runat="server" Text="Показать выполненные задачи" Width="300px" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Показать не выполненные задачи" Width="246px" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Все задачи" />
    <br />
    <br />
        <div  ID="Div1" runat="server">
        </div>
    </form>
    </div>
    <p>
        &nbsp;</p>
</body>
</html>
