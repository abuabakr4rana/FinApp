<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucDataPager.ascx.cs" Inherits="FinPro.Controls.wucDataPager" %>

<asp:Panel ID="pnlPager" runat="server" CssClass="pager_container">
    <%--<asp:updatepanel id="uppager" runat="server" childrenastriggers="false" updatemode="conditional">
        <contenttemplate>--%>
            <table class="table_pager">
                <tr class="pager_row">
                    <td width="50px">
                        <asp:LinkButton ID="lbtnPrevious" runat="server" CssClass="pager_next" OnClick="lbtnPrevious_Click">Previous</asp:LinkButton>
                    </td>
                    <td>
                        <asp:Repeater ID="rptPages" runat="server" OnItemCommand="rptPages_ItemCommand">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnPage" runat="server" Text='<%# Eval("pageNo").ToString() %>' CommandArgument='<%# Eval("pageNo").ToString() %>' CssClass='<%# isSelectedCss(Eval("pageNo").ToString()) %>' CommandName="PageChanged"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:HiddenField ID="hfCurrentPage" runat="server" Value="1" />
                        <asp:Label ID="lblDotted" runat="server" Text="..."></asp:Label>

                        <asp:Repeater ID="rptLastPages" runat="server" OnItemCommand="rptPages_ItemCommand">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnPage" runat="server" CssClass='<%# isSelectedCss(Eval("pageNo").ToString()) %>' Text='<%# Eval("pageNo").ToString() %>' CommandArgument='<%# Eval("pageNo").ToString() %>' CommandName="PageChanged"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:Repeater>
                    </td>
                    <td width="100px" class="align_right">
                        <asp:Literal ID="ltrPageSummary" runat="server"></asp:Literal>
                    </td>
                    <td width="50px" class="align_right">
                        <asp:LinkButton ID="lbtnNext" runat="server" CssClass="pager_previous" OnClick="lbtnNext_Click">Next</asp:LinkButton>
                    </td>
                </tr>
            </table>
        <%--</ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="rptPages" EventName="ItemCommand" />
            <asp:AsyncPostBackTrigger ControlID="lbtnPrevious" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="lbtnNext" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>--%>
</asp:Panel>
