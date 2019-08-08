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
    public partial class Cascadingdropdownlist : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cascadingddl();
            }
        }

        protected void Cascadingddl()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Country",con);
            cmd.CommandType = CommandType.Text;
            ddlcountry.DataSource = cmd.ExecuteReader();
            ddlcountry.DataTextField = "CountryName";
            ddlcountry.DataValueField = "CID";
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0,new ListItem("--Select Country--","0"));
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int CountryId = Convert.ToInt32(ddlcountry.SelectedValue);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from State where CID='"+CountryId+"'",con);
            cmd.CommandType = CommandType.Text;
            ddlstate.DataSource = cmd.ExecuteReader();
            ddlstate.DataTextField = "StateName";
            ddlstate.DataValueField = "SID";
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select State--", "0"));
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int StateId = Convert.ToInt32(ddlstate.SelectedValue);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from City where SID='"+StateId+"'",con);
            cmd.CommandType = CommandType.Text;
            ddlcity.DataSource = cmd.ExecuteReader();
            ddlcity.DataTextField = "CityName";
            ddlcity.DataValueField = "CityID";
            ddlcity.DataBind();
            ddlcity.Items.Insert(0,new ListItem("--Slect City--","0"));
        }
    }
}