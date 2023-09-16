using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MyPage.SQLHelper;
using System.IO;

namespace MyPage.Master
{
    public partial class UserPersonalDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _sFirstName = Session["UserFirstName"].ToString();
                string _sLasttName = Session["UserFirstName"].ToString();
                string _sUserEmailId = Session["UserEmail"].ToString();
                string _sUserImage = Session["UserImage"].ToString();
                string _sUserId = Session["UserId"].ToString();
                Image.ImageUrl = "/Images/" + _sUserImage + "";

                SetData();
            }
        }


        public void SetData()
        {
            try
            {
                string _sUserUQId = Session["UserId"].ToString();

                SqlParameter[] parms = new SqlParameter[1];
                parms[0] = new SqlParameter();
                parms[0].SqlDbType = SqlDbType.NVarChar;
                parms[0].ParameterName = "@PsUserId";
                parms[0].Value = _sUserUQId;

                DataTable dt = Common.GetData("stp_GetUserDetails", parms);

                tbFirstName.Text = dt.Rows[0].ItemArray[0].ToString();
                tbLastName.Text = dt.Rows[0].ItemArray[1].ToString();
                tbEmail.Text = dt.Rows[0].ItemArray[2].ToString();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + ex.Message.ToString() + "','','error');", true);
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            fpChange.Visible = true;

            btnUpdate.Visible = true;
            btnCancel.Visible = true;

            tbFirstName.ReadOnly = false;
            tbLastName.ReadOnly = false;
            tbEmail.ReadOnly = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            tbFirstName.ReadOnly = true;
            tbLastName.ReadOnly = true;
            tbEmail.ReadOnly = true;
            fpChange.Visible = false;

            btnEdit.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string _sFileName = "";
            if (fpChange.HasFile)
            {
                try
                {
                    string sFileName = Path.GetFileName(fpChange.PostedFile.FileName);
                    string sUserName = Session["UserId"].ToString();
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
                _sFileName = Session["UserImage"].ToString();
            }


            //if (_sFileName == string.Empty || _sFileName == "")
            //{
            //    
            //}

            SqlParameter[] parms = new SqlParameter[6];
            parms[0] = new SqlParameter();
            parms[0].SqlDbType = SqlDbType.NVarChar;
            parms[0].ParameterName = "@PsFirstName";
            parms[0].Value = tbFirstName.Text.Trim().ToString();

            parms[1] = new SqlParameter();
            parms[1].SqlDbType = SqlDbType.NVarChar;
            parms[1].ParameterName = "@PsLastName";
            parms[1].Value = tbLastName.Text.Trim().ToString();

            parms[2] = new SqlParameter();
            parms[2].SqlDbType = SqlDbType.NVarChar;
            parms[2].ParameterName = "@PsEmailId";
            parms[2].Value = tbEmail.Text.Trim().ToString();

            parms[3] = new SqlParameter();
            parms[3].SqlDbType = SqlDbType.NVarChar;
            parms[3].ParameterName = "@PsImage";
            parms[3].Value = _sFileName.ToString();

            parms[4] = new SqlParameter();
            parms[4].SqlDbType = SqlDbType.NVarChar;
            parms[4].ParameterName = "@PsUser";
            parms[4].Value = Session["UserId"].ToString();

            parms[5] = new SqlParameter();
            parms[5].SqlDbType = SqlDbType.NVarChar;
            parms[5].ParameterName = "@sMessage";
            parms[5].Size = 100;
            parms[5].Direction = ParameterDirection.Output;

            string _sMessage = Common.SetData("stp_UpdateUserDetails", parms, 5);
            string[] sFlags = _sMessage.Split(',');

            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + sFlags[0].ToString() + "','','" + sFlags[1] + "');", true);

            if (sFlags[1] == "success")
            {
                Session["UserFirstName"] = tbFirstName.Text.Trim().ToString();    //Setting Updated Values
                Session["UserLastName"] = tbLastName.Text.Trim().ToString();    //Setting Updated Values
                Session["UserImage"] = _sFileName.Trim().ToString();    //Setting Updated Values
            }

            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            Response.Redirect(Request.RawUrl);
        }


        //Validate Personal Details
        public bool IsValidUpdate(string sImageName)
        {
            string _sFirstName = Session["UserFirstName"].ToString();
            string _sLastName = Session["UserLastName"].ToString();
            string _sUserEmailId = Session["UserEmail"].ToString();
            string _sUserImage = Session["UserImage"].ToString();

            if (tbFirstName.Text == string.Empty || tbFirstName.Text == _sFirstName)
            {
                return true;
            }

            if (tbLastName.Text == string.Empty || tbLastName.Text == _sFirstName)
            {
                return true;
            }

            if (sImageName == string.Empty || sImageName == _sUserImage)
            {
                return true;
            }

            return true;
        }
    }
}