<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.Master" AutoEventWireup="true" CodeBehind="Vendor_Edit.aspx.cs" Inherits="FinPro.FinApp.Vendor_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">

    <asp:ScriptManager ID="smPage" runat="server" ValidateRequestMode="Disabled"></asp:ScriptManager>
    <section class="body_content">
        <div class="body_heading_strip">
            <h1>
                <asp:Literal ID="ltrTitle" runat="server">Vendor Editor</asp:Literal>
            </h1>

            <div class="clr"></div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <!-- BEGIN Portlet PORTLET-->

                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            Vendors
                        </div>
                        <div class="actions">
                            <asp:HyperLink ID="HyperLink1" CssClass="btn btn-default btn-sm" runat="server" NavigateUrl="~/FinApp/Vendors.aspx">
                            <i class="fa fa-arrow-left"></i>Back to Vendors
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
                                                <label>Vendor Title</label>
                                                <asp:TextBox ID="tbVendorTitle" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Vendor Code</label>
                                                <asp:TextBox ID="tbVendorCode" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>First Name</label>
                                                <asp:TextBox ID="tbVendorFirstName" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Last Name</label>
                                                <asp:TextBox ID="tbVendorLastName" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>

                                        </div>
                                        <div class="row">

                                            <div class="form-group col-md-6">
                                                <label>Vendor URL</label>
                                                <asp:TextBox ID="tbVendorURL" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-6">
                                                <label>Description</label>
                                                <asp:TextBox ID="tbVendorDescription" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="row">

                                            <div class="form-group col-md-6">
                                                <label>Street Address</label>
                                                <asp:TextBox ID="tbVendorAddressLine1" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-6">
                                                <label>Street Address 2</label>
                                                <asp:TextBox ID="tbVendorAddressLine2" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>

                                        </div>
                                        <div class="row">
                                            <div class="form-group col-md-3">
                                                <label>Email</label>
                                                <asp:TextBox ID="tbVendorEmail" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Alternate Email</label>
                                                <asp:TextBox ID="tbVendorAltEmail" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Phone No.</label>
                                                <asp:TextBox ID="tbVendorPhone" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Alternate Phone No.</label>
                                                <asp:TextBox ID="tbVendorAltPhone" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>

                                        </div>
                                        <div class="row">

                                            <div class="form-group col-md-3">
                                                <label>State</label>
                                                <asp:TextBox ID="tbVendorState" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Zip Code</label>
                                                <asp:TextBox ID="tbVendorZip" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Country</label>
                                                <asp:TextBox ID="tbVendorCountry" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group col-md-3">
                                                <label>Minimum Quantity</label>
                                                <asp:TextBox ID="tbVendorMinQty" runat="server" CssClass="form-control"></asp:TextBox>

                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Maximum Quantity</label>
                                                <asp:TextBox ID="tbVendorMaxQty" runat="server" CssClass="form-control"></asp:TextBox>

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
