using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace hakaton
{
    public partial class Edit : System.Web.UI.Page
    {
        public void LoadTable()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=LUKA; Database=Hakaton; Integrated Security = True; MultipleActiveResultSets=True;"))
            {
                SqlCommand command = new SqlCommand("Select id, Convert(varchar, Datum, 102) as 'Datum', Convert(varchar, Vreme, 108) as 'Vreme', Domacin, Gost, Sport FROM Utakmica", connection);
                connection.Open();
                SqlDataReader sdr = command.ExecuteReader();
                gv_baza.DataSource = sdr;
                gv_baza.DataBind();

                connection.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTable();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=LUKA; Database=Hakaton; Integrated Security = True; MultipleActiveResultSets=True;"))
            {
                string sqlstring = "INSERT INTO Utakmica(Datum, Vreme, Domacin, Gost, Sport) Values (Convert(Varchar, @datum, 103), @vreme, @domacin, @gost, @sport)";
                SqlCommand cmd = new SqlCommand(sqlstring, connection);
                cmd.Parameters.AddWithValue("@datum", date.Value);
                cmd.Parameters.AddWithValue("@vreme", time.Value);
                cmd.Parameters.AddWithValue("@domacin", home.Value);
                cmd.Parameters.AddWithValue("@gost", away.Value);
                cmd.Parameters.AddWithValue("@sport", sport.Value);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { }
                connection.Close();
                LoadTable();
            }
        }

        protected void gv_baza_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = gv_baza.SelectedIndex;
            DateTime dt = Convert.ToDateTime(gv_baza.SelectedRow.Cells[2].Text);
            string godina = dt.Year.ToString();
            string mesec = dt.Month.ToString("D2");
            string dan = dt.Day.ToString("D2");
            date.Value = $"{godina}-{mesec}-{dan}";
            time.Value = gv_baza.SelectedRow.Cells[3].Text;
            home.Value = gv_baza.SelectedRow.Cells[4].Text;
            away.Value = gv_baza.SelectedRow.Cells[5].Text;
            sport.Value = gv_baza.SelectedRow.Cells[6].Text;

            btn_add.Enabled = false;
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=LUKA; Database=Hakaton; Integrated Security = True; MultipleActiveResultSets=True;"))
            {
                string sqlstring = "UPDATE Utakmica SET Datum = Convert(varchar, @datum, 103), Vreme = @vreme, Domacin = @domacin, Gost = @gost, Sport = @sport WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sqlstring, connection);

                cmd.Parameters.AddWithValue("@id", gv_baza.SelectedRow.Cells[1].Text);
                cmd.Parameters.AddWithValue("@datum", date.Value);
                cmd.Parameters.AddWithValue("@vreme", time.Value);
                cmd.Parameters.AddWithValue("@domacin", home.Value);
                cmd.Parameters.AddWithValue("@gost", away.Value);
                cmd.Parameters.AddWithValue("@sport", sport.Value);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { }

                connection.Close();
                LoadTable();
            }
            date.Value = "";
            time.Value = "";
            home.Value = "";
            away.Value = "";
            sport.Value = "";
            LoadTable();
            gv_baza.SelectedIndex = -1;
            btn_add.Enabled = true;
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            if(gv_baza.SelectedIndex >= 0)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=LUKA; Database=Hakaton; Integrated Security = True; MultipleActiveResultSets=True;"))
                {
                    string sqlstring = "DELETE FROM Utakmica WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(sqlstring, connection);

                    cmd.Parameters.AddWithValue("@id", gv_baza.SelectedRow.Cells[1].Text);
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex) { }

                    connection.Close();
                    LoadTable();
                }
                gv_baza.SelectedIndex = -1;
                btn_add.Enabled = true;
            } 
        }
    }
}