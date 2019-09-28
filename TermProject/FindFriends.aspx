<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindFriends.aspx.cs" Inherits="TermProject.FindFriends" %>

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
    <link href="styles/findFriendsStyleSheet.css" rel="stylesheet" />
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
            <div class="col-md-5">
                <br />
                <asp:Label Text="Find New Friends" runat="server"></asp:Label>
                <br />
                <asp:ScriptManager runat="server"></asp:ScriptManager>
                <div id="findFriendDiv">
                    <asp:Button ID="btnFindName" Text="Add By Name" runat="server" CssClass="btn btn-danger" OnClick="btnFindName_Click" />
                    <asp:Button ID="btnFindLocation" Text="Add By Location" runat="server" CssClass="btn btn-danger" OnClick="btnFindLocation_Click" />
                    <asp:Button ID="btnFindOrganization" Text="Add By Organization" runat="server" CssClass="btn btn-danger" OnClick="btnFindOrganization_Click" />
                    <asp:Panel ID="pnlFindFriendsName" runat="server" Visible="false">
                        <asp:Label ID="lblFirstName" Text="First Name: " runat="server"></asp:Label>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        <asp:Label ID="lblLastName" Text="Last Name: " runat="server"></asp:Label>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        <asp:Button ID="btnFindFriendsName" Text="Search" runat="server" OnClick="btnFindFriendsName_Click" CssClass="btn btn-danger" />
                    </asp:Panel>
                    <asp:Panel ID="pnlFindFriendsLocation" runat="server" Visible="false">
                        <asp:Label ID="lblState" Text="State: " runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlState" runat="server">
                            <asp:ListItem Value="AL">Alabama</asp:ListItem>
                            <asp:ListItem Value="AK">Alaska</asp:ListItem>
                            <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                            <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                            <asp:ListItem Value="CA">California</asp:ListItem>
                            <asp:ListItem Value="CO">Colorado</asp:ListItem>
                            <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                            <asp:ListItem Value="DE">Delaware</asp:ListItem>
                            <asp:ListItem Value="DC">District Of Columbia</asp:ListItem>
                            <asp:ListItem Value="FL">Florida</asp:ListItem>
                            <asp:ListItem Value="GA">Georgia</asp:ListItem>
                            <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                            <asp:ListItem Value="ID">Idaho</asp:ListItem>
                            <asp:ListItem Value="IL">Illinois</asp:ListItem>
                            <asp:ListItem Value="IN">Indiana</asp:ListItem>
                            <asp:ListItem Value="IA">Iowa</asp:ListItem>
                            <asp:ListItem Value="KS">Kansas</asp:ListItem>
                            <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                            <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                            <asp:ListItem Value="ME">Maine</asp:ListItem>
                            <asp:ListItem Value="MD">Maryland</asp:ListItem>
                            <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                            <asp:ListItem Value="MI">Michigan</asp:ListItem>
                            <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                            <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                            <asp:ListItem Value="MO">Missouri</asp:ListItem>
                            <asp:ListItem Value="MT">Montana</asp:ListItem>
                            <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                            <asp:ListItem Value="NV">Nevada</asp:ListItem>
                            <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                            <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                            <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                            <asp:ListItem Value="NY">New York</asp:ListItem>
                            <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                            <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                            <asp:ListItem Value="OH">Ohio</asp:ListItem>
                            <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                            <asp:ListItem Value="OR">Oregon</asp:ListItem>
                            <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                            <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                            <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                            <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                            <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                            <asp:ListItem Value="TX">Texas</asp:ListItem>
                            <asp:ListItem Value="UT">Utah</asp:ListItem>
                            <asp:ListItem Value="VT">Vermont</asp:ListItem>
                            <asp:ListItem Value="VA">Virginia</asp:ListItem>
                            <asp:ListItem Value="WA">Washington</asp:ListItem>
                            <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                            <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                            <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblCity" Text="City: " runat="server"></asp:Label>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        <asp:Button ID="btnFindFriendsLocation" Text="Search" runat="server" OnClick="btnFindFriendsLocation_Click" CssClass="btn btn-danger" />
                    </asp:Panel>
                    <asp:Panel ID="pnlFindFriendsOrganization" runat="server" Visible="false">
                        <asp:Label ID="lblOrganization" Text="Organization: " runat="server"></asp:Label>
                        <asp:TextBox ID="txtOrganization" runat="server"></asp:TextBox>
                        <asp:Button ID="btnFindFriendsOrganization" Text="Search" runat="server" OnClick="btnFindFriendsOrganization_Click" CssClass="btn btn-danger" />
                    </asp:Panel>
                    <asp:Label ID="lblFindFriendsErrorMessage" runat="server"></asp:Label>
                    <asp:GridView runat="server" ID="gvResults" AutoGenerateColumns="False" DataKeyNames="Email" OnRowCommand="gvResults_RowCommand">
                        <Columns>
                            <asp:ImageField DataImageUrlField="ProfilePhotoUrl" ControlStyle-Width="50px" ControlStyle-Height="50px">
                                <ControlStyle Height="50px" Width="50px"></ControlStyle>
                            </asp:ImageField>
                            <asp:BoundField DataField="FirstName" />
                            <asp:BoundField DataField="LastName" />
                            <asp:BoundField DataField="State" />
                            <asp:BoundField DataField="City" />
                            <asp:BoundField DataField="Organization" />
                            <asp:ButtonField CommandName="viewProfile" Text="View Profile"/>
                            <asp:ButtonField CommandName="sendRequest" Text="Add Friend"/>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-md-5">
                <br />
                <asp:Label Text="Manage Requests" runat="server"></asp:Label>
                <asp:UpdatePanel ID="updpnlFriends" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="timer1" EventName="Tick" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:Timer ID="timer1" runat="server" Interval="1000"></asp:Timer>
                        <asp:Label runat="server" Text="Accept Friend Requests"></asp:Label>
                        <asp:Label ID="lblFriendRequestsErrorMessage" runat="server"></asp:Label>
                        <asp:GridView ID="gvFriendRequests" runat="server" AutoGenerateColumns="false" DataKeyNames="Email" OnRowCommand="gvFriendRequests_RowCommand">
                            <Columns>
                                <asp:ImageField DataImageUrlField="ProfilePhotoUrl" ControlStyle-Width="50px" ControlStyle-Height="50px">
                                    <ControlStyle Height="50px" Width="50px"></ControlStyle>
                                </asp:ImageField>
                                <asp:BoundField DataField="FirstName" />
                                <asp:BoundField DataField="LastName" />
                            <asp:ButtonField CommandName="acceptRequest" Text="Accept Request"/>
                            <asp:ButtonField CommandName="denyRequest" Text="Decline" />
                            <asp:ButtonField CommandName="viewProfile" Text="View Profile" />
                            </Columns>
                        </asp:GridView>
                        <asp:Label runat="server" Text="Friend Requests Sent"></asp:Label>
                        <asp:Label ID="lblFriendRequestedErrorMessage" runat="server"></asp:Label>
                        <asp:GridView ID="gvFriendRequested" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvFriendRequested_SelectedIndexChanged" DataKeyNames="Email">
                            <Columns>
                                <asp:ImageField DataImageUrlField="ProfilePhotoUrl" ControlStyle-Width="50px" ControlStyle-Height="50px">
                                    <ControlStyle Height="50px" Width="50px"></ControlStyle>
                                </asp:ImageField>
                                <asp:BoundField DataField="FirstName" />
                                <asp:BoundField DataField="LastName" />
                                <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Delete" ShowCancelButton="False" ControlStyle-CssClass="btn btn-danger"></asp:CommandField>
                            </Columns>
                        </asp:GridView>
                        <asp:Label runat="server" Text="People You May Know"></asp:Label>
                        <asp:Label ID="lblPeopleYouMayKnowErrorMessage" runat="server"></asp:Label>
                        <asp:GridView ID="gvPeopleYouMayKnow" runat="server" AutoGenerateColumns="false" DataKeyNames="Email" OnSelectedIndexChanged="gvPeopleYouMayKnow_SelectedIndexChanged" >
                            <Columns>
                                <asp:ImageField DataImageUrlField="ProfilePhotoUrl" ControlStyle-Width="50px" ControlStyle-Height="50px">
                                    <ControlStyle Height="50px" Width="50px"></ControlStyle>
                                </asp:ImageField>
                                <asp:BoundField DataField="FirstName" />
                                <asp:BoundField DataField="LastName" />
                                <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Add Friend" ShowCancelButton="False" ControlStyle-CssClass="btn btn-danger"></asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-1"></div>
        </div>
    </form>
</body>
</html>
