using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace Emailsent
{
    public partial class Emailsent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {

            MailMessage msgg = new MailMessage();
            msgg.From = new MailAddress("xxxxxxxxxxx@gmail.com");
            msgg.To.Add(txtemail.Text);
            msgg.Subject = "Email sent successfully";
            msgg.Body = txtmsg.Text;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 25;           
            smtp.Credentials = new System.Net.NetworkCredential("xxxxxxxxx@gmail.com", "xxxxxxxxxxx");
            smtp.EnableSsl = true;
            smtp.Send(msgg);
            lblerror.Text = "Message sent successfully";

            

        }
    }
}


