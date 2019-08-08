using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Emailsent
{
    public partial class Fileupload : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lblupload_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/images/" + FileUpload1.FileName));
            }

            SqlCommand cmd = new SqlCommand("insert into Fileuploadgrid(ImageName,Image) values('" + txtimagename.Text + "','" + "~/images/" + FileUpload1.FileName + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Image uploaded successfully";
            Label1.ForeColor = System.Drawing.Color.Green;
            SqlDataAdapter sda = new SqlDataAdapter("select * from Fileuploadgrid", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            GridView1.DataSourceID = null;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSourceID = null;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
            Label1.Text = "";
            GridView1.EditRowStyle.BackColor = System.Drawing.Color.OrangeRed;
        }

        protected void GridView1_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSourceID = null;
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
            Label1.Text = "";
        }

        protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
            int Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string path = "";
            TextBox ImageName = GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
            FileUpload Image = GridView1.Rows[e.RowIndex].FindControl("FileUpload3") as FileUpload;
            if (Image.HasFile)
            {
                Image.PostedFile.SaveAs(Server.MapPath("~/images/" + Image.FileName));
                path = "~/images/" + Image.FileName;
            }


            SqlCommand sda = new SqlCommand("update Fileuploadgrid set ImageName='" + txtimagename.Text + "',Image='" + path + "' where Id='" + Id + "'", con);
            con.Open();
            sda.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Row updated sucessfully";
            GridView1.EditIndex = -1;
            GridView1.DataSourceID = null;
            SqlDataSource1.DataBind();
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataSourceID = null;
        }

        //protected void LinkButton3_Click(object sender, EventArgs e)
        //{
        //    if (e.CommandName == "Select")
        //    {

        //    }
        //    int Id = Convert.ToInt32(GridView1.DataKeys[rowindex].Value);
        //    TextBox ImageName = GridView1.FooterRow.FindControl("TextBox3") as TextBox;
        //    string path = "";
        //    FileUpload Image = GridView1.FooterRow.FindControl("FileUpload3") as FileUpload;
        //    if (Image.HasFile)
        //    {
        //        Image.PostedFile.SaveAs(Server.MapPath("~/images/" + Image.FileName));
        //        path = "~/images/" + Image.FileName;
        //    }
        //    SqlCommand sda = new SqlCommand("update Fileuploadgrid set ImageName='" + txtimagename.Text + "',Image='" + path + "' where Id='" + Id + "'", con);
        //    con.Open();
        //    sda.ExecuteNonQuery();
        //    con.Close();
        //    Label1.Text = "Rows inserted successfully";
        //    SqlDataSource1.DataBind();
        //    GridView1.DataSourceID = null;
        //    GridView1.DataSource = SqlDataSource1;
        //    GridView1.DataBind();
        //}

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int Id = Convert.ToInt32(e.CommandArgument);
                TextBox ImageName = GridView1.FooterRow.FindControl("TextBox3") as TextBox;
                string path = "";
                FileUpload Image = GridView1.FooterRow.FindControl("FileUpload3") as FileUpload;
                if (Image.HasFile)
                {
                    Image.PostedFile.SaveAs(Server.MapPath("~/images/" + Image.FileName));
                    path = "~/images/" + Image.FileName;
                }
                SqlCommand sda = new SqlCommand("update Fileuploadgrid set ImageName='" + txtimagename.Text + "',Image='" + path + "' where Id='" + Id + "'", con);
                con.Open();
                sda.ExecuteNonQuery();
                con.Close();
                Label1.Text = "Rows inserted successfully";
                SqlDataSource1.DataBind();
                GridView1.DataSourceID = null;
                GridView1.DataSource = SqlDataSource1;
                GridView1.DataBind();
            }
        }
    }
}