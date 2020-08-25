using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COVID_Protocols
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void HeathScreenLinkButton_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["tablet_mode"] = "0";
            Response.Redirect("~\\covid_workplace_health_screening.aspx");

        }

        protected void TabletHeathScreenLinkButton_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["tablet_mode"] = "1";
            Response.Redirect("~\\ScanBadge.aspx");
        }
    }
}