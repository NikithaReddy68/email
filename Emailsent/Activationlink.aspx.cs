using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Emailsent
{
    public partial class Activationlink : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Gridview();
            
            

        }

        private string getemail(string Email)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Id from Registrationform where Email='"+txtemail.Text+"'", con);
            string userid = cmd.ExecuteScalar().ToString();
            return userid;
            con.Close();
        }

        private void Sendemail()
        {
            string ActivationUrl;
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("xxxxxxxxxxxxxx@gmail.com");
            msg.To.Add(txtemail.Text);
            msg.Subject = "Email Verification";
            ActivationUrl = Server.HtmlEncode("http://localhost:1871/login.aspx?Id="+getemail(txtemail.Text));
            msg.Body = "<a href='"+ActivationUrl+"'>Click here to activate your account</a>";
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("xxxxxxx@gmail.com", "xxxxxxxxxxxx");
            smtp.EnableSsl = true;
            smtp.Send(msg);
            
            
        }

        private void Gridview()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from Registrationform", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            gridview.DataSource = dt;
            gridview.DataBind();
        }

        

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            int id = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Registrationform(Name,Contactno,Email,Password,Location,Gender) values('" + txtname.Text + "','" + txtcontact.Text + "','" + txtemail.Text + "','" + txtpwd.Text + "','" + txtlocation.Text + "','" + ddlgender.SelectedValue + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Gridview();
            Sendemail();
            if(id==0)
            {
                lblsuccess.Text = "Registration successfully";
            }
            else
            {
                lblsuccess.Text="not registered";
            }
        }

        protected void btnalreadyreg_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActivationLogin.aspx");
        }
    }
}