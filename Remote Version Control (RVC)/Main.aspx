<%@ Page language="c#" Codebehind="Main.aspx.cs" AutoEventWireup="false" Inherits="RVC.Main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Main</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Main" method="post" runat="server">
			<asp:label id="Status" style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 480px" runat="server" Width="433px" Font-Bold="True" ForeColor="Red"></asp:label>
			<asp:label id="Label6" style="Z-INDEX: 122; LEFT: 51px; POSITION: absolute; TOP: 53px" runat="server" Font-Bold="True">Working Folder:</asp:label>
			<asp:label id="Label5" style="Z-INDEX: 120; LEFT: 47px; POSITION: absolute; TOP: 23px" runat="server" Font-Bold="True">Current Project:</asp:label>
			<asp:label id="Label4" style="Z-INDEX: 119; LEFT: 427px; POSITION: absolute; TOP: 401px" runat="server" Font-Bold="True">Comments:</asp:label><asp:label id="lblSrcSafeINI" style="Z-INDEX: 117; LEFT: 662px; POSITION: absolute; TOP: 95px" runat="server" Visible="False">Label</asp:label><asp:label id="lblPassword" style="Z-INDEX: 116; LEFT: 665px; POSITION: absolute; TOP: 126px" runat="server" Visible="False">Label</asp:label><asp:label id="Label3" style="Z-INDEX: 111; LEFT: 13px; POSITION: absolute; TOP: 331px" runat="server" Font-Bold="True">Checked Out:</asp:label><asp:label id="Label2" style="Z-INDEX: 108; LEFT: 54px; POSITION: absolute; TOP: 196px" runat="server" Font-Bold="True">Files:</asp:label><asp:dropdownlist id="ddlProject" style="Z-INDEX: 102; LEFT: 112px; POSITION: absolute; TOP: 161px" runat="server" Width="306px" Font-Bold="True" BackColor="#E0E0E0"></asp:dropdownlist><asp:listbox id="lbFiles" style="Z-INDEX: 103; LEFT: 110px; POSITION: absolute; TOP: 195px" runat="server" Width="304px" Height="131px" SelectionMode="Multiple"></asp:listbox><asp:listbox id="lbCheckedOutFiles" style="Z-INDEX: 104; LEFT: 110px; POSITION: absolute; TOP: 325px" runat="server" Width="304px" Height="122px" SelectionMode="Multiple"></asp:listbox><asp:label id="Label1" style="Z-INDEX: 105; LEFT: 42px; POSITION: absolute; TOP: 159px" runat="server" Font-Bold="True">Project: </asp:label><asp:button id="bChangeProject" style="Z-INDEX: 106; LEFT: 423px; POSITION: absolute; TOP: 160px" runat="server" Text="Change Project"></asp:button><asp:button id="bUp" style="Z-INDEX: 107; LEFT: 114px; POSITION: absolute; TOP: 131px" runat="server" Text="Up One Level"></asp:button><asp:button id="bCheckOut" style="Z-INDEX: 109; LEFT: 426px; POSITION: absolute; TOP: 201px" runat="server" Width="85px" Text="Check Out"></asp:button><asp:button id="bGetLatest" style="Z-INDEX: 110; LEFT: 427px; POSITION: absolute; TOP: 233px" runat="server" Text="Get Latest"></asp:button><asp:button id="bCheckIn" style="Z-INDEX: 112; LEFT: 426px; POSITION: absolute; TOP: 369px" runat="server" Text="Check In"></asp:button><asp:button id="bUndoCheckout" style="Z-INDEX: 113; LEFT: 426px; POSITION: absolute; TOP: 333px" runat="server" Text="Undo Check Out"></asp:button>
			<asp:Label id="lblCurrentProject" style="Z-INDEX: 114; LEFT: 172px; POSITION: absolute; TOP: 25px" runat="server" Width="461px" ForeColor="#0000C0">Label</asp:Label>
			<asp:Label id="lblUsername" style="Z-INDEX: 115; LEFT: 667px; POSITION: absolute; TOP: 155px" runat="server" Visible="False">Label</asp:Label>
			<asp:TextBox id="tbCheckInComments" style="Z-INDEX: 118; LEFT: 508px; POSITION: absolute; TOP: 400px" runat="server" Width="214px" Height="92px" TextMode="MultiLine"></asp:TextBox>
			<asp:TextBox id="tbWorkingFolder" style="Z-INDEX: 121; LEFT: 167px; POSITION: absolute; TOP: 52px" runat="server" Width="471px"></asp:TextBox>
			<asp:Button id="bChangeWorkingFolder" style="Z-INDEX: 123; LEFT: 165px; POSITION: absolute; TOP: 83px" runat="server" Width="145px" Text="Change Working Folder"></asp:Button>
			<asp:Label id="Label7" style="Z-INDEX: 124; LEFT: 321px; POSITION: absolute; TOP: 85px" runat="server" Width="302px" Font-Size="X-Small">Note: Working folder must be under G:\Docs\DMD in order to be accesible through FTP.</asp:Label></form>
	</body>
</HTML>
