<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sports.aspx.cs" Inherits="hakaton.Sports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="sports">
        <div class="">
            <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-inner">
                  <div class="carousel-item active">
                    <div class="slide-my-sports">
                        <div class="slide-img s1"></div>
                        <div class="carousel-content">
                            <h2>Basketball</h2>
                            <p>Follow results and news of the most popular league in the world: The NBA League.</p>
                        </div>
                    </div>
                  </div>
                  <div class="carousel-item">
                    <div class="slide-my-sports">
                        <div class="slide-img s2"></div>
                        <div class="carousel-content">
                            <h2>Football</h2>
                            <p>Follow results and news of the most popular leagues: Premier League, Serie A, Bundesliga, Ligue 1, LaLiga and many more.</p>
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
        </div>
    </section>
</asp:Content>
