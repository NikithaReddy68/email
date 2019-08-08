using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Emailsent
{
    public partial class index : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TableConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //dtlistbind();
            }
        }

        //private void dtlistbind()
        //{
            
        //    SqlDataAdapter sda = new SqlDataAdapter("select * from Registrationform where Email='" + Session["email"] .ToString()+ "'", con);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    dt1.DataSource = dt;
        //    dt1.DataBind();

        //}

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("ChangePassword.aspx");
        
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("ActivationLogin.aspx");
        }
    }
}