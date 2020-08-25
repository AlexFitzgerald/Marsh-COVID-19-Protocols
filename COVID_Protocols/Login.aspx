<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="COVID_Protocols.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Marsh COVID Protocols</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/Login.css" rel="stylesheet" />
</head>
<body class="wood-bg">
    <form id="form1" class="form-signin" runat="server">
        <div>
            <h3>
                <asp:Label ID="message_label" runat="server"></asp:Label></h3>
        </div>
        <div class="text-center m-0 p-3 rounded-top" style="background-color: #3F4727; color: #E1D1A6;">
            <img src="Images/marsh_logo_tan.png" class="mb-1" style="width: 140px;" />

            <h3>COVID Protocols</h3>
        </div>
        <div class="p-4 m-0 rounded-bottom" style="background-color: #E1D1A6;">
            <div class="form-label-group">
                <asp:TextBox type="email"   ID="username_textbox" class="form-control" placeholder="Email address" runat="server"></asp:TextBox>
                <label for="username_textbox">Email address</label>
            </div>
            <div class="form-label-group">
                <asp:TextBox type="password" ID="password_textbox" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                <label for="password_textbox">Password</label>
            </div>
            <asp:Button ID="login_button" OnClick="login_button_click" class="btn btn-lg btn-dark btn-block" runat="server" Text="Sign in" />
        </div>
    </form>
</body>
<script src="Scripts/jquery-3.0.0.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
<script src="Scripts/popper.min.js"></script>
</html>
