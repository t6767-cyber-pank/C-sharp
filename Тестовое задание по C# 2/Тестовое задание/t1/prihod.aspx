<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prihod.aspx.cs" Inherits="t1.prihod" %>

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
      
        <asp:Label ID="Label1" runat="server" Text="Наименование товара"></asp:Label>    
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Width="297px"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Цена"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Number">0</asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Количество"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox3" runat="server" TextMode="Number">0</asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Дата поступления"></asp:Label>
        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        <asp:Label ID="Label6" runat="server" Text="Выберите категорию"></asp:Label>
        <br />
        <asp:RadioButtonList ID="CheckBoxList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
        </asp:RadioButtonList>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Добавить новый товар" Height="35px" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Label ID="Label5" runat="server"></asp:Label>
        <br />
    
    </div>
    </form>
    </div>
</body>
</html>
