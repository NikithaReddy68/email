<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fileupload.aspx.cs" Inherits="Emailsent.Fileupload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblImagename" Text="Imagename" runat="server" />
            <asp:TextBox ID="txtimagename" runat="server" />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="lblupload" Text="Upload" runat="server" OnClick="lblupload_Click" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnRowCancelingEdit="GridView1_RowCancelingEdit1" OnRowDeleting="GridView1_RowDeleting1" OnRowEditing="GridView1_RowEditing1" OnRowUpdating="GridView1_RowUpdating1" OnRowCommand="GridView1_RowCommand" ShowFooter="True">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:TemplateField HeaderText="ImageName" SortExpression="ImageName">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ImageName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ImageName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image">
                        <%--<EditItemTemplate>
                            <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("Image") %>' />                            
                        </EditItemTemplate>--%>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:FileUpload ID="FileUpload3" runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:FileUpload ID="FileUpload2" runat="server" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("Image") %>' Height="16px" />                            
                        </ItemTemplate>
                        <ControlStyle Height="100px" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Select" CommandArgument="<% # Container.DataItemIndex %>">Insert</asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" Text='<%# Eval("Id") %>'></asp:TextBox>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TableConnectionString %>" SelectCommand="SELECT * FROM [Fileuploadgrid]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
