<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.Master" AutoEventWireup="true" CodeBehind="Vouchar_View.aspx.cs" Inherits="FinPro.FinApp.Vouchar_View" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=7.2.13.1016, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<asp:Content ID="cContent" ContentPlaceHolderID="cphBody" runat="server">
    <telerik:ReportViewer ID="rvReport" runat="server" Height="800px" Width="100%" BackColor="White">
                <typereportsource typename="rpTransaction, FinPro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"></typereportsource>
    </telerik:ReportViewer>
</asp:Content>
