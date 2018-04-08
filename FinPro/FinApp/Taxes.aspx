<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.Master" AutoEventWireup="true" CodeBehind="Taxes.aspx.cs" Inherits="FinPro.FinApp.Taxes" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="cContent" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="smPage" runat="server"></asp:ScriptManager>
    <script>
        function treeClicked(ctrl) {
            var ulObject = document.getElementById(ctrl);
            var liObject = document.getElementById("li" + ctrl);
            if (ulObject.style.display == "none") {
                ulObject.style.display = "block";
                liObject.className = "tree_li tree_collapse";
            }
            else {
                ulObject.style.display = "none";
                liObject.className = "tree_li tree_expand";
            }
        }
    </script>
    <!-- BEGIN PAGE HEADER-->
    <h3 class="page-title">Tax Rates
    </h3>

    <asp:UpdatePanel ID="upGrid" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN SAMPLE TABLE PORTLET-->
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-pie-chart"></i>Taxes
                            </div>

                            <div class="actions">
                                <asp:HyperLink ID="hplNewAccount" runat="server" CssClass="btn btn-default btn-sm">
							        <i class="fa fa-plus"></i>Add Tax
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
                                            <th class="col-md-1">Tax Title
                                            </th>
                                            <th class="col-md-2">Amount
                                            </th>
                                            <th class="col-md-9">Description
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:ListView ID="lvGrid" runat="server" OnItemCommand="lvGrid_ItemCommand">
                                            <ItemTemplate>
                                                <tr class="grid_first_row">
                                                    <td>
                                                        <asp:HiddenField ID="hfTaxId" runat="server" />
                                                        <asp:LinkButton ID="lbtnTaxTtile" runat="server" Text='<%# Eval("taxTitle").ToString() %>' CommandName="change" CommandArgument='<%# Eval("taxId").ToString() %>'></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="ltrTaxAmount" runat="server" Text='<%# Convert.ToDecimal(Eval("taxValue")).ToString("0.00") + TaxUnit(Convert.ToBoolean(Eval("taxTypeIsPercent"))) %>'></asp:Literal>
                                                    </td>
                                                   
                                                    <td>
                                                        <asp:Literal ID="ltrTaxDescription" runat="server" Text='<%# Eval("taxTransNarration").ToString() %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </tbody>
                                </table>
                            </div>
                           
                        </ContentTemplate>
                    </asp:UpdatePanel>
                        </div>
                    </div>
                    <!-- END SAMPLE TABLE PORTLET-->
                </div>
            </div>
            <!-- END PAGE CONTENT-->

            <telerik:RadNotification ID="rnNotify" runat="server" VisibleOnPageLoad="false" AutoCloseDelay="100000"
                Width="330" Height="100" Animation="Fade" EnableRoundedCorners="true" EnableShadow="true"
                Title="Notification" Style="z-index: 35000" Skin="Glow">
            </telerik:RadNotification>
       

            <ajaxToolkit:ModalPopupExtender ID="mpeNewAccount" runat="server" PopupControlID="pnlNewAccount" CancelControlID="lbtnModalClose" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="hplNewAccount"></ajaxToolkit:ModalPopupExtender>

            <asp:Panel ID="pnlNewAccount" runat="server" CssClass="model_popup modal-dialog" Width="500">
                <div class="modal_header">
                    <div class="modal_header_title">
                        Tax Editor
                    </div>
                    <div class="modal_header_close">
                        <asp:LinkButton ID="lbtnModalClose" runat="server">
                            <asp:Image ID="imgClose" runat="server" ImageUrl="~/Images/close_summary.png" />
                        </asp:LinkButton>
                    </div>
                    <div class="clr"></div>
                </div>
                <asp:UpdatePanel ID="upAccountEditor" runat="server">
                    <ContentTemplate>
                        <div class="modal_body control_block">
                            <asp:HiddenField ID="hfTaxId" runat="server" />
                            <div class="col-md-13 form-group">
                                <label>Tax Type</label>
                                <asp:DropDownList ID="ddlTaxType" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">Amount</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="1">Percentage</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-md-13">
                                <label>Tax Amount</label>
                                <asp:TextBox ID="tbTaxValue" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-13">
                                <label>Tax Title</label>
                                <asp:TextBox ID="tbTaxTitle" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-13">
                                <label>Description</label>
                                <asp:TextBox ID="tbTaxDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="lbtnSubmit" runat="server" CssClass="btn blue" OnClick="lbtnSubmit_Click">Submit</asp:LinkButton>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
