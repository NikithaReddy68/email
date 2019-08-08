<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cascadingddpgrid.aspx.cs" Inherits="Emailsent.Cascadingddpgrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cascading Dropdownlist in gridview</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:GridView ID="gridview1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowDeleting="gridview1_RowDeleting" OnRowDataBound="gridview1_RowDataBound1" OnRowCancelingEdit="gridview1_RowCancelingEdit1" onrowupdating="gridview1_RowUpdating" OnRowEditing="gridview1_RowEditing" >
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                <asp:TemplateField HeaderText="country">
                    <EditItemTemplate>
                        <asp:DropDownList ID="drpcountry" AutoPostBack="true" OnSelectedIndexChanged="drpcountry_SelectedIndexChanged" runat="server">                          
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("country") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="state">
                    <EditItemTemplate>
                       <asp:DropDownList ID="drpstate" AutoPostBack="true" OnSelectedIndexChanged="drpstate_SelectedIndexChanged" runat="server"> 
                           </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("state") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="city">
                    <EditItemTemplate>
                        <asp:DropDownList ID="drpcity" AutoPostBack="true" runat="server"> 
                            </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("city") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="operation" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
        </div>
    </form>
</body>
</html>


