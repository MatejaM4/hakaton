using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace hakaton
{
    public partial class LiveMatches : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated && Session["firstRun"] == null)
            {
                    var client = new RestClient("https://therundown-inc.api.blobr.app/free-trial/v1/");
                    var request = new RestRequest("sports/4/schedule?limit=3", Method.Get);

                    request.AddHeader("X-TheRundown-Key", "mTW7n0Qxuw8lRjlrdskI5nt33Xv9AKAl");
                    request.AddHeader("X-BLOBR-KEY", "mTW7n0Qxuw8lRjlrdskI5nt33Xv9AKAl");

                    var response = client.Execute(request);
                    request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

                    var res1 = JObject.Parse(response.Content)["schedules"];

                // ----------------------------------------------------------------------------------
                var client1 = new RestClient("https://therundown-inc.api.blobr.app/free-trial/v1/");
                var request1 = new RestRequest("sports/14/schedule?limit=3", Method.Get);

                request1.AddHeader("X-TheRundown-Key", "mTW7n0Qxuw8lRjlrdskI5nt33Xv9AKAl");
                request1.AddHeader("X-BLOBR-KEY", "mTW7n0Qxuw8lRjlrdskI5nt33Xv9AKAl");

                var response1 = client1.Execute(request1);
                request1.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

                var res2 = JObject.Parse(response1.Content)["schedules"];


               var result = (JContainer)res1;
                result.Merge(res2, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Concat });


                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-Q6VS2HN; Database=master; Integrated Security = True; MultipleActiveResultSets=True;"))
                    {
                        string sqlstring = "INSERT INTO Utakmica(Datum, Vreme, Domacin, Gost, Sport) Values (@datum, @vreme, @domacin, @gost, @sport)";
                        SqlCommand cmd = new SqlCommand(sqlstring, connection);
                        connection.Open();
                        SqlCommand cmd2 = new SqlCommand("Delete from Utakmica", connection);
                        cmd2.ExecuteNonQuery();

                        for (int i = 0; i < 6; i++)
                        {
                            Panel panel1 = new Panel() { CssClass = "feed-wrap", ID = "contentWrap" };
                            Panel panel2 = new Panel() { CssClass = "card-match-wrap", ID = "cardWrap" };
                            Panel panel3 = new Panel() { CssClass = "left-feed", ID = "leftWrap" };
                            Panel panel4 = new Panel() { CssClass = "right-feed", ID = "rightWrap" };

                            panel1.Controls.Add(panel2);
                            panel2.Controls.Add(panel3);
                            panel2.Controls.Add(panel4);

                        string vreme;

                        string godina;
                        string mesec;
                        string dan;

                        if (result[i]["sport_id"].ToString() == "4")
                        {
                            godina = result[i]["updated_at"].ToString().Substring(6, 4);
                            mesec = result[i]["event_status_detail"].ToString().Substring(0, 2);
                            dan = result[i]["event_status_detail"].ToString().Substring(3, 2);

                            vreme = $"{result[i]["date_event"].ToString().Substring(11, 5)}";
                        }
                        else
                        {
                            godina = result[i]["updated_at"].ToString().Substring(6, 4);
                            mesec = result[i]["date_event"].ToString().Substring(0, 2);
                            dan = result[i]["date_event"].ToString().Substring(3, 1);

                            if (result[i]["date_event"].ToString().Substring(18, 2) == "PM")
                            {
                                vreme = $"{Convert.ToInt32(result[i]["date_event"].ToString().Substring(10, 1)) + 12}:{result[i]["date_event"].ToString().Substring(12, 2)}";
                            }
                            else
                            {
                                vreme = $"0{result[i]["date_event"].ToString().Substring(9, 5)}";
                            }
                        }

                            var p1 = new HtmlGenericControl("p") { InnerText = $"{dan}.{mesec}.{godina}" };
                            p1.Attributes.Add("class", "date");
                            var p2 = new HtmlGenericControl("p") { InnerText = $"{vreme}" };
                            p2.Attributes.Add("class", "time");
                            panel3.Controls.Add(p1);
                            panel3.Controls.Add(p2);

                            var img = new HtmlGenericControl("img");
                            string sport;
                            if (result[i]["sport_id"].ToString() == "4")
                            {
                                img.Attributes.Add("src", "../Content/Images/loptak.png");
                                sport = "Kosarka";
                            }
                            else
                            {
                                img.Attributes.Add("src", "../Content/Images/loptaf.png");
                                sport = "Fudbal";
                            }

                            panel2.Controls.Add(img);

                            var p3 = new HtmlGenericControl("p") { InnerText = $"{result[i]["home_team"]} VS {result[i]["away_team"]}" };
                            p3.Attributes.Add("class", "teams");
                            panel4.Controls.Add(p3);

                            results.Controls.Add(panel1);
                        if (Convert.ToInt32(dan) < 10) dan = $"0{dan}";

                            cmd.Parameters.AddWithValue("@datum", $"{godina}{mesec}{dan}");
                            cmd.Parameters.AddWithValue("@vreme", $"{vreme}");
                            cmd.Parameters.AddWithValue("@domacin", $"{result[i]["home_team"]}");
                            cmd.Parameters.AddWithValue("@gost", $"{result[i]["away_team"]}");
                            cmd.Parameters.AddWithValue("@sport", sport);

                            try
                            {
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                            catch (Exception ex) { }
                        }
                        connection.Close();
                    }
                    Session["firstRun"] = "no";
            }
            else if (Session["firstRun"] != null)
            {
                // TODO NE RADI LEPO UCITAVANJE POPRAVI
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-Q6VS2HN; Database=master; Integrated Security = True; MultipleActiveResultSets=True;"))
                {
                    string sqlstring = "Select * From Utakmica";
                    SqlCommand cmd = new SqlCommand(sqlstring, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Panel panel1 = new Panel() { CssClass = "feed-wrap", ID = "contentWrap" };
                        Panel panel2 = new Panel() { CssClass = "card-match-wrap", ID = "cardWrap" };
                        Panel panel3 = new Panel() { CssClass = "left-feed", ID = "leftWrap" };
                        Panel panel4 = new Panel() { CssClass = "right-feed", ID = "rightWrap" };

                        panel1.Controls.Add(panel2);
                        panel2.Controls.Add(panel3);
                        panel2.Controls.Add(panel4);


                        string godina = reader["Datum"].ToString().Substring(0, 4);
                        string mesec = reader["Datum"].ToString().Substring(5,2);
                        string dan = reader["Datum"].ToString().Substring(8,2);

                        string vreme = reader["Vreme"].ToString().Substring(11, 5);


                        var p1 = new HtmlGenericControl("p") { InnerText = $"{dan}.{mesec}.{godina}" };
                        p1.Attributes.Add("class", "date");
                        var p2 = new HtmlGenericControl("p") { InnerText = $"{vreme}" };
                        p2.Attributes.Add("class", "time");
                        panel3.Controls.Add(p1);
                        panel3.Controls.Add(p2);

                        var img = new HtmlGenericControl("img");
                        string sport;

                        if (reader["Sport"].ToString() == "Kosarka")
                        {
                            img.Attributes.Add("src", "../Content/Images/loptak.png");
                        }
                        else
                        {
                            img.Attributes.Add("src", "../Content/Images/loptaf.png");
                        }

                        panel2.Controls.Add(img);

                        var p3 = new HtmlGenericControl("p") { InnerText = $"{reader["Domacin"].ToString()} VS {reader["Gost"].ToString()}" };
                        p3.Attributes.Add("class", "teams");
                        panel4.Controls.Add(p3);

                        results.Controls.Add(panel1);
                    }
                    connection.Close();
                }
            }
            else
            {
                Response.Redirect("~/SignIn.aspx");
            }
        }
    }
}