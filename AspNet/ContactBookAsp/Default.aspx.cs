using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
        if (ViewState["dt"] != null)
        {
            btnSave.Visible = true;
        }
        else
        {
            btnSave.Visible = false;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ViewState["dt"] == null)
        {
            CreateDt();
        }

        DataTable dt = (DataTable)ViewState["dt"];

        if (btnAdd.Text.Equals("Update"))
        {
            int srno = Convert.ToInt32(hfSrNo.Value);

            DataRow[] dtr = dt.Select("SrNo = '" + srno + "'");

            if (dtr.Length == 1)
            {
                dtr[0][1] = txtFirstName.Text;
                dtr[0][2] = txtMiddleName.Text;
                dtr[0][3] = txtLstName.Text;
                dtr[0][4] = txtContactNo.Text;
                dtr[0][5] = txtAddress.Text;
                dtr[0][6] = txtCity.Text;
                dtr[0][7] = txtNativePlace.Text;
                dtr[0][8] = txtEmail.Text;
                dtr[0][9] = txtReference.Text;
                dtr[0][10] = txtBdate.Text;
                dtr[0][11] = txtExDate.Text;
                dtr[0][12] = txtEducation.Text;
                dtr[0][13] = txtOccupation.Text;
                dtr[0][14] = txtDesignation.Text;
                dtr[0][15] = txtCompanyName.Text;
                dtr[0][16] = txtWorkAddress.Text;

                btnAdd.Text = "Add";
                btnEdit.Visible = false;
            }

        }
        else
        {


            if (ViewState["SrNo"] == null)
            {
                ViewState["SrNo"] = 0;
            }
            int SrNo = Convert.ToInt32(ViewState["SrNo"]) + 1;

            dt.Rows.Add(SrNo,
                txtFirstName.Text,
                txtMiddleName.Text,
                txtLstName.Text,
                txtContactNo.Text,
                txtAddress.Text,
                txtCity.Text,
                txtNativePlace.Text,
                txtEmail.Text,
                txtReference.Text,
                txtBdate.Text,
                txtExDate.Text,
                txtEducation.Text,
                txtOccupation.Text,
                txtDesignation.Text,
                txtCompanyName.Text,
                txtWorkAddress.Text);

        }
        ClearControls();

        ViewState["dt"] = dt;

        if (dt.Rows.Count > 0)
        {
            btnSave.Visible = true;
        }
        else
        {
            btnSave.Visible = false;
        }

        BindGv();
    }

    private void ClearControls()
    {
        txtFirstName.Text = null;
        txtMiddleName.Text = null;
        txtLstName.Text = null;
        txtContactNo.Text = null;
        txtAddress.Text = null;
        txtCity.Text = null;
        txtNativePlace.Text = null;
        txtEmail.Text = null;
        txtReference.Text = null;
        txtBdate.Text = null;
        txtExDate.Text = null;
        txtEducation.Text = null;
        txtOccupation.Text = null;
        txtDesignation.Text = null;
        txtCompanyName.Text = null;
        txtWorkAddress.Text = null;
    }

    private void BindGv()
    {
        DataTable dt = new DataTable();
        dt = ViewState["dt"] as DataTable;

        gv.DataSource = dt;
        gv.DataBind();

    }

    private void CreateDt()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("SrNo");
        dt.Columns.Add("FirstName");
        dt.Columns.Add("MiddleName");
        dt.Columns.Add("LastName");
        dt.Columns.Add("ContactNo");
        dt.Columns.Add("Address");
        dt.Columns.Add("City");
        dt.Columns.Add("NativeAddress");
        dt.Columns.Add("Email");
        dt.Columns.Add("Reference");
        dt.Columns.Add("Bdate");
        dt.Columns.Add("ExDate");
        dt.Columns.Add("Education");
        dt.Columns.Add("Occupation");
        dt.Columns.Add("Designation");
        dt.Columns.Add("CompanyName");
        dt.Columns.Add("WorkAddress");

        ViewState["dt"] = dt;
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)(sender as Button).NamingContainer;
        int SrNo = Convert.ToInt32((gvr.FindControl("SrNo") as Label).Text);

        if (ViewState["dt"] != null && (ViewState["dt"] as DataTable).Rows.Count > 0)
        {
            DataRow[] dtr = (ViewState["dt"] as DataTable).Select("SrNo = '" + SrNo.ToString() + "'");

            hfSrNo.Value = Convert.ToString(dtr[0][0]);
            txtFirstName.Text = Convert.ToString(dtr[0][1]);
            txtMiddleName.Text = Convert.ToString(dtr[0][2]);
            txtLstName.Text = Convert.ToString(dtr[0][3]);
            txtContactNo.Text = Convert.ToString(dtr[0][4]);
            txtAddress.Text = Convert.ToString(dtr[0][5]);
            txtCity.Text = Convert.ToString(dtr[0][6]);
            txtNativePlace.Text = Convert.ToString(dtr[0][7]);
            txtEmail.Text = Convert.ToString(dtr[0][8]);
            txtReference.Text = Convert.ToString(dtr[0][9]);
            txtBdate.Text = Convert.ToString(dtr[0][10]);
            txtExDate.Text = Convert.ToString(dtr[0][11]);
            txtEducation.Text = Convert.ToString(dtr[0][12]);
            txtOccupation.Text = Convert.ToString(dtr[0][13]);
            txtDesignation.Text = Convert.ToString(dtr[0][14]);
            txtCompanyName.Text = Convert.ToString(dtr[0][15]);
            txtWorkAddress.Text = Convert.ToString(dtr[0][16]);

            pnl.Enabled = false;
            btnEdit.Visible = true;
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        pnl.Enabled = true;
        btnAdd.Text = "Update";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

            DataTable dt = ViewState["dt"] as DataTable;

            using (SqlConnection con = new SqlConnection(cs))
            {
                int i = 0;
                Guid fId = Guid.NewGuid();
           
                foreach (DataRow item in dt.Rows)
                {
                    string insertInto = @"insert into UserMaster (FID,PID,FirstName,MiddleName,LastName,ContactNo,Address,City,NativeAddress,
Email,Reference,Bdate,Exdate,Education,Occupation,Designation,CompanyName,WorkAddress,UID) 
                    values (@FID,@PID,@FirstName,@MiddleName,@LastName,@ContactNo,@Address,@City,@NativeAddress,
@Email,@Reference,@Bdate,@Exdate,@Education,@Occupation,@Designation,@CompanyName,@WorkAddress,@UID)";
                    SqlCommand cmd = new SqlCommand(insertInto, con);

                    cmd.Parameters.AddWithValue("@FID", fId);
                    cmd.Parameters.AddWithValue("@PID", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@FirstName", Convert.ToString(item["FirstName"]));
                    cmd.Parameters.AddWithValue("@MiddleName", Convert.ToString(item["MiddleName"]));
                    cmd.Parameters.AddWithValue("@LastName", Convert.ToString(item["LastName"]));
                    cmd.Parameters.AddWithValue("@ContactNo", Convert.ToString(item["ContactNo"]));
                    cmd.Parameters.AddWithValue("@Address", Convert.ToString(item["Address"]));
                    cmd.Parameters.AddWithValue("@City", Convert.ToString(item["City"]));
                    cmd.Parameters.AddWithValue("@NativeAddress", Convert.ToString(item["NativeAddress"]));
                    cmd.Parameters.AddWithValue("@Email", Convert.ToString(item["Email"]));
                    cmd.Parameters.AddWithValue("@Reference", Convert.ToString(item["Reference"]));
                    cmd.Parameters.AddWithValue("@Bdate", Convert.ToString(item["Bdate"]));
                    cmd.Parameters.AddWithValue("@Exdate", Convert.ToString(item["Exdate"]));
                    cmd.Parameters.AddWithValue("@Education", Convert.ToString(item["Education"]));
                    cmd.Parameters.AddWithValue("@Occupation", Convert.ToString(item["Occupation"]));
                    cmd.Parameters.AddWithValue("@Designation", Convert.ToString(item["Designation"]));
                    cmd.Parameters.AddWithValue("@CompanyName", Convert.ToString(item["CompanyName"]));
                    cmd.Parameters.AddWithValue("@WorkAddress", Convert.ToString(item["WorkAddress"]));
                    cmd.Parameters.AddWithValue("@UID", i++);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        Response.Redirect("List.aspx");
    }
}