<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Emailsent.aspx.cs" Inherits="Emailsent.Emailsent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
  
          <asp:Label ID="lblemail" Text="Enter Email" runat="server" />
        <asp:TextBox ID="txtemail" runat="server" />
       <br />
        <asp:Label ID="lblmsg" Text="Enter Message" runat="server" />
        <asp:TextBox ID="txtmsg" runat="server" TextMode="MultiLine" />
        <br /><br />
        <asp:Button ID="btnsend" Text="Send" runat="server" OnClick="btnsend_Click" />
        <br />
        <asp:Label ID="lblerror" runat="server" />
    
        
    </div>
    </form>
</body>
</html>
