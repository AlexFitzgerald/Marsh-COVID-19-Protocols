using System;
using System.Collections.Generic;
using System.Data.SqlClient; 
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace COVID_Protocols
{
    public class MarshFormsFunctions
    {
        public static bool SubmitAnswer1(int question_id, int employee_id, String employee_name, String employee_badge_id, String answer1bit, String answer2bit, String answer3bit, String guid)
        {
            String SQLString = "INSERT INTO form_answers(question_id, employee_id, employee_name, employee_badge_id, answer1bit, answer2bit, answer3bit, dts, guid) VALUES (@question_id, @employee_id, @employee_name, @employee_badge_id, @answer1bit, @answer2bit, @answer3bit, GETDATE(), @guid )";

            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@question_id", String.IsNullOrEmpty(question_id.ToString()) ? (object)DBNull.Value : question_id.ToString());
                    command.Parameters.AddWithValue("@employee_id", employee_id);
                    command.Parameters.AddWithValue("@employee_name", String.IsNullOrEmpty(employee_name) ? (object)DBNull.Value : employee_name);
                    command.Parameters.AddWithValue("@employee_badge_id", String.IsNullOrEmpty(employee_badge_id) ? (object)DBNull.Value : employee_badge_id);
                    command.Parameters.AddWithValue("@answer1bit", String.IsNullOrEmpty(answer1bit) ? (object)DBNull.Value : answer1bit);
                    command.Parameters.AddWithValue("@answer2bit", String.IsNullOrEmpty(answer2bit) ? (object)DBNull.Value : answer2bit);
                    command.Parameters.AddWithValue("@answer3bit", String.IsNullOrEmpty(answer3bit) ? (object)DBNull.Value : answer3bit);
                    command.Parameters.AddWithValue("@guid", String.IsNullOrEmpty(guid) ? (object)DBNull.Value : guid);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static bool SubmitTemp(int employee_id, String employee_name, String employee_badge_id, String temperature, String guid, String additional_comments)
        {
            String SQLString = " INSERT INTO dbo.form_temp_answers(employee_id, employee_name, employee_badge_id, temperature, dts, guid, additional_comments) VALUES (@employee_id, @employee_name, @employee_badge_id, @temperature, GETDATE(), @guid,@additional_comments )";

            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@employee_id", employee_id);
                    command.Parameters.AddWithValue("@employee_name", String.IsNullOrEmpty(employee_name) ? (object)DBNull.Value : employee_name);
                    command.Parameters.AddWithValue("@employee_badge_id", String.IsNullOrEmpty(employee_badge_id) ? (object)DBNull.Value : employee_badge_id);
                    command.Parameters.AddWithValue("@temperature", String.IsNullOrEmpty(temperature) ? (object)DBNull.Value : temperature);
                    command.Parameters.AddWithValue("@guid", String.IsNullOrEmpty(guid) ? (object)DBNull.Value : guid);
                    command.Parameters.AddWithValue("@additional_comments", String.IsNullOrEmpty(additional_comments) ? (object)DBNull.Value : additional_comments);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static bool SubmitPhone(int employee_id, String phone_number)
        {
            String SQLString = "UPDATE dbo.employees SET phone_number = @phone_number WHERE id = @employee_id";

            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@employee_id", employee_id);
                    command.Parameters.AddWithValue("@phone_number", String.IsNullOrEmpty(phone_number) ? (object)DBNull.Value : phone_number);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static int GetFormID(int badge_id)
        {
            //switch (badge_id)
            //{
            //    case 1:
            //        return 1;
            //    case 2:
            //        return 2;
            //    case 3:
            //        return 3;
            //    case 4:
            //        return 4;
            //    case 5:
            //        return 5;
            //    case 6:
            //        return 6;
            //    case 7:
            //        return 7;
            //    case 8:
            //        return 8;
            //    default:
            //        return 1;
            //}

            int form_id = 1;
            String SQLString = "SELECT f.id FROM MarshForms.dbo.employees e INNER JOIN forms f ON e.default_language = f.language_id WHERE card_number = @badge_id";
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    cmd.Parameters.AddWithValue("@badge_id", badge_id);

                    using (SqlDataReader SQLReader = cmd.ExecuteReader())
                    {
                        if (SQLReader != null)
                        {
                            while (SQLReader.Read())
                            {
                                form_id = Convert.ToInt32(SQLReader["id"]);
                            }
                        }
                    }
                }
            }
            return form_id;
        }

        public static int GetEmployeeID(int badge_id)
        {


            int employee_id = 1;
            String SQLString = "SELECT id FROM employees WHERE card_number = @badge_id";
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    cmd.Parameters.AddWithValue("@badge_id", badge_id);

                    using (SqlDataReader SQLReader = cmd.ExecuteReader())
                    {
                        if (SQLReader != null)
                        {
                            while (SQLReader.Read())
                            {
                                employee_id = Convert.ToInt32(SQLReader["id"]);
                            }
                        }
                    }
                }
            }
            return employee_id;
        }


        public static String GetLastTemp(string badge_id)
        {


            String calculated_object_temperature_f = "";
            String SQLString = "SELECT TOP 1 badge_id, date_time_stamp, calculated_object_temperature_f FROM MarshForms.dbo.mts_temperatures WHERE CAST(date_time_stamp AS DATE) = CAST(GETDATE() AS DATE) AND badge_id = @badge_id ORDER BY date_time_stamp DESC";
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    cmd.Parameters.AddWithValue("@badge_id", badge_id);

                    using (SqlDataReader SQLReader = cmd.ExecuteReader())
                    {
                        if (SQLReader != null)
                        {
                            while (SQLReader.Read())
                            {
                                calculated_object_temperature_f = SQLReader["calculated_object_temperature_f"].ToString();
                            }
                        }
                    }
                }
            }
            return calculated_object_temperature_f;
        }


        public static int GetEmployeeIDFromGuid(String guid)
        {
            int employee_id = 0;
            String SQLString = "SELECT TOP 1 employee_id FROM form_answers WHERE guid = @guid";
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    cmd.Parameters.AddWithValue("@guid", guid);

                    using (SqlDataReader SQLReader = cmd.ExecuteReader())
                    {
                        if (SQLReader != null)
                        {
                            while (SQLReader.Read())
                            {
                                employee_id = Convert.ToInt32(SQLReader["employee_id"]);
                            }
                        }
                    }
                }
            }
            return employee_id;
        }

        public static int GetEmployeePayrollIDFromBadge(String card_number)
        {
            int payroll_id = 0;
            String SQLString = "SELECT TOP 1 payroll_id FROM form_answers left join employees on employees.card_number = form_answers.employee_badge_id WHERE card_number = @card_number";
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    cmd.Parameters.AddWithValue("@card_number", card_number);

                    using (SqlDataReader SQLReader = cmd.ExecuteReader())
                    {
                        if (SQLReader != null)
                        {
                            while (SQLReader.Read())
                            {
                                payroll_id = Convert.ToInt32(SQLReader["payroll_id"]);
                            }
                        }
                    }
                }
            }
            return payroll_id;
        }


        public static String GetEmployeeNameFromGuid(String guid)
        {
            String employee_name = "";
            String SQLString = "SELECT TOP 1 employee_name FROM form_answers WHERE guid = @guid";
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    cmd.Parameters.AddWithValue("@guid", guid);

                    using (SqlDataReader SQLReader = cmd.ExecuteReader())
                    {
                        if (SQLReader != null)
                        {
                            while (SQLReader.Read())
                            {
                                employee_name = SQLReader["employee_name"].ToString();
                            }
                        }
                    }
                }
            }
            return employee_name;
        }

 


        public static String GetPayrollIDFromGuid(String guid)
        {
            String payroll_id = "";
            String SQLString = "SELECT TOP 1 payroll_id FROM form_answers left join employees on employees.card_number = form_answers.employee_badge_id WHERE guid = @guid";
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    cmd.Parameters.AddWithValue("@guid", guid);

                    using (SqlDataReader SQLReader = cmd.ExecuteReader())
                    {
                        if (SQLReader != null)
                        {
                            while (SQLReader.Read())
                            {
                                payroll_id = SQLReader["payroll_id"].ToString();
                            }
                        }
                    }
                }
            }
            return payroll_id;
        }

        public static String GetEmployeeBadgeImage(String badge_id)
        {
            byte[] bytes = new Byte[64];
            Array.Clear(bytes, 0, bytes.Length);
            String SQLString = "EXECUTE dbo.stored_proc_get_badge_image @card_number";
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    cmd.Parameters.AddWithValue("@card_number", badge_id);

                    using (SqlDataReader SQLReader = cmd.ExecuteReader())
                    {
                        if (SQLReader != null)
                        {
                            while (SQLReader.Read())
                            {
                                bytes = (byte[])SQLReader["attachment"];
                            }
                        }
                    }
                }
            }
            String ReturnString = "data:image/bmp;base64,";
            //if (bytes.Length != 0) {
            string base64String = Convert.ToBase64String(bytes);
            ReturnString += base64String;
            //}
            return ReturnString;
        }
        public static String GetEmployeeName(int badge_id)
        {
            String employee_name = "";
            String SQLString = "SELECT COALESCE(nick_name, first_name) + ' ' + last_name AS employee_name FROM MarshForms.dbo.employees WHERE card_number = @badge_id";
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    cmd.Parameters.AddWithValue("@badge_id", badge_id);

                    using (SqlDataReader SQLReader = cmd.ExecuteReader())
                    {
                        if (SQLReader != null)
                        {
                            while (SQLReader.Read())
                            {
                                employee_name = SQLReader["employee_name"].ToString();
                            }
                        }
                    }
                }
            }
            return employee_name;
        }


        public static String GetLastWorkplaceSurveyDate(int badge_id)
        {
            String max_dt = "";
            String SQLString = "SELECT COALESCE(MAX(CAST(dts AS DATE)), '1900-01-01') AS max_dt FROM MarshForms.dbo.form_temp_answers WHERE employee_badge_id <> 0 AND employee_badge_id = @badge_id";
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    cmd.Parameters.AddWithValue("@badge_id", badge_id);

                    using (SqlDataReader SQLReader = cmd.ExecuteReader())
                    {
                        if (SQLReader != null)
                        {
                            while (SQLReader.Read())
                            {
                                max_dt = SQLReader["max_dt"].ToString();
                            }
                        }
                    }
                }
            }
            return max_dt;
        }



        public static String wellness_email()
        {
            String wellness_email = "";
            String SQLString = "SELECT TOP 1 config_value FROM MarshForms.dbo.config WHERE config_name = 'wellness_email'";
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    using (SqlDataReader SQLReader = cmd.ExecuteReader())
                    {
                        if (SQLReader != null)
                        {
                            while (SQLReader.Read())
                            {
                                wellness_email = SQLReader["config_value"].ToString();
                            }
                        }
                    }
                }
            }
            return wellness_email;
        }

        public static List<String> hr_email()
        {
            var hr_email = new List<String>();
            String SQLString = "SELECT config_value FROM MarshForms.dbo.config WHERE config_name = 'hr_email'";
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    using (SqlDataReader SQLReader = cmd.ExecuteReader())
                    {
                        if (SQLReader != null)
                        {
                            while (SQLReader.Read())
                            {
                                hr_email.Add(SQLReader["config_value"].ToString());
                            }
                        }
                    }
                }
            }
            return hr_email;
        }

        public static bool get_monitor(String card_number)
        {
            String monitor = "0";
            String SQLString = " SELECT CASE WHEN GETDATE() BETWEEN monitor_start_date AND monitor_end_date THEN 1 ELSE 0 END AS monitor FROM MarshForms.dbo.employees WHERE card_number = @card_number";
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    cmd.Parameters.AddWithValue("@card_number", card_number);
                    using (SqlDataReader SQLReader = cmd.ExecuteReader())
                    {
                        if (SQLReader != null)
                        {
                            while (SQLReader.Read())
                            {
                                monitor = SQLReader["monitor"].ToString();
                            }
                        }
                    }
                }
            }
            if (monitor == "1") { return true; }
            else { return false; }
        }
        public static void sendEmail(String guid, String employee_name, String phone_number, bool monitor, String payroll_id)
        {

            String strReportUser = "MarshCredits";
            String strReportUserPW = "MarshCred2016";
            String strReportUserDomain = "Marsh_PDC";
            String sendto = MarshFormsFunctions.wellness_email();
            String subject;
            String body;
            if (monitor)
            {
                subject = "Follow up : Coronavirus Workplace Health Screening " + employee_name;
            }
            else
            {
                subject = "Symptomatic : Coronavirus Workplace Health Screening " + employee_name;

            }

            body = "phone number : " + phone_number + " | payroll id : " + payroll_id;




            String MMREmail = "marshhealth@marshfurniture.com";
            String sTargetURL = "http://marshsql5/ReportServer?%2fMarshFormsReports%2fCoronavirus%20Workplace%20Health%20Screening&rs:Command=Render&rs:format=PDF&guid=" + guid;

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

                    var hr_email = MarshFormsFunctions.hr_email();
                    foreach (String a in hr_email)
                    {
                        mm.To.Add(a);
                    }

                    mm.Attachments.Add(new Attachment(ms, employee_name + "_Health_Survey.pdf"));
                    mm.IsBodyHtml = true;
                    mm.BodyEncoding = UTF8Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    smtp_client.Send(mm);
                }
            }
        }
    }
}