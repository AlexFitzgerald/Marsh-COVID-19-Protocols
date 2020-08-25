using System; 
using System.Web;
using System.Web.Services;

namespace COVID_Protocols
{
    public partial class ScanBadge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        public static void set_session(String badge_id)
        {
            HttpContext.Current.Session["badge_id"] = badge_id;
            int badge;
            if (Int32.TryParse(badge_id, out badge))
            {
                HttpContext.Current.Session["id"] = MarshFormsFunctions.GetFormID(badge);
                HttpContext.Current.Session["employee_name"] = MarshFormsFunctions.GetEmployeeName(badge);
                String max_dt = MarshFormsFunctions.GetLastWorkplaceSurveyDate(badge);
                if (max_dt == "1900-01-01")
                {
                    HttpContext.Current.Session["max_dt"] = "";
                }
                else
                {
                    HttpContext.Current.Session["max_dt"] = "Last Surveyed " + max_dt.Replace(" 12:00:00 AM", "");
                }

            }
        }
    }
}