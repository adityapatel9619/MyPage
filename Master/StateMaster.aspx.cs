using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MyPage.SQLHelper;
using MyPage.Models;

namespace MyPage.Master
{
    public partial class StateMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //LoadCountryDropDown();
                //BindState();
            }
        }

        protected void btnAddState_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsStateValid())
                {
                    StateModel.nCountryId = Convert.ToInt32(dpCountry.SelectedValue);
                    StateModel.sStateName = tbStateName.Text.Trim().ToString().ToUpper();
                    StateModel.sStateCode = tbStateCode.Text.Trim().ToString().ToUpper();
                    StateModel.sIsActive = 1;


                    SqlParameter[] parms = new SqlParameter[5];

                    parms[0] = new SqlParameter();
                    parms[0].SqlDbType = SqlDbType.VarChar;
                    parms[0].ParameterName = "@nCountryID";
                    parms[0].Value = StateModel.nCountryId;

                    parms[1] = new SqlParameter();
                    parms[1].SqlDbType = SqlDbType.VarChar;
                    parms[1].ParameterName = "@sStateName";
                    parms[1].Value = StateModel.sStateName;

                    parms[2] = new SqlParameter();
                    parms[2].SqlDbType = SqlDbType.VarChar;
                    parms[2].ParameterName = "@sStateCode";
                    parms[2].Value = StateModel.sStateCode;

                    parms[3] = new SqlParameter();
                    parms[3].SqlDbType = SqlDbType.VarChar;
                    parms[3].ParameterName = "@sIsActive";
                    parms[3].Value = StateModel.sIsActive;

                    parms[4] = new SqlParameter();
                    parms[4].SqlDbType = SqlDbType.VarChar;
                    parms[4].ParameterName = "@sMessage";
                    parms[4].Size = 100;
                    parms[4].Direction = ParameterDirection.Output;

                    StateModel.sMessage = Common.SetData("stp_SetStateMaster", parms, 4);
                    string[] sFlags = StateModel.sMessage.Split(',');

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + sFlags[0].ToString() + "','','" + sFlags[1] + "');", true);

                    dpCountry.SelectedIndex = 0;
                    tbStateName.Text = "";
                    tbStateCode.Text = "";

                    BindState();
                }
            }
            catch (Exception ex)
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('"+ex.Message.ToString()+"','','error');", true);
            }
        }

        //Loads List of Countries
        public void LoadCountryDropDown()
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter();
            parms[0].SqlDbType = SqlDbType.VarChar;
            parms[0].ParameterName = "@sType";
            parms[0].Value = "S";

            parms[1] = new SqlParameter();
            parms[1].SqlDbType = SqlDbType.VarChar;
            parms[1].ParameterName = "@nId";
            parms[1].Value = 0;

            DataTable dtDropDownList = new DataTable();
            dtDropDownList = Common.GetData("stp_GetCommunityMaster", parms);

            dpCountry.DataSource = dtDropDownList;
            dpCountry.DataBind();
            dpCountry.DataTextField = dtDropDownList.Columns["CountryName"].ToString();
            dpCountry.DataValueField = dtDropDownList.Columns["ID"].ToString();
            dpCountry.DataBind();
            dpCountry.Items.Insert(0, new ListItem("--- Select ---", "0"));

            //dpFilterCountry.DataSource = dtDropDownList;
            //dpFilterCountry.DataBind();
            //dpFilterCountry.DataTextField = dtDropDownList.Columns["CountryName"].ToString();
            //dpFilterCountry.DataValueField = dtDropDownList.Columns["ID"].ToString();
            //dpFilterCountry.DataBind();
            //dpFilterCountry.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }

        //Validation for State
        public bool IsStateValid()
        {
            if (dpCountry.SelectedIndex <= 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Invalid Country','','error');", true);
                dpCountry.Focus();
                return false;
            }

            if (tbStateName.Text == string.Empty || tbStateName.Text == "" || tbStateName.Text.Length <= 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('State Name Cannot Be Empty','','error');", true);
                tbStateName.Focus();
                return false;
            }

            if (tbStateCode.Text == string.Empty || tbStateCode.Text == "" || tbStateCode.Text.Length <= 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('State Code Cannot Be Empty','','error');", true);
                tbStateCode.Focus();
                return false;
            }

            return true;
        }

        protected void gvState_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvState.EditIndex = e.NewEditIndex;
            BindState();
        }

        protected void gvState_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvState.EditIndex = -1;
            BindState();
        }

        protected void gvState_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = gvState.Rows[e.RowIndex].FindControl("lblStateID") as Label;
            TextBox statename = gvState.Rows[e.RowIndex].FindControl("tbStateName") as TextBox;
            TextBox statecode = gvState.Rows[e.RowIndex].FindControl("tbStateCode") as TextBox;

            string command = "UPDATE tbl_StateMaster SET sStateName ='" + statename.Text.ToString().ToUpper() + "', sStateCode ='" + statecode.Text.ToString().ToUpper() +
                "' WHERE nID = " + Convert.ToInt32(id.Text)+"";
            Common.SetStringCommandData(command);
            gvState.EditIndex = -1;
            BindState();
        }

        public void BindState()
        {
            string command = "SELECT * FROM vw_GetState";

            DataTable dt = new DataTable();
            dt = Common.GetStringCommandData(command);

            gvState.DataSource = dt;
            gvState.DataBind();
        }

        protected void gvState_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label id = gvState.Rows[e.RowIndex].FindControl("lblStateID") as Label;
            string command = "DELETE tbl_StateMaster WHERE nID =" + Convert.ToInt32(id.Text);
            Common.SetStringCommandData(command);
            gvState.EditIndex = -1;
            BindState();
        }


        //protected void dpFilterCountry_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int id = Convert.ToInt32(dpFilterCountry.SelectedValue);

        //    string command = "SELECT nID AS 'ID',sStateName AS 'StateName',sStateCode AS 'StateCode' FROM tbl_StateMaster WHERE nCountryCode = " + id;
        //    DataTable dt = Common.GetStringCommandData(command);
        //    gvState.DataSource = dt;
        //    gvState.DataBind();
        //}
       
    }
}