using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace COVID_Protocols.Maintenance
{
    public partial class Employees : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SelectEmployeeLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton SelectEmployeeLinkButton = (LinkButton)sender;
            ListViewDataItem EmployeeNameListView_lvdi = (ListViewDataItem)SelectEmployeeLinkButton.NamingContainer;
            ListView EmployeeNameListView_lv = (ListView)EmployeeNameListView_lvdi.NamingContainer;
            String id = EmployeeNameListView_lv.DataKeys[EmployeeNameListView_lvdi.DataItemIndex].Values["id"].ToString();
            EmployeeEditSqlDataSource.SelectParameters["id"].DefaultValue = id;
            EmployeeNameListView_lv.SelectedIndex = EmployeeNameListView_lvdi.DataItemIndex;
            EmployeeEditListView.DataBind();
            MonitorListView.DataBind();
        }


        protected void monitor_start_dateTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox monitor_start_dateTextBox = (TextBox)sender;
            String monitor_start_date = monitor_start_dateTextBox.Text;
            ListViewDataItem lvdi = (ListViewDataItem)monitor_start_dateTextBox.NamingContainer;
            ListView lv = (ListView)lvdi.NamingContainer;
            String id = lv.DataKeys[lvdi.DataItemIndex].Values["id"].ToString();
            if (EmployeeFunctions.MonitorStartDateChanged(id, monitor_start_date))
            {
                MessageLabel.Text = "Saved " + monitor_start_date.ToString() + " on " + DateTime.Now.ToString();
            }
            else
            {
                MessageLabel.Text = "An Error Occurred.";
            }
        }

        protected void monitor_end_dateTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox monitor_end_dateTextBox = (TextBox)sender;
            String monitor_end_date = monitor_end_dateTextBox.Text;
            ListViewDataItem lvdi = (ListViewDataItem)monitor_end_dateTextBox.NamingContainer;
            ListView lv = (ListView)lvdi.NamingContainer;
            String id = lv.DataKeys[lvdi.DataItemIndex].Values["id"].ToString();
            if (EmployeeFunctions.MonitorEndDateChanged(id, monitor_end_date))
            {
                MessageLabel.Text = "Saved " + monitor_end_date.ToString() + " on " + DateTime.Now.ToString();
            }
            else
            {
                MessageLabel.Text = "An Error Occurred.";
            }
        }

        protected void CardNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox CardNumberTextBox = (TextBox)sender;
            String card_number = CardNumberTextBox.Text;
            ListViewDataItem lvdi = (ListViewDataItem)CardNumberTextBox.NamingContainer;
            ListView lv = (ListView)lvdi.NamingContainer;
            String id = lv.DataKeys[lvdi.DataItemIndex].Values["id"].ToString();
            if (EmployeeFunctions.CardNumberChanged(id, card_number))
            {
                MessageLabel.Text = "Saved " + card_number.ToString() + " on " + DateTime.Now.ToString();
            }
            else
            {
                MessageLabel.Text = "An Error Occurred.";
            }
        }

        protected void LanguageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList LanguageDropDownList = (DropDownList)sender;
            String default_language = LanguageDropDownList.SelectedValue;
            ListViewDataItem lvdi = (ListViewDataItem)LanguageDropDownList.NamingContainer;
            ListView lv = (ListView)lvdi.NamingContainer;
            String id = lv.DataKeys[lvdi.DataItemIndex].Values["id"].ToString();
            if (EmployeeFunctions.LanguageChanged(id, default_language))
            {
                MessageLabel.Text = "Saved " + default_language.ToString() + " on " + DateTime.Now.ToString();
            }
            else
            {
                MessageLabel.Text = "An Error Occurred.";
            }
        }

        protected void return_to_work_textbox_TextChanged(object sender, EventArgs e)
        {
            TextBox return_to_work_textbox = (TextBox)sender;
            String return_to_work = return_to_work_textbox.Text;
            ListViewDataItem lvdi = (ListViewDataItem)return_to_work_textbox.NamingContainer;
            ListView lv = (ListView)lvdi.NamingContainer;
            String id = lv.DataKeys[lvdi.DataItemIndex].Values["id"].ToString();
            if (EmployeeFunctions.ReturnToWorkChanged(id, return_to_work))
            {
                MessageLabel.Text = "Saved " + return_to_work.ToString() + " on " + DateTime.Now.ToString();
            }
            else
            {
                MessageLabel.Text = "An Error Occurred.";
            }
        }

        protected void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox EmailTextBox = (TextBox)sender;
            String email = EmailTextBox.Text;
            ListViewDataItem lvdi = (ListViewDataItem)EmailTextBox.NamingContainer;
            ListView lv = (ListView)lvdi.NamingContainer;
            String id = lv.DataKeys[lvdi.DataItemIndex].Values["id"].ToString();
            if (EmployeeFunctions.EmailChanged(id, email))
            {
                MessageLabel.Text = "Saved " + email.ToString() + " on " + DateTime.Now.ToString();
            }
            else
            {
                MessageLabel.Text = "An Error Occurred.";
            }
        }

        protected void EmailSurveyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox EmailSurveyCheckBox = (CheckBox)sender;
            String checked_status = EmailSurveyCheckBox.Checked.ToString();
            ListViewDataItem lvdi = (ListViewDataItem)EmailSurveyCheckBox.NamingContainer;
            ListView lv = (ListView)lvdi.NamingContainer;
            String id = lv.DataKeys[lvdi.DataItemIndex].Values["id"].ToString();
            if (EmployeeFunctions.EmailSurveyChanged(id, checked_status))
            {
                MessageLabel.Text = "Saved " + checked_status.ToString() + " on " + DateTime.Now.ToString();
            }
            else
            {
                MessageLabel.Text = "An Error Occurred.";
            }
        }
    }
}