<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="hakaton.SignIn" %>

<!DOCTYPE html>
<html lang="en">
  <head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Sign In</title>
    <link rel="stylesheet" href="~/Content/styles.css">
  </head>
  <body>
    <nav>
      <div class="sign-nav">
        <img src="./Content/images/logo.png" />
      </div>
    </nav>

    <section class="signin container-my">
      <div class="signin-wrap">
        <div class="left-img">Sign In</div>
        <div class="right-div">
          <div class="input-container">
            <input class="sign-control" placeholder="Email Address..." type="text" />
            <input class="sign-control" placeholder="Password..." type="password" />
          </div>
          <div>
            <a class="btn-main">Sign In</a>
          </div>
          <div>
            <p><a href="SignUp.aspx" class="redirect">Don't have an account</a></p>
          </div>
        </div>
      </div>
    </section>
  </body>
</html>

