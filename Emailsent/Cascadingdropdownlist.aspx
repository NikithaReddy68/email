<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cascadingdropdownlist.aspx.cs" Inherits="Emailsent.Cascadingdropdownlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <asp:Label ID="lblcountry" Text="Country: " runat="server" />
        <asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        <br />
        <asp:Label ID="lblstate" Text="State: " runat="server" />
        <asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true" style="height: 22px"></asp:DropDownList>
        <br />
        <asp:Label ID="lblcity" Text="City: " runat="server" />
        <asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList>
   
    </div>
    </form>
</body>
</html>
