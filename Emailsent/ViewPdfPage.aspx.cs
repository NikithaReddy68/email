using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Emailsent
{
    public partial class ViewPdfPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string filePath = Request.QueryString["fileName"];
                Response.ContentType = "Application/pdf";
                Response.WriteFile(filePath);
                Response.End();
            }
        }
    }
}