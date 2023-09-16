using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MyPage.SQLHelper;
using System.Configuration;

namespace MyPage.Master
{
    public partial class UserProfessionalDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitializeGrid();
                SetValues();
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            MultiView1.ActiveViewIndex = index;
        }


        private void InitializeGrid()
        {
            try
            {
                
                DataTable dt = new DataTable();
                DataRow dr = null;

                SqlParameter[] parm = new SqlParameter[1];
                parm[0] = new SqlParameter();
                parm[0].SqlDbType = SqlDbType.VarChar;
                parm[0].ParameterName = "@PsEmpID";
                parm[0].Value = Session["UserId"].ToString();

                dt = Common.GetData("stp_GetUserProfessionalDetails",parm);

                if (dt.Rows.Count > 0)
                {
                    gvExperience.DataSource = dt;
                    gvExperience.DataBind();
                    ViewState["applicationDetail"] = dt;
                }
                else
                {

                    dt.Clear();
                    //dt.Columns.Add(new DataColumn("Id", typeof(int)));
                    //dt.Columns.Add(new DataColumn("CompanyName", typeof(string)));
                    //dt.Columns.Add(new DataColumn("StartDate", typeof(string)));
                    //dt.Columns.Add(new DataColumn("EndDate", typeof(string)));

                    dr = dt.NewRow();
                    dr["Id"] = 1;
                    dr["CompanyName"] = string.Empty;
                    dr["StartDate"] = string.Empty;
                    dr["EndDate"] = string.Empty;
                    dt.Rows.Add(dr);

                    ViewState["applicationDetail"] = dt;

                    gvExperience.DataSource = dt;
                    gvExperience.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        protected void btnNewRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["applicationDetail"] != null)
                {
                    DataTable dt = (DataTable)ViewState["applicationDetail"];
                    DataRow dr;
                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.NewRow();
                        dr["Id"] = dt.Rows.Count + 1;
                        dt.Rows.Add(dr);
                        ViewState["applicationDetail"] = dt;

                        for (int i = 0; i < dt.Rows.Count - 1; i++)
                        {
                            TextBox t1 = (TextBox)gvExperience.Rows[i].Cells[1].Controls[1];
                            TextBox t2 = (TextBox)gvExperience.Rows[i].Cells[2].Controls[1];
                            TextBox t3 = (TextBox)gvExperience.Rows[i].Cells[3].Controls[1];
                            //TextBox t1 = (TextBox)gvExperience.Rows[i].Cells[1].FindControl("CompanyName");
                            //TextBox t2 = (TextBox)gvExperience.Rows[i].Cells[2].FindControl("StartDate");
                            //TextBox t3 = (TextBox)gvExperience.Rows[i].Cells[3].FindControl("EndDate");

                            dt.Rows[i]["CompanyName"] = t1.Text;
                            dt.Rows[i]["StartDate"] = t2.Text;
                            dt.Rows[i]["EndDate"] = t3.Text;
                        }

                        gvExperience.DataSource = dt;
                        gvExperience.DataBind();
                    }
                    else
                    {
                        Response.Write("ViewState is null");
                    }

                    SetPreviousData();
                }
            }
            catch (Exception ex)
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('"+ex.Message.ToString()+"','','warning');", true);
            }
        }

        private void SetPreviousData()
        {
            try
            {
                int rowIndex = 0;

                if (ViewState["applicationDetail"] != null)
                {
                    DataTable dt = (DataTable)ViewState["applicationDetail"];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            TextBox tb1 = (TextBox)gvExperience.Rows[i].Cells[1].Controls[1];
                            TextBox tb2 = (TextBox)gvExperience.Rows[i].Cells[2].Controls[1];
                            TextBox tb3 = (TextBox)gvExperience.Rows[i].Cells[3].Controls[1];
                            //TextBox tb1 = (TextBox)gvExperience.Rows[rowIndex].Cells[1].FindControl("CompanyName");
                            //TextBox tb2 = (TextBox)gvExperience.Rows[rowIndex].Cells[2].FindControl("StartDate");
                            //TextBox tb3 = (TextBox)gvExperience.Rows[rowIndex].Cells[3].FindControl("EndDate");

                            tb1.Text = dt.Rows[i]["CompanyName"].ToString();
                            tb2.Text = dt.Rows[i]["StartDate"].ToString();
                            tb3.Text = dt.Rows[i]["EndDate"].ToString();

                            rowIndex++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnDraft_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)ViewState["applicationDetail"];


                    DataTable experienceTable = new DataTable();
                    DataRow dRow;
                    experienceTable.Columns.Add(new DataColumn("nID", typeof(int)));
                    experienceTable.Columns.Add(new DataColumn("sCompanyName", typeof(string)));
                    experienceTable.Columns.Add(new DataColumn("sStartDate", typeof(DateTime)));
                    experienceTable.Columns.Add(new DataColumn("sEndDate", typeof(DateTime)));
                    experienceTable.Columns.Add(new DataColumn("sEmployeeID", typeof(string)));
                    experienceTable.Columns.Add(new DataColumn("nStatus", typeof(string)));
                    experienceTable.Columns.Add(new DataColumn("dLUT", typeof(DateTime)));

                    int rows = 1;
                    foreach (GridViewRow row in gvExperience.Rows)
                    {
                        TextBox txtCompanyName = (TextBox)row.FindControl("tbCompanyName");
                        TextBox txtStartDate = (TextBox)row.FindControl("tbStartDate");
                        TextBox txtEndDate = (TextBox)row.FindControl("tbEndDate");

                        dRow = experienceTable.NewRow();
                        dRow[0] = rows;
                        dRow[1] = txtCompanyName.Text;
                        dRow[2] = txtStartDate.Text;
                        dRow[3] = txtEndDate.Text;
                        dRow[4] = Session["UserId"].ToString();
                        dRow[5] = Convert.ToInt32(0);
                        dRow[6] = DateTime.Now;
                        experienceTable.Rows.Add(dRow);
                        rows++;
                    }

                    SqlParameter[] parms = new SqlParameter[3];
                    parms[0] = new SqlParameter();
                    parms[0].SqlDbType = SqlDbType.Structured;
                    parms[0].ParameterName = "@dtExperienceDetails";
                    parms[0].Value = experienceTable;

                    parms[1] = new SqlParameter();
                    parms[1].SqlDbType = SqlDbType.VarChar;
                    parms[1].ParameterName = "@sEmpID";
                    parms[1].Value = Session["UserId"].ToString();

                    parms[2] = new SqlParameter();
                    parms[2].SqlDbType = SqlDbType.NVarChar;
                    parms[2].ParameterName = "@sMessage";
                    parms[2].Size = 100;
                    parms[2].Direction = ParameterDirection.Output;

                    string _sMessage = Common.SetData("stp_SetUserExperienceDetails", parms, 2);
                    string[] sFlags = _sMessage.Split(',');

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + sFlags[0].ToString() + "','','" + sFlags[1] + "');", true);

                    //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()))
                    //{
                    //    SqlCommand cmd = conn.CreateCommand();
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.CommandText = "stp_SetUserExperienceDetails";
                    //    SqlParameter param = cmd.Parameters.AddWithValue("@dtExperienceDetails", experienceTable);
                    //    conn.Open();
                    //    cmd.ExecuteNonQuery();
                    //    conn.Close();
                    //}
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + ex.Message.ToString() + "','','error');", true);
            }
        }

        public bool IsValidData()
        {
            if (tbFName.Text == string.Empty || tbFName.Text == "" || tbFName.Text.Length<= 0 )
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('First Name Cannot Be Empty','','warning');", true);
                tbFName.Focus();
                return false;
            }

            if (tblName.Text == string.Empty || tblName.Text == "" || tblName.Text.Length <= 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Last Name Cannot Be Empty','','warning');", true);
                tblName.Focus();
                return false;
            }

            if (dtDoJ.Text == string.Empty || dtDoJ.Text == "" || dtDoJ.Text.Length <= 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Date of Joining Cannot Be Empty','','warning');", true);
                dtDoJ.Focus();
                return false;
            }

            if (tbEMPID.Text == string.Empty || tbEMPID.Text == "" || tbEMPID.Text.Length <= 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Employee ID Cannot Be Empty','','warning');", true);
                tbEMPID.Focus();
                return false;
            }

            if (tbEmailID.Text == string.Empty || tbEmailID.Text == "" || tbEmailID.Text.Length <= 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Email ID Cannot Be Empty','','warning');", true);
                tbEmailID.Focus();
                return false;
            }

            //DataTable dt = new DataTable();
            //dt = (DataTable)gvExperience;

            for (int i = 0; i < gvExperience.Rows.Count; i++)
            {
                TextBox tbCompanyName = gvExperience.Rows[i].FindControl("tbCompanyName") as TextBox;
                TextBox tbStartDate = gvExperience.Rows[i].FindControl("tbStartDate") as TextBox;
                TextBox tbEndDate = gvExperience.Rows[i].FindControl("tbEndDate") as TextBox;

                DateTime dstartDate = DateTime.Parse(tbStartDate.Text);
                DateTime dEndDate = DateTime.Parse(tbEndDate.Text);

                if (tbCompanyName.Text.ToString() == "" || tbCompanyName.Text.ToString() == string.Empty || tbCompanyName.Text.ToString().Length <= 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Few Details missing in Experience Section','','warning');", true);
                    gvExperience.Focus();
                    return false;
                }

                if (tbStartDate.Text.ToString() == "" || tbStartDate.Text.ToString() == string.Empty || tbStartDate.Text.ToString().Length <= 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Few Details missing in Experience Section','','warning');", true);
                    gvExperience.Focus();
                    return false;
                }


                if (dstartDate >= DateTime.Now)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + tbCompanyName.Text.ToString() + " Start Date Cannot be Greater than Today','','warning');", true);
                    tbStartDate.Focus();
                    return false;
                }

                if (dEndDate >= DateTime.Now)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + tbCompanyName.Text.ToString() + " End Date Cannot be Greater than Today','','warning');", true);
                    tbEndDate.Focus();
                    return false;
                }

                if (tbEndDate.Text.ToString() == "" || tbEndDate.Text.ToString() == string.Empty || tbEndDate.Text.ToString().Length <= 0)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Few Details missing in Experience Section','','warning');", true);
                    gvExperience.Focus();
                    return false;
                }
            }

            return true;
        }
    
        public void SetValues()
        {
            tbFName.Text = Session["UserFirstName"].ToString();
            tblName.Text = Session["UserLastName"].ToString();
            tbEmailID.Text = Session["UserEmail"].ToString();
            tbEMPID.Text = "E001";
            dtDoJ.Text = "2022-01-11";
        }
    
    }
}