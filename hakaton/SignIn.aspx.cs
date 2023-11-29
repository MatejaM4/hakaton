using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace hakaton
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-Q6VS2HN; Database=master; Integrated Security = True; MultipleActiveResultSets=True;"))
            {
                string sqlstring = "SELECT * FROM Korisnik WHERE Email = @email AND Sifra = @pass";
                SqlCommand cmd = new SqlCommand(sqlstring, connection);
                cmd.Parameters.AddWithValue("@email", email.Value);
                cmd.Parameters.AddWithValue("@pass", pass.Value);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.Read())
                    { 
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(reader["id"].ToString(), false, 30);
                        string encTicket = FormsAuthentication.Encrypt(ticket);

                        HttpCookie loginCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        loginCookie.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(loginCookie);

                        Response.Redirect("~/Profile/LiveMatches.aspx");
                    }
                    else
                    {
                        email.Value = "";
                        pass.Value = "";
                    }
                }
                catch (Exception ex) { }

                connection.Close();
            }
        }
    }
}