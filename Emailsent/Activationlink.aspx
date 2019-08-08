<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Activationlink.aspx.cs" Inherits="Emailsent.Activationlink" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
    <script lang="javascript" type="text/javascript">
        function uservalid() {
            var txtname = document.getElementById("txtname").value;
            //var ddlgender = document.getElementById("ddlgender").value;            
            var txtcontact = document.getElementById("txtcontact").value;
            var pattern = /^\d{10}$/;
            var txtemail = document.getElementById("txtemail").value;
            var EmailExp = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/;
            var txtpwd = document.getElementById("txtpwd").value;
            //var Confirmpwd = document.getElementById("txtconfirmpwd").value;
            var txtlocation = document.getElementById("txtlocation").value;

            //if (txtname == '' && ddlgender == 0 && txtcontact == '' && txtemail == '' && txtpwd == '' && txtlocation == '') {
            //    alert("Enter all fields");
            //    return false;
            //}
            if (txtname.trim() == '') {
                alert("Please enter name");
                return false;
            }
            if (document.getElementById("ddlgender").value == "--select--") {
                alert("Please select gender");
                return false;
            }
            if(txtcontact.trim()==''||!pattern.test(txtcontact.trim()))
            {
                alert("Enter the 10 digits number");
                return false;
            }
            if (txtemail.trim() == '' || !EmailExp.test(txtemail.trim())) {
                alert("Email id is required");
                return false;
            }
            if (txtpwd == '')
            {
                alert("Password is required ");
                return false;
            }
            //if (txtpwd != txtconfirmpwd) {
            //    alert("Password and confirm password doen't match");
            //    return false;
            //}

            if (txtlocation.trim() == '') {
                alert("Please enter the location");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2 style="text-align:center;color:blueviolet">Registration Form</h2>
        <asp:Label ID="lblname" Text="Name: " runat="server" />
        <asp:TextBox ID="txtname" runat="server" /><br />
        <asp:Label ID="lblgender" Text="Gender: " runat="server" />
        <asp:DropDownList ID="ddlgender" runat="server">
            <asp:ListItem Text="--select--" Value="--select--" />
            <asp:ListItem Text="Male" Value="Male" />
            <asp:ListItem Text="Female" Value="Female" />
        </asp:DropDownList><br />
        <asp:Label ID="lblcontact" Text="Contact No:" runat="server" />
        <asp:TextBox ID="txtcontact" runat="server" TextMode="Phone" MaxLength="10" /><br />
        <asp:Label ID="lblemail" Text="Email id: " runat="server" />
        <asp:TextBox ID="txtemail" runat="server" TextMode="Email" /><br />
        <asp:Label ID="lblpwd" Text="Password: " runat="server" />
        <asp:TextBox ID="txtpwd" runat="server" TextMode="Password" /><br />
        <%--<asp:Label ID="lblconfirmpwd" Text="Confirm Password: " runat="server" />
        <asp:TextBox ID="txtconfirmpwd" runat="server" TextMode="Password" /><br />--%>
        <asp:Label ID="lbllocation" Text="Location:" runat="server" />
        <asp:TextBox ID="txtlocation" runat="server" /><br />
        <asp:Button ID="btnsubmit" Text="Submit" runat="server" OnClick="btnsubmit_Click" OnClientClick="return uservalid();"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnalreadyreg" Text="Already Registered" runat="server" OnClick="btnalreadyreg_Click" />
        <asp:Label ID="lblsuccess" runat="server" /><br /><br />
        <asp:GridView ID="gridview" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
