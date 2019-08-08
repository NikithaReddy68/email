<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gridvwrow.aspx.cs" Inherits="Emailsent.Gridvwrow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false">

        <Columns>

        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

        <asp:TemplateField HeaderText="Header 1">

            <ItemTemplate>

                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

            </ItemTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Header 2">

            <ItemTemplate>

                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

            </ItemTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Header 3">

            <ItemTemplate>

                 <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

            </ItemTemplate>

            <FooterStyle HorizontalAlign="Right" />

            <FooterTemplate>

             <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click1" Text="Add New Row" />

            </FooterTemplate>

        </asp:TemplateField>

        </Columns>

</asp:gridview>
    </div>
    </form>
</body>
</html>
