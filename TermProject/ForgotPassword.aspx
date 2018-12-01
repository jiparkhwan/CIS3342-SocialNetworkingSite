<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="TermProject.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account Recovery</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" />

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
                <h1><a href="Default.aspx" style="color: white; font-style: normal;">OwlSpace</a></h1>
            </div>
            <div class="col-md-5">
                <br />
                <br />
                <br />
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
                <div id="tblForgotPasswordDiv">
                    Email Address:
                    <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnSubmit" runat="server" CssClass="txtbtn" OnClick="btnSubmit_Click" Text="Submit" />
                    <br />
                    <asp:Table ID="tblForgotPassword" runat="server" HorizontalAlign="Center">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>Security Questions</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Question 1:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblQuestion1" runat="server"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtAnswer1" runat="server" CssClass="btn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Question 2:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblQuestion2" runat="server"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtAnswer2" runat="server" CssClass="btn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                Question 3:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblQuestion3" runat="server"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtAnswer3" runat="server" CssClass="btn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    <br />
                    <asp:Button ID="btnSubmitAnswer" runat="server" OnClick="btnSubmitAnswer_Click" Text="Submit" />
                    <br />
                </div>
            </div>
            <div class="col-md-4"></div>
        </div>
    </form>
</body>
</html>
