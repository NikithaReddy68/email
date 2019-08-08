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
    public partial class Cascadingddpgrid : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TableConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                showgrid();
        }

        private void showgrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Cascadingddwngrid", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gridview1.DataSource = ds;
            gridview1.DataBind();
        }



        protected void gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Value);
            DropDownList drpcountry = gridview1.Rows[e.RowIndex].Cells[1].FindControl("drpcountry") as DropDownList;
            DropDownList drpstate = gridview1.Rows[e.RowIndex].Cells[2].FindControl("drpstate") as DropDownList;
            DropDownList drpcity = gridview1.Rows[e.RowIndex].Cells[3].FindControl("drpcity") as DropDownList;
            gridview1.EditIndex = -1;
            SqlCommand cmd = new SqlCommand("Update Cascadingddwngrid set Country='" + drpcountry.Text + "',State='" + drpstate.Text + "',City='" + drpcity.Text + "' where id='" + id + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            showgrid();

        }

        protected void drpcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList drpcountry = sender as DropDownList;
            GridViewRow row = drpcountry.NamingContainer as GridViewRow;
            DropDownList drpstate = (DropDownList)row.FindControl("drpstate");
            DropDownList drpcity = (DropDownList)row.FindControl("drpcity");
            SqlDataAdapter da = new SqlDataAdapter("Select * from Cascadingddwngrid where Country='" + drpcountry.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            drpstate.DataSource = ds;
            drpstate.DataValueField = "State";
            drpstate.DataTextField = "State";
            drpstate.DataBind();
            drpstate.Items.Insert(0, new ListItem("Select One", "0"));
            RemoveDuplicateItems(drpstate);
            drpstate.SelectedIndex = 0;
            if (drpcountry.SelectedIndex != 0)
            {
                drpstate.Enabled = true;
                drpstate.SelectedIndex = 0;
                drpcity.Enabled = false;
            }
            else
            {
                drpstate.Enabled = false;
                drpcity.Enabled = false;
                drpstate.SelectedIndex = 0;
                drpcity.SelectedIndex = 0;
            }
        }

            void RemoveDuplicateItems(DropDownList drp)
        {
            for (int i = 0; i < drp.Items.Count; i++)
            {
                drp.SelectedIndex = i;
                string str = drp.SelectedItem.ToString();
                for (int counter = i + 1; counter < drp.Items.Count; counter++)
                {
                    drp.SelectedIndex = counter;
                    string compareStr = drp.SelectedItem.ToString();
                    if (str == compareStr)
                    {
                        drp.Items.RemoveAt(counter);
                        counter = counter - 1;
                    }
                }
            }
        }

         protected void gridview1_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
        {
            gridview1.EditIndex = -1;
            showgrid();
        }
        protected void gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridview1.EditIndex = e.NewEditIndex;
           
            showgrid();
        }


        protected void gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Value);
            DropDownList drpcountry = gridview1.Rows[e.RowIndex].Cells[1].FindControl("drpcountry") as DropDownList;
            DropDownList drpstate = gridview1.Rows[e.RowIndex].Cells[2].FindControl("drpstate") as DropDownList;
            DropDownList drpcity = gridview1.Rows[e.RowIndex].Cells[3].FindControl("drpcity") as DropDownList;
            gridview1.EditIndex = -1;
            SqlCommand cmd = new SqlCommand("delete Cascadingddwngrid where id='" + id + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            showgrid();

        }

        protected void gridview1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gridview1.EditIndex == e.Row.RowIndex)
            {
                DropDownList drpcountry = e.Row.FindControl("drpcountry") as DropDownList;
                DropDownList drpstate = e.Row.FindControl("drpstate") as DropDownList;
                DropDownList drpcity = e.Row.FindControl("drpcity") as DropDownList;
                SqlDataAdapter da = new SqlDataAdapter("Select * from Cascadingddwngrid", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                drpcountry.DataSource = ds;
                drpcountry.DataTextField = "country";
                drpcountry.DataValueField = "country";
                drpcountry.DataBind();
                drpcountry.Items.Insert(0, new ListItem("Select One", "0"));
                drpstate.Items.Insert(0, new ListItem("Select One", "0"));
                drpcity.Items.Insert(0, new ListItem("Select One", "0"));
                RemoveDuplicateItems(drpcountry);
                drpcountry.SelectedIndex = 0;
            }

        }

        protected void drpstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList drpstate = sender as DropDownList;
            GridViewRow row = drpstate.NamingContainer as GridViewRow;
            DropDownList drpcity = row.FindControl("drpcity") as DropDownList;
            SqlDataAdapter da = new SqlDataAdapter("Select * from Cascadingddwngrid where State='" + drpstate.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            drpcity.DataSource = ds;
            drpcity.DataValueField = "City";
            drpcity.DataTextField = "City";
            drpcity.DataBind();
            drpcity.Items.Insert(0, new ListItem("Select One", "0"));
            RemoveDuplicateItems(drpcity);
            drpcity.SelectedIndex = 0;
            if (drpstate.SelectedIndex != 0)
            {
                drpcity.Enabled = true;
                drpcity.SelectedIndex = 0;
            }
            else
            {
                drpcity.Enabled = false;
                drpcity.SelectedIndex = 0;
            }

        
        }
    }

}