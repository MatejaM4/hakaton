<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="hakaton.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="hero">
        <div class="hero-wrap1">
            <h1 class="main-header">Experience <span class="outline">The Game as</span> it happens</h1>
            <p class="header-p">Live. Action. Thrill.</p>
            <span class="btn-main full"><a href="SignUp.aspx">Sign Up</a></span>
        </div>
        <span class="scroll-btn">
            <a href="#">
                <span class="mouse">
                    <span>
                    </span>
                </span>
            </a>
        </span>
     </div>

     <section class="hiw container-my" id="hiw">
        <h2><span class="red-h">How</span> it Works<span class="red-h">?</span></h2>

        <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
            <div class="carousel-inner">
              <div class="carousel-item active">
                <div class="slide-my">
                    <img src="./Content/images/slide1.svg" alt="slide1">
                    <div>
                        <h3>Sign Up</h3>
                        <p>To get started, simply create an account by clicking on sign up button and providing your basic details.</p>
                    </div>
                </div>
              </div>
              <div class="carousel-item">
                <div class="slide-my">
                    <img src="./Content/images/slide2.svg" alt="slide2">
                    <div>
                        <h3>Follow Your Favorite Clubs</h3>
                        <p>Easily search and select your favorite sports clubs. Add the selected clubs to your personalized list for tracking.</p>
                    </div>
                </div>
              </div>
              <div class="carousel-item">
                <div class="slide-my">
                    <img src="./Content/images/slide3.svg" alt="slide3">
                    <div>
                        <h3>Watch Live Results</h3>
                        <p>Navigate to sport section and receive real-time updates, including goals and key events.</p>
                    </div>
                </div>
              </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
              <img src="./Content/images/back.png" alt="back">
              <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
                <img src="./Content/images/next.png" alt="next">
              <span class="visually-hidden">Next</span>
            </button>
          </div>
     </section>

     <section class="features" id="features">
        <h2 class="section-heading">Features</h2>
        <div class="features-cards">
            <div class="features-card">
                <img src="./Content/images/news.svg">
                <h3 class="card-subheading">Read News</h3>
            </div>
            <div class="features-card">
                <img src="./Content/images/live.svg">
                <h3 class="card-subheading">Live Results</h3>
            </div>
            <div class="features-card">
                <img src="./Content/images/favorites.svg">
                <h3 class="card-subheading">Add Favorites</h3>
            </div>
            <div class="features-card">
                <img src="./Content/images/sport.svg">
                <h3 class="card-subheading">Popular Sports</h3>
            </div>
            <div class="features-card">
                <img src="./Content/images/notification.svg">
                <h3 class="card-subheading">Push Notifications</h3>
            </div>
            <div class="features-card">
                <img src="./Content/images/custom.svg">
                <h3 class="card-subheading">Add Custom Games</h3>
            </div>
        </div>
     </section>
    <footer>
        <div class="footer-column">
            <img src="images/logo-sm.svg">
            <span><a href="#hiw">How it works</a></span>
            <span><a href="#features">Features</a></span>
            <span><a href="sports.html">Sports</a></span>
        </div>
        <div class="footer-column">
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d91892.64399393559!2d21.165482183279725!3d43.96670663029036!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x4756c46f63f3b5ff%3A0x7d7de6c47baa8c0e!2sJagodina!5e0!3m2!1sen!2srs!4v1701164839522!5m2!1sen!2srs" width="300" height="230" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
        </div>
        <div class="footer-column">
            <h4>Subscribe For Our Newsletter</h4>
            <div>
                <input type="text" placeholder="Enter your email...">
                <a href="#">Subscribe</a>
            </div>
            <div class="social-icons">
                <img src="images/google.svg">
                <img src="images/fb.svg">
                <img src="images/ig.svg">
            </div>
        </div>
     </footer>
</asp:Content>
