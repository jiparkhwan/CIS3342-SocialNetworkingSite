<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessengerControl.ascx.cs" Inherits="TermProject.MessengerControl" %>
<asp:ScriptManager ID="smMessenger" runat="server">
</asp:ScriptManager>
<asp:DropDownList ID="ddlFriends" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFriends_SelectedIndexChanged">
</asp:DropDownList>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="tmrMessenger" EventName="Tick" />
        <asp:AsyncPostBackTrigger ControlID="btnSend" EventName="Click" />
    </Triggers>
    <ContentTemplate>
        <asp:Timer ID="tmrMessenger" runat="server" Interval="5000">
        </asp:Timer>
        <asp:GridView ID="gvMessenger" runat="server" AutoGenerateColumns="False" DataKeyNames="ConversationID, MessageID" OnRowDeleting="gvMessenger_RowDeleting" ShowHeader="False">
            <Columns>
                <asp:BoundField DataField="ConversationID" Visible="False" />
                <asp:BoundField DataField="MessageID" Visible="False" />
                <asp:BoundField DataField="Time" />
                <asp:BoundField DataField="FirstName" />
                <asp:BoundField DataField="LastName" />
                <asp:BoundField DataField="Message" />
                <asp:CommandField ButtonType="Image" ShowCancelButton="False" ShowDeleteButton="True" DeleteImageUrl="~/images/Cancel_Button.png" ControlStyle-Width="20" ControlStyle-Height="20"/>
                
            </Columns>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:TextBox ID="txtMessage" runat="server"></asp:TextBox>
<asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
<br />
