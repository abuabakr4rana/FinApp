<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.master" AutoEventWireup="true" CodeBehind="Reports_Ledger.aspx.cs" Inherits="FinPro.FinApp.Reports_Ledger" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="cContent" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="smMain" runat="server"></asp:ScriptManager>
    <h3 class="page-title">Account Ledger<small></small>
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
                        <asp:HyperLink ID="hlPrintable" runat="server" Target="_blank">Printable</asp:HyperLink>
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
                                        <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn blue" OnClick="btnSubmit_Click" />
                                    </span>
                                </div>
                                <span class="help-block">Select date range </span>
                            </div>

                            <div class="col-md-4">
                            </div>
                        </div>

                        <div class="table-responsive">
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th class="col-md-1">Date</th>
                                        <th class="col-md-1">Vouchar</th>
                                        <th class="col-md-3">Narration</th>
                                        <th class="col-md-1">Ref.</th>
                                        <th class="col-md-1">Debit</th>
                                        <th class="col-md-1">Credit</th>
                                        <th class="col-md-1">Balance
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr class="grid_first_row">
                                        <td>---
                                        </td>
                                        <td>---
                                        </td>
                                        <td>Openning Balance</td>
                                        <td>---
                                        </td>
                                        <td class="align_right">---
                                        </td>
                                        <td class="align_right">---
                                        </td>
                                        <td class="align_right">
                                            <asp:Literal ID="ltrOpeningBalance" runat="server"></asp:Literal></td>

                                    </tr>
                                    <asp:ListView ID="lvGrid" runat="server">

                                        <ItemTemplate>
                                            <tr class="grid_first_row">
                                                <td>
                                                    <asp:Literal ID="ltrDate" runat="server" Text='<%# Convert.ToDateTime(Eval("CreatedOn")).ToString("MMM dd, yyyy") %>'></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltrVouchar" runat="server" Text='<%# Eval("transVoucharNo").ToString() %>'></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:HyperLink ID="hplDescription" runat="server" CssClass="tooltip" Target="_blank" ToolTip='<%# Eval("Narration").ToString() %>' Text='<%# Get_Description_Trimmed(Eval("Narration").ToString()) %>' NavigateUrl='<%# Get_Trans_Link(Convert.ToInt32(Eval("transGroupID"))) %>'></asp:HyperLink>
                                                    <td>
                                                        <asp:Literal ID="ltrRef" runat="server" Text='<%# Eval("transGroupRefId").ToString() %>'></asp:Literal>
                                                    </td>
                                                    <td class="align_right">
                                                        <asp:Literal ID="ltrDebitAmount" runat="server" Text='<%# Eval("DebitAmount").ToString() %>'></asp:Literal></td>
                                                    <td class="align_right">
                                                        <asp:Literal ID="ltrCreditAmount" runat="server" Text='<%# Eval("CreditAmount").ToString() %>'></asp:Literal></td>
                                                    <td class="align_right">
                                                        <asp:Literal ID="ltrTotalAmount" runat="server" Text='<%# Eval("DiffAmountString").ToString() %>'></asp:Literal></td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="grid_alt_row">
                                                <td>
                                                    <asp:Literal ID="ltrDate" runat="server" Text='<%# Convert.ToDateTime(Eval("CreatedOn")).ToString("MMM dd, yyyy") %>'></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltrVouchar" runat="server" Text='<%# Eval("transVoucharNo").ToString() %>'></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:HyperLink ID="hplDescription" runat="server" CssClass="tooltip" Target="_blank" ToolTip='<%# Eval("Narration").ToString() %>' Text='<%# Get_Description_Trimmed(Eval("Narration").ToString()) %>' NavigateUrl='<%# Get_Trans_Link(Convert.ToInt32(Eval("transGroupID"))) %>'></asp:HyperLink>
                                                    <%--<asp:HyperLink ID="HyperLink1" runat="server" CssClass="description" Target="_blank" ToolTip='<%# Eval("Narration").ToString() %>' Text='<%# Get_Description_Trimmed(Eval("Narration").ToString()) %>' NavigateUrl='<%# Get_Trans_Link(Convert.ToInt32(Eval("transGroupID"))) %>'></asp:HyperLink>--%>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltrRef" runat="server" Text='<%# Eval("transGroupRefId").ToString() %>'></asp:Literal>
                                                </td>
                                                <td class="align_right">
                                                    <asp:Literal ID="ltrDebitAmount" runat="server" Text='<%# Eval("DebitAmount").ToString() %>'></asp:Literal></td>
                                                <td class="align_right">
                                                    <asp:Literal ID="ltrCreditAmount" runat="server" Text='<%# Eval("CreditAmount").ToString() %>'></asp:Literal></td>
                                                <td class="align_right">
                                                    <asp:Literal ID="ltrTotalAmount" runat="server" Text='<%# Eval("DiffAmountString").ToString() %>'></asp:Literal></td>

                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:ListView>

                                </tbody>
                                <tfoot>
                                    <tr class="grid_total_bottom_row">
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td class="align_right">
                                            <asp:Literal ID="ltrTotalDebit" runat="server"></asp:Literal>
                                        </td>
                                        <td class="align_right">
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
    </div>


    <div class="filter_container">
        <table>
            <tbody>
                <tr>
                    <td class="title_cell">Account
                    </td>
                    <td>
                        <telerik:RadComboBox ID="ddlAccounts" runat="server" Width="200" Height="400px" EmptyMessage="Type an E-mail" DataTextField="accountTitle" DataValueField="accountID" AllowCustomText="true" MarkFirstMatch="true" Filter="Contains" Skin="Silk" NoWrap="true" DropDownWidth="480">
                        </telerik:RadComboBox>
                        <%--<asp:DropDownList ID="ddlAccounts" runat="server" CssClass="ddl_border ddl_generic ddl_padding" Width="200px"></asp:DropDownList>--%>
                    </td>
                    <td class="title_cell">Department
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDepartment" runat="server" DataValueField="deptId" DataTextField="deptTitle" CssClass="ddl_border ddl_generic ddl_padding" Width="150px"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

    <asp:UpdatePanel ID="upGrid" runat="server">
        <ContentTemplate>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
