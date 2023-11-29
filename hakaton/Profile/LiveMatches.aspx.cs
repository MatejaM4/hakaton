using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace hakaton
{
    public partial class LiveMatches : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            var client = new RestClient("https://therundown-inc.api.blobr.app/free-trial/v1/");
            var request = new RestRequest("sports/4/schedule", Method.Get);
            request.AddHeader("X-TheRundown-Key", "mTW7n0Qxuw8lRjlrdskI5nt33Xv9AKAl");
            request.AddHeader("X-BLOBR-KEY", "mTW7n0Qxuw8lRjlrdskI5nt33Xv9AKAl");
            var response = client.Execute(request);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var res = JObject.Parse(response.Content);

            for(int i = 0; i < 3; i++)
            {
                Panel panel1 = new Panel() { CssClass = "feed-wrap", ID = "contentWrap" };
                Panel panel2 = new Panel() { CssClass = "card-match-wrap", ID = "cardWrap" };
                Panel panel3 = new Panel() { CssClass = "left-feed", ID = "leftWrap" };
                Panel panel4 = new Panel() { CssClass = "right-feed", ID = "rightWrap" };

                panel1.Controls.Add(panel2);
                panel2.Controls.Add(panel3);
                panel2.Controls.Add(panel4);


                var p1 = new HtmlGenericControl("p") { InnerText = $"{res["schedules"][i]["event_status_detail"].ToString().Substring(3, 2)}.{res["schedules"][0]["event_status_detail"].ToString().Substring(0,2)}.2023" };
                p1.Attributes.Add("class", "date");
                var p2 = new HtmlGenericControl("p") { InnerText = $"{res["schedules"][i]["event_status_detail"].ToString().Substring(8, 4)}" };
                p2.Attributes.Add("class", "time");
                panel3.Controls.Add(p1);
                panel3.Controls.Add(p2);

                var img = new HtmlGenericControl("img");
                if (res["schedules"][0]["sport_id"].ToString() == "4")
                {
                    img.Attributes.Add("src", "../Content/Images/loptak.png");
                }
                else
                {
                    img.Attributes.Add("src", "../Content/Images/loptaf.png");
                }

                panel2.Controls.Add(img);

                var p3 = new HtmlGenericControl("p") { InnerText = $"{res["schedules"][i]["home_team"]} VS {res["schedules"][i]["away_team"]}" };
                p3.Attributes.Add("class", "teams");
                panel4.Controls.Add(p3);

                results.Controls.Add(panel1);
            }

        }
    }
}