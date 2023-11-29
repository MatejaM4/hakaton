<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="hakaton.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="signin container-my">
        <div class="signin-wrap edit-wrap">
            <div class="left-div">
                <div class="input-container">
                    <input class="sign-control" placeholder="Date..." type="date" />
                    <input class="sign-control" placeholder="Time..." type="time"  />
                    <input class="sign-control" placeholder="Home..." type="text" />
                    <input class="sign-control" placeholder="Away..." type="text" />
                    <div class="custom-select">
                        <select>
                          <option value="0">Football</option>
                          <option value="1">Basketball</option>
                        </select>
                    </div>
                </div>
                <div>
                    <a class="btn-main full">Add</a>
                    <a class="btn-main">Edit</a>
                </div>
            </div>

            <div class="right"></div>
        </div>
      </section>
</asp:Content>
