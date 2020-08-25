using Microsoft.Reporting.WebForms;
using System;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COVID_Protocols
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FTReportViewer.ServerReport.ReportServerUrl = new Uri(System.Web.Configuration.WebConfigurationManager.AppSettings["ReportServerURL"]);

                ReportServerCredentials cred = new ReportServerCredentials();
                FTReportViewer.ServerReport.ReportServerCredentials = cred;

            }
            else
            {
                try
                {
                    FTReportViewer.ServerReport.ReportPath = ReportDropDownList.SelectedValue;
                    ReportErrorLabel.Text = "";
                }
                catch
                {
                    ReportErrorLabel.Text = "Go back to the top level of the existing report before trying to navigate to a second report";
                }
            }
        }

        protected void FTReportViewer_ReportRefresh(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ReportParameterInfoCollection ReportParms = FTReportViewer.ServerReport.GetParameters();
            String ReportParmString = "";
            foreach (ReportParameterInfo ReportParm in ReportParms)
            {
                string DType = ReportParm.DataType.ToString();
                if (DType == "DateTime")
                {
                    DateTime ParmDateTime = Convert.ToDateTime(ReportParm.Values[0]);
                    ReportParmString = ParmDateTime.ToString("yyyyMMdd") + ReportParmString;
                }
                else
                {
                    ReportParmString = ReportParm.Values[0] + ReportParmString;
                }
            }
            FTReportViewer.ServerReport.DisplayName = ReportParmString + ReportDropDownList.SelectedItem.Text;
        }
    }
}