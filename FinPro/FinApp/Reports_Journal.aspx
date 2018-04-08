<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/Reports.master" AutoEventWireup="true" CodeBehind="Reports_Journal.aspx.cs" Inherits="FinPro.FinApp.Reports_Journal" %>

<asp:Content ID="cTitle" ContentPlaceHolderID="cphTitle" runat="server">
    General Journal
</asp:Content>
<asp:Content ID="cContent" ContentPlaceHolderID="cphReport" runat="server">
    <asp:ScriptManager ID="smMain" runat="server"></asp:ScriptManager>
    <div class="filter_container">
        <table>
            <tbody>
                <tr>
                    <td class="title_cell">From
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="radFromDate" runat="server"></telerik:RadDatePicker>
                    </td>
                    <td class="title_cell">To
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="radToDate" runat="server"></telerik:RadDatePicker>
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

    <div class="grid_container">
        <asp:UpdatePanel ID="upGrid" runat="server">
            <ContentTemplate>
                <table cellspacing="0">
                    <thead>
                        <tr>
                            <td width="80px">Date</td>
                            <td width="80px">ID</td>
                            <td>Account Title</td>
                            <td width="120px">Debit</td>
                            <td width="120px">Credit</td>
                        </tr>
                    </thead>
                    <tbody>

                        <asp:ListView ID="lvGrid" runat="server">
                            <ItemTemplate>
                                <tr style="font-weight:bold">
                                    <td>
                                        <asp:Literal ID="ltrVoucharDate" runat="server" Text='<%# Convert.ToDateTime(Eval("transGroupCreatedOn")).ToString("MMM dd, yyyy") %>'></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:HyperLink ID="hplVouchar" runat="server" Text='<%# Eval("voucharNo").ToString() %>' NavigateUrl='<%# Get_Trans_Link(Convert.ToInt32(Eval("transGroupID"))) %>'></asp:HyperLink>
                                    </td>
                                    <td colspan="3">
                                        <asp:Literal ID="ltrVoucharTitle" runat="server" Text='<%# Eval("transGroupTitle").ToString() %>'></asp:Literal>
                                    </td>
                                </tr>
                                <asp:ListView ID="lvDetailsVouchar" runat="server" DataSource='<%# Get_Vouchar_Transactions(Convert.ToInt32(Eval("transGroupID"))) %>'>
                                    <ItemTemplate>
                                        <tr class="grid_first_row">
                                            <td></td>
                                            <td>
                                                <asp:Literal ID="ltrAccountID" runat="server" Text='<%# "" %>'></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="ltrDescription" runat="server" Text='<%# Eval("accountTitle").ToString() + Eval("crAccountTitle").ToString() %>'></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="ltrDebit" runat="server" Text='<%# Eval("debitAmountFormatted").ToString() %>'></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="ltrCredit" runat="server" Text='<%# Eval("creditAmountFormatted").ToString() %>'></asp:Literal>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </ItemTemplate>
                        </asp:ListView>
                    </tbody>
                    <tfoot>
                        <tr class="grid_total_bottom_row">
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>
                                <asp:Literal ID="ltrTotalDebit" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal ID="ltrTotalCredit" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr class="grid_total_bottom_row">
                            <td colspan="5">
                                <myControl:wucDataPager runat="server" ID="wucDataPager" OnPageChange="wucDataPager_PageChange" OnNextPageClicked="wucDataPager_NextPageClicked" OnPreviousPageClicked="wucDataPager_PreviousPageClicked" />
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
