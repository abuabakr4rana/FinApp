<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="FinPro.FinApp.Departments" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="cContent" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="smPage" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upGrid" runat="server">
        <ContentTemplate>
            <section class="body_content">
                <div class="body_heading_strip">
                    <h3 class="page-title">Departments
                    </h3>


                    <div class="clr"></div>
                </div>
                <telerik:RadNotification ID="rnNotify" runat="server" VisibleOnPageLoad="false" AutoCloseDelay="100000"
                    Width="330" Height="100" Animation="Fade" EnableRoundedCorners="true" EnableShadow="true"
                    Title="Notification" Style="z-index: 35000" Skin="Glow">
                </telerik:RadNotification>

                <asp:ModalPopupExtender ID="mpeNewAccount" runat="server" PopupControlID="pnlNewAccount" CancelControlID="lbtnModalClose" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="lbtnNewDepartment"></asp:ModalPopupExtender>

                <asp:Panel ID="pnlNewAccount" runat="server" CssClass="model_popup modal-dialog" Width="500">

                    <div class="modal_header">
                        <div class="modal_header_title">
                            <asp:Literal ID="ltrModalTitle" runat="server"></asp:Literal>
                        </div>
                        <div class="modal_header_close">
                            <asp:LinkButton ID="lbtnModalClose" runat="server">
                                <asp:Image ID="imgClose" runat="server" ImageUrl="~/Images/close_summary.png" />
                            </asp:LinkButton>
                        </div>
                        <div class="clr"></div>
                    </div>

                    <div class="modal_body">

                        <div class="row">
                            <div class="form-group col-md-12">
                                <label>Department Code</label>
                                <asp:HiddenField ID="hfDeptId" runat="server" />
                                <asp:TextBox ID="tbDeptCode" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label>Department Title</label>
                                <asp:TextBox ID="tbDeptTitle" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group col-md-12">
                                <label>Department Description</label>
                                <asp:TextBox ID="tbDeptDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" data-dismiss="modal" class="btn btn-default">Close</button>
                        <asp:LinkButton ID="lbtnSubmit" runat="server" CssClass="btn blue" OnClick="lbtnSubmit_Click">Submit</asp:LinkButton>
                    </div>

                </asp:Panel>


                <!-- BEGIN PAGE CONTENT-->
                <div class="row">
                    <div class="col-md-12">
                        <!-- BEGIN SAMPLE TABLE PORTLET-->
                        <div class="portlet box blue">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="fa fa-cogs"></i>Departments
                                </div>
                                <div class="actions">
                                    <asp:LinkButton ID="lbtnNewDepartment" CssClass="btn btn-default btn-sm" runat="server"><i class="fa fa-plus"></i>New Department</asp:LinkButton>

                                    <a class="btn btn-sm btn-icon-only btn-default fullscreen" href="javascript:;" data-original-title="" title=""></a>
                                </div>
                            </div>
                            <div class="portlet-body">

                                <div class="control_block">
                                    <div>
                                        <asp:Repeater ID="rptDepatments" runat="server" OnItemCommand="rptDepatments_ItemCommand">
                                            <HeaderTemplate>
                                                <table class="table table-striped table-bordered table-hover">
                                                    <thead>
                                                        <tr>
                                                            <th>Code</th>
                                                            <th>Department Title</th>
                                                            <th>Description</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>

                                            <FooterTemplate>
                                                </tbody>
								            </table>
                                            </FooterTemplate>

                                            <ItemTemplate>
                                                <tr class="grid_first_row">
                                                    <td>
                                                        <asp:LinkButton ID="lbtnDeptCode" runat="server" data-toggle="modal" Text='<%# Eval("deptCode").ToString() %>' CommandName="edit_item" CommandArgument='<%# Eval("deptId").ToString() %>'></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="ltrDeptTitle" runat="server" Text='<%# Eval("deptTitle").ToString() %>'></asp:Literal></td>
                                                    <td>
                                                        <asp:Literal ID="ltrDeptDesc" runat="server" Text='<%# Eval("deptDesc").ToString() %>'></asp:Literal></td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="grid_alt_row">
                                                    <td>
                                                        <asp:LinkButton ID="lbtnDeptCode" runat="server" data-toggle="modal" Text='<%# Eval("deptCode").ToString() %>' CommandName="edit_item" CommandArgument='<%# Eval("deptId").ToString() %>'></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="ltrDeptTitle" runat="server" Text='<%# Eval("deptTitle").ToString() %>'></asp:Literal></td>
                                                    <td>
                                                        <asp:Literal ID="ltrDeptDesc" runat="server" Text='<%# Eval("deptDesc").ToString() %>'></asp:Literal></td>
                                                </tr>
                                            </AlternatingItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
