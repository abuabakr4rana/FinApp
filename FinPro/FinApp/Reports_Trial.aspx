<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.master" AutoEventWireup="true" CodeBehind="Reports_Trial.aspx.cs" Inherits="FinPro.FinApp.Reports_Trial" %>

<asp:Content ID="cContent" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="smMain" runat="server"></asp:ScriptManager>
    <h3 class="page-title">Trial Balance<small></small>
    </h3>

    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN SAMPLE TABLE PORTLET-->
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-cogs"></i>Report
                    </div>
                    <div class="actions">
                        <a class="btn btn-sm btn-icon-only btn-default fullscreen" href="javascript:;" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body">

                    <div class="table-container">

                        <div class="row">

                            <div class="col-md-5">
                                <div class="input-group date-picker input-daterange" data-date="10/11/2012" data-date-format="mm/dd/yyyy">
                                    <asp:TextBox ID="tbFromDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon">to </span>
                                    <asp:TextBox ID="tbToDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn blue" OnClick="btnSubmit_Click" />
                                    </span>
                                </div>
                                <span class="help-block">Select date range </span>
                            </div>

                            <div class="col-md-4">
                            </div>
                        </div>

                    </div>

                    <div class="table-responsive">
                        <asp:HiddenField ID="hfCurrentPage" runat="server" />
                        <table class="table">
                            <thead>
                                <tr>
                                    <th class="col-md-2">Account No.</th>
                                    <th class="col-md-4">Account Title</th>
                                    <th class="col-md-2 text-align-reverse">Debit</th>
                                    <th class="col-md-2 text-align-reverse">Credit</th>
                                    <th class="col-md-2 text-align-reverse">Difference
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="lvGrid" runat="server">

                                    <ItemTemplate>
                                        <tr class="grid_first_row">
                                            <td>
                                                <asp:Literal ID="ltrAccountNo" runat="server" Text='<%# "" %>'></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:HyperLink ID="hplAccountTitle" runat="server" Text='<%# Eval("accountTitle").ToString() %>' NavigateUrl='<%# "~/FinApp/Reports_Ledger.aspx?id=" + Eval("accountId").ToString() %>'></asp:HyperLink>

                                            </td>
                                            <td class=" text-align-reverse">
                                                <asp:Literal ID="ltrDebitAmount" runat="server" Text='<%# Eval("debit").ToString() %>'></asp:Literal></td>
                                            <td class=" text-align-reverse">
                                                <asp:Literal ID="ltrCreditAmount" runat="server" Text='<%# Eval("credit").ToString() %>'></asp:Literal></td>
                                            <td class="text-align-reverse">
                                                <asp:Literal ID="ltrCreditDiff" runat="server" Text='<%# Difference_Amount(Convert.ToDecimal(Eval("creditDiff"))).ToString() %>'></asp:Literal></td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr class="grid_alt_row">
                                            <td>
                                                <asp:Literal ID="ltrAccountNo" runat="server" Text='<%# "" %>'></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:HyperLink ID="hplAccountTitle" runat="server" Text='<%# Eval("accountTitle").ToString() %>' NavigateUrl='<%# "~/FinApp/Reports_Ledger.aspx?id=" + Eval("accountId").ToString() %>'></asp:HyperLink>

                                            </td>
                                            <td class="text-align-reverse">
                                                <asp:Literal ID="ltrDebitAmount" runat="server" Text='<%# Eval("debit").ToString() %>'></asp:Literal></td>
                                            <td class="text-align-reverse">
                                                <asp:Literal ID="ltrCreditAmount" runat="server" Text='<%# Eval("credit").ToString() %>'></asp:Literal></td>
                                            <td class="text-align-reverse">
                                                <asp:Literal ID="ltrCreditDiff" runat="server" Text='<%# Difference_Amount(Convert.ToDecimal(Eval("creditDiff"))).ToString() %>'></asp:Literal></td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                </asp:ListView>
                            </tbody>
                            <tfoot>
                                <tr class="grid_total_bottom_row">
                                    <td></td>

                                    <td class="bold">Total Amount
                                    </td>
                                    <td class="text-align-reverse bold">
                                        <asp:Literal ID="ltrTotalDebit" runat="server"></asp:Literal>
                                    </td>
                                    <td class="text-align-reverse bold">
                                        <asp:Literal ID="ltrTotalCredit" runat="server"></asp:Literal>
                                    </td>
                                    <td></td>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>




</asp:Content>
