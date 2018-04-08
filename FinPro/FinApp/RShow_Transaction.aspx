<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RShow_Transaction.aspx.cs" Inherits="FinPro.FinApp.RShow_Transaction" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=7.2.13.1016, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin:0; padding:0;">
    <form id="frmReport" runat="server">
        <div>
            <telerik:ReportViewer ID="rvReport" runat="server" Height="800px" Width="100%">
                <typereportsource typename="rpTransaction, FinPro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"></typereportsource>
            </telerik:ReportViewer>
        </div>
    </form>
</body>
</html>
