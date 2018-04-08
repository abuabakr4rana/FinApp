<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.Master" AutoEventWireup="true" CodeBehind="Customer_New.aspx.cs" Inherits="FinPro.FinApp.Customer_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">

    <asp:ScriptManager ID="smPage" runat="server" ValidateRequestMode="Disabled"></asp:ScriptManager>
    <section class="body_content">
        <div class="body_heading_strip">
            <h3 class="page-title">
                <asp:Literal ID="ltrTitle" runat="server">Customer Editor</asp:Literal>

            </h3>

            <div class="clr"></div>

        </div>
        <div class="row">
            <div class="col-md-12">
                <!-- BEGIN Portlet PORTLET-->

                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            Customer
                        </div>
                        <div class="actions">
                            <asp:HyperLink ID="hplBack" CssClass="btn btn-default btn-sm" runat="server" NavigateUrl="~/FinApp/Customers.aspx">
                            <i class="fa fa-arrow-left"></i>Back to Customers
                            </asp:HyperLink>

                            <a class="btn btn-sm btn-icon-only btn-default fullscreen" href="javascript:;" data-original-title="" title=""></a>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="control_block">
                            <asp:UpdatePanel ID="upTrans" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="control_block">

                                        <telerik:RadNotification ID="rnNotify" runat="server" VisibleOnPageLoad="false" AutoCloseDelay="100000"
                                            Width="330" Height="100" Animation="Fade" EnableRoundedCorners="true" EnableShadow="true"
                                            Title="Notification" Style="z-index: 35000" Skin="Glow">
                                        </telerik:RadNotification>

                                        <div class="row">
                                            <div class="form-group col-md-3">
                                                <label>Customer Title</label>
                                                <asp:TextBox ID="tbCustomerTitle" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Customer Code</label>
                                                <asp:TextBox ID="tbCustomerCode" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>First Name</label>
                                                <asp:TextBox ID="tbCustomerFirstName" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Last Name</label>
                                                <asp:TextBox ID="tbCustomerLastName" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>

                                        </div>
                                        <div class="row">

                                            <div class="form-group col-md-6">
                                                <label>Customer URL</label>
                                                <asp:TextBox ID="tbCustomerURL" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-6">
                                                <label>Description</label>
                                                <asp:TextBox ID="tbCustomerDescription" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="row">

                                            <div class="form-group col-md-6">
                                                <label>Street Address</label>
                                                <asp:TextBox ID="tbCustomerAddressLine1" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-6">
                                                <label>Street Address 2</label>
                                                <asp:TextBox ID="tbCustomerAddressLine2" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="form-group col-md-3">
                                                <label>Email</label>
                                                <asp:TextBox ID="tbCustomerEmail" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Alternate Email</label>
                                                <asp:TextBox ID="tbCustomerAltEmail" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Phone No.</label>
                                                <asp:TextBox ID="tbCustomerPhone" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Alternate Phone No.</label>
                                                <asp:TextBox ID="tbCustomerAltPhone" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>

                                        </div>
                                        <div class="row">

                                            <div class="form-group col-md-3">
                                                <label>State</label>
                                                <asp:TextBox ID="tbCustomerState" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Zip Code</label>
                                                <asp:TextBox ID="tbCustomerZip" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Country</label>
                                                <asp:TextBox ID="tbCustomerCountry" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group col-md-3">
                                                <label>Minimum Quantity</label>
                                                <asp:TextBox ID="tbCustomerMinQty" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Maximum Quantity</label>
                                                <asp:TextBox ID="tbCustomerMaxQty" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Status</label>
                                                <asp:RadioButtonList ID="rblStatus" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="0">Inactive &nbsp &nbsp</asp:ListItem>
                                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group col-md-1">
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn" OnClick="btnSubmit_Click" Text="Submit" />

                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <!-- End Control Block -->
                    </div>
                </div>
                <!-- END Portlet PORTLET-->
            </div>
        </div>
    </section>

</asp:Content>
