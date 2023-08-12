using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.Common;

namespace IntroEnlight
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = null;
            DataTable dt;
            string strsqlquery = string.Empty;
            string connection1 = string.Empty;

            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["connection1"].ConnectionString);

            try
            {
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddClientEnquiry";
                cmd.Parameters.AddWithValue("@name", TextBox1.Text);
                cmd.Parameters.AddWithValue("@contact", TextBox2.Text);
                cmd.Parameters.AddWithValue("@email", TextBox3.Text);
                cmd.Parameters.AddWithValue("@enquiry", TextBox4.Text);
                //var bname = Convert.ToString(System.Web.HttpContext.Current.Session["bname"]);
                cmd.Parameters.AddWithValue("@CreatedBy", TextBox1.Text);
                cmd.Parameters.AddWithValue("@CreatedOn", DateTime.Now.ToString("dd/MM/yyyy"));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (con1.State != ConnectionState.Closed)
                {
                    con1.Close();
                }
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "alert('We will get back to you soon!');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "popup", "alert('Something went wrong!');", true);
            }
        }

    }
}