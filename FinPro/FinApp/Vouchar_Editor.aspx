<%@ Page Title="" Language="C#" MasterPageFile="~/FinApp/App.Master" AutoEventWireup="true" CodeBehind="Vouchar_Editor.aspx.cs" Inherits="FinPro.FinApp.Vouchar_Editor" %>

<asp:Content ID="cContent" ContentPlaceHolderID="cphBody" runat="server">
    <script>
        
        function Update_Debit_Total(senderControl) {
            var totalFigure = 0;
            for (var i = 0; i <= 50; i++) {
                var controlPrefix = "cphBody_rptVoucherItems_tbDebitAmount_"; //01$tbDebitAmount";

                //if (i < 10) {
                //    controlPrefix = controlPrefix + "0";
                //}

                var controlForFix = "_tbDebitAmount";
                var thisControlId = controlPrefix + i.toString();
                var thisControl = document.getElementById(thisControlId);
                if (thisControl != null) {
                    totalFigure = totalFigure + +thisControl.value.replace(",", "");
                }
            }

            document.getElementById('cphBody_ltrTotalDebit').innerHTML = totalFigure.toString();
        }


        function Update_Credit_Total(senderControl) {
            var totalFigure = 0;
            for (var i = 0; i <= 50; i++) {
                var controlPrefix = "cphBody_rptVoucherItems_tbCreditAmount_"; //01$tbDebitAmount";

                //if (i < 10) {
                //    controlPrefix = controlPrefix + "0";
                //}

                var thisControlId = controlPrefix + i.toString();
                var thisControl = document.getElementById(thisControlId);
                if (thisControl != null) {
                    totalFigure = totalFigure + +thisControl.value.replace(",", "");
                }
            }

            document.getElementById('cphBody_ltrTotalCredit').innerHTML = totalFigure.toString();
        }
    </script>

<%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbtnAddVouchar_Click" ValidationGroup="Create">Create Vouchar</asp:LinkButton>--%>
    <asp:ScriptManager ID="smPage" runat="server"></asp:ScriptManager>
    <section class="body_content">
        <div class="body_heading_strip">
            <h1>
                <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
            </h1>

            <div class="body_heading_menu">
                <ul>
                    <li>
                        <asp:HyperLink ID="hplHeaderBack" runat="server" NavigateUrl="~/FinApp/Transactions.aspx">Back to Transactions</asp:HyperLink>
                    </li>
                </ul>
            </div>
            <div class="clr"></div>
        </div>

        <div class="control_block">

            <asp:UpdatePanel ID="upGrid" runat="server">
                <ContentTemplate>
                    <telerik:RadNotification ID="rnNotify" runat="server" VisibleOnPageLoad="false" AutoCloseDelay="100000"
                        Width="330" Height="100" Animation="Fade" EnableRoundedCorners="true" EnableShadow="true"
                        Title="Notification" Style="z-index: 35000" Skin="Glow">
                    </telerik:RadNotification>

                    <div class="grid_top">
                        <table cellspacing="5">
                            <tbody>

                                <tr>
                                    <td>Date
                                        <asp:RequiredFieldValidator ID="rfvDate" runat="server" ErrorMessage="*" ControlToValidate="radVoucharDate" ValidationGroup="Create" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                    <td>
                                        <telerik:RadDatePicker ID="radVoucharDate" runat="server" DateInput-EnabledStyle-CssClass="tb_padding tb_calendar" RenderMode="Lightweight" DateInput-ValidationGroup="Create">
                                            <Calendar EnableWeekends="True" RenderMode="Lightweight" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                            </Calendar>
                                            <DateInput DateFormat="M/d/yyyy" DisplayDateFormat="M/d/yyyy" LabelWidth="40%">
                                                <EmptyMessageStyle Resize="None" />
                                                <ReadOnlyStyle Resize="None" />
                                                <FocusedStyle Resize="None" />
                                                <DisabledStyle Resize="None" />
                                                <InvalidStyle Resize="None" />
                                                <HoveredStyle Resize="None" />
                                                <EnabledStyle CssClass="tb_padding tb_calendar" Resize="None" />
                                            </DateInput>
                                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                        </telerik:RadDatePicker>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Narration
                                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ErrorMessage="*" ControlToValidate="tbDescription" ValidationGroup="Create" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                    <td>
                                        <asp:TextBox ID="tbDescription" runat="server" CssClass="tb_padding tb_main" Width="350px" ValidationGroup="Create"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Reference
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbRefId" runat="server" CssClass="tb_padding tb_main" Width="200px" ValidationGroup="Create"></asp:TextBox></td>
                                </tr>
                                <tr runat="server" id="tr_cfield1">
                                    <td>
                                        <asp:Literal ID="ltrCField1Title" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbCustomValue1" runat="server" CssClass="tb_padding tb_main" Width="250px" ValidationGroup="Create"></asp:TextBox></td>
                                </tr>
                                <tr runat="server" id="tr_cfield2">
                                    <td>
                                        <asp:Literal ID="ltrCField2Title" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbCustomValue2" runat="server" CssClass="tb_padding tb_main" Width="100px" ValidationGroup="Create"></asp:TextBox></td>
                                </tr>
                                <tr runat="server" id="tr_cfield3">
                                    <td>
                                        <asp:Literal ID="ltrCField3Title" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbCustomValue3" runat="server" CssClass="tb_padding tb_main" Width="200px" ValidationGroup="Create"></asp:TextBox></td>
                                </tr>
                                <tr runat="server" id="tr_cfield4">
                                    <td>
                                        <asp:Literal ID="ltrCField4Title" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbCustomValue4" runat="server" CssClass="tb_padding tb_main" Width="200px" ValidationGroup="Create"></asp:TextBox></td>
                                </tr>
                                <tr runat="server" id="tr_branchField">
                                    <td>Branch
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="ddl_border ddl_generic ddl_padding" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Default Department
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDefautlDept" runat="server" CssClass="ddl_border ddl_generic ddl_padding"></asp:DropDownList>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>


                    <div class="grid_container">
                        <asp:HiddenField ID="hfTotalItems" runat="server" />
                        <table cellspacing="0">
                            <thead>
                                <tr>
                                    <td style="display:none;"></td>
                                    <td width="200px">Account</td>
                                    <td width="80px">Dept.
                                    </td>
                                    <td>Description</td>
                                    <td width="80px" class="align_right">Debit</td>
                                    <td width="80px" class="align_right">Credit</td>
                                    <td></td>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptVoucherItems" runat="server" OnItemDataBound="rptVoucherItems_ItemDataBound">
                                    <HeaderTemplate>
                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <tr class="grid_first_row">
                                            <td style="display:none;">
                                                <asp:CheckBox ID="chkShowOff" runat="server" Checked='<%# ShowOffIsChecked(Eval("chkShowOff").ToString()) %>' />
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hfAdditionalTransId" runat="server" Value='<%# Eval("additionalTransId").ToString() %>' />
                                                <asp:HiddenField ID="hfItemNo" runat="server" Value='<%# Eval("itemNo").ToString() %>' />
                                                <asp:HiddenField ID="hfTransID" runat="server" Value='<%# Eval("transID").ToString() %>' />
                                                <asp:HiddenField ID="hfSelectedAccount" runat="server" Value='<%# Eval("accountId").ToString() %>' />

                                                <telerik:RadComboBox ID="ddlAccounts" runat="server" Width="190" Height="400px" EmptyMessage="Select an Account" DataTextField="accountTitle" DataValueField="accountID" AllowCustomText="true" MarkFirstMatch="true" Filter="Contains" NoWrap="true" DropDownWidth="480" DataSource='<%# List_Accounts() %>'>
												</telerik:RadComboBox>

                                                <%--<asp:DropDownList ID="ddlAccounts" runat="server" DataSource='<%# List_Accounts() %>' DataTextField="accountTitle" DataValueField="accountID" Width="190px" CssClass="borderless backgroundless tb_padding"></asp:DropDownList>--%>
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hfSelectedDept" runat="server" Value='<%# Eval("deptId").ToString() %>' />
                                                <asp:DropDownList ID="ddlDept" runat="server" DataSource='<%# List_Departments() %>' DataTextField="deptCode" DataValueField="deptId" Width="70px" CssClass="borderless backgroundless tb_padding"></asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbDescription" runat="server" Width="380px" CssClass="borderless backgroundless tb_padding" Text='<%# Eval("description").ToString() %>'></asp:TextBox></td>
                                            <td  class="align_right">
                                                <asp:TextBox ID="tbDebitAmount" runat="server" Width="70px" CssClass="borderless backgroundless tb_padding align_right" Text='<%# Eval("debitAmount").ToString() %>' onchange="Update_Debit_Total(this)" oninput="Update_Debit_Total(this)"></asp:TextBox>
                                            </td>
                                            <td class="align_right">
                                                <asp:TextBox ID="tbCreditAmount" runat="server" Width="70px" CssClass="borderless backgroundless tb_padding align_right" Text='<%# Eval("creditAmount").ToString() %>' onchange="Update_Credit_Total(this)" oninput="Update_Credit_Total(this)"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                    </ItemTemplate>

                                    <AlternatingItemTemplate>
                                        <tr class="grid_alt_row">
                                            <td  style="display:none;">
                                                <asp:CheckBox ID="chkShowOff" runat="server" Checked='<%# ShowOffIsChecked(Eval("chkShowOff").ToString()) %>' />
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hfAdditionalTransId" runat="server" Value='<%# Eval("additionalTransId").ToString() %>' />
                                                <asp:HiddenField ID="hfItemNo" runat="server" Value='<%# Eval("itemNo").ToString() %>' />
                                                <asp:HiddenField ID="hfTransID" runat="server" Value='<%# Eval("transID").ToString() %>' />
                                                <asp:HiddenField ID="hfSelectedAccount" runat="server" Value='<%# Eval("accountId").ToString() %>' />
                                                <telerik:RadComboBox ID="ddlAccounts" runat="server" Width="190" Height="400px" EmptyMessage="Select an Account" DataTextField="accountTitle" DataValueField="accountID" AllowCustomText="true" MarkFirstMatch="true" Filter="Contains" NoWrap="true" DropDownWidth="480" DataSource='<%# List_Accounts() %>'>
                        </telerik:RadComboBox>
                                                <%--<asp:DropDownList ID="ddlAccounts" runat="server" DataSource='<%# List_Accounts() %>' DataTextField="accountTitle" DataValueField="accountID" Width="190px" CssClass="borderless backgroundless tb_padding"></asp:DropDownList>--%>
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hfSelectedDept" runat="server" Value='<%# Eval("deptId").ToString() %>' />
                                                <asp:DropDownList ID="ddlDept" runat="server" DataSource='<%# List_Departments() %>' DataTextField="deptCode" DataValueField="deptId" Width="70px" CssClass="borderless backgroundless tb_padding"></asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbDescription" runat="server" Width="380px" CssClass="borderless backgroundless tb_padding" Text='<%# Eval("description").ToString() %>'></asp:TextBox></td>
                                            <td class="align_right">
                                                <asp:TextBox ID="tbDebitAmount" runat="server" Width="70px" CssClass="borderless backgroundless tb_padding align_right" Text='<%# Eval("debitAmount").ToString() %>' onchange="Update_Debit_Total(this)" oninput="Update_Debit_Total(this)"></asp:TextBox>
                                            </td>
                                            <td class="align_right">
                                                <asp:TextBox ID="tbCreditAmount" runat="server" Width="70px" CssClass="borderless backgroundless tb_padding align_right" Text='<%# Eval("creditAmount").ToString() %>' onchange="Update_Credit_Total(this)" oninput="Update_Credit_Total(this)"></asp:TextBox>
                                            </td>
                                            <td></td>
                                        </tr>
                                    </AlternatingItemTemplate>

                                    <FooterTemplate>
                                        <asp:Repeater ID="rptAdditionalItems" runat="server" DataSource='<%# Get_Additional_Items() %>'>
                                            <ItemTemplate>
                                                <tr class="grid_first_row">
                                                    <td style="display:none;"></td>
                                                    <td>
                                                        <asp:HiddenField ID="hfAdditionalTransId" runat="server" Value='<%# Eval("additionalTransId").ToString() %>' />
                                                        <asp:HiddenField ID="hfModuleId" runat="server" Value='<%# Eval("moduleId").ToString() %>' />
                                                        <asp:Label ID="lblAdditionalTitle" runat="server" Text='<%# Eval("additionalTransTitle").ToString() %>' CssClass="module_additional_item_title"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbAdditionalDescription" runat="server" Width="455px" CssClass="borderless backgroundless tb_padding" Text='<%# Eval("additionalTransDescription").ToString() %>'></asp:TextBox></td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="tbAddiotionalAmount" runat="server" Width="150px" CssClass="borderless backgroundless tb_padding" Text='<%# Eval("Amount").ToString() %>'></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </FooterTemplate>
                                </asp:Repeater>

                                <tr id="tr_TotalRow" runat="server" class="grid_total_bottom_row">
                                    <td colspan="3">Total</td>
                                    <td class="align_right">
                                        <asp:Label ID="ltrTotalDebit" runat="server" Text="0"></asp:Label>
                                        <%--<asp:Literal ID="ltrTotalDebit" runat="server"></asp:Literal>--%>
                                    </td>
                                    <td class="align_right">
                                        <asp:Label ID="ltrTotalCredit" runat="server" Text="0"></asp:Label>
                                    </td>
                                    <td></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <telerik:RadPanelBar ID="rdPanelRelated" runat="server" ExpandMode="MultipleExpandedItems" Width="100%" Visible="false">
                        <Items>
                            <telerik:RadPanelItem Text="Related Transactions">
                                <Items>
                                    <telerik:RadPanelItem>
                                        <ContentTemplate>
                                            <div class="grid_container padding10">
                                                <table cellspacing="0">
                                                    <thead>
                                                        <tr>

                                                            <td width="80px">Voucher</td>
                                                            <td width="80px">
                                                                <asp:LinkButton ID="lbtnHeaderDate" runat="server">Date</asp:LinkButton></td>
                                                            <td>Description</td>
                                                            <td width="120px">
                                                                <asp:LinkButton ID="lbtnHeaderAmount" runat="server">Amount</asp:LinkButton></td>
                                                            <td width="120px">
                                                                <asp:LinkButton ID="lbtnHeaderCreater" runat="server">Created By</asp:LinkButton></td>

                                                        </tr>
                                                    </thead>
                                                    <tbody>

                                                        <asp:ListView ID="lvGridRelated" runat="server">
                                                            <ItemTemplate>
                                                                <tr class="grid_first_row">

                                                                    <td>

                                                                        <asp:HyperLink ID="hplVouchar" runat="server" Text='<%# Eval("voucharNo").ToString() %>' NavigateUrl='<%# Get_Trans_Link(Convert.ToInt32(Eval("transGroupID"))) %>'></asp:HyperLink>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="ltrDate" runat="server" Text='<%# Convert.ToDateTime(Eval("transGroupCreatedOn")).ToString("MMM dd, yyyy") %>'></asp:Literal></td>
                                                                    <td>
                                                                        <asp:Literal ID="ltrDescription" runat="server" Text='<%# Eval("transGroupTitle").ToString() %>'></asp:Literal></td>
                                                                    <td>
                                                                        <asp:Literal ID="ltrAmount" runat="server" Text='<%# Eval("transGroupTotalAmount").ToString() %>'></asp:Literal></td>
                                                                    <td>
                                                                        <asp:Literal ID="ltrCreatedBy" runat="server" Text='<%# Eval("CreatedBy").ToString() %>'></asp:Literal></td>

                                                                </tr>
                                                            </ItemTemplate>
                                                            <AlternatingItemTemplate>
                                                                <tr class="grid_alt_row">

                                                                    <td>

                                                                        <asp:HyperLink ID="hplVouchar" runat="server" Text='<%# Eval("voucharNo").ToString() %>' NavigateUrl='<%# Get_Trans_Link(Convert.ToInt32(Eval("transGroupID"))) %>'></asp:HyperLink>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="ltrDate" runat="server" Text='<%# Convert.ToDateTime(Eval("transGroupCreatedOn")).ToString("MMM dd, yyyy") %>'></asp:Literal></td>
                                                                    <td>
                                                                        <asp:Literal ID="ltrDescription" runat="server" Text='<%# Eval("transGroupTitle").ToString() %>'></asp:Literal></td>
                                                                    <td>
                                                                        <asp:Literal ID="ltrAmount" runat="server" Text='<%# Eval("transGroupTotalAmount").ToString() %>'></asp:Literal></td>
                                                                    <td>
                                                                        <asp:Literal ID="ltrCreatedBy" runat="server" Text='<%# Eval("CreatedBy").ToString() %>'></asp:Literal></td>

                                                                </tr>
                                                            </AlternatingItemTemplate>
                                                        </asp:ListView>
                                                    </tbody>
                                                    <tfoot>
                                                        <tr>

                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>

                                                        </tr>
                                                    </tfoot>
                                                </table>
                                            </div>
                                        </ContentTemplate>
                                    </telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>

                    <telerik:RadPanelBar ID="rdPanelRegions" runat="server" ExpandMode="MultipleExpandedItems" Width="100%">
                        <Items>
                            <telerik:RadPanelItem Text="Attachments">
                                <Items>
                                    <telerik:RadPanelItem>
                                        <ContentTemplate>

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
                                        </ContentTemplate>
                                    </telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>

                    <asp:Panel ID="pnlActions" runat="server" CssClass="action_panel">
                        <div>
                            <table width="100%">
                                <tr>
                                    <td width="100px">
                                        <asp:LinkButton ID="lbtnAddRow" runat="server" OnClick="lbtnAddRow_Click">Add Rows</asp:LinkButton>
                                    </td>
                                    <td></td>
                                    <td width="150px" align="right">
                                        <asp:HyperLink ID="hplPrintVouchar" runat="server" NavigateUrl="~/FinApp/RShow_Transaction.aspx">Print Voucher</asp:HyperLink>
                                        <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbtnAddVouchar_Click" ValidationGroup="Create">Create Vouchar</asp:LinkButton>--%>
                                    </td>
                                    <td width="200px" align="right" runat="server" id="tr_lbtnDelete">
                                        <asp:LinkButton ID="lbtnDeleteVouchar" runat="server" OnClick="lbtnDeleteVouchar_Click" ValidationGroup="Create" OnClientClick="return confirm('Do you really want to delete this vouchar?')">Delete Vouchar</asp:LinkButton>
                                    </td>
                                    <td width="200px" align="right" runat="server" id="tr_lbtnUpdate">
                                        <asp:LinkButton ID="lbtnAddVouchar" runat="server" OnClick="lbtnAddVouchar_Click" ValidationGroup="Create" OnClientClick="return confirm('Please Confirm Submission')">Create Vouchar</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
