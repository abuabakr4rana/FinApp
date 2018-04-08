<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="FinPro.FinApp.Transactions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="cContent" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="smPage" runat="server"></asp:ScriptManager>

    <%--<asp:ToolkitScriptManager ID="tsmPage" runat="server"></asp:ToolkitScriptManager>--%>

    <!-- BEGIN PAGE HEADER-->
    <h3 class="page-title">
        <asp:Literal ID="ltrTitle" runat="server"></asp:Literal><small><asp:Literal ID="ltrDetails" runat="server"></asp:Literal></small>
    </h3>
    <!-- BEGIN PAGE CONTENT-->
    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN SAMPLE TABLE PORTLET-->
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-cogs"></i>Vouchars
                    </div>
                    <div class="actions">
                        <asp:HyperLink ID="hplNewVouchar" runat="server" CssClass="btn btn-default btn-sm">
							<i class="fa fa-plus"></i>Add
                        </asp:HyperLink>

                        <a class="btn btn-sm btn-icon-only btn-default fullscreen" href="javascript:;" data-original-title="" title=""></a>
                    </div>
                </div>
                <div class="portlet-body">
                    <asp:UpdatePanel ID="upTransactions" runat="server">
                        <ContentTemplate>
                            <div class="table-responsive">
                                <asp:HiddenField ID="hfCurrentPage" runat="server" />
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>#
                                            </th>
                                            <th>Vouchar
                                            </th>
                                            <th>Date
                                            </th>
                                            <th class="col-md-6">Description
                                            </th>
                                            <th>Amount
                                            </th>
                                            <th>Created By
                                            </th>
                                            <th>Status
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:ListView ID="lvGrid" runat="server" OnItemCommand="lvGrid_ItemCommand">

                                            <ItemTemplate>
                                                <tr class="grid_first_row">
                                                    <td>
                                                        <asp:HiddenField ID="hfItem" runat="server" />
                                                        <asp:CheckBox ID="chkItem" runat="server" />
                                                    </td>
                                                    <td>

                                                        <asp:HyperLink ID="hplVouchar" runat="server" Text='<%# Eval("voucharNo").ToString() %>' NavigateUrl='<%# Get_Trans_Link(Convert.ToInt32(Eval("transGroupID"))) %>'></asp:HyperLink>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="ltrDate" runat="server" Text='<%# Convert.ToDateTime(Eval("transGroupCreatedOn")).ToString("MMM dd, yyyy") %>'></asp:Literal></td>
                                                    <td>
                                                        <asp:HyperLink ID="hplDescription" runat="server" Text='<%# Get_Description_Trimmed(Eval("transGroupTitle").ToString()) %>' NavigateUrl='<%# "~/FinApp/Vouchar_Edit.aspx?gid=" + Eval("transGroupId").ToString() %>'></asp:HyperLink>
                                                    </td>
                                                    <td class="align_right">
                                                        <asp:Literal ID="ltrAmount" runat="server" Text='<%# string.Format("{0:n0}", Convert.ToInt32(Eval("transGroupTotalAmount"))) %>'></asp:Literal></td>
                                                    <td>
                                                        <asp:Literal ID="ltrCreatedBy" runat="server" Text='<%# Eval("CreatedBy").ToString() %>'></asp:Literal></td>
                                                    <td>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("transGroupStatusTitle") %>' CssClass='<%# get_status_css(Convert.ToInt32(Eval("transGroupStatus"))) %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            
                                        </asp:ListView>
                                    </tbody>
                                </table>
                            </div>
                            <div class="row">
                                <div class="col-md-9">
                                    <div class="dataTables_paginate paging_simple_numbers align-reverse" id="sample_2_paginate">
                                        <ul class="pagination">
                                            <li class="paginate_button previous" aria-controls="sample_2" tabindex="0" id="sample_2_previous" runat="server">
                                                <asp:LinkButton ID="lbtnPrevious" runat="server" OnClick="Do_Pagination">
													<i class="fa fa-angle-left"></i>
                                                </asp:LinkButton>
                                            </li>

                                            <asp:Repeater ID="rptStartPaging" runat="server" OnItemCommand="Do_Pagination">
                                                <ItemTemplate>
                                                    <li class="paginate_button <%# Eval("selectedCSS").ToString() %>" aria-controls="sample_2" tabindex="0">
                                                        <asp:LinkButton ID="lbtnStartPage" runat="server" Text='<%# Eval("pageNo").ToString() %>' CommandArgument='<%# Eval("pageNo").ToString() %>'></asp:LinkButton>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                            <asp:Repeater ID="rptLastPages" runat="server">
                                                <ItemTemplate>
                                                    <li class="paginate_button" aria-controls="sample_2" tabindex="0">
                                                        <asp:LinkButton ID="lbtnStartPage" runat="server" Text='<%# Eval("pageNo").ToString() %>'></asp:LinkButton>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                            <li class="paginate_button next" aria-controls="sample_2" tabindex="0" id="sample_2_next" runat="server">
                                                <asp:LinkButton ID="lbtnNext" runat="server" OnClick="Do_Pagination">
													<i class="fa fa-angle-right"></i>
                                                </asp:LinkButton>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="dataTables_length" id="sample_1_length">
                                        <label>
                                            Show
											<asp:DropDownList ID="ddlPaginationRows" runat="server" aria-controls="sample_1" class="form-control input-xsmall input-inline" OnSelectedIndexChanged="Do_Pagination" AutoPostBack="true">
                                                <asp:ListItem Text="10" Value="10" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                            </asp:DropDownList>
                                            Transacations</label>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <!-- END SAMPLE TABLE PORTLET-->

        </div>
    </div>
    <!-- END PAGE CONTENT-->





    <section class="body_content" style="display: none;">
        <div class="body_heading_strip">
            <h1></h1>

            <div class="body_heading_menu">
                <ul>
                    <li></li>
                </ul>
            </div>
            <div class="clr"></div>
        </div>

        <asp:UpdatePanel ID="upTrans" runat="server">
            <ContentTemplate>
                <div class="control_block">
                    <div class="filter_container">
                        <table>
                            <tbody>
                                <tr>
                                    <td class="title_cell">From
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbFromDate" runat="server" CssClass="tb_border tb_main tb_padding" Width="100px"></asp:TextBox>
                                        <asp:CalendarExtender ID="tbFromDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="tbFromDate"></asp:CalendarExtender>
                                    </td>
                                    <td class="title_cell">To
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbToDate" runat="server" CssClass="tb_border tb_main tb_padding" Width="100px"></asp:TextBox>
                                        <asp:CalendarExtender ID="tbToDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="tbToDate"></asp:CalendarExtender>
                                    </td>
                                    <td class="title_cell">Description
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbDescription" runat="server" CssClass="tb_border tb_main tb_padding" Width="200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnFilter" runat="server" CssClass="tb_padding" Text="Filter" OnClick="btnFilter_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>
