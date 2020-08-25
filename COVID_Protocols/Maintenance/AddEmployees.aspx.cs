using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COVID_Protocols.Maintenance
{
    public partial class AddEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SubmitLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton SubmitLinkButton = (LinkButton)sender;

            ListViewDataItem lvdi = (ListViewDataItem)SubmitLinkButton.NamingContainer;
            ListView lv = (ListView)lvdi.NamingContainer;
            String payroll_id = lv.DataKeys[lvdi.DataItemIndex].Values["payroll_id"].ToString();
            TextBox BadgeTextBox = (TextBox)lvdi.FindControl("BadgeTextBox");
            String card_number = BadgeTextBox.Text;
            if (EmployeeFunctions.AddEmployee(payroll_id, card_number))
            {
                lv.DataBind();
            }
            else
            {

            }
        }
    }
}