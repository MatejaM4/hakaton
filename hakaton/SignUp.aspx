<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="hakaton.SignUp" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Sign Up</title>
    <link rel="stylesheet" href="~/Content/styles.css">
    <style>
        .btn-main {
            background: transparent;
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
                <div class="left-div">
                    <div class="input-container">
                        <input id="name" class="sign-control" placeholder="Name..." type="text" runat="server" />
                        <input id="username" class="sign-control" placeholder="Username..." type="text" runat="server"  />
                        <input id="email" class="sign-control" placeholder="Email Address..." type="text" runat="server" />
                        <input id="pass" class="sign-control" placeholder="Password..." type="password" runat="server" />
                    </div>
                    <div>
                        <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="btn-main" OnClick="btnSignUp_Click" OnClientClick="return Test()" />
                    </div>
                    <div>
                        <p><a href="SignIn.aspx" class="redirect-signup">Already have an account</a></p>
                    </div>
                </div>

                <div class="right-img">Sign Up</div>
            </div>
          </section>
      </form>

    <script>
        const Test = () => {
            if (document.getElementById("name").value != "" && document.getElementById("username").value != "" && /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(document.getElementById("email").value) && /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,32}$/.test(document.getElementById("pass").value)) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</body>
</html>
