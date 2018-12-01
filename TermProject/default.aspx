<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TermProject.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
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
                Email:
                <asp:TextBox ID="txtLoginEmail" runat="server" Style="color: black" CssClass="btn"></asp:TextBox>
                Password:
                <asp:TextBox ID="txtLoginPassword" runat="server" Style="color: black" CssClass="btn"></asp:TextBox>
                <asp:Button ID="btnLogin" Text="Login" runat="server" CssClass="btn btn-danger" OnClick="btnLogin_Click" /><br />
                <a href="ForgotPassword.aspx" style="color:white;">Forgot Password</a>
                <asp:CheckBox ID="chkRememberMe" Text="Remember Me" runat="server" CssClass="form-check-input"/>            
            </div>
        </div>
        <div class="container-fluid">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4 register">
                <br />
                <br />
             Sign up for OwlSpace! <br />
                <asp:Button ID="btnRegister" Text="Sign Up" runat="server"  CssClass="btn btn-danger" OnClick="btnRegister_Click"/>
            </div>
            <div class="col-md-4"></div>
        </div>
            </div>
    </form>
</body>
</html>
