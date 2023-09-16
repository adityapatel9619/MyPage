using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace MyPage.Master
{
    public partial class TestModal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenrateData_Click(object sender, EventArgs e)
        {

            Response.Redirect("/ReportViewer/ViewReport.aspx");
        }
    }
}