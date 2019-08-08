<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Securelogin.aspx.cs" Inherits="Emailsent.Securelogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:Label ID="lbluname" Text="Username:" runat="server" />
        <asp:TextBox ID="txtuname" runat="server" /><br />
        <asp:Label ID="lblpwd" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnsubmit" runat="server" Text="Login" OnClick="btnsubmit_Click" style="width: 47px" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
