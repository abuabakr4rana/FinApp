<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.Master" AutoEventWireup="true" CodeBehind="Entities.aspx.cs" Inherits="FinPro.FinApp.Entities" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="cContent" ContentPlaceHolderID="cphBody" runat="server">
    
    <asp:ScriptManager ID="smPage" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upGrid" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <section class="body_content">
                <div class="body_heading_strip">
                    <h1>Entities
                    </h1>

                    <div class="body_heading_menu">
                        <ul>
                            <li>
                                <asp:LinkButton ID="lbtnNew" runat="server">New Entity</asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                    <div class="clr"></div>
                </div>
                <telerik:RadNotification ID="rnNotify" runat="server" VisibleOnPageLoad="false" AutoCloseDelay="100000"
                    Width="330" Height="100" Animation="Fade" EnableRoundedCorners="true" EnableShadow="true"
                    Title="Notification" Style="z-index: 35000" Skin="Glow">
                </telerik:RadNotification>


                <asp:ModalPopupExtender ID="mpeNewAccount" runat="server" PopupControlID="pnlNew" CancelControlID="lbtnModalClose" BackgroundCssClass="modalBackground" DropShadow="true" TargetControlID="lbtnNew"></asp:ModalPopupExtender>
                <asp:Panel ID="pnlNew" runat="server" CssClass="model_popup">
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
                            <div class="modal_body">
                                <asp:HiddenField ID="hfAccountId" runat="server" />
                                <table>
                                    <tr>
                                        <td>Account Category</td>
                                        <td>
                                            <asp:DropDownList ID="ddlEditCategory" runat="server" CssClass="ddl_padding ddl_border ddl_generic" DataTextField="accCatTitle" DataValueField="accCatId" AutoPostBack="true" OnSelectedIndexChanged="ddlEditCategory_SelectedIndexChanged"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td>Control Account</td>
                                        <td>
                                            <asp:DropDownList ID="ddlParentAccount" runat="server" CssClass="ddl_padding ddl_border ddl_generic" Width="280px"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>New Account</td>
                                        <td>
                                            <asp:TextBox ID="tbEditTitle" runat="server" CssClass="tb_border tb_padding tb_generic"></asp:TextBox></td>
                                    </tr>

                                    <tr>
                                        <td valign="top">Account Description</td>
                                        <td>
                                            <asp:TextBox ID="tbEditDescription" runat="server" CssClass="tb_border tb_padding tb_generic" TextMode="MultiLine" Width="280px"></asp:TextBox></td>
                                    </tr>
                                    <tr runat="server" id="tr_usability">
                                        <td>Usability</td>
                                        <td>
                                            <asp:RadioButtonList ID="rblUsability" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="0">Unofficial</asp:ListItem>
                                                <asp:ListItem Value="1">Both</asp:ListItem>
                                                <asp:ListItem Value="2">Official Only</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td height="30px">
                                            <asp:LinkButton ID="lbtnSubmit" runat="server" CssClass="lbtn_form" OnClick="lbtnSubmit_Click">Submit</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>

                <div class="control_block">

                    <div class="grid_container">
                        <table cellspacing="0">
                            <thead>
                                <tr>
                                    <td>Type</td>
                                    <td>Title</td>
                                    <td>Description</td>
                                    <td></td>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="lvGrid" runat="server">
                                    <ItemTemplate>
                                        <tr class="grid_first_row">
                                            <td>
                                                <asp:Literal ID="ltrEntityType" runat="server" Text='<%# Eval("entityType").ToString() %>'></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="ltrEntityTitle" runat="server" Text='<%# Eval("entityTitle").ToString() %>'></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal ID="ltrEntityDescription" runat="server" Text='<%# Eval("entityDescription").ToString() %>'></asp:Literal>
                                            </td>
                                            <td></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </tbody>
                        </table>

                    </div>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
