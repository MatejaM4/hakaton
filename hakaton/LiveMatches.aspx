<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="LiveMatches.aspx.cs" Inherits="hakaton.LiveMatches" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="feed container-my">
        <h2>Today</h2>
        <div class="feed-wrap">
            <div class="card-match-wrap">
                <div class="left-feed">
                    <p class="date">27.11.2023</p>
                    <p class="time">18:00</p>
                </div>
                <img src="./Content/Images/loptak.png">
                <div class="right-feed">
                    <p class="teams">GSW VS LAL</p>
                </div>
            </div>
            <div class="card-match-wrap">
                <div class="left-feed">
                    <p class="date">27.11.2023</p>
                    <p class="time">18:00</p>
                </div>
                <img src="./Content/Images/loptaf.png">
                <div class="right-feed">
                    <p class="teams">GSW VS LAL</p>
                </div>
            </div>
        </div>
     </section>

</asp:Content>
