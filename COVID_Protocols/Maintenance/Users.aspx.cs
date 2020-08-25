using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COVID_Protocols.Maintenance
{
    public partial class Users : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
        }

        protected void AddUserLinkButton_Click(object sender, EventArgs e)
        {
            String email = AddEmailTextBox.Text;
            String password = AddPasswordTextBox.Text;
            String reports = ReportsCheckBox.Checked.ToString();
            String maintenance = MaintenanceCheckBox.Checked.ToString();
            if (email == "")
            {
                AddEmailTextBox.Focus();
            }
            else
            {
                try
                {
                    String SQLString = "EXECUTE dbo.stored_proc_insert_user @email, @password, @reports, @maintenance, @application_user";
                    System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                    using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                    {
                        SqlCommand command = new SqlCommand(SQLString, connection);
                        command.Parameters.AddWithValue("@email", String.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                        command.Parameters.AddWithValue("@password", String.IsNullOrEmpty(password) ? (object)DBNull.Value : password);
                        command.Parameters.AddWithValue("@reports", String.IsNullOrEmpty(reports) ? (object)DBNull.Value : reports);
                        command.Parameters.AddWithValue("@maintenance", String.IsNullOrEmpty(maintenance) ? (object)DBNull.Value : maintenance);
                        command.Parameters.AddWithValue("@application_user", String.IsNullOrEmpty(User.Identity.Name) ? (object)DBNull.Value : User.Identity.Name);
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                    }
                    UserListView.DataBind();
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message.ToString();
                }
            }
        }

        protected void DeleteLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            ListViewDataItem lvdi = (ListViewDataItem)lb.NamingContainer;
            ListView lv = (ListView)lvdi.NamingContainer;
            String email = lv.DataKeys[lvdi.DataItemIndex].Values["email"].ToString();
            try
            {
                String SQLString = "DELETE FROM users WHERE email =  @email";
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@email", String.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                UserListView.DataBind();
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message.ToString();
            }

        }

        protected void UpdateLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            ListViewDataItem lvdi = (ListViewDataItem)lb.NamingContainer;
            ListView lv = (ListView)lvdi.NamingContainer;
            TextBox passwordTextBox = (TextBox)lvdi.FindControl("passwordTextBox");
            String password = passwordTextBox.Text;
            CheckBox reportsCheckBox = (CheckBox)lvdi.FindControl("reportsCheckBox");
            String reports = reportsCheckBox.Checked.ToString();
            CheckBox maintenanceCheckBox = (CheckBox)lvdi.FindControl("maintenanceCheckBox");
            String maintenance = maintenanceCheckBox.Checked.ToString();
            String email = lv.DataKeys[lvdi.DataItemIndex].Values["email"].ToString();

            try
            {
                String SQLString = "EXECUTE dbo.stored_proc_update_user @email, @password, @reports, @maintenance, @application_user";
                System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
                using (SqlConnection connection = new SqlConnection(config.ConnectionStrings.ConnectionStrings["MarshFormsConnectionString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLString, connection);
                    command.Parameters.AddWithValue("@email", String.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                    command.Parameters.AddWithValue("@password", String.IsNullOrEmpty(password) ? (object)DBNull.Value : password);
                    command.Parameters.AddWithValue("@reports", String.IsNullOrEmpty(reports) ? (object)DBNull.Value : reports);
                    command.Parameters.AddWithValue("@maintenance", String.IsNullOrEmpty(maintenance) ? (object)DBNull.Value : maintenance);
                    command.Parameters.AddWithValue("@application_user", String.IsNullOrEmpty(User.Identity.Name) ? (object)DBNull.Value : User.Identity.Name);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                UserListView.EditIndex = -1;
                UserListView.DataBind();
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message.ToString();
            }
        }
    }
}