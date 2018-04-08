<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.Master" AutoEventWireup="true" CodeBehind="Problems.aspx.cs" Inherits="FinPro.FinApp.Problems" %>

<asp:Content ID="cContent" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="smPage" runat="server"></asp:ScriptManager>
    <%--<asp:ToolkitScriptManager ID="tsmPage" runat="server"></asp:ToolkitScriptManager>--%>
    <section class="body_content">
        <div class="body_heading_strip">
            <h3 class="page-title">
                <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
            </h3>
            <div class="note note-bordered bg-danger">
                <p>problem warning notification</p>
            </div>

            <div class="clr"></div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <!-- BEGIN SAMPLE TABLE PORTLET-->
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="fa fa-cogs"></i>Problems
                        </div>
                        <div class="actions">
                            <a class="btn btn-sm btn-icon-only btn-default fullscreen" href="javascript:;" data-original-title="" title=""></a>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <asp:UpdatePanel ID="upTrans" runat="server">
                            <ContentTemplate>
                                <div class="control_block">

                                    <div>

                                        <table class="table table-striped table-bordered table-hover" id="sample_2">
                                            <thead>
                                                <tr>
                                                    <th id="grid_selectable" style="display: none;"></th>
                                                    <th>Voucher</th>
                                                    <th>
                                                        <asp:LinkButton ID="lbtnHeaderDate" runat="server">Date</asp:LinkButton></th>
                                                    <th>Description</th>
                                                    <th>
                                                        <asp:LinkButton ID="lbtnHeaderAmount" runat="server">Amount</asp:LinkButton></th>
                                                    <th>
                                                        <asp:LinkButton ID="lbtnHeaderCreater" runat="server">Created By</asp:LinkButton></th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                            <tbody>

                                                <asp:ListView ID="lvGrid" runat="server" OnItemCommand="lvGrid_ItemCommand">

                                                    <ItemTemplate>
                                                        <tr class="grid_first_row odd gradeX">
                                                            <td style="display: none;">
                                                                <asp:HiddenField ID="hfItem" runat="server" />
                                                                <asp:CheckBox ID="chkItem" runat="server" />
                                                            </td>
                                                            <td>

                                                                <asp:HyperLink ID="hplVouchar" runat="server" Text='<%# Eval("voucharNo").ToString() %>' NavigateUrl='<%# Get_Trans_Link(Convert.ToInt32(Eval("transGroupID"))) %>'></asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:Literal ID="ltrDate" runat="server" Text='<%# Convert.ToDateTime(Eval("transGroupCreatedOn")).ToString("MMM dd, yyyy") %>'></asp:Literal></td>
                                                            <td>
                                                                <asp:Literal ID="ltrDescription" runat="server" Text='<%# Eval("transGroupTitle").ToString() %>'></asp:Literal></td>
                                                            <td>
                                                                <asp:Literal ID="ltrAmount" runat="server" Text='<%# Eval("transGroupTotalAmount").ToString() %>'></asp:Literal></td>
                                                            <td>
                                                                <asp:Literal ID="ltrCreatedBy" runat="server" Text='<%# Eval("CreatedBy").ToString() %>'></asp:Literal></td>
                                                            <td>
                                                                <ul class="grid_item_tools">
                                                                    <li>
                                                                        <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument="0" CommandName="delete_this"></asp:LinkButton>
                                                                    </li>
                                                                </ul>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <AlternatingItemTemplate>
                                                        <tr class="grid_alt_row odd gradeX">
                                                            <td style="display: none;">
                                                                <asp:HiddenField ID="hfItem" runat="server" />
                                                                <asp:CheckBox ID="chkItem" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:HyperLink ID="hplVouchar" runat="server" Text='<%# Eval("voucharNo").ToString() %>' NavigateUrl='<%# Get_Trans_Link(Convert.ToInt32(Eval("transGroupID"))) %>'></asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:Literal ID="ltrDate" runat="server" Text='<%# Convert.ToDateTime(Eval("transGroupCreatedOn")).ToString("MMM dd, yyyy") %>'></asp:Literal></td>
                                                            <td>
                                                                <asp:Literal ID="ltrDescription" runat="server" Text='<%# Eval("transGroupTitle").ToString() %>'></asp:Literal></td>
                                                            <td>
                                                                <asp:Literal ID="ltrAmount" runat="server" Text='<%# Eval("transGroupTotalAmount").ToString() %>'></asp:Literal></td>
                                                            <td>
                                                                <asp:Literal ID="ltrCreatedBy" runat="server" Text='<%# Eval("CreatedBy").ToString() %>'></asp:Literal></td>
                                                            <td>
                                                                <ul class="grid_item_tools">
                                                                    <li>
                                                                        <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument="0" CommandName="delete_this"></asp:LinkButton></li>
                                                                </ul>
                                                            </td>
                                                        </tr>
                                                    </AlternatingItemTemplate>
                                                </asp:ListView>
                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <td colspan="7"></td>
                                                </tr>
                                            </tfoot>
                                        </table>

                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>

    </section>
</asp:Content>
