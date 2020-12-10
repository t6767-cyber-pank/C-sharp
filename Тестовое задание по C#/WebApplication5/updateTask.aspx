<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateTask.aspx.cs" Inherits="WebApplication5.updateTask" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="33px" Width="522px"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" Height="42px" OnClick="Button1_Click" Text="Импортировать данные с записи" Width="527px" />
            <input id="Hidden1" type="hidden" runat="server" />
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Сохранить" Width="526px" />
        </p>
    </form>
</body>
</html>
