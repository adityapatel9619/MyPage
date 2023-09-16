using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyPage.Models;
using MyPage.SQLHelper;

namespace MyPage
{
    public partial class AdminLoginaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbEmail.Text = "admin";
            tbPassword.Text = "admin";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsUserValid())
                {
                    AdminModel.sAdminId = tbEmail.Text.Trim().ToString();        //Storing Username
                    AdminModel.sAdminPassword = tbPassword.Text.Trim().ToString();  //Storing Password

                    DataTable dtUser = new DataTable();
                    SqlParameter[] parm = new SqlParameter[2];
                    parm[0] = new SqlParameter();
                    parm[0].SqlDbType = SqlDbType.VarChar;
                    parm[0].ParameterName = "@PsUid";
                    parm[0].Value = AdminModel.sAdminId;

                    parm[1] = new SqlParameter();
                    parm[1].SqlDbType = SqlDbType.VarChar;
                    parm[1].ParameterName = "@PsPwd";
                    parm[1].Value = AdminModel.sAdminPassword;

                    dtUser = Common.GetData("stp_AdminLogin", parm);

                    if (dtUser.Rows.Count > 0)
                    {
                        AdminModel.sAdminUserId = dtUser.Rows[0].ItemArray[0].ToString();
                        AdminModel.sAdminImage = dtUser.Rows[0].ItemArray[3].ToString();
                        AdminModel.sAdminUKID = dtUser.Rows[0].ItemArray[4].ToString();


                        Session["AdminUserName"] = AdminModel.sAdminUserId;
                        Session["AdminUserImage"] = AdminModel.sAdminImage;
                        Session["AdminUniqueID"] = AdminModel.sAdminUKID;
                        Response.Redirect("Master/WelcomeAdmin.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Invalid Admin','','error');", true);
                    }
                }
            }
            catch (Exception ex)
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('"+ex.Message.ToString()+"','','error');", true);
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