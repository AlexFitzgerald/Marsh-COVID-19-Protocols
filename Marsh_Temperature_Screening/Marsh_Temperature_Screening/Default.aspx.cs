using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Services;
using System.Windows.Forms;

namespace Marsh_Temperature_Screening
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cursor.Position = new Point(0, 0);
        }

        [WebMethod]
        public static bool WritePiInformation(String mac_address, String ambient_temperature_c, String object_temperature_c, String distance_centimeters, String badge_id)
        {
            String SQLString = "EXECUTE dbo.mts_insert_temperatures @mac_address, @ambient_temperature_c, @object_temperature_c, @distance_centimeters, @badge_id";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(SQLString, connection))
                    {
                        command.Parameters.AddWithValue("@mac_address", String.IsNullOrEmpty(mac_address) ? (object)DBNull.Value : mac_address);
                        command.Parameters.AddWithValue("@ambient_temperature_c", String.IsNullOrEmpty(ambient_temperature_c) ? (object)DBNull.Value : ambient_temperature_c);
                        command.Parameters.AddWithValue("@object_temperature_c", String.IsNullOrEmpty(object_temperature_c) ? (object)DBNull.Value : object_temperature_c);
                        command.Parameters.AddWithValue("@distance_centimeters", String.IsNullOrEmpty(distance_centimeters) ? (object)DBNull.Value : distance_centimeters);
                        command.Parameters.AddWithValue("@badge_id", String.IsNullOrEmpty(badge_id) ? (object)DBNull.Value : badge_id);

                        using (SqlDataReader SQLReader = command.ExecuteReader())
                        {
                            if (SQLReader != null)
                            {
                                while (SQLReader.Read())
                                {
                                    return Convert.ToBoolean(SQLReader["return_value"]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //catch this error probably..
                return false;
            }
            return false;
        }




        [WebMethod]
        public static int GetFeverStatusCount(String badge_id, String interval, String interval_value)
        {
            String SQLString = "EXECUTE dbo.mts_get_fever_status_count @badge_id, @interval, @interval_value";
            try
            {
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(SQLString, connection))
                    {
                        command.Parameters.AddWithValue("@badge_id", String.IsNullOrEmpty(badge_id) ? (object)DBNull.Value : badge_id);
                        command.Parameters.AddWithValue("@interval", String.IsNullOrEmpty(interval) ? (object)DBNull.Value : interval);
                        command.Parameters.AddWithValue("@interval_value", String.IsNullOrEmpty(interval_value) ? (object)DBNull.Value : interval_value);

                        using (SqlDataReader SQLReader = command.ExecuteReader())
                        {
                            if (SQLReader != null)
                            {
                                while (SQLReader.Read())
                                {
                                    return Convert.ToInt32(SQLReader["fever_status_count"]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //catch this error probably..
                return 0;
            }
            return 0;
        }

    }
}