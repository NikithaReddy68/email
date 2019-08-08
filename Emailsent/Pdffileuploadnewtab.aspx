<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pdffileuploadnewtab.aspx.cs" Inherits="Emailsent.Pdffileuploadnewtab" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="f1" runat="server" /><br />
        <asp:Button ID="b" runat="server" Text="submit" OnClick="b_Click" />
        <asp:GridView ID="grvDocuments" runat="server" AutoGenerateColumns="false" >
            <Columns>
               <asp:BoundField HeaderText="Id" DataField="id" />
                 <asp:BoundField DataField="name" HeaderText="File Name"/>
               <asp:TemplateField ItemStyle-HorizontalAlign = "Center" HeaderText="Action">
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownload" runat="server" Text="Read" OnClick="Downloadfile"
                    CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
                 <asp:TemplateField HeaderText="Download">
                    <ItemTemplate>
   <asp:LinkButton ID="lnkRead" runat="server" Text= "Download" CommandName="Download" OnClick="Readpdf" CommandArgument='<%#Eval("name") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>


        </asp:GridView>
    </div>
    </form>

</body>
</html>
