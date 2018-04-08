<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.Master" AutoEventWireup="true" CodeBehind="Accounts.aspx.cs" Inherits="FinPro.FinApp.Accounts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
    <h3 class="page-title">Chart of Accounts
    </h3>

    <asp:UpdatePanel ID="upGrid" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN SAMPLE TABLE PORTLET-->
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-cogs"></i>Active Accounts
                            </div>

                            <div class="tools">
                                <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                            </div>

                            <div class="actions">
                                <asp:HyperLink ID="hplNewAccount" runat="server" CssClass="btn btn-default btn-sm">
							        <i class="fa fa-plus"></i>Add
                                </asp:HyperLink>

                                <a class="btn btn-sm btn-icon-only btn-default fullscreen" href="javascript:;" data-original-title="" title=""></a>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <asp:Repeater ID="rptAccountCategories" runat="server" OnItemCommand="rptAccountCategories_ItemCommand" OnItemDataBound="rptAccountCategories_ItemDataBound">
                                <HeaderTemplate>
                                    <ul class="tree_ul">
                                </HeaderTemplate>

                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <li id="<%# "li" + rand %>" class="tree_li tree_expand">
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# string.Format("javascript:treeClicked(\"{0}\")", rand) %>' Text='<%# Eval("accCatTitle").ToString() %>'></asp:HyperLink>
                                        <asp:Repeater ID="rptAccounts" runat="server" DataSource='<%# Get_Accounts(Convert.ToInt32(Eval("accCatID"))) %>' OnItemCommand="rptAccountCategories_ItemCommand" OnItemDataBound="rptAccountCategories_ItemDataBound">
                                            <HeaderTemplate>
                                                <ul id="<%# rand %>" style="display: none;">
                                            </HeaderTemplate>
                                            <FooterTemplate>
                                                </ul>
                                            </FooterTemplate>
                                            <ItemTemplate>
                                                <li id="<%# "li" + rand1 %>" class="tree_li tree_expand">
                                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# string.Format("javascript:treeClicked(\"{0}\")", rand1) %>' Text='<%# "-" + Eval("accountTitle").ToString() %>'></asp:HyperLink>
                                                    <asp:LinkButton ID="lbtnAddSubAccount" runat="server" CssClass="small_btn_accounts" CommandName="addchildaccount" CommandArgument='<%# Eval("accountId").ToString() %>' Visible='<%# CanHaveChild(Convert.ToInt32(Eval("accountId").ToString())) %>'>Add Child Account</asp:LinkButton>
                                                    <asp:Repeater ID="rptAccounts" runat="server" DataSource='<%# Get_Child_Accounts(Convert.ToInt32(Eval("accountId"))) %>' OnItemCommand="rptAccountCategories_ItemCommand" OnItemDataBound="rptAccountCategories_ItemDataBound">
                                                        <HeaderTemplate>
                                                            <ul id="<%# rand1 %>" style="display: none;">
                                                        </HeaderTemplate>
                                                        <FooterTemplate>
                                                            </ul>
                                                        </FooterTemplate>
                                                        <ItemTemplate>
                                                            <li id="<%# "li" + rand2 %>" class="tree_li tree_expand">
                                                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# string.Format("javascript:treeClicked(\"{0}\")", rand2) %>' Text='<%# "--" + Eval("accountTitle").ToString() %>'></asp:HyperLink>
                                                                <asp:LinkButton ID="lbtnAddSubAccount" runat="server" CssClass="small_btn_accounts" CommandName="addchildaccount" CommandArgument='<%# Eval("accountId").ToString() %>' Visible='<%# CanHaveChild(Convert.ToInt32(Eval("accountId").ToString())) %>'>Add Child Account</asp:LinkButton>
                                                                <asp:Repeater ID="rptAccounts" runat="server" DataSource='<%# Get_Child_Accounts(Convert.ToInt32(Eval("accountId"))) %>' OnItemCommand="rptAccountCategories_ItemCommand" OnItemDataBound="rptAccountCategories_ItemDataBound">
                                                                    <HeaderTemplate>
                                                                        <ul id="<%# rand2 %>" style="display: none;">
                                                                    </HeaderTemplate>
                                                                    <FooterTemplate>
                                                                        </ul>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <li id="<%# "li" + rand3 %>" class="tree_li tree_expand">
                                                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# string.Format("javascript:treeClicked(\"{0}\")", rand3) %>' Text='<%# "---" + Eval("accountTitle").ToString() %>'></asp:HyperLink>
                                                                            <asp:LinkButton ID="lbtnAddSubAccount" runat="server" CssClass="small_btn_accounts" CommandName="addchildaccount" CommandArgument='<%# Eval("accountId").ToString() %>' Visible='<%# CanHaveChild(Convert.ToInt32(Eval("accountId").ToString())) %>'>Add Child Account</asp:LinkButton>
                                                                            <asp:Repeater ID="rptAccounts" runat="server" DataSource='<%# Get_Child_Accounts(Convert.ToInt32(Eval("accountId"))) %>' OnItemCommand="rptAccountCategories_ItemCommand" OnItemDataBound="rptAccountCategories_ItemDataBound">
                                                                                <HeaderTemplate>
                                                                                    <ul id="<%# rand3 %>" style="display: none;">
                                                                                </HeaderTemplate>
                                                                                <FooterTemplate>
                                                                                    </ul>
                                                                                </FooterTemplate>
                                                                                <ItemTemplate>
                                                                                    <li id="<%# "li" + rand4 %>" class="tree_li tree_expand">
                                                                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# string.Format("javascript:treeClicked(\"{0}\")", rand4) %>' Text='<%# "----" + Eval("accountTitle").ToString() %>'></asp:HyperLink>
                                                                                    </li>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>
                                                                        </li>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
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


            <asp:ModalPopupExtender ID="mpeNewAccount" runat="server" PopupControlID="pnlNewAccount" CancelControlID="lbtnModalClose" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="hplNewAccount"></asp:ModalPopupExtender>
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
                <asp:UpdatePanel ID="upAccountEditor" runat="server">
                    <ContentTemplate>
                        <div class="modal_body control_block">
                            <asp:HiddenField ID="hfAccountId" runat="server" />
                            <div class="col-md-13 form-group">
                                <label>Account Category</label>
                                <asp:DropDownList ID="ddlEditCategory" runat="server" CssClass="form-control" DataTextField="accCatTitle" DataValueField="accCatId" AutoPostBack="true" OnSelectedIndexChanged="ddlEditCategory_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <div class="col-md-13 form-group">
                                <label>Control Account</label>
                                <asp:DropDownList ID="ddlParentAccount" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>

                            <div class="form-group col-md-13">
                                <label>New Account</label>
                                <asp:TextBox ID="tbEditTitle" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group col-md-13">
                                <label>Account Description</label>
                                <asp:TextBox ID="tbEditDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" data-dismiss="modal" class="btn btn-default">Close</button>
                            <asp:LinkButton ID="lbtnSubmit" runat="server" CssClass="btn blue" OnClick="lbtnSubmit_Click">Submit</asp:LinkButton>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
