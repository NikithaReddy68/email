<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Emailsent.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label ID="lblregemail" Text="Enter your Registered email id: " runat="server" />
            <asp:TextBox ID="txtregemail" runat="server" />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btngetpwd" Text="Get your Password" runat="server" OnClick="btngetpwd_Click" />
            <br />
            <asp:Label ID="lblpwdsent" runat="server" />
        
    </div>
    </form>
</body>
</html>
