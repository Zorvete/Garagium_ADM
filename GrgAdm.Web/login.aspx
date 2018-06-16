<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="garagium_adm.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html >
<head>
  <meta charset="UTF-8" />
  <title>PinTelele - Login</title>

    <link rel="stylesheet" href="Styles/login.css" />

    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="description" content="A front-end template that helps you build fast, modern mobile web apps."/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0"/>
    <meta name="apple-mobile-web-app-capable" content="yes"/>
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="apple-mobile-web-app-title" content="Material Design Lite" />
    <meta name="msapplication-TileColor" content="#3372DF" />
    <meta name="mobile-web-app-capable" content="yes" />
  </head>

<body>
    <div class="login-page">
        <div class="form">
            <form runat="server" class="login-form">
                <asp:TextBox ID="userTxt" runat="server" placeholder="User" CssClass="input" />
                <asp:TextBox ID="pwTxt" runat="server" placeholder="Password" CssClass="input" TextMode="Password" />
                <asp:Button ID="dologinBtn" runat="server" Text="Entrar" CssClass="button" 
                    style="background-color: #4CAF50; color: #fff" onclick="dologinBtn_Click"/>
            </form>
        </div>
    </div>

<script type="text/javascript">	    
    $('.message a').click(function () {
	    $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
	});
</script>

</body>
</html>