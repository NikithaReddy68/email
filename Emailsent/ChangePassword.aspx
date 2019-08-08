<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Emailsent.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:Label ID="lbloldpwd" Text=" Enter Current Password: " runat="server" />
        <asp:TextBox ID="txtoldpwd" runat="server" TextMode="Password" />
        <asp:RequiredFieldValidator ErrorMessage="Enter old Password" ControlToValidate="txtoldpwd" ValidationGroup="i" ForeColor="Red" SetFocusOnError="true" runat="server" /><br />
        <asp:Label Text="Enter New Password: " runat="server" />
        <asp:TextBox ID="txtnewpwd" runat="server" TextMode="Password" />
        <asp:RequiredFieldValidator ErrorMessage="Enter new Password" ControlToValidate="txtnewpwd" ValidationGroup="i" ForeColor="Red" SetFocusOnError="true" runat="server" /><br />
        <asp:Label Text="Confirm Password: " runat="server" />
        <asp:TextBox ID="txtconfirmpwd" runat="server" TextMode="Password" />
        <asp:RequiredFieldValidator ErrorMessage="Confirm the Password" ControlToValidate="txtconfirmpwd" ValidationGroup="i" ForeColor="Red" SetFocusOnError="true" runat="server" /><br /><br />
        <asp:CompareValidator ErrorMessage="Password not same" ControlToValidate="txtconfirmpwd" ValidationGroup="i" ControlToCompare="txtnewpwd" ForeColor="Red" runat="server" /><br />
        
        <asp:Button ID="btnchangepwd" Text="ChangePassword" runat="server" ValidationGroup="i" OnClick="btnchangepwd_Click1"/> 

        <asp:Label ID="lblmsg" runat="server" />
       
    </div>
    </form>
</body>
</html>
