<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.Master" AutoEventWireup="true" CodeBehind="Cheque_Printing.aspx.cs" Inherits="FinPro.FinApp.Cheque_Printing" %>

<asp:Content ID="cContent" ContentPlaceHolderID="cphBody" runat="server">


    <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbtnAddVouchar_Click" ValidationGroup="Create">Create Vouchar</asp:LinkButton>--%>
    <asp:ScriptManager ID="smPage" runat="server"></asp:ScriptManager>
    <section class="body_content">
        <div class="body_heading_strip">
            <h3 class="page-title">
                <asp:Literal ID="ltrTitle" runat="server">Cheque Printing Editor</asp:Literal>
            </h3>

            <div class="clr"></div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <!-- BEGIN Portlet PORTLET-->
                <div class="portlet box blue">
                    <div class="portlet-title">
                        <div class="caption">
                            Cheque Details
                        </div>
                        <div class="actions">
                            <asp:HyperLink ID="hplHeaderBack" runat="server" CssClass="btn btn-default btn-sm" NavigateUrl="~/FinApp/Transactions.aspx">
                            <i class="fa fa-arrow-left"></i>Back to Transactions
                            </asp:HyperLink>
                            <a class="btn btn-sm btn-icon-only btn-default fullscreen" href="javascript:;" data-original-title="" title=""></a>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="control_block">

                            <asp:UpdatePanel ID="upGrid" runat="server">
                                <ContentTemplate>
                                    <telerik:RadNotification ID="rnNotify" runat="server" VisibleOnPageLoad="false" AutoCloseDelay="100000"
                                        Width="330" Height="100" Animation="Fade" EnableRoundedCorners="true" EnableShadow="true"
                                        Title="Notification" Style="z-index: 35000" Skin="Glow">
                                    </telerik:RadNotification>

                                    <div class="grid_top">

                                        <div class="row">
                                            <div class="form-group col-md-3">
                                                <label>Bank</label>
                                                <asp:DropDownList ID="ddlBankAccount" runat="server" CssClass="form-control">
                                                    <asp:ListItem Selected="True" Value="1">Bank Alfalah</asp:ListItem>
                                                    <asp:ListItem Value="2">United Bank</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <div class="form-group col-md-3">
                                                <label>Cheque Date</label>
                                                <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="chequeDate" ErrorMessage="*" ForeColor="Red" ValidationGroup="Create"></asp:RequiredFieldValidator>
                                                <div class="input-group input-medium date date-picker">
                                                    <asp:TextBox ID="chequeDate" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <span class="input-group-btn">
                                                        <button class="btn default date-set" type="button">
                                                            <i class="fa fa-calendar"></i>
                                                        </button>
                                                    </span>
                                                </div>



                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group col-md-6">
                                                <label>Cheque Title</label>
                                                <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ErrorMessage="*" ControlToValidate="tbChequeTitle" ValidationGroup="Create" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:TextBox ID="tbChequeTitle" runat="server" CssClass="form-control" ValidationGroup="Create"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Cheque No</label>
                                                <asp:TextBox ID="tbChequeNo" runat="server" CssClass="form-control" ValidationGroup="Create"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group col-md-3">
                                                <label>Amount</label>
                                                <asp:TextBox ID="tbChequeAmount" runat="server" CssClass="form-control" ValidationGroup="Create"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-6">
                                                <label>Amount in Words</label>
                                                <asp:TextBox ID="tbChequeAmountInWords" runat="server" CssClass="form-control" ValidationGroup="Create"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="form-group col-md-3">
                                                <label>Receiver Name</label>
                                                <asp:TextBox ID="tbChequeReceiverName" runat="server" CssClass="form-control" ValidationGroup="Create"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Receiver Phone</label>
                                                <asp:TextBox ID="tbChequeReceiverPhone" runat="server" CssClass="form-control" ValidationGroup="Create"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-3">
                                                <label>Receiver CNIC</label>
                                                <asp:TextBox ID="tbChequeReceiverCNIC" runat="server" CssClass="form-control" ValidationGroup="Create"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="form-group col-md-2">
                                                <asp:Button ID="btnCreateCheque" CssClass="btn blue" runat="server" Text="Create Cheque" OnClick="btnCreateCheque_Click" />
                                            </div>
                                        </div>

                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <!-- END CONTROL BLOCK -->
                    </div>
                </div>
            </div>
        </div>

    </section>
</asp:Content>
