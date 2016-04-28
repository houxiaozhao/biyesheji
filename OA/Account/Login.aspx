<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OA.Account.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="ThemeBucket">
    <link rel="shortcut icon" href="#" type="image/png">
    <title>Login</title>
    <link href="../css/style.css" rel="stylesheet">
    <link href="../css/style-responsive.css" rel="stylesheet">
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->
</head>
<body class="login-body">
    <form id="form1" runat="server">
    <div class="container">
        <div class="form-signin">
            <div class="form-signin-heading text-center">
                <h1 class="sign-title">
                    Sign In</h1>
                <img src="../images/login-logo.png" alt="" />
            </div>

            <div class="login-wrap">
                <asp:TextBox ID="username" CssClass="form-control" runat="server" placeholder="User ID" autofocus></asp:TextBox>
                <asp:TextBox ID="password" CssClass="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                <asp:Button Text="√" CssClass="btn btn-lg btn-login btn-block" runat="server" 
                    ID="btnLogin" onclick="btnLogin_Click" />
                <label class="checkbox">
                    <span class="pull-left"><a data-toggle="modal" href="#myModal">Signup</a> </span>
                    <span class="pull-right"><a data-toggle="modal" href="#myModal">Forgot Password?</a>
                    </span>
                </label>
            </div>
            <!-- Modal -->
            <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1"
                id="myModal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-body">
                            <p>
                                请联系管理员</p>
                            <input type="text" name="email" placeholder="Email" autocomplete="off" class="form-control placeholder-no-fix">
                        </div>
                        <div class="modal-footer">
                            <button data-dismiss="modal" class="btn btn-default" type="button">
                                Cancel</button>
                        </div>
                    </div>
                </div>
            </div>
            <!-- modal -->
        </div>
    </div>
    <!-- Placed js at the end of the document so the pages load faster -->
    <!-- Placed js at the end of the document so the pages load faster -->
    <script src="../js/jquery-1.10.2.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/modernizr.min.js"></script>
    </form>
</body>
</html>
