using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data.OleDb;
using System.Data.Common;

namespace Emailsent
{
    public partial class ImportExceltogridDB : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mehtabConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridview();
            }
        }

        private void BindGridview()
        {

            SqlCommand cmd = new SqlCommand("spGetAlEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            GridView1.DataSource = cmd.ExecuteReader();
            GridView1.DataBind();

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile != null)
            {
                try

                {
                    string connString = "";
                    string strFileType = Path.GetExtension(FileUpload1.FileName).ToLower();
                    string path = FileUpload1.PostedFile.FileName;


                    //string excelpath = Path.GetFileName(FileUpload1.FileName);
                    //string path = Server.MapPath("~/UploadFile/" + FileUpload1.FileName)+excelpath;
                    //FileUpload1.SaveAs(path);
                    // Connection String to Excel Workbook  
                    connString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                    using (OleDbConnection con = new OleDbConnection(connString))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        DbDataReader dr = cmd.ExecuteReader();
                        // SQL Server Connection String  
                        string CS = ConfigurationManager.ConnectionStrings["mehtabConnectionString"].ConnectionString;
                        // Bulk Copy to SQL Server   
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = "Emplyoee";
                        bulkInsert.WriteToServer(dr);
                        BindGridview();
                        lbl.Text = "Your file uploaded successfully";
                        lbl.ForeColor = System.Drawing.Color.Green;
                    }
                }
                catch (Exception ex )
                {
                    lbl.Text =ex.Message ;
                    lbl.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}