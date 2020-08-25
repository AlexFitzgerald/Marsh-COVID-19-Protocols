using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COVID_Protocols
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String email = "";
                String reports = "";
                String maintenance = "";
                email = HttpContext.Current.User.Identity.Name;
                UserLabel.Text = email;


                String SQLString = "SELECT email, password, reports, maintenance FROM users WHERE email = @email";
                try
                {
                    System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                    using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                        {
                            cmd.Parameters.AddWithValue("@email", email);

                            using (SqlDataReader SQLReader = cmd.ExecuteReader())
                            {
                                if (SQLReader != null)
                                {
                                    while (SQLReader.Read())
                                    {
                                        reports = SQLReader["reports"].ToString();
                                        maintenance = SQLReader["maintenance"].ToString();
                                    }
                                }
                            }
                        }
                    }
                    if (reports != "") { reports_link_button.Visible = Convert.ToBoolean(reports); }
                    if (maintenance != "") { maintenance_link_button.Visible = Convert.ToBoolean(maintenance); }
                }
                catch (Exception ex)
                {
                    Label1.Text = ex.Message.ToString();
                }
            }
        }

        protected void logout_button_click(object sender, EventArgs e)
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }

        protected void MarshCOVIDProtocolsLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void maintenance_link_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Maintenance/Maintenance.aspx");
        }

        protected void reports_link_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reports.aspx");
        }
    }
}