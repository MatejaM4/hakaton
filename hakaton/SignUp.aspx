<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="hakaton.SignUp" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Sign Up</title>
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
            <div class="left-div">
                <div class="input-container">
                    <input class="sign-control" placeholder="Name..." type="text" />
                    <input class="sign-control" placeholder="Username..." type="text"  />
                    <input class="sign-control" placeholder="Email Address..." type="text" />
                    <input class="sign-control" placeholder="Password..." type="password" />
                </div>
                <div>
                    <a class="btn-main">Sign Up</a>
                </div>
                <div>
                    <p><a href="SignIn.aspx" class="redirect-signup">Already have an account</a></p>
                </div>
            </div>

            <div class="right-img">Sign Up</div>
        </div>
      </section>
</body>
</html>
