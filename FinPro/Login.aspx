<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FinPro.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/fin_login.css" rel="stylesheet" />
</head>
<body>
    <form id="frmLogin" runat="server">

		<header>
		</header>

		<section>
			<div class="wrapper">
				<div class="left_col">
					<div class="logo">
						<asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/finanxol.png" />
					</div>

					<div class="lines">
						<asp:Image ID="imgLines" runat="server" ImageUrl="~/Images/fin_login_lines.png" />
					</div>

					<div class="clr"></div>
				</div>

				<div class="right_col">
					<asp:Login ID="lgnFinanxol" runat="server" DestinationPageUrl="~/FinApp/" CssClass="login_control">
						<LayoutTemplate>
							<table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
								<tr>
									<td>
										<table cellpadding="2">
											<tr>
												<td align="center" colspan="2">
													<asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
												</td>
											</tr>
											<tr>
												<td align="right">
													<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
												</td>
												<td>
													<asp:TextBox ID="UserName" runat="server" CssClass="login_tb"></asp:TextBox>
													<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="lgnFinanxol">*</asp:RequiredFieldValidator>
												</td>
											</tr>
											<tr>
												<td align="right">
													<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
												</td>
												<td>
													<asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="login_tb"></asp:TextBox>
													<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="lgnFinanxol">*</asp:RequiredFieldValidator>
												</td>
											</tr>
											<tr>
												<td align="right">&nbsp;</td>
												<td height="30px">
													<asp:Button ID="LoginButton" runat="server" CommandName="Login" ValidationGroup="lgnFinanxol" CssClass="login_btn" Text="Sign In"></asp:Button>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</LayoutTemplate>
					</asp:Login>
				</div>
				<div class="clr"></div>
			</div>
		</section>
	</form>
</body>
</html>
