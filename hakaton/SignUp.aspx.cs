using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hakaton
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("Profile/LiveMatches");
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-Q6VS2HN; Database=master; Integrated Security = True; MultipleActiveResultSets=True;"))
            {
                string sqlstring = "INSERT INTO Korisnik(Ime, Korisnicko_Ime, Email, Sifra) Values (@ime, @username, @email, @sifra)";
                SqlCommand cmd = new SqlCommand(sqlstring, connection);
                cmd.Parameters.AddWithValue("@ime", name.Value);
                cmd.Parameters.AddWithValue("@username", username.Value);
                cmd.Parameters.AddWithValue("@email", email.Value);
                cmd.Parameters.AddWithValue("@sifra", pass.Value);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { }
                SqlDataReader reader = cmd.ExecuteReader();
                connection.Close();


                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(username.Value, false, 30);
                string encTicket = FormsAuthentication.Encrypt(ticket);

                HttpCookie loginCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                loginCookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(loginCookie);
                Session["firstRun"] = "first";

                Response.Redirect("~/Profile/LiveMatches.aspx");
            }
        }
    }
}