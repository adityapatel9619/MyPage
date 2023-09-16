using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyPage
{
    public partial class AdminDashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string imagepath = "/Images/";
            string imageName = Session["AdminUserImage"].ToString();

            Image.ImageUrl = imagepath + imageName;
        }
    }
}