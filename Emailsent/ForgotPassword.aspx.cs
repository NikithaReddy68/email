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
using System.Net;
using System.Net.Mail;


namespace Emailsent
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btngetpwd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select Email,Password from Registrationform where Email='" + txtregemail.Text + "'", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string email = sdr["Email"].ToString();
                string password = sdr["Password"].ToString();

                MailMessage msg = new MailMessage("xxxxxxxxxxx@gmail.com", txtregemail.Text);
                
                msg.Subject = "Your Password !";
                msg.Body = string.Format("Hello:<h1>{0}</h1> is your email id <br/> your password is <h1>{1}</h1>", email, password);
                msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential nc = new NetworkCredential();
                nc.UserName="xxxxxxxxxx@gmail.com";
                nc.Password = "xxxxxxxx";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Port = 587;
                smtp.Send(msg);
                lblpwdsent.Text = "Your Password has been sent to " + txtregemail.Text;
                lblpwdsent.ForeColor = Color.Red;
            }
            else
            {
                lblpwdsent.Text = txtregemail.Text + "- This email id is not exists";
                lblpwdsent.ForeColor = Color.Red;
            }
        }
    }
}