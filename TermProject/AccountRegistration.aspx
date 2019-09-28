<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountRegistration.aspx.cs" Inherits="TermProject.AccountRegistration" %>
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
            </div>
        </div>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4">
                <br />
                <div id="tblRegisterDiv">
                    <asp:Table ID="tblRegister" runat="server" HorizontalAlign="Center">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell>Sign Up</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Email:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterEmail" runat="server" CssClass="txtbtn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Password:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterPassword" runat="server" CssClass="txtbtn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            First Name:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterFirstName" runat="server" CssClass="txtbtn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Last Name:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterLastName" runat="server" CssClass="txtbtn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Address:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterAddress" runat="server" CssClass="txtbtn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            City:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterCity" runat="server" CssClass="txtbtn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            State:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterState" runat="server" CssClass="txtbtn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Zipcode:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterZipCode" runat="server" CssClass="txtbtn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Phone Number:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtRegisterPhoneNumber" runat="server" CssClass="txtbtn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Security Question #1:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList ID="ddlSecurityQuestion1" runat="server" CssClass="ddl">
                                    <asp:ListItem>What was your childhood nickname?</asp:ListItem>
                                    <asp:ListItem>What city did you meet your spouse?</asp:ListItem>
                                    <asp:ListItem>What is the name of your favorite childhood friend?</asp:ListItem>
                                    <asp:ListItem>What street did you live on in third grade?</asp:ListItem>
                                    <asp:ListItem>What is your oldest sibling's birthday and year?</asp:ListItem>
                                </asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Answer:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtSecurityAnswer1" runat="server" CssClass="txtbtn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Security Question #2:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList ID="ddlSecurityQuestion2" runat="server" CssClass="ddl">
                                    <asp:ListItem>What is the middle name of your youngest child?</asp:ListItem>
                                    <asp:ListItem>WHat is your oldest sibling's middle name?</asp:ListItem>
                                    <asp:ListItem>What school did you attend for sixth grade?</asp:ListItem>
                                    <asp:ListItem>What was your childhood phone number including area code?</asp:ListItem>
                                    <asp:ListItem>What is your oldest cousin's first and last name?</asp:ListItem>
                                </asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Answer:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtSecurityAnswer2" runat="server" CssClass="txtbtn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Security Question #3:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:DropDownList ID="ddlSecurityQuestion3" runat="server" CssClass="ddl">
                                    <asp:ListItem>In what city or town did your mother and father meet?</asp:ListItem>
                                    <asp:ListItem>In what city does your nearest sibling live?</asp:ListItem>
                                    <asp:ListItem>What is your maternal grandmother's maiden name?</asp:ListItem>
                                    <asp:ListItem>In what city or town was your first job?</asp:ListItem>
                                    <asp:ListItem>What city did you go on your honeymoon?</asp:ListItem>
                                </asp:DropDownList>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            Answer:
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtSecurityAnswer3" runat="server" CssClass="txtbtn"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" ForeColor="Black" />
                    <br />
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-md-4">
            </div>
        </div>
    </form>
</body>
</html>
