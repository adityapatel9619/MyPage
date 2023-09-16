using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyPage.Master
{
    public partial class WelcomeUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTxt.Text = Session["UserFirstName"].ToString() + Session["UserLastName"].ToString();
        }
    }
}