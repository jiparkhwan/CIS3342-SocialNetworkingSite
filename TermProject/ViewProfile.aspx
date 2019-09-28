<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="TermProject.ViewProfile" %>

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
    <link href="styles/viewProfileStyleSheet.css" rel="stylesheet" />
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
                <div class="col-md-12" id="photoColumn" runat="server">
                    <h2>Photos</h2>
                    <asp:GridView ID="gvPhotos" runat="server" AutoGenerateColumns="false" ShowHeader="false">
                        <Columns>
                            <asp:ImageField DataImageUrlField="PhotoURL" ControlStyle-Width="200" ControlStyle-Height="200"></asp:ImageField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-md-4">
                <div class="col-md-12" id="postColumn" runat="server">
                    <h2>Create Post</h2>
                    <br />
                    <asp:TextBox ID="txtPost" TextMode="MultiLine" Style="resize: none" Height="200px" Width="500px" MaxLength="300" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnSubmitPost" Text="Post" runat="server" CssClass="btn btn-danger" />
                </div>
                <div class="col-md-12" id="previousPostColumn" runat="server">

                </div>
                <div class="col-md-12" id="PrivacyColumn" runat="server">
                    <p>You do not have access to this person's information.</p>
                </div>
            </div>
            <div class="col-md-3">
                <div class="col-md-12" id="friends" runat="server">
                    <h2>Friends</h2>
                    <asp:GridView runat="server" ID="gvFriends" AutoGenerateColumns="False" OnSelectedIndexChanged="gvFriends_SelectedIndexChanged" DataKeyNames="Email" ShowHeader="false">
                        <Columns>
                            <asp:ImageField DataImageUrlField="ProfilePhotoUrl" ControlStyle-Width="50px" ControlStyle-Height="50px">
                                <ControlStyle Height="200px" Width="200px"></ControlStyle>
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
