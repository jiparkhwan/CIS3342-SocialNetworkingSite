<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindFriends.aspx.cs" Inherits="TermProject.FindFriends" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account Registration</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css">

    <!-- Latest compiled and minified JavaScript -->
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
                <h1><a href="Default.aspx" style="color:white; font-style:normal;">OwlSpace</a></h1>
            </div>
            <div class="col-md-5">
                <br />
                <br />
                <br />
                <asp:Button ID="btnHome" Text="Home" runat="server" CssClass="btn btn-danger" OnClick="btnHome_Click" />
                <asp:Button ID="btnFindFriends" Text="Find Friends" runat="server" CssClass="btn btn-danger" OnClick="btnFindFriends_Click" />
                <asp:Button ID="btnLogout" Text="Logout" runat="server" CssClass="btn btn-danger" OnClick="btnLogout_Click" />
                <asp:ImageButton ID="btnSettings" AlternateText="Settings" runat="server" CssClass="btn btn-danger" OnClick="btnSettings_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-6"></div>
            <div class="col-md-6">
                <asp:GridView ID="gvFriendRequests" runat="server" AutoGenerateColumns="false">

                </asp:GridView>
                </div>
            </div>
    </form>
</body>
</html>
