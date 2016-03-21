using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        try
        {
            string cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                DataTable dt = new DataTable();

                SqlDataAdapter sda = new SqlDataAdapter("select FirstName,LastName,City from UserMaster where IsActive = 'True' order by FirstName,LastName", con);
                sda.Fill(dt);

                gvData.DataSource = dt;
                gvData.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;

        }
    }

    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvData.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
}