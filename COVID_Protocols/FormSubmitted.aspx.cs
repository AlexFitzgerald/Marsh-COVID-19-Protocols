using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Web;
using System.Web.Services;

namespace COVID_Protocols
{
    public partial class FormSubmitted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.Session["tablet_mode"] == null)
            {
                HttpContext.Current.Session["tablet_mode"] = "0";
            }
            //Session["tablet_mode"] = "1";
        }

    }
}