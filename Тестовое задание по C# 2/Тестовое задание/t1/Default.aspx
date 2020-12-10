<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="t1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Test</title>
    <style type="text/css">
        .auto-style1 {
            width: 324px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Добавить категорию" Width="322px" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Добавить товар" Width="344px" />
        <table width="100%">
        <tr>
            <td class="auto-style1">
        <asp:ListBox ID="ListBox1" runat="server" Height="357px" Width="323px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" OnTextChanged="ListBox1_TextChanged"></asp:ListBox>
            </td>
            <td>
        <div ID="Div1" runat="server">
        </div>
            </td>
        </tr>
        </table>
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Открыть категорию" Width="322px" />
    
    </div>
    </form>
</body>
</html>
