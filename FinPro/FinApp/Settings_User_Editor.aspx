<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.Master" AutoEventWireup="true" CodeBehind="Settings_User_Editor.aspx.cs" Inherits="FinPro.FinApp.Settings_User_Editor" %>
<asp:Content ID="cContent" ContentPlaceHolderID="cphBody" runat="server">

    <table>
        <tr>
            <td>Username</td>
            <td>
                <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Password</td>
            <td><asp:TextBox ID="tbPassword" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>First Name</td>
            <td><asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td><asp:TextBox ID="tbLastName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Email</td>
            <td><asp:TextBox ID="tbEmail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnCreateUser" runat="server" Text="Create User" OnClick="btnCreateUser_Click" /></td>
        </tr>
    </table>

</asp:Content>
