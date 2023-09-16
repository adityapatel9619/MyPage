using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyPage
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblName.Text = Session["Username"].ToString();
            lblName.Text = Session["Username"].ToString();

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            if (fImage.HasFile)
            {
                string sfileName = Path.GetFileName(fImage.PostedFile.FileName);
                //fImage.PostedFile.SaveAs(Server.MapPath("~/Images/") + sfileName);
                string sUserName = Session["UserName"].ToString();

                string savelocation = Server.MapPath("~/Images/");
                string ac = "";
                ac = ac.Replace(" ", "_").Replace(".", "_");
                try
                {
                    Guid guid = Guid.NewGuid();
                    string newguid = guid.ToString();
                    string extension = Path.GetExtension(fImage.FileName);
                    var  Filename =  sUserName+"_"+newguid + extension;
                    fImage.SaveAs(savelocation + Filename);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('Image Uploaded','','success');", true);

                    iImage.ImageUrl = "~/Images/"+ Filename;
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" +ex.Message+ "','','error');", true);
                }



                //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('" + Request.Url.AbsoluteUri + "','','success');", true);
                //string sFile = Path.GetFileName(fImage.PostedFile.FileName);
                //string basePath = Server.MapPath("~/Images/");
                //string guid = Guid.NewGuid().ToString();
                //var fullPath = Path.Combine(basePath, guid);
                //fImage.SaveAs(Path.Combine(fullPath, guid + Path.GetExtension(sFile)));
            }


            //string ImageName = fImage.FileName.ToString();
            //string ImagePath = Server.MapPath()
            //if (ImageName.Length >0)
            //{
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('"+ImagePath+"','','success');", true);
            //}
        }
    }
}