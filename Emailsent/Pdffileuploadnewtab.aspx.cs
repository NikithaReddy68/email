using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Emailsent
{
    public partial class Pdffileuploadnewtab : System.Web.UI.Page
    {
         static string constr = ConfigurationManager.ConnectionStrings["TableConnectionString"].ConnectionString;
        SqlConnection con=new SqlConnection(constr);
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                Getfiles();
            }

        }

        protected void b_Click(object sender, EventArgs e)
        {
            if (f1.HasFile)
            {
               string filename  =   f1.PostedFile.FileName;
          string content      =   f1.PostedFile.ContentType;
          Stream strm     =  f1.PostedFile.InputStream;
            f1.SaveAs(Server.MapPath("~/Uploads/"+filename));
          BinaryReader br = new BinaryReader(strm);
         byte[] data=   br.ReadBytes(Convert.ToInt32(strm.Length));

         using (SqlCommand cmd = new SqlCommand("proc_insert ", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", filename);
                //cmd.Parameters.AddWithValue("@contenettype", content);
                cmd.Parameters.AddWithValue("@data", data);
                con.Open();
                cmd.ExecuteNonQuery();
            }
         Getfiles();
        }
            }
        
                
                // Response.Redirect(Request.Url.AbsoluteUri);
           
            protected void Getfiles()
            {
                SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select id, name from files", con);
            con.Open();
          grvDocuments.DataSource  =  cmd.ExecuteReader();
          grvDocuments.DataBind();
          con.Close();
            }

            protected void Downloadfile(object sender, EventArgs e)
            {
                string contenttype; byte[] bytes; string filename;
                int id = Convert.ToInt32((sender as LinkButton).CommandArgument);
                SqlCommand cmd = new SqlCommand("select name,data  from files where id='" + id + "'", con);
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    filename = dr["name"].ToString();
                    //contenttype = dr["contenttype"].ToString();
                    bytes = (byte[])dr["data"];
                }
                con.Close();
                //  QueryString["filename"] = filename;
                Response.Clear();
                // Response.Buffer = true;
                // Response.Charset = "";
                // Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "files";
                // Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.BinaryWrite(bytes);
                //  Response.Flush();
                Response.End();
            }
        protected void Readpdf(object sender, EventArgs e)
        {
            string filename = (sender as LinkButton).CommandArgument;
            Response.Redirect("newPage.aspx?filename=" + filename);
        }

        }
    }




     
    
