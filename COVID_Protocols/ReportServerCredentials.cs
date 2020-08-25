using System;
using Microsoft.Reporting.WebForms;
using System.Net;
using System.Security.Principal;
public sealed class ReportServerCredentials : IReportServerCredentials
{
    public WindowsIdentity ImpersonationUser
    {
        get
        {
            return null;
        }
    }

    public ICredentials NetworkCredentials
    {
        get
        {
            string userName = System.Web.Configuration.WebConfigurationManager.AppSettings["MarshReportViewerUser"];
            if (string.IsNullOrEmpty(userName))
                throw new Exception("ErrorUser");
            string password = System.Web.Configuration.WebConfigurationManager.AppSettings["MarshReportViewerPassword"];

            if (string.IsNullOrEmpty(password))
                throw new Exception(
                    "ErrorPassword");


            string domain = System.Web.Configuration.WebConfigurationManager.AppSettings["MarshReportViewerDomain"];

            if (string.IsNullOrEmpty(domain))
                throw new Exception(
                    "ErrorDomain");

            return new NetworkCredential(userName, password, domain);
        }
    }

    public bool GetFormsCredentials(out Cookie authCookie,
        out string userName, out string password,
        out string authority)
    {
        authCookie = null;
        userName = null;
        password = null;
        authority = null;

        // Not using form credentials
        return false;
    }
}
