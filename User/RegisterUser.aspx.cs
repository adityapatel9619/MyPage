using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MyPage.Models;
using MyPage.SQLHelper;

namespace MyPage.User
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                UserModel.sFirstName = tbName.Text.Trim().ToString();
                UserModel.sLastName = tbLastName.Text.Trim().ToString();
                UserModel.sUserPassword = Common.EncryptString(tbPass.Text.Trim().ToString());
                UserModel.sUserEmail = tbEmail.Text.Trim().ToString();

                SqlParameter[] parms = new SqlParameter[5];
                parms[0] = new SqlParameter();
                parms[0].SqlDbType = SqlDbType.VarChar;
                parms[0].ParameterName = "@PsFName";
                parms[0].Value = UserModel.sFirstName;

                parms[1] = new SqlParameter();
                parms[1].SqlDbType = SqlDbType.VarChar;
                parms[1].ParameterName = "@PsLName";
                parms[1].Value = UserModel.sLastName;

                parms[2] = new SqlParameter();
                parms[2].SqlDbType = SqlDbType.VarChar;
                parms[2].ParameterName = "@PsEmail";
                parms[2].Value = UserModel.sUserEmail;

                parms[3] = new SqlParameter();
                parms[3].SqlDbType = SqlDbType.VarChar;
                parms[3].ParameterName = "@PsPass";
                parms[3].Value = UserModel.sUserPassword;

                parms[4] = new SqlParameter();
                parms[4].SqlDbType = SqlDbType.VarChar;
                parms[4].ParameterName = "@PsError";
                parms[4].Size = 100;
                parms[4].Direction = ParameterDirection.Output;

                string Message = Common.SetData("stp_RegisterUser", parms, 4);
                string[] sFlags = Message.Split(',');

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + sFlags[0].ToString() + "','','" + sFlags[1] + "');", true);

                tbName.Text = "";
                tbLastName.Text = "";
                tbEmail.Text = "";
                tbPass.Text = "";
                //Response.Redirect("/");
            }
        }

        public bool IsValidData()
        {
            if (tbName.Text.ToString() == null || tbName.Text.ToString() == string.Empty || tbName.Text.ToString() == "") 
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('First Name Is Blank','','error');", true);
                return false;
            }

            if (tbLastName.Text.ToString() == null || tbLastName.Text.ToString() == string.Empty || tbLastName.Text.ToString() == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Last Name Is Blank','','error');", true);
                return false;
            }

            if (tbEmail.Text.ToString() == null || tbEmail.Text.ToString() == string.Empty || tbEmail.Text.ToString() == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Email Is Blank','','error');", true);
                return false;
            }

            if (tbPass.Text.ToString() == null || tbPass.Text.ToString() == string.Empty || tbPass.Text.ToString() == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Password Is Blank','','error');", true);
                return false;
            }

            if (!chkTerms.Checked)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Kindly Agree Terms and Condition','','warning');", true);
                return false;
            }

            return true;
        }
    }
}