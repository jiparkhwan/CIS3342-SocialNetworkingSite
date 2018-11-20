<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountRegistration.aspx.cs" Inherits="TermProject.AccountRegistration" %>

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
                <h1>OwlSpace</h1>
            </div>
            <div class="col-md-5">
                <br />
                <br />
                <br />
                <asp:Button ID="btnHome" Text="Home" runat="server" CssClass="btn btn-danger" />
                <asp:Button ID="btnLogout" Text="Logout" runat="server" CssClass="btn btn-danger" />
                <asp:ImageButton ID="btnSettings" AlternateText="Settings" runat="server" CssClass="btn btn-danger" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4">
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <div id="tblDiv">
                    <asp:Table ID="tblRegister" runat="server" HorizontalAlign="Center">
                        <asp:TableRow>
                            <asp:TableCell>
                            Email:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterEmail" runat="server" CssClass="btn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Username:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterUsername" runat="server" CssClass="btn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            First Name:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterFirstName" runat="server" CssClass="btn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Last Name:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterLastName" runat="server" CssClass="btn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Address:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterAddress" runat="server" CssClass="btn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            City:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterCity" runat="server" CssClass="btn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            State:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterState" runat="server" CssClass="btn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Zipcode:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterZipCode" runat="server" CssClass="btn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Phone Number:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterPhoneNumber" runat="server" CssClass="btn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
            <div class="col-md-4"></div>
        </div>
    </form>
</body>
</html>
