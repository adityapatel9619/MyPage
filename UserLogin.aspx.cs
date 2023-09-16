using MyPage.Models;
using MyPage.SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyPage
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbEmail.Text = "adityapatel9619@gmail.com";
            tbPassword.Text = "123";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsUserValid())
                {
                    UserModel.sUserLoginId = tbEmail.Text.Trim().ToString();        //Storing Username
                    UserModel.sUserLoginPassword = Common.EncryptString(tbPassword.Text.Trim().ToString());     //Storing Password

                    DataTable dtUser = new DataTable();
                    SqlParameter[] parm = new SqlParameter[2];
                    parm[0] = new SqlParameter();
                    parm[0].SqlDbType = SqlDbType.VarChar;
                    parm[0].ParameterName = "@PsUid";
                    parm[0].Value = UserModel.sUserLoginId;

                    parm[1] = new SqlParameter();
                    parm[1].SqlDbType = SqlDbType.VarChar;
                    parm[1].ParameterName = "@PsPwd";
                    parm[1].Value = UserModel.sUserLoginPassword;

                    dtUser = Common.GetData("stp_UserLogin", parm);

                    if (dtUser.Rows.Count > 0)
                    {
                        UserModel.sFirstName = dtUser.Rows[0].ItemArray[0].ToString();
                        UserModel.sLastName = dtUser.Rows[0].ItemArray[1].ToString();
                        UserModel.sUserEmail = dtUser.Rows[0].ItemArray[2].ToString();
                        UserModel.sUserImage = dtUser.Rows[0].ItemArray[3].ToString();
                        UserModel.sUserId = dtUser.Rows[0].ItemArray[4].ToString();
                        
                        Session["UserFirstName"] = UserModel.sFirstName;
                        Session["UserLastName"] = UserModel.sLastName;
                        Session["UserEmail"] = UserModel.sUserEmail;
                        Session["UserImage"] = UserModel.sUserImage;
                        Session["UserId"] = UserModel.sUserId;

                        Response.Redirect("Master/WelcomeUser.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Invalid User','','error');", true);
                    }
                }
            }
            catch (Exception ex)
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + ex.Message.ToString() + "','','error');", true);
            }
        }

        public bool IsUserValid()
        {
            if (tbEmail.Text == string.Empty || tbEmail.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Username is Empty','','error');", true);
                tbEmail.Focus();
                return false;
            }

            if (tbPassword.Text == string.Empty || tbPassword.Text == "")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Password is Empty','','error');", true);
                tbPassword.Focus();
                return false;
            }

            return true;
        }
    }
}