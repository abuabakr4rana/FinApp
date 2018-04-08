<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.Master" AutoEventWireup="true" CodeBehind="Vendors.aspx.cs" Inherits="FinPro.FinApp.Vendors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">

    <asp:ScriptManager ID="smPage" runat="server"></asp:ScriptManager>
    <section class="body_content">
        <div class="body_heading_strip">
            <h3 class="page-title">
                <asp:Literal ID="ltrTitle" runat="server">Vendors</asp:Literal>
            </h3>

            <div class="clr"></div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <!-- BEGIN Portlet PORTLET-->
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            List of Vendors
                        </div>
                        <div class="actions">
                            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-default btn-sm" NavigateUrl="~/FinApp/Vendor_Edit.aspx">
                            <i class="fa fa-plus"></i>New Vendor
                            </asp:HyperLink>

                            <a class="btn btn-sm btn-icon-only btn-default fullscreen" href="javascript:;" data-original-title="" title=""></a>
                        </div>
                    </div>
                    <div class="portlet-body">

                        <div class="row">
                            <div class="col-md-12">
                                <div class="control_block">

                                    <asp:UpdatePanel ID="upTrans" runat="server">
                                        <ContentTemplate>
                                            <div class="control_block">


                                                <div class="grid_container">
                                                    <asp:HiddenField ID="hfCurrentPage" runat="server" />
                                                    <table cellspacing="0" class="table">
                                                        <thead>
                                                            <tr>
                                                                <td width="200px">Vendor Title</td>
                                                                <td width="100px">Vendor Code</td>
                                                                <td width="170px">Vendor Name</td>
                                                                <td width="150px">Phone</td>
                                                            </tr>
                                                        </thead>
                                                        <tbody>

                                                            <asp:ListView ID="lvGrid" runat="server">

                                                                <ItemTemplate>
                                                                    <tr class="grid_first_row">
                                                                        <td>
                                                                            <asp:HyperLink ID="hplVendorTitle" runat="server" NavigateUrl='<%# "~/FinApp/Vendor_Edit.aspx?id=" + Eval("vendorId").ToString() %>' Text='<%# Eval("vendorTitle").ToString() %>'></asp:HyperLink>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Literal ID="ltrVendorCode" runat="server" Text='<%# Eval("vendorCode").ToString() %>'></asp:Literal>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Literal ID="ltrVendorName" runat="server" Text='<%# Eval("vendorFirstName").ToString() + " " + Eval("vendorLastName").ToString() %>'></asp:Literal>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Literal ID="ltrPhone" runat="server" Text='<%# Eval("vendorPhone").ToString() %>'></asp:Literal>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <AlternatingItemTemplate>
                                                                    <tr class="grid_alt_row">
                                                                        <td>
                                                                            <asp:HyperLink ID="hplVendorTitle" runat="server" NavigateUrl='<%# "~/FinApp/Vendor_Edit.aspx?id=" + Eval("vendorId").ToString() %>' Text='<%# Eval("vendorTitle").ToString() %>'></asp:HyperLink>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Literal ID="ltrVendorCode" runat="server" Text='<%# Eval("vendorCode").ToString() %>'></asp:Literal>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Literal ID="ltrVendorName" runat="server" Text='<%# Eval("vendorFirstName").ToString() + " " + Eval("vendorLastName").ToString() %>'></asp:Literal>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Literal ID="ltrPhone" runat="server" Text='<%# Eval("vendorPhone").ToString() %>'></asp:Literal>
                                                                        </td>
                                                                    </tr>
                                                                </AlternatingItemTemplate>
                                                            </asp:ListView>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <!-- End Control Block -->
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
                                        Vendors</label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END Portlet PORTLET-->
                </div>
            </div>
        </div>
    </section>

</asp:Content>
