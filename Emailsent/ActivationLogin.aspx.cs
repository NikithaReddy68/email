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
    public partial class ActivationLogin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TableConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            SqlDataAdapter daa = new SqlDataAdapter("select * from Registrationform where Email='" + txtemail.Text + "' and Password='" + txtpwd.Text + "'", con);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            if (dtt.Rows.Count == 1)
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Registrationform where Email='" + txtemail.Text + "' and Password='" + txtpwd.Text + "' and Activationlink=1", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    Session["email"] = txtemail.Text;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Label1.Text = "Activation Pending";
                }
            }
            else
            {
                Label1.Text = "Invalid username and Password";
            }



        }

      
        
    }
}