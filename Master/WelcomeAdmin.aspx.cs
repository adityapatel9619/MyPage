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
using System.IO;

namespace MyPage.Master
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblTxt.Text = Session["AdminUserName"].ToString();
            if (!Page.IsPostBack)
            {
                LoadAdminData();
                //lblHomeIcon.Text = "<h2><i class='fa fa-home fa-3x'></i></h2>";
            }
        }

        public void LoadAdminData()
        {
            try
            {
                AdminModel.sAdminUKID = Session["AdminUniqueID"].ToString();

                DataTable dtAdmin = new DataTable();
                SqlParameter[] parm = new SqlParameter[1];
                parm[0] = new SqlParameter();
                parm[0].SqlDbType = SqlDbType.NVarChar;
                parm[0].ParameterName = "@PsAdminUKID";
                parm[0].Value = AdminModel.sAdminUKID;

                dtAdmin = Common.GetData("stp_GetAdminDetails", parm);

                AdminModel.sAdminName = dtAdmin.Rows[0].ItemArray[0].ToString();
                AdminModel.sAdminDesignation = dtAdmin.Rows[0].ItemArray[1].ToString();
                AdminModel.sAdminBOAddress = dtAdmin.Rows[0].ItemArray[2].ToString();
                AdminModel.sAdminOfficeMailID = dtAdmin.Rows[0].ItemArray[3].ToString();
                AdminModel.sAdminOfficePersonalID = dtAdmin.Rows[0].ItemArray[4].ToString();
                AdminModel.sAdminExtension = dtAdmin.Rows[0].ItemArray[5].ToString();
                AdminModel.sAdminPhone = dtAdmin.Rows[0].ItemArray[6].ToString();

                crdNickName.Text = AdminModel.sAdminName;
                crdDesignation.Text = AdminModel.sAdminDesignation;
                crdBOAdd.Text = AdminModel.sAdminBOAddress;
                crdOffMail.Text = AdminModel.sAdminOfficeMailID;
                crdOffExt.Text = AdminModel.sAdminExtension;
                crdPhone.Text = AdminModel.sAdminPhone;

                string _sImage = Session["AdminUserImage"].ToString();
                crdImage.ImageUrl = "/Images/" + _sImage + "";
                ModImage.ImageUrl = "/Images/" + _sImage + "";
            }
            catch (Exception ex)
            {

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + ex.Message.ToString() + "','','error');", true);
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            string _sFileName = "";
            if (fpChange.HasFile)
            {
                try
                {
                    string sFileName = Path.GetFileName(fpChange.PostedFile.FileName);
                    string sUserName = Session["AdminUniqueID"].ToString();
                    string _saveLocation = Server.MapPath("~/Images/");

                    Guid guid = Guid.NewGuid();
                    string newGuid = guid.ToString();
                    string extension = Path.GetExtension(fpChange.FileName);

                    var FileName = sUserName + "_" + newGuid + extension;
                    fpChange.SaveAs(_saveLocation + FileName);
                    _sFileName = FileName.ToString();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + ex.Message.ToString() + "','','error');", true); ;
                }
            }
            else
            {
                _sFileName = Session["AdminUserImage"].ToString();
            }

            SqlParameter[] parms = new SqlParameter[3];
            parms[0] = new SqlParameter();
            parms[0].SqlDbType = SqlDbType.NVarChar;
            parms[0].ParameterName = "@PsAdminImage";
            parms[0].Value = _sFileName.ToString();

            parms[1] = new SqlParameter();
            parms[1].SqlDbType = SqlDbType.NVarChar;
            parms[1].ParameterName = "@PsAdminUKID";
            parms[1].Value = Session["AdminUniqueID"].ToString();

            parms[2] = new SqlParameter();
            parms[2].SqlDbType = SqlDbType.NVarChar;
            parms[2].ParameterName = "@sMessage";
            parms[2].Size = 100;
            parms[2].Direction = ParameterDirection.Output;

            string _sMessage = Common.SetData("stp_UpdateAdminDashboardDetails", parms, 2);
            string[] sFlags = _sMessage.Split(',');

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + sFlags[0].ToString() + "','','" + sFlags[1] + "');", true);

            if (sFlags[1] == "success")
            {
                Session["AdminUserImage"] = _sFileName.Trim().ToString(); //Setting Updated Image
            }

            PanelModal.Visible = false;
            Response.Redirect(Request.RawUrl);
        }

        //protected void btnChangeImage_Click(object sender, EventArgs e)
        //{
        //    string title = "Greetings";
        //    string body = "Welcome to ASPSnippets.com";
        //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        //}


    }
}