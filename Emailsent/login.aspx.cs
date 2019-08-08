using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Emailsent
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);
                SqlCommand cmd = new SqlCommand("update Registrationform set ActivationLink=1 where Id='" + id + "'", con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i == 1)
                {
                    lbl.Text = "Activation success";
                    lbl.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lbl.Text = "Activation fail";
                    lbl.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}