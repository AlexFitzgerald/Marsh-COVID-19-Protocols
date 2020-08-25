using System;
using System.Web;
using System.Web.Services;

namespace COVID_Protocols
{
    public partial class FormSubmittedTrue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["guid"] != null)
                {
                    guid_HiddenField.Value = Session["guid"].ToString();
                }
            }
        }

        protected void MarshFormsLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\Default.aspx");
        }

        protected void SubmitLinkButton_Click(object sender, EventArgs e)
        {
            int employee_id = MarshFormsFunctions.GetEmployeeIDFromGuid(guid_HiddenField.Value);
            String payroll_id = MarshFormsFunctions.GetPayrollIDFromGuid(guid_HiddenField.Value);
            String employee_name = MarshFormsFunctions.GetEmployeeNameFromGuid(guid_HiddenField.Value);
            String phone_number = PhoneTextBox.Text;

            if (phone_number != "")
            {
                if (MarshFormsFunctions.SubmitPhone(employee_id, phone_number))
                {
                    //TODO : Send an email to the employee’s supervisor and the clinic if the employee answers yes to any of the questions.
                    try
                    {
                        MarshFormsFunctions.sendEmail(guid_HiddenField.Value.ToString(), employee_name, phone_number,false, payroll_id);
                    }
                    catch (Exception ex)
                    {

                    }
                    Response.Redirect("~\\FormSubmitted.aspx");
                }
                else
                {

                }
            }


        }




    }
}