<%@ Page Title="" Language="C#" MasterPageFile="~/LoggedIn.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="hakaton.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        td, tr {
            padding: 10px !important;
        }
        table {
            max-width: 100%;
        }

        @media only screen and (max-width: 1199px) {
            td, tr {
                padding: 0;
            }
            table {
                width: 100% !important;
            }
        }
    </style>
    <section class="signin container-my">
        <div class="signin-wrap edit-wrap">
            <div class="left-div">
                <div class="input-container">
                    <input id="date" class="sign-control" placeholder="Date..." type="date" runat="server" />
                    <input id="time" class="sign-control" placeholder="Time..." type="time" runat="server"  />
                    <input id="home" class="sign-control" placeholder="Home..." type="text" runat="server" />
                    <input id="away" class="sign-control" placeholder="Away..." type="text" runat="server" />
                    <div class="custom-select">
                        <select runat="server" id="sport">
                          <option value="Fudbal">Football</option>
                          <option value="Kosarka">Basketball</option>
                        </select>
                    </div>
                </div>
                <div>
                    <asp:Button ID="btn_add" runat="server" Text="Add" CssClass="btn_edit" OnClick="btn_add_Click" />
                    <asp:Button ID="btn_edit" runat="server" Text="Edit" CssClass="btn_edit" OnClick="btn_edit_Click" />
                    <asp:Button ID="btn_del" runat="server" Text="Delete" CssClass="btn_edit" OnClick="btn_del_Click" />
                </div>
            </div>

            <div class="right">
                <asp:GridView ID="gv_baza" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="gridview" OnSelectedIndexChanged="gv_baza_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:ButtonField CommandName="Select" HeaderText="Select" ShowHeader="True" Text="Select" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </div>
        </div>
      </section>
</asp:Content>
