using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;


namespace Emailsent
{
    public partial class Importexceltogrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = Path.GetFileName(FileUpload1.FileName);
            path = path.Replace(" ", " ");
            
            string Excelpath = Server.MapPath("~/ExcelFile/") + path;
            OleDbConnection oldb = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Excelpath + ";Extended Properties=\"Excel 12.0 Xml;HDR=NO;IMEX=1;\"");
            oldb.Open();
            OleDbCommand olcmd = new OleDbCommand("select * from [Sheet1$]", oldb);
            OleDbDataAdapter olsda = new OleDbDataAdapter();
            olsda.SelectCommand = olcmd;
            DataTable da = new DataTable();
            olsda.Fill(da);
            GridView1.DataSource = da;
            GridView1.DataBind();
            oldb.Close();
            Label1.Text = "Excel file has been saved and data captured";


        }
    }
}