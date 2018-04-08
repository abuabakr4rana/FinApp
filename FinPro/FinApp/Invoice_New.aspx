<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.Master" AutoEventWireup="true" CodeBehind="Invoice_New.aspx.cs" Inherits="FinPro.FinApp.Invoice_New" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="cContent" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="smPage" runat="server"></asp:ScriptManager>
    <%--<asp:ToolkitScriptManager ID="tsmPage" runat="server"></asp:ToolkitScriptManager>--%>

    <!-- BEGIN PAGE HEADER-->
    <h3 class="page-title">Invoices<small><asp:Literal ID="ltrDetails" runat="server"></asp:Literal></small>
    </h3>

    <!-- END PAGE HEADER-->
    <div class="row">
        <div class="col-md-12">

            <asp:UpdatePanel ID="upTransaction" runat="server">
                <ContentTemplate>
                    <telerik:RadNotification ID="rnNotify" runat="server" VisibleOnPageLoad="false" AutoCloseDelay="100000"
                        Width="330" Height="150" Animation="Fade" EnableRoundedCorners="true" EnableShadow="true"
                        Title="Notification" Style="z-index: 35000" Skin="Glow">
                    </telerik:RadNotification>

                    <!-- BEGIN SAMPLE FORM PORTLET-->
                    <div class="portlet light bordered">
                        <div class="portlet-title">
                            <div class="caption font-red-sunglo">
                                <span class="caption-subject bold uppercase">
                                    <asp:Literal ID="ltrTitle" runat="server">New Invoice</asp:Literal></span>
                            </div>
                        </div>
                        <div class="portlet-body form">

                            <div class="form-body">
                                <div class="row">
                                    <div class="col-md-4" runat="server" id="tr_branchField">
                                        <div class="form-group form-md-line-input has-info">
                                            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control"></asp:DropDownList>
                                            <label for="ddlDepartment">Client</label>
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group form-md-line-input has-success">
                                            <div class="input-icon datepicker" id="datetimepicker1" data-date="12-02-2012" data-date-format="dd-mm-yyyy">
                                                <asp:TextBox ID="tbDate" runat="server" CssClass="form-control" placeholder="Click Here" TextMode="Date"></asp:TextBox>
                                                <label for="form_control_1">Date</label>
                                                <span class="help-block">Select Vouchar Date</span>
                                                <i class="fa fa-calendar"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group form-md-line-input has-success">
                                            <div class="input-icon">
                                                <asp:TextBox ID="tbRefId" runat="server" CssClass="form-control" Placeholder="Number or Code"></asp:TextBox>
                                                <label for="form_control_1">PO Number</label>
                                                <span class="help-block">Number or Code that represents this vouchar.</span>
                                                <i class="fa fa-file-text"></i>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                </div>

                                <div class="row">

                                    <div class="col-md-12">
                                        <div class="form-group form-md-line-input has-success">
                                            <div class="input-icon">
                                                <asp:TextBox ID="tbDescription" runat="server" CssClass="form-control" Placeholder="Narration"></asp:TextBox>
                                                <label for="form_control_1">Description</label>
                                                <span class="help-block">A Short Description...</span>
                                                <i class="fa fa-align-justify"></i>
                                            </div>
                                        </div>
                                    </div>
                                </div>




                                <asp:HiddenField ID="hfTotalItems" runat="server" />

                                <div class="portlet-body">
                                    <div class="row">


                                        <table class="table table-striped table-bordered table-hover table-header-fixed">
                                            <thead>
                                                <tr class="row">
                                                    <th>Item</th>
                                                    <th>Description</th>
                                                    <th>Dept</th>
                                                    <th>Unit Cost</th>
                                                    <th>Quantity</th>
                                                    <th>Tax 1</th>
                                                    <th>Tax 2</th>
                                                </tr>
                                            </thead>
                                            <tbody>

                                                <asp:Repeater ID="rptVoucherItems" runat="server" OnItemDataBound="rptVoucherItems_ItemDataBound">
                                                    <ItemTemplate>
                                                        <tr class="row">

                                                            <asp:HiddenField ID="hfItemCount" runat="server" Value='<%# Eval("itemCount").ToString() %>' />
                                                            <asp:HiddenField ID="hfInvItemId" runat="server" Value='<%# Eval("invItemid").ToString() %>' />
                                                            <asp:HiddenField ID="hfCrSelectedAccount" runat="server" Value='<%# Eval("invItemAccId").ToString() %>' />

                                                            <td class="col-md-4">
                                                                <div class="form-group has-info input-zero-padding">
                                                                    <telerik:RadComboBox ID="ddlCreditAccount" runat="server" EmptyMessage="Select an Item" DataTextField="accountTitle" DataValueField="accountID" AllowCustomText="true" MarkFirstMatch="true" Filter="Contains" NoWrap="true" DropDownWidth="500px" DataSource='<%# List_Accounts() %>' InputCssClass="form-control input-zero-padding" EnableEmbeddedSkins="false">
                                                                    </telerik:RadComboBox>
                                                                </div>
                                                            </td>
                                                            <td class="col-md-3">
                                                                <div class="form-group form-md-line-input has-success input-zero-padding">
                                                                    <asp:TextBox ID="tbDescription" runat="server" class="form-control input-zero-border input-zero-padding " placeholder="Type Here..." Text='<%# Eval("invItemDescription").ToString() %>'></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td class="col-md-1">
                                                                <div class="form-group form-md-line-input has-success input-zero-padding">
                                                                    <asp:HiddenField ID="hfSelectedDept" runat="server" Value='<%# Eval("deptId").ToString() %>' />
                                                                    <asp:DropDownList ID="ddlDept" runat="server" DataSource='<%# List_Departments() %>' DataTextField="deptCode" DataValueField="deptId" CssClass="form-control input-zero-padding firstDisabled input-zero-border"></asp:DropDownList>
                                                                </div>
                                                            </td>
                                                            <td class="col-md-1">
                                                                <div class="form-group form-md-line-input has-success input-zero-padding">
                                                                    <div class="input-group">
                                                                        <asp:TextBox ID="tbUnitCost" runat="server" class="form-control input-zero-border input-zero-padding text-right" placeholder="" Text='<%# Eval("invItemCost").ToString() %>'></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td class="col-md-1">
                                                                <div class="form-group form-md-line-input has-success input-zero-padding">
                                                                    <div class="input-group">
                                                                        <asp:TextBox ID="tbQty" runat="server" class="form-control input-zero-border input-zero-padding text-right" placeholder="" Text='<%# Eval("invItemQty").ToString() %>'></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td class="col-md-1">
                                                                <div class="form-group form-md-line-input has-success input-zero-padding">
                                                                    <asp:HiddenField ID="hfTax1" runat="server" Value='<%# Eval("invItemTax1Id").ToString() %>' />
                                                                    <asp:DropDownList ID="ddlTax1" runat="server" DataSource='<%# List_Departments() %>' DataTextField="deptCode" DataValueField="deptId" CssClass="form-control input-zero-padding firstDisabled input-zero-border"></asp:DropDownList>
                                                                </div>
                                                            </td>
                                                            <td class="col-md-1">
                                                                <div class="form-group form-md-line-input has-success input-zero-padding">
                                                                    <asp:HiddenField ID="hfTax2" runat="server" Value='<%# Eval("invItemTax2Id").ToString() %>' />
                                                                    <asp:DropDownList ID="ddlTax2" runat="server" DataSource='<%# List_Departments() %>' DataTextField="deptCode" DataValueField="deptId" CssClass="form-control input-zero-padding firstDisabled input-zero-border"></asp:DropDownList>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-actions noborder">
                            <div class="col-md-3">
                                <a type="button" class="btn green" data-toggle="modal" href="#attachments"><i class="fa fa-paperclip"></i>Attachments</a>

                                <asp:Button ID="btnAddRows" runat="server" Text="Add Rows" CssClass="btn yellow" OnClick="btnAddRows_Click" />
                            </div>

                            <div class="col-md-5 pull-right">
                                <asp:Button ID="btnSubmitForm" runat="server" CssClass="btn pull-right blue" Text="Submit" OnClick="btnSubmitForm_Click" />

                                <button type="button" class="btn default pull-right margin-right-10">Cancel</button>
                            </div>
                            <div class="clearfix"></div>
                        </div>

                    </div>



                    <div class="modal fade in" id="attachments" tabindex="-1" role="attachments" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                                    <h4 class="modal-title">Attachments</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="file_upload_container">
                                        <asp:Panel ID="pnlUploadedFiles" runat="server" CssClass="uploaded_files">
                                            <asp:Repeater ID="rptUploadedFiles" runat="server">
                                                <HeaderTemplate>
                                                    <ul>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <li>
                                                        <asp:HyperLink ID="hplUploadedFile" runat="server" Target="_blank" NavigateUrl='<%# "~/Attachments/" + Eval("attachmentMaskedFileName").ToString() %>' Text='<%# Eval("attachmentOriginalFileName").ToString() %>'></asp:HyperLink>
                                                    </li>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </ul>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </asp:Panel>

                                        <telerik:RadAsyncUpload ID="radSyncAttachments" runat="server" Skin="Vista"></telerik:RadAsyncUpload>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn default" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <!-- END SAMPLE FORM PORTLET-->

    </div>
</asp:Content>
