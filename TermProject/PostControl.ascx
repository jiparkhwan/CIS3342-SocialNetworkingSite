<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostControl.ascx.cs" Inherits="TermProject.PostControl" %>
<style type="text/css">
    .auto-style1 {
        width: 64%;
    }
</style>
<table class="auto-style1">
    <tr>
        <td>
<asp:Image ID="imgPosterIcon" runat="server"/>
&nbsp;<asp:Label ID="lblPosterName" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblTime" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblPost" runat="server"></asp:Label>
        </td>
    </tr>
</table>

