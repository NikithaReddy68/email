using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Emailsent
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //protected void btnchangepwd_Click(object sender, EventArgs e)
        //{
            
        //    lblmsg.Text = "";
        //    SqlDataAdapter sda = new SqlDataAdapter("select * from Registrationform where Password='"+txtoldpwd.Text+"'",con);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    if (dt.Rows.Count == 0)
        //    {
        //        lblmsg.Text = "Invalid current password";
        //        lblmsg.ForeColor = Color.Red;
        //    }
        //    else
        //    {            
        //        SqlDataAdapter sdp = new SqlDataAdapter("update Registrationform set Password='"+txtnewpwd.Text+"' where Email='"+Session["email"].ToString()+"'",con);
        //        sda.Fill(dt);
        //        lblmsg.Text = "Password changed succesfully";
        //        lblmsg.ForeColor = Color.Purple;
        //    }
        //}

        protected void btnchangepwd_Click1(object sender, EventArgs e)
        {

            lblmsg.Text = "";
            SqlDataAdapter sda = new SqlDataAdapter("select * from Registrationform where Password='" + txtoldpwd.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                lblmsg.Text = "Invalid current password";
                lblmsg.ForeColor = Color.Red;
            }
            else
            {
                SqlDataAdapter sdp = new SqlDataAdapter("update Registrationform set Password='" + txtnewpwd.Text + "' where Email='" + Session["email"].ToString() + "'", con);
                sdp.Fill(dt);
                lblmsg.Text = "Password changed succesfully";
                lblmsg.ForeColor = Color.Purple;
            }
        }       
    }
}