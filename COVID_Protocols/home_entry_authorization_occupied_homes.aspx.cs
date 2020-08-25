using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COVID_Protocols
{
    public partial class home_entry_authorization_occupied_homes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitLinkButton_Click(object sender, EventArgs e)
        {
            String customer_name = customer_name_textbox.Text;
            String customer_address = customer_address_textbox.Text;
            String under_quarantine_yes = yes_rb_1.Checked.ToString();
            String under_quarantine_no = no_rb_1.Checked.ToString();
            String confirmed_case_yes = yes_rb_2.Checked.ToString();
            String confirmed_case_no = no_rb_2.Checked.ToString();
            String diagnosis_date = DiagnosisDateTextBox.Text;
            String case_resolved_yes = yes_rb_3.Checked.ToString();
            String case_resolved_no = no_rb_3.Checked.ToString();
            String covid_symptoms_yes = yes_rb_4.Checked.ToString();
            String covid_symptoms_no = no_rb_4.Checked.ToString();
            String customer_signature = sig1TextBox.Text;
            String mkb_signature = sig2TextBox.Text;
            String g = Guid.NewGuid().ToString();

            if (customer_name == "")
            {
                MessageLabel.Text = "Please check the customer name field.";
                MessageLabel.Focus();
            }
            else if (customer_address == "")
            {
                MessageLabel.Text = "Please check the customer address field.";
                MessageLabel.Focus();
            }
            else if (under_quarantine_yes == "False" && under_quarantine_no == "False")
            {
                MessageLabel.Text = "Please make sure that you have checked the fields below.";
                MessageLabel.Focus();
            }
            else if (confirmed_case_yes == "False" && confirmed_case_no == "False")
            {
                MessageLabel.Text = "Please make sure that you have checked the fields below.";
                MessageLabel.Focus();
            }
            else if (confirmed_case_yes == "True" && diagnosis_date == "")
            {
                MessageLabel.Text = "Please make sure that you have checked the fields below.";
                MessageLabel.Focus();
            }
            else if (confirmed_case_yes == "True" && case_resolved_yes == "False" && case_resolved_no == "False")
            {
                MessageLabel.Text = "Please make sure that you have checked the fields below.";
                MessageLabel.Focus();
            }
            else if (covid_symptoms_yes == "True" && covid_symptoms_no == "False")
            {
                MessageLabel.Text = "Please make sure that you have checked the fields below.";
                MessageLabel.Focus();
            }
            else if (customer_signature == "" || mkb_signature == "")
            {
                MessageLabel.Text = "Please make sure that you have signed the form.";
                MessageLabel.Focus();
                sig1TextBox.Text = "";
                sig2TextBox.Text = "";
            }
            else
            {
                try
                {
                    String SQLString = " INSERT INTO dbo.home_entry_authorization_occupied_homes(customer_name, customer_address, under_quarantine, confirmed_case, diagnosis_date, case_resolved, covid_symptoms, customer_signature, mkb_signature, date_time_stamp, application_user, guid) VALUES (@customer_name, @customer_address, @under_quarantine, @confirmed_case, @diagnosis_date, @case_resolved, @covid_symptoms, @customer_signature, @mkb_signature, GETDATE(), @application_user, @guid )";
                    System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                    using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(SQLString, connection);
                        command.Parameters.AddWithValue("@customer_name", String.IsNullOrEmpty(customer_name) ? (object)DBNull.Value : customer_name);
                        command.Parameters.AddWithValue("@customer_address", String.IsNullOrEmpty(customer_address) ? (object)DBNull.Value : customer_address);
                        command.Parameters.AddWithValue("@under_quarantine", String.IsNullOrEmpty(under_quarantine_yes) ? (object)DBNull.Value : under_quarantine_yes);
                        command.Parameters.AddWithValue("@confirmed_case", String.IsNullOrEmpty(confirmed_case_yes) ? (object)DBNull.Value : confirmed_case_yes);
                        command.Parameters.AddWithValue("@diagnosis_date", String.IsNullOrEmpty(diagnosis_date) ? (object)DBNull.Value : diagnosis_date);
                        command.Parameters.AddWithValue("@case_resolved", String.IsNullOrEmpty(case_resolved_yes) ? (object)DBNull.Value : case_resolved_yes);
                        command.Parameters.AddWithValue("@covid_symptoms", String.IsNullOrEmpty(covid_symptoms_yes) ? (object)DBNull.Value : covid_symptoms_yes);
                        command.Parameters.AddWithValue("@customer_signature", String.IsNullOrEmpty(customer_signature) ? (object)DBNull.Value : customer_signature);
                        command.Parameters.AddWithValue("@mkb_signature", String.IsNullOrEmpty(mkb_signature) ? (object)DBNull.Value : mkb_signature);
                        command.Parameters.AddWithValue("@application_user", String.IsNullOrEmpty(User.Identity.Name) ? (object)DBNull.Value : User.Identity.Name);
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
                    subject = "HOME ENTRY AUTHORIZATION: OCCUPIED HOMES | " + customer_name;
                    body = "";

                    String MMREmail = "marshhealth@marshfurniture.com";
                    String sTargetURL = "http://marshsql5/ReportServer?%2fMarshFormsReports%2fHome%20Entry%20Authorization%20Occupied%20Homes&rs:Command=Render&rs:format=PDF&guid=" + g;

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
                            mm.Attachments.Add(new Attachment(ms, "Home_Entry_Authorization.pdf"));
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
                }
            }
        }
    }
}