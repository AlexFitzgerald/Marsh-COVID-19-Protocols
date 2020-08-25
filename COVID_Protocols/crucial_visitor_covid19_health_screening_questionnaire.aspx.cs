using System;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace COVID_Protocols
{
    public partial class crucial_visitor_covid19_health_screening_questionnaire : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckInputs();
        }

        public void CheckInputs()
        {

            String flu_yes = yes_rb_1.Checked.ToString();
            String flu_no = no_rb_1.Checked.ToString();

            String contact_yes = yes_rb_2.Checked.ToString();
            String contact_no = no_rb_2.Checked.ToString();

            String travel_yes = yes_rb_3.Checked.ToString();
            String travel_no = no_rb_3.Checked.ToString();

            String temperature = temperature_textbox.Text;



            float temperature_float;
            if (temperature == "")
            {
                temperature_float = 0;
            }
            else
            {
                temperature_float = float.Parse(temperature, CultureInfo.InvariantCulture.NumberFormat); ;
            }

            String approved = ApprovedRadioButton.Checked.ToString();
            String denied = DeniedRadioButton.Checked.ToString();

            if (flu_yes == "True" || contact_yes == "True" || travel_yes == "True" || temperature_float >= 100.4)
            {
                if (!DeniedRadioButton.Checked)
                {
                    DeniedRadioButton.Checked = true;
                    ApprovedRadioButton.Checked = false;
                }
            }
            else if (flu_no == "True" && contact_no == "True" && travel_no == "True" && temperature_float < 100.4 && temperature_float > 0)
            {
                if (DeniedRadioButton.Checked)
                {
                    DeniedRadioButton.Checked = false;
                    ApprovedRadioButton.Checked = true;
                }
            }
        }

        protected void SubmitLinkButton_Click(object sender, EventArgs e)
        {
            String visitor_name = visitor_name_textbox.Text;
            String visitor_phone = visitor_phone_textbox.Text;
            String visitor_company = visitor_company_textbox.Text;
            String visitor_host = visitor_host_textbox.Text;
            String visitor_purpose = visitor_purpose_textbox.Text;

            String flu_yes = yes_rb_1.Checked.ToString();
            String flu_no = no_rb_1.Checked.ToString();

            String contact_yes = yes_rb_2.Checked.ToString();
            String contact_no = no_rb_2.Checked.ToString();

            String travel_yes = yes_rb_3.Checked.ToString();
            String travel_no = no_rb_3.Checked.ToString();

            String temperature = temperature_textbox.Text;

            String visitor_signature = sigTextBox.Text;

            String approved = ApprovedRadioButton.Checked.ToString();
            String denied = DeniedRadioButton.Checked.ToString();

            String g = Guid.NewGuid().ToString();


            //CHECK INPUTS
            if (visitor_name == "") { visitor_name_textbox.Focus(); MessageLabel.Text = "Please check to make sure all fields are correct."; }
            else if (visitor_phone == "") { visitor_phone_textbox.Focus(); MessageLabel.Text = "Please check to make sure all fields are correct."; }
            else if (visitor_company == "") { visitor_company_textbox.Focus(); MessageLabel.Text = "Please check to make sure all fields are correct."; }
            else if (visitor_host == "") { visitor_host_textbox.Focus(); MessageLabel.Text = "Please check to make sure all fields are correct."; }
            else if (visitor_purpose == "") { visitor_purpose_textbox.Focus(); MessageLabel.Text = "Please check to make sure all fields are correct."; }
            else if (flu_yes == "False" && flu_no == "False") { yes_rb_1.Focus(); MessageLabel.Text = "Please check to make sure all fields are correct."; }
            else if (contact_yes == "False" && contact_no == "False") { yes_rb_2.Focus(); MessageLabel.Text = "Please check to make sure all fields are correct."; }
            else if (travel_yes == "False" && travel_no == "False") { yes_rb_3.Focus(); MessageLabel.Text = "Please check to make sure all fields are correct."; }
            else if (temperature == "") { temperature_textbox.Focus(); MessageLabel.Text = "Please check to make sure all fields are correct."; }
            else if (approved == "False" && denied == "False") { ApprovedRadioButton.Focus(); MessageLabel.Text = "Please check to make sure all fields are correct."; }
            else if (visitor_signature == "") { MessageLabel.Text = "Please check to make sure all fields are correct."; }
            else
            {
                try
                {
                    String SQLString = " EXECUTE dbo.stored_proc_insert_into_crucial_visitor @visitor_name, @visitor_phone, @visitor_company, @visitor_host, @visitor_purpose, @recent_flu_like_symptoms, @recent_contact, @recent_travel, @temperature, @access_approved, @application_user, @visitor_signature, @guid";
                    System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                    using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(SQLString, connection);
                        command.Parameters.AddWithValue("@visitor_name", String.IsNullOrEmpty(visitor_name) ? (object)DBNull.Value : visitor_name);
                        command.Parameters.AddWithValue("@visitor_phone", String.IsNullOrEmpty(visitor_phone) ? (object)DBNull.Value : visitor_phone);
                        command.Parameters.AddWithValue("@visitor_company", String.IsNullOrEmpty(visitor_company) ? (object)DBNull.Value : visitor_company);
                        command.Parameters.AddWithValue("@visitor_host", String.IsNullOrEmpty(visitor_host) ? (object)DBNull.Value : visitor_host);
                        command.Parameters.AddWithValue("@visitor_purpose", String.IsNullOrEmpty(visitor_purpose) ? (object)DBNull.Value : visitor_purpose);
                        command.Parameters.AddWithValue("@recent_flu_like_symptoms", String.IsNullOrEmpty(flu_yes) ? (object)DBNull.Value : flu_yes);
                        command.Parameters.AddWithValue("@recent_contact", String.IsNullOrEmpty(contact_yes) ? (object)DBNull.Value : contact_yes);
                        command.Parameters.AddWithValue("@recent_travel", String.IsNullOrEmpty(travel_yes) ? (object)DBNull.Value : travel_yes);
                        command.Parameters.AddWithValue("@temperature", String.IsNullOrEmpty(temperature) ? (object)DBNull.Value : temperature);
                        command.Parameters.AddWithValue("@access_approved", String.IsNullOrEmpty(approved) ? (object)DBNull.Value : approved);
                        command.Parameters.AddWithValue("@application_user", String.IsNullOrEmpty(User.Identity.Name) ? (object)DBNull.Value : User.Identity.Name);
                        command.Parameters.AddWithValue("@visitor_signature", String.IsNullOrEmpty(visitor_signature) ? (object)DBNull.Value : visitor_signature);
                        command.Parameters.AddWithValue("@guid", String.IsNullOrEmpty(g) ? (object)DBNull.Value : g);
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                    }

                    String strReportUser = "MarshCredits";
                    String strReportUserPW = "MarshCred2016";
                    String strReportUserDomain = "Marsh_PDC";
                    String sendto = User.Identity.Name;//"afitzgerald@marshfurniture.com";
                    String subject;
                    String body;
                    subject = "CRUCIAL VISITOR COVID-19 HEALTH SCREENING QUESTIONNAIRE | " + visitor_name;
                    body = "";

                    String MMREmail = "marshhealth@marshfurniture.com";
                    String sTargetURL = "http://marshsql5/ReportServer?%2fMarshFormsReports%2fCrucial%20Visitor%20COVID-19%20Health%20Screening%20Questionnaire&rs:Command=Render&rs:format=PDF&guid=" + g;

                    using (WebClient web_client = new WebClient())
                    {
                        web_client.Credentials = new NetworkCredential(strReportUser, strReportUserPW, strReportUserDomain);
                        byte[] bytes = web_client.DownloadData(sTargetURL);
                        MemoryStream ms = new MemoryStream(bytes);

                        using (SmtpClient smtp_client = new SmtpClient())
                        {
                            smtp_client.Port = 465;
                            smtp_client.Host = "exchange.marshfurniture.com";
                            smtp_client.EnableSsl = false;
                            smtp_client.Timeout = 10000;
                            smtp_client.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp_client.UseDefaultCredentials = false;
                            smtp_client.Credentials = new NetworkCredential("marshhealth", "M@rsh!1234");
                            MailMessage mm = new MailMessage(MMREmail, sendto, subject, body);
                            mm.Attachments.Add(new Attachment(ms, "crucial_visitor_health_screening_questionnaire.pdf"));
                            mm.IsBodyHtml = true;
                            mm.BodyEncoding = UTF8Encoding.UTF8;
                            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                            smtp_client.Send(mm);
                        }
                    }

                    Response.Redirect("~\\FormSubmitted.aspx");
                }
                catch (Exception ex)
                {
                    //boo boo
                }
            }
        }

        protected void no_rb_1_CheckedChanged(object sender, EventArgs e)
        {
            CheckInputs();
        }

        protected void yes_rb_1_CheckedChanged(object sender, EventArgs e)
        {
            CheckInputs();
        }

        protected void yes_rb_2_CheckedChanged(object sender, EventArgs e)
        {
            CheckInputs();
        }

        protected void no_rb_2_CheckedChanged(object sender, EventArgs e)
        {
            CheckInputs();
        }

        protected void yes_rb_3_CheckedChanged(object sender, EventArgs e)
        {
            CheckInputs();
        }

        protected void no_rb_3_CheckedChanged(object sender, EventArgs e)
        {
            CheckInputs();
        }

        protected void temperature_textbox_TextChanged(object sender, EventArgs e)
        {
            CheckInputs();
        }
    }
}