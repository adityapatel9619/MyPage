using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using MyPage.Dataset;
using MyPage.SQLHelper;
using MyPage.Reports;

namespace MyPage.ReportViewer
{
    public partial class ViewReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ReportDocument document = new ReportDocument();

            //ParameterField parameterField = new ParameterField();
            //ParameterFields parameterFields = new ParameterFields();
            //ParameterDiscreteValue parameterDiscreteValue = new ParameterDiscreteValue();

            //parameterField.Name = "@PsAdminUKID";
            //parameterDiscreteValue.Value = Session["AdminUniqueID"].ToString();

            //parameterField.CurrentValues.Add(parameterDiscreteValue);
            //parameterFields.Add(parameterField);

            //CrystalReportViewer1.ParameterFieldInfo = parameterFields;

            //document.Load(Server.MapPath("/Reports/AdminReport.rpt"));
            //CrystalReportViewer1.ReportSource = document;
            //CrystalReportViewer1.RefreshReport();
            //document.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Crystal");
            //Response.End();

            //dsAdminReport dsAdmin = new dsAdminReport();

            SqlParameter[] parms = new SqlParameter[1];
            parms[0] = new SqlParameter();
            parms[0].SqlDbType = SqlDbType.NVarChar;
            parms[0].ParameterName = "@PsAdminUKID";
            parms[0].Value = Session["AdminUniqueID"].ToString();

            DataTable dt = Common.GetData("stp_GetAdminDetailsReport", parms);

            //dtAdminReport
            //    AdminReport adminReport = new AdminReport();

            //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()))
            //{
            //    conn.Open();
            //    string sQuery = "SELECT sAdminName FROM tbl_AdminMaster WHERE sAdminUKID ="+ Session["AdminUniqueID"].ToString();

            //    SqlDataAdapter da = new SqlDataAdapter(sQuery,conn);
            //    da.Fill(dsAdmin, "dtAdminReport");

            //    if (dsAdmin.Tables[0].Rows.Count <=0)
            //    {
            //        //Checking
            //    }

            //    adminReport.SetDataSource(dsAdmin);

            //    ReportDocument document = new ReportDocument();
            //    document.Load(Server.MapPath("/Reports/AdminReport.rpt"));
            //    CrystalReportViewer1.ReportSource = document;
            //    CrystalReportViewer1.RefreshReport();
            //    document.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Crystal");
            //    Response.End();

            //    conn.Close();
            //}
            AdminReport adminReport = new AdminReport();
            adminReport.SetDataSource(dt);

             ReportDocument document = new ReportDocument();
             document.Load(Server.MapPath("/Reports/AdminReport.rpt"));
            document.SetDataSource(dt);
             CrystalReportViewer1.ReportSource = document;
             CrystalReportViewer1.RefreshReport();
             document.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Crystal");
             Response.End();
        }
    }
}