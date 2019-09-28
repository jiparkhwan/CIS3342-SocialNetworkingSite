<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TermProject.Profile" %>

<%@ Register Src="~/PostControl.ascx" TagPrefix="uc1" TagName="PostControl" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OwlSpace</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="styles/profileStyleSheet.css" rel="stylesheet" />
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
            <div class="col-md-1"></div>
            <div class="col-md-3">
                <div class="col-md-12" id="profileColumn">
                    <div class="row">
                        <div class="col-md-6">
                            <div id="profileImageDiv" runat="server">
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div id="profileInformationDiv" runat="server">
                            </div>
                        </div>
                    </div>
                    <div id="profileContactInformationDiv" runat="server">
                    </div>
                </div>
                <div class="col-md-12">
                    <p></p>
                </div>
                <div class="col-md-12" id="navigationLinks" runat="server">
                    <asp:Button ID="btnLinkProfile" Text="Profile" runat="server" CssClass="btn btn-danger" OnClick="btnProfile_Click" Width="99%" />
                    <br />
                    <asp:Button ID="btnLinkNewsFeed" Text="News Feed" runat="server" CssClass="btn btn-danger" OnClick="btnHome_Click" Width="99%" />
                    <br />
                    <asp:Button ID="btnLinkFindFriends" Text="Find Friends" runat="server" CssClass="btn btn-danger" OnClick="btnFindFriends_Click" Width="99%" />
                    <br />
                    <asp:Button ID="btnLinkEditProfile" Text="Edit Profile" runat="server" CssClass="btn btn-danger" OnClick="btnEditProfile_Click" Width="99%" />
                    <br />
                    <asp:ImageButton ID="btnLinkSettings" Text="Settings" AlternateText="Settings" runat="server" CssClass="btn btn-danger" OnClick="btnSettings_Click" Width="99%" />
                </div>
                <div class="col-md-12">
                    <p></p>
                </div>
                <div class="col-md-12" id="photoColumn">
                    <h2>Photos</h2>
                    <asp:GridView ID="gvPhotos" runat="server" AutoGenerateColumns="false" ShowHeader="false">
                        <Columns>
                            <asp:ImageField DataImageUrlField="PhotoURL" ControlStyle-Width="200" ControlStyle-Height="200"></asp:ImageField>
                        </Columns>
                    </asp:GridView>
                    <asp:FileUpload ID="fupAddPhoto" runat="server"/>
                    <asp:TextBox ID="txtPhotoDescription" runat="server"></asp:TextBox>
                    <asp:Button ID="btnUploadPhoto" runat="server" Text="Upload photo" OnClick="btnUploadPhoto_Click"/>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-md-4">
                <div class="col-md-12" id="postColumn">
                    <h2>Create Post</h2>
                    <br />
                    <asp:TextBox ID="txtPost" TextMode="MultiLine" Style="resize: none" Height="200px" Width="500px" MaxLength="300" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnSubmitPost" Text="Post" runat="server" OnClick="btnSubmitPost_Click" CssClass="btn btn-danger" />
                </div>
                <div class="col-md-12" id="previousPostColumn" runat="server">
                </div>
            </div>
            <div class="col-md-3">
                <div class="col-md-12" id="friends">
                    <h2>Friends</h2>
                    <asp:GridView runat="server" ID="gvFriends" AutoGenerateColumns="False" DataKeyNames="Email" ShowHeader="false" OnSelectedIndexChanged="gvFriends_SelectedIndexChanged">
                        <Columns>
                            <asp:ImageField DataImageUrlField="ProfilePhotoUrl" ControlStyle-Width="50" ControlStyle-Height="50">
                                <ControlStyle Height="200" Width="200"></ControlStyle>
                            </asp:ImageField>
                            <asp:BoundField DataField="FirstName" />
                            <asp:BoundField DataField="LastName" />
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Profile" ShowCancelButton="False" ControlStyle-CssClass="btn btn-danger"></asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-md-1"></div>
        </div>
    </form>
</body>
</html>

