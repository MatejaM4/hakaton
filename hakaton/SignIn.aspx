<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="hakaton.SignIn" %>

<!DOCTYPE html>
<html lang="en">
  <head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Sign In</title>
    <link rel="stylesheet" href="~/Content/styles.css">
      <style>
          .btn-main:hover {
                background: #d62823 !important;
            }
      </style>
  </head>
  <body>
    <nav>
      <div class="sign-nav">
        <a href="Default.aspx"><img src="./Content/images/logo.png" /></a>
      </div>
    </nav>
    <form runat="server">
    <section class="signin container-my">
      <div class="signin-wrap">
        <div class="left-img">Sign In</div>
        <div class="right-div">
          <div class="input-container">
            <input id="email" class="sign-control" placeholder="Email Address..." type="text" runat="server" />
            <input id="pass" class="sign-control" placeholder="Password..." type="password" runat="server" />
          </div>
          <div>
              <asp:Button ID="btnSignIn" runat="server" Text="Sign In" CssClass="btn-main" OnClick="btnSignIn_Click" />
          </div>
          <div>
            <p><a href="SignUp.aspx" class="redirect">Don't have an account</a></p>
          </div>
        </div>
      </div>
    </section>
    </form>
  </body>
</html>

