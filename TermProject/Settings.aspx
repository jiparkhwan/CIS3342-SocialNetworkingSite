<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="TermProject.Settings" %>
 <!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account Registration</title>
<!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
 <!-- jQuery library -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
 <!-- Latest compiled JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
     <link href="styles/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row header justify-content-around">
            <div class="col-md-1 col-sm-1 col-lg-1">
            </div>
            <div class="col-md-6">
                <br />
                <h1><a href="Default.aspx" style="color: white; font-style: normal;">OwlSpace</a></h1>
            </div>
            <div class="col-md-5">
                <br />
                <br />
                <br />
                <asp:Button ID="btnProfile" Text="Profile" runat="server" CssClass="btn btn-danger" OnClick="btnProfile_Click" />
                <asp:Button ID="btnHome" Text="Home" runat="server" CssClass="btn btn-danger" OnClick="btnHome_Click" />
                <asp:Button ID="btnFindFriends" Text="Find Friends" runat="server" CssClass="btn btn-danger" OnClick="btnFindFriends_Click" />
                <asp:Button ID="btnMessenger" Text="Messenger" runat="server" CssClass="btn btn-danger" OnClick="btnMessenger_Click" />
                <asp:Button ID="btnEditProfile" Text="Edit Profile" runat="server" CssClass="btn btn-danger" OnClick="btnEditProfile_Click" />
                <asp:Button ID="btnLogout" Text="Logout" runat="server" CssClass="btn btn-danger" OnClick="btnLogout_Click" />
                 <asp:ImageButton ID="btnSettings" ImageUrl="~/images/settings.png" Width="45" Height="34" AlternateText="Settings" runat="server" CssClass="btn btn-danger" OnClick="btnSettings_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <br />
                <div id="tblPreferenceDiv">
                    <asp:Table ID="tblPreference" runat="server" HorizontalAlign="Center">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>Preferences</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Auto Sign In:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList ID="ddlAutoSignIn" runat="server" Style="color: black;">
                                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                </asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Theme:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList ID="ddlColorStyle" runat="server" Style="color: black;">
                                    <asp:ListItem Value="Normal">Normal</asp:ListItem>
                                    <asp:ListItem Value="Colorblind">Colorblind</asp:ListItem>
                                    <asp:ListItem Value="Nightmode">Nightmode</asp:ListItem>
                                </asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
            <div class="col-md-6">
                <br />
                <div id="tblPrivacyDiv">
                    <asp:Table ID="tblPrivacy" runat="server" HorizontalAlign="Center">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>Privacy Settings</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Profile Viewing:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList ID="ddlProfileView" runat="server" Style="color: black;">
                                    <asp:ListItem Value="Everyone">Everyone</asp:ListItem>
                                    <asp:ListItem Value="Friends">Friends</asp:ListItem>
                                </asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <asp:Button ID="btnSaveSettings" Text="Save Changes" runat="server" OnClick="btnSaveSettings_Click"/>
            </div>
        </div>
    </form>
</body>
</html>

