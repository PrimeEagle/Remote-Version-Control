<%@ Page language="c#" Codebehind="VSSLogin.aspx.cs" AutoEventWireup="false" Inherits="RVC.VSSLogin" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label6" style="Z-INDEX: 108; LEFT: 35px; POSITION: absolute; TOP: 188px" runat="server"
				Font-Bold="True">Default Project: </asp:Label>
			<asp:Label id="Label7" style="Z-INDEX: 113; LEFT: 34px; POSITION: absolute; TOP: 222px" runat="server"
				Font-Bold="True">VSS INI Path:</asp:Label>
			<asp:TextBox id="DefaultProject" style="Z-INDEX: 107; LEFT: 154px; POSITION: absolute; TOP: 188px"
				runat="server" Width="384px">$/Projects/DreamMatrix/Active/Isis</asp:TextBox>
			<asp:Label id="Label5" style="Z-INDEX: 103; LEFT: 33px; POSITION: absolute; TOP: 151px" runat="server"
				Font-Bold="True">Password: </asp:Label>
			<asp:TextBox id="Username" style="Z-INDEX: 100; LEFT: 108px; POSITION: absolute; TOP: 114px"
				runat="server"></asp:TextBox>
			<asp:TextBox id="Password" style="Z-INDEX: 101; LEFT: 109px; POSITION: absolute; TOP: 152px"
				runat="server" Width="153px" TextMode="Password"></asp:TextBox>
			<asp:Label id="Label2" style="Z-INDEX: 102; LEFT: 33px; POSITION: absolute; TOP: 114px" runat="server"
				Font-Bold="True">Username: </asp:Label>
			<asp:Label id="Label3" style="Z-INDEX: 104; LEFT: 33px; POSITION: absolute; TOP: 151px" runat="server"
				Font-Bold="True">Password: </asp:Label>
			<asp:Button id="bLogin" style="Z-INDEX: 105; LEFT: 40px; POSITION: absolute; TOP: 274px" runat="server"
				Text="Login" Width="73px"></asp:Button>
			<asp:Label id="Status" style="Z-INDEX: 106; LEFT: 47px; POSITION: absolute; TOP: 317px" runat="server"
				Width="524px" Font-Bold="True" ForeColor="Red" Visible="False" Height="51px">Label</asp:Label>
			<asp:Label id="Label1" style="Z-INDEX: 110; LEFT: 38px; POSITION: absolute; TOP: 28px" runat="server"
				ForeColor="#0000C0" Font-Size="X-Large">Welcome to RVC.NET</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 111; LEFT: 50px; POSITION: absolute; TOP: 66px" runat="server"
				Width="256px">Please login to the VSS Server.</asp:Label>
			<asp:TextBox id="srcSafeINI" style="Z-INDEX: 112; LEFT: 153px; POSITION: absolute; TOP: 223px"
				runat="server" Width="381px">G:\Docs\DMD\vss\DreamMatrix\srcsafe.ini</asp:TextBox>
		</form>
	</body>
</HTML>
