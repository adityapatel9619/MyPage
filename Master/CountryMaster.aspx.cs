using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPage.SQLHelper;
using MyPage.Models;
using System.Data.SqlClient;
using System.Data;

namespace MyPage.Master
{
    public partial class CountryMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Bind();
            }
        }


        protected void btnAddCountry_Click(object sender, EventArgs e)
        {
            try
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

                    string sMessage = Common.SetData("stp_SetCountryMaster", parms, 3);
                    string[] sFlags = sMessage.Split(',');

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + sFlags[0].ToString() + "','','" + sFlags[1] + "');", true);

                    tbCountryName.Text = "";
                    tbCountryCode.Text = "";
                    Bind();
                }

            }
            catch (Exception ex)
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + ex.Message.ToString() + "','','error');", true);
            }
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

        protected void gvCountry_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCountry.EditIndex = e.NewEditIndex;
            Bind();
        }

        protected void gvCountry_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCountry.EditIndex = -1;
            Bind();
        }

        protected void gvCountry_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = gvCountry.Rows[e.RowIndex].FindControl("lblCountryID") as Label;
            TextBox countryName = gvCountry.Rows[e.RowIndex].FindControl("tbCountryName") as TextBox;
            TextBox coutryCode = gvCountry.Rows[e.RowIndex].FindControl("tbCountryCode") as TextBox;

            string Command = "UPDATE tbl_CountryMaster SET sCountryName = '"+countryName.Text.ToString().ToUpper()+"', sAltCode = '"+coutryCode.Text.ToString().ToUpper()+"' " +
                "WHERE nID ="+Convert.ToInt32(id.Text)+"";

            Common.SetStringCommandData(Command);
            gvCountry.EditIndex = -1;
            Bind();
        }

        public void Bind()
        {
            string command = "SELECT * FROM vw_GetCountry";

            DataTable dt = new DataTable();
            dt = Common.GetStringCommandData(command);

            gvCountry.DataSource = dt;
            gvCountry.DataBind();
        }
    }
}