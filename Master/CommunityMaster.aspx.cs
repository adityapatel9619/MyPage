using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPage.SQLHelper;
using MyPage.Models;

namespace MyPage.Master
{
    public partial class CommunityMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCountryDropDown();
                LoadCountryCityDropDown();
            }
         
        }

        protected void btnAddCountry_Click(object sender, EventArgs e)
        {
            if (IsCountryValid())
            {
                string _sCountryName = tbCountryName.Text.ToString().Trim().ToUpper();
                string _sCountryCode = tbCountryCode.Text.ToString().Trim().ToUpper();

                SqlParameter[] parms = new SqlParameter[4];
                parms[0] = new SqlParameter();
                parms[0].SqlDbType = SqlDbType.VarChar;
                parms[0].ParameterName = "@sCountryName";
                parms[0].Value = _sCountryName;

                parms[1] = new SqlParameter();
                parms[1].SqlDbType = SqlDbType.VarChar;
                parms[1].ParameterName = "@sAltCode";
                parms[1].Value = _sCountryCode;


                parms[2] = new SqlParameter();
                parms[2].SqlDbType = SqlDbType.Bit;
                parms[2].ParameterName = "@sIsActive";
                parms[2].Value = 1;

                parms[3] = new SqlParameter();
                parms[3].SqlDbType = SqlDbType.VarChar;
                parms[3].ParameterName = "@sMessage";
                parms[3].Size = 100;
                parms[3].Direction = ParameterDirection.Output;

                string sMessage = Common.SetData("stp_SetCountryMaster", parms,3);
                string[] sFlags = sMessage.Split(',');

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + sFlags[0].ToString() + "','','" + sFlags[1] + "');", true);
                LoadCountryDropDown();
                LoadCountryCityDropDown();
                tbCountryName.Text = "";
                tbCountryCode.Text = "";
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
            dtDropDownList= Common.GetData("stp_GetCommunityMaster", parms);

            dpCountry.DataSource = dtDropDownList;
            dpCountry.DataBind();
            dpCountry.DataTextField = dtDropDownList.Columns["CountryName"].ToString();
            dpCountry.DataValueField = dtDropDownList.Columns["ID"].ToString();
            dpCountry.DataBind();
            dpCountry.Items.Insert(0, new ListItem("--- Select ---","0"));
        }


        //Validation for Country
        public bool IsCountryValid()
        {

            if (tbCountryName.Text == string.Empty || tbCountryName.Text == "" || tbCountryName.Text.Length <= 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Country Cannot Be Empty','','error');", true);
                tbCountryName.Focus();
                return false;
            }

            if (tbCountryCode.Text == string.Empty || tbCountryCode.Text == "" || tbCountryCode.Text.Length <= 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Country Code Cannot Be Empty','','error');", true);
                tbCountryCode.Focus();
                return false;
            }

            return true;
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
                tbCountryName.Focus();
                return false;
            }

            if (tbStateCode.Text == string.Empty || tbStateCode.Text == "" || tbStateCode.Text.Length <= 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('State Code Cannot Be Empty','','error');", true);
                tbCountryName.Focus();
                return false;
            }

            return true;
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
                }
            }
            catch (Exception ex)
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + ex.Message.ToString() + "','','error');", true);
            }
        }



        //Loads List of Countries for City
        public void LoadCountryCityDropDown()
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

            cmbCountry.DataSource = dtDropDownList;
            cmbCountry.DataBind();
            cmbCountry.DataTextField = dtDropDownList.Columns["CountryName"].ToString();
            cmbCountry.DataValueField = dtDropDownList.Columns["ID"].ToString();
            cmbCountry.DataBind();
            cmbCountry.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }

        //Loads List of State for City
        public void LoadStateCityDropDown(int stateid)
        {
            SqlParameter[] parms = new SqlParameter[2];
            parms[0] = new SqlParameter();
            parms[0].SqlDbType = SqlDbType.VarChar;
            parms[0].ParameterName = "@sType";
            parms[0].Value = "CT";

            parms[1] = new SqlParameter();
            parms[1].SqlDbType = SqlDbType.VarChar;
            parms[1].ParameterName = "@nId";
            parms[1].Value = stateid;

            DataTable dtDropDownList = new DataTable();
            dtDropDownList = Common.GetData("stp_GetCommunityMaster", parms);

            cmbState.DataSource = dtDropDownList;
            cmbState.DataBind();
            cmbState.DataTextField = dtDropDownList.Columns["StateName"].ToString();
            cmbState.DataValueField = dtDropDownList.Columns["StateCode"].ToString();
            cmbState.DataBind();
            cmbState.Items.Insert(0, new ListItem("--- Select ---", "0"));
        }

        //When in City Country Dropdown index is changed
        protected void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityId = Convert.ToInt32(cmbCountry.SelectedValue);
            LoadStateCityDropDown(cityId);

        }
    }
}