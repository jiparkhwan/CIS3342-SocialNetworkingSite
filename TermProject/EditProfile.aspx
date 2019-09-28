<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="TermProject.EditProfile" %>

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
            <div class="col-md-4"></div>
            <div class="col-md-4">
                <br />
                <div class="col-md-4">
                    <br />
                    <div id="tblEditDiv">
                        <asp:Table ID="tblEditUser" runat="server" HorizontalAlign="Center">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell>Edit Profile</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                            <asp:TableRow>
                                <asp:TableCell>
                            Profile Picture:
                                </asp:TableCell>
                                <asp:TableCell>
                                   <asp:FileUpload ID="fupProfilePhoto" runat="server"/>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                            First Name:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtEditFirstName" runat="server" CssClass="txtbtn"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                            Last Name:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtEditLastName" runat="server" CssClass="txtbtn"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                            Address:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtEditAddress" runat="server" CssClass="txtbtn"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                            City:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtEditCity" runat="server" CssClass="txtbtn"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                            State:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtEditState" runat="server" CssClass="txtbtn"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                            Zipcode:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtEditZipCode" runat="server" CssClass="txtbtn"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                            Phone Number:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtEditPhoneNumber" runat="server" CssClass="txtbtn"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                                                        <asp:TableRow>
                                <asp:TableCell>
                            Organization:
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtEditOrganization" runat="server" CssClass="txtbtn"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        <br />
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" ForeColor="Black" />
                        <br />
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
