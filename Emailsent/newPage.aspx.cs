using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;


namespace Emailsent
{
    public partial class newPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fileName = Request.QueryString["filename"];
            string path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
            WebClient client = new WebClient();

            Byte[] buffer = client.DownloadData(path);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Content-Type", "application/xls");
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" + fileName);
            HttpContext.Current.Response.BinaryWrite(buffer);
            HttpContext.Current.Response.End();
        }
    }
}