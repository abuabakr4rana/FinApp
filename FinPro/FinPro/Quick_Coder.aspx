<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quick_Coder.aspx.cs" Inherits="FinPro.Quick_Coder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmMain" runat="server">
        Class File Name<asp:TextBox ID="tbClassFileName" runat="server"></asp:TextBox>
        Table Name<asp:TextBox ID="tbname" runat="server"></asp:TextBox>
        Stored Procedure Name<asp:TextBox ID="tbprocname" runat="server">SP_</asp:TextBox>
        Procedure Name<asp:TextBox ID="tbproc" runat="server"></asp:TextBox>
        Control Name Prefix<asp:TextBox ID="tbControlNamePrefix" runat="server">tb_add_</asp:TextBox>
        Control CSS Class<asp:TextBox ID="tbControlCSS" runat="server">StdSingleTB</asp:TextBox>
        Validation Group<asp:TextBox ID="tbValidationGroup" runat="server"></asp:TextBox>
        Title Cell CSS Class<asp:TextBox ID="tbTitleCellCSS" runat="server">StdSingle_Title</asp:TextBox>
        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create" />
    </form>
</body>
</html>
