using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace Emailsent
{
    public partial class Securelogin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TableConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from AddEmployee where Username='"+txtuname.Text+"' and Password='"+txtpwd.Text+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string securepass = FormsAuthentication.HashPasswordForStoringInConfigFile(txtpwd.Text, "MD5");
                lbluname.Text = "Your username is: " + txtuname.Text;
                lblpwd.Text = "Your Password is: " + securepass;
                lbluname.ForeColor = System.Drawing.Color.Brown;
                lblpwd.ForeColor = System.Drawing.Color.Brown;
                SqlCommand cmd = new SqlCommand("insert into Securelogin(Username,Password) values('" + txtuname.Text + "','" + securepass + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.Text = "Successfully logined";
                Label1.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                Label1.Text = "Incorrect username and password";
                Label1.ForeColor = System.Drawing.Color.Red;
            }


        }
    }
}