using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COVID_Protocols
{
    public partial class covid_workplace_health_screening : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                form_id_HiddenField.Value = "1";
                LangDropDownList.SelectedValue = "1";

                if (Session["tablet_mode"] != null)
                {
                    if (Session["tablet_mode"].ToString() == "1")
                    {


                        if (Session["id"] != null)
                        {
                            form_id_HiddenField.Value = Session["id"].ToString();
                            LangDropDownList.SelectedValue = Session["id"].ToString();
                        }

                        if (Session["badge_id"] != null)
                        {
                            BadgeTextBox.Text = Session["badge_id"].ToString();

                            // byte[] bytes = MarshFormsFunctions.GetEmployeeBadgeImage(Session["badge_id"]);
                            // BitmapImage bmpImage = new BitmapImage();
                            // MemoryStream msImageStream = new MemoryStream();
                            // msImageStream.Write(bytes, 0, bytes.Length);
                            // bmpCardImage.BeginInit();
                            // bmpCardImage.StreamSource = new MemoryStream(msImageStream.ToArray());
                            // bmpCardImage.EndInit();
                            //// image.Source = bmpCardImage;
                            // BadgeImage.ImageUrl =   MarshFormsFunctions.GetEmployeeBadgeImage(Session["badge_id"].ToString());

                            TemperatureTextBox.Text = MarshFormsFunctions.GetLastTemp(Session["badge_id"].ToString());

                        }

                        if (Session["employee_name"] != null)
                        {
                            EmployeeNameTextBox.Text = Session["employee_name"].ToString();
                        }


                        if (Session["max_dt"] != null)
                        {
                            LastSurveyedLabel.Text = Session["max_dt"].ToString();
                        }
                    }
                    else if (Session["tablet_mode"].ToString() == "0")
                    {

                    }
                }
                else
                {

                }

                EmployeeNameTextBox.Focus();
            }

            //EmployeeNameTextBox.Focus();
        }

        protected void question_headings_ListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                String id = question_headings_ListView.DataKeys[e.Item.DataItemIndex].Values["id"].ToString();
                SqlDataSource questions_SqlDataSource = (SqlDataSource)e.Item.FindControl("questions_SqlDataSource");
                questions_SqlDataSource.SelectParameters["question_heading_id"].DefaultValue = id;
            }
        }

        protected void SubmitLinkButton_Click(object sender, EventArgs e)
        {
            String employee_name = EmployeeNameTextBox.Text;
            String employee_badge_id = BadgeTextBox.Text;
            String temperature = TemperatureTextBox.Text;
            String additional_comments = AdditionalCommentsTextBox.Text;
            bool NoBlanks = true;
            if (employee_name == "")
            {
                NoBlanks = false;
                EmployeeNameTextBox.Focus();
                MessageLabel.Text = "Employee name field must be filled in.";
            }
            else if (employee_badge_id == "")
            {
                NoBlanks = false;
                BadgeTextBox.Focus();
            }
            //REMOVED 10/5/2020 
            /*else if (temperature == "")
             {
                 NoBlanks = false;
                 TemperatureTextBox.Focus();
             }*/
            else
            {

                int employee_id = MarshFormsFunctions.GetEmployeeID(Convert.ToInt32(employee_badge_id));
                int payroll_id = MarshFormsFunctions.GetEmployeePayrollIDFromBadge(employee_badge_id);
                String g = Guid.NewGuid().ToString();
                //IDictionary<int, string> answers = new Dictionary<int, string>();
                List<List<string>> answers = new List<List<string>>();

                bool answeredTrue = false;
                int critical_count = 0;
                int non_critical_count = 0;
                foreach (ListViewItem lvi1 in question_headings_ListView.Items)
                {
                    ListView questions_ListView = (ListView)lvi1.FindControl("questions_ListView");

                    foreach (ListViewItem lvi2 in questions_ListView.Items)
                    {
                        int question_id;
                        if (Int32.TryParse(questions_ListView.DataKeys[lvi2.DataItemIndex].Values["id"].ToString(), out question_id))
                        {
                            CheckBox answer1bit = (CheckBox)lvi2.FindControl("answer1bit");
                            CheckBox answer2bit = (CheckBox)lvi2.FindControl("answer2bit");
                            CheckBox answer3bit = (CheckBox)lvi2.FindControl("answer3bit");
                            String critical_question = questions_ListView.DataKeys[lvi2.DataItemIndex].Values["critical"].ToString();

                            answers.Add(new List<string> { question_id.ToString(), answer1bit.Checked.ToString(), answer2bit.Checked.ToString(), answer3bit.Checked.ToString() });


                            if (answer1bit.Checked || answer2bit.Checked)
                            {
                                //answers.Add(question_id, "True");
                                answeredTrue = true;
                                if (critical_question == "True") { critical_count++; }
                                else { non_critical_count++; }
                            }
                            else if (answer3bit.Checked)
                            {
                                //answers.Add(question_id, "False");
                            }
                            else
                            {
                                //answers.Add(question_id, "Blank");
                                NoBlanks = false;
                            }
                        }
                    }
                }

                ////ERROR CHECKING


                if (NoBlanks)
                {
                    if (!MarshFormsFunctions.SubmitTemp(employee_id, employee_name, employee_badge_id, temperature, g, additional_comments))
                    {
                        //ERROR database exception
                        MessageLabel.Text = "An unexpected error occurred when trying to submit the form. Please try again.";
                    }
                    else
                    {



                        foreach (List<string> subList in answers)
                        {
                            int question_id;
                            String answer1 = "";
                            String answer2 = "";
                            String answer3 = "";
                            if (Int32.TryParse(subList[0], out question_id))
                            {
                                answer1 = subList[1];
                                answer2 = subList[2];
                                answer3 = subList[3];

                            }


                            if (!MarshFormsFunctions.SubmitAnswer1(question_id, employee_id, employee_name, employee_badge_id, answer1, answer2, answer3, g))
                            {
                                //ERROR database exception
                                MessageLabel.Text = "An unexpected error occurred when trying to submit the form. Please try again.";
                                break;
                            }
                        }

                        //IF THERE TEMP IS HIGH THEN GRAB A PHONE # AND GO TO YOUR CAR

                        if (temperature != "")
                        {
                            if (double.Parse(temperature, System.Globalization.CultureInfo.InvariantCulture) >= 100.4)
                            {
                                HttpContext.Current.Session["guid"] = g;
                                Response.Redirect("~\\FormSubmittedTrue.aspx");
                            }
                        }


                        //IF THEY ARE IN THE PROGRAM THEN BUSINESS AS USUAL
                        if (MarshFormsFunctions.get_monitor(employee_badge_id))
                        {
                            //MarshFormsFunctions.sendEmail(g, employee_name, "", true, payroll_id.ToString());
                            Response.Redirect("~\\FormSubmitted.aspx");
                        }


                        //ANY AMOUNT OF YES -- GO TO CAR
                        //else if (answeredTrue)
                        //{
                        //    HttpContext.Current.Session["guid"] = g;
                        //    Response.Redirect("~\\FormSubmittedTrue.aspx");
                        //}
                        //IF YOU ANSWER 1 OR MORE CRITICAL QUESTIONS TRUE THEN GO TO YOUR CAR
                        else if (critical_count > 0)
                        {
                            HttpContext.Current.Session["guid"] = g;
                            Response.Redirect("~\\FormSubmittedTrue.aspx");
                        }
                        //IF YOU ANSWER 2 OR MORE SOFT QUESTIONS TRUE THEN GO TO YOUR CAR
                        else if (non_critical_count > 1)
                        {
                            HttpContext.Current.Session["guid"] = g;
                            Response.Redirect("~\\FormSubmittedTrue.aspx");
                        }

                        //OTHERWISE YOUR GOOD TO STAY IN THE FACILITY
                        else
                        {
                            //SEND FOLLOW UP EMAIL IF THERE IS ONE SOFT YES
                            if (non_critical_count > 0)
                            {
                                MarshFormsFunctions.sendEmail(g, employee_name, "", true, payroll_id.ToString());
                            }
                            Response.Redirect("~\\FormSubmitted.aspx");

                        }
                    }
                }
                else
                {
                    // MessageLabel.Text = "Please be sure to fill out each field on the form.";
                    //ERROR blank value
                }
            }
        }

        protected void NoToAllLinkButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi1 in question_headings_ListView.Items)
            {
                ListView questions_ListView = (ListView)lvi1.FindControl("questions_ListView");
                foreach (ListViewItem lvi2 in questions_ListView.Items)
                {
                    CheckBox answer1bit = (CheckBox)lvi2.FindControl("answer1bit");
                    CheckBox answer2bit = (CheckBox)lvi2.FindControl("answer2bit");
                    CheckBox answer3bit = (CheckBox)lvi2.FindControl("answer3bit");
                    answer1bit.Checked = false;
                    answer2bit.Checked = false;
                    answer3bit.Checked = true;
                }
            }
        }

        protected void LangDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            String form_id = ddl.SelectedValue.ToString();
            form_id_HiddenField.Value = form_id;

        }
    }
}