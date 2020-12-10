<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addNew.aspx.cs" Inherits="t1.addNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div align="Center">
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="Добавить новую категорию товара" Width="294px" OnClick="Button1_Click" Height="54px" />
    
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Введите новые категории товаров"></asp:Label>
    
    </div>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Width="280px" BorderStyle="Groove"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <%
            table();
        %>

    </form>
    </div>
</body>
</html>
