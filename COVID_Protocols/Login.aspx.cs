using System;
using System.Data.SqlClient;
using System.Web.Security;

namespace COVID_Protocols
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_button_click(object sender, EventArgs e)
        {
            String username = username_textbox.Text;
            String password = password_textbox.Text;
            //if (ValidEmail(username))
            //{
                if (ValidateUser(username, password))
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    FormsAuthentication.RedirectFromLoginPage(username, true);
                }
            //}
            //else
            //{
            //    message_label.Text = "Please make sure your email address is correct.";
            //}
        }
        private bool ValidEmail(String username)
        {
            if (username.Contains("@marshfurniture.com"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ValidateUser(String username, String password)
        {
            bool validate = false;

            String sql_password = "";

            String SQLString = "SELECT email, password, reports, maintenance FROM users WHERE email = @email";
            try
            {

                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                    {
                        cmd.Parameters.AddWithValue("@email", username);

                        using (SqlDataReader SQLReader = cmd.ExecuteReader())
                        {
                            if (SQLReader != null)
                            {
                                while (SQLReader.Read())
                                {
                                    sql_password = SQLReader["password"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                message_label.Text = e.Message.ToString();
                validate = false;
            }

            if (sql_password == "" && ValidEmail(username)) {
                String MarshLDAP = System.Configuration.ConfigurationManager.AppSettings["MarshLDAP"];
                String MarshDomain = System.Configuration.ConfigurationManager.AppSettings["MarshDomain"];
                System.DirectoryServices.DirectoryEntry LDAPDirectoryEntry = new System.DirectoryServices.DirectoryEntry(MarshLDAP, MarshDomain + username, password, System.DirectoryServices.AuthenticationTypes.Secure);
                try
                {
                    
                    System.DirectoryServices.DirectorySearcher LDAPDirectoryService = new System.DirectoryServices.DirectorySearcher(LDAPDirectoryEntry);
                    LDAPDirectoryService.FindOne();
                    validate = true;
                }
                catch (Exception e)
                {
                    message_label.Text = e.Message.ToString();
                    validate = false;
                }
                finally { }
            }
            else
            {
                if (password == sql_password)
                {
                    validate = true;
                }
                else
                {
                    message_label.Text = "The user name or password is incorrect.";
                    validate = false;
                }
            }

            //if (Request.Url.ToString().Contains("localhost")) { validate = true; } //locally debugging return true; Backdoor
            return validate;
        }
    }
}