using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace COVID_Protocols.Maintenance
{
    public class EmployeeFunctions
    {

        public static bool ReturnToWorkChanged(String id, String return_to_work)
        {
            String SQLString = "UPDATE dbo.employees SET return_to_work = @return_to_work WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@return_to_work", String.IsNullOrEmpty(return_to_work) ? (object)DBNull.Value : return_to_work);
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

        public static bool MonitorStartDateChanged(String id, String monitor_start_date)
        {
            String SQLString = "UPDATE dbo.employees SET monitor_start_date = @monitor_start_date WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@monitor_start_date", String.IsNullOrEmpty(monitor_start_date) ? (object)DBNull.Value : monitor_start_date);
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

        public static bool MonitorEndDateChanged(String id, String monitor_end_date)
        {
            String SQLString = "UPDATE dbo.employees SET monitor_end_date = @monitor_end_date WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@monitor_end_date", String.IsNullOrEmpty(monitor_end_date) ? (object)DBNull.Value : monitor_end_date);
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


        public static bool CardNumberChanged(String id, String card_number)
        {
            String SQLString = "UPDATE dbo.employees SET card_number = @card_number WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@card_number", String.IsNullOrEmpty(card_number) ? (object)DBNull.Value : card_number);
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

        public static bool EmailChanged(String id, String email)
        {
            String SQLString = "UPDATE dbo.employees SET email = @email WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@email", String.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
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

        public static bool EmailSurveyChanged(String id, String daily_survey_email)
        {
            String SQLString = "UPDATE dbo.employees SET daily_survey_email = @daily_survey_email WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@daily_survey_email", String.IsNullOrEmpty(daily_survey_email) ? (object)DBNull.Value : daily_survey_email);
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


        public static bool LanguageChanged(String id, String default_language)
        {
            String SQLString = "UPDATE dbo.employees SET default_language = @default_language WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@default_language", String.IsNullOrEmpty(default_language) ? (object)DBNull.Value : default_language);
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

        public static bool AddEmployee(String payroll_id, String card_number)
        {
            String SQLString = " INSERT INTO dbo.employees(card_number, payroll_id, first_name, middle_name, last_name, nick_name, default_language, monitor_start_date, monitor_end_date, audit, active, phone_number,daily_survey_email) SELECT @card_number AS card_number, pe.id AS payroll_id, pe.firstName AS first_name, pe.middleName AS middle_name, pe.lastName AS last_name, pe.nickname AS nick_name, 1, NULL, NULL, 'Created ' + CAST(GETDATE() AS VARCHAR(20)) + '| ', 1, NULL, 0 FROM view_payroll_employees pe LEFT JOIN employees e ON pe.id = e.payroll_id WHERE e.id IS NULL AND pe.id = @payroll_id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@payroll_id", String.IsNullOrEmpty(payroll_id) ? (object)DBNull.Value : payroll_id);
                    command.Parameters.AddWithValue("@card_number", String.IsNullOrEmpty(card_number) ? (object)DBNull.Value : card_number);
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

        public static bool CovidPositive(String id, String covid_positive)
        {
            String SQLString = "UPDATE dbo.employees SET covid_positive = @covid_positive WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@covid_positive", String.IsNullOrEmpty(covid_positive) ? (object)DBNull.Value : covid_positive);
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


        public static bool CovidCloseContact(String id, String covid_close_contact)
        {
            String SQLString = "UPDATE dbo.employees SET covid_close_contact = @covid_close_contact WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@covid_close_contact", String.IsNullOrEmpty(covid_close_contact) ? (object)DBNull.Value : covid_close_contact);
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

        public static bool CovidWatchList(String id, String covid_watch_list)
        {
            String SQLString = "UPDATE dbo.employees SET covid_watch_list = @covid_watch_list WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@covid_watch_list", String.IsNullOrEmpty(covid_watch_list) ? (object)DBNull.Value : covid_watch_list);
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



        public static bool CovidTestDateChanged(String id, String covid_test_date)
        {
            String SQLString = "UPDATE dbo.employees SET covid_test_date = @covid_test_date WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@covid_test_date", String.IsNullOrEmpty(covid_test_date) ? (object)DBNull.Value : covid_test_date);
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

        public static bool CovidResultedDate(String id, String covid_resulted_date)
        {
            String SQLString = "UPDATE dbo.employees SET covid_resulted_date = @covid_resulted_date WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@covid_resulted_date", String.IsNullOrEmpty(covid_resulted_date) ? (object)DBNull.Value : covid_resulted_date);
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


        public static bool CovidContactResultDate(String id, String covid_contact_result_date)
        {
            String SQLString = "UPDATE dbo.employees SET covid_contact_result_date = @covid_contact_result_date WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@covid_contact_result_date", String.IsNullOrEmpty(covid_contact_result_date) ? (object)DBNull.Value : covid_contact_result_date);
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



        public static bool CovidSymptoms(String id, String covid_symptoms)
        {
            String SQLString = "UPDATE dbo.employees SET covid_symptoms = @covid_symptoms WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@covid_symptoms", String.IsNullOrEmpty(covid_symptoms) ? (object)DBNull.Value : covid_symptoms);
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


        public static bool CovidEstimateReturnDate(String id, String covid_estimate_return_date)
        {
            String SQLString = "UPDATE dbo.employees SET covid_estimate_return_date = @covid_estimate_return_date WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@covid_estimate_return_date", String.IsNullOrEmpty(covid_estimate_return_date) ? (object)DBNull.Value : covid_estimate_return_date);
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


        public static bool CovidActualReturnDate(String id, String covid_actual_return_date)
        {
            String SQLString = "UPDATE dbo.employees SET covid_actual_return_date = @covid_actual_return_date WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@covid_actual_return_date", String.IsNullOrEmpty(covid_actual_return_date) ? (object)DBNull.Value : covid_actual_return_date);
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

        public static bool covid_notes(String id, String covid_notes)
        {
            String SQLString = "UPDATE dbo.employees SET covid_notes = @covid_notes WHERE id = @id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@id", String.IsNullOrEmpty(id) ? (object)DBNull.Value : id);
                    command.Parameters.AddWithValue("@covid_notes", String.IsNullOrEmpty(covid_notes) ? (object)DBNull.Value : covid_notes);
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

    }
}