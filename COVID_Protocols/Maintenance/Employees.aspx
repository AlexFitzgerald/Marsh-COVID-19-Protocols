<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="COVID_Protocols.Maintenance.Employees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-12">
                    <asp:Label ID="MessageLabel" runat="server" />
                </div>
            </div>
            <div class="row small">
                <div class="col-4">
                    <div class="m-3  p-3 bg-white shadow-sm ">
                        <h5>Employees</h5>
                        <div style="height: 80vh;" class="overflow-auto">
                            <asp:ListView ID="EmployeeNameListView" runat="server" DataKeyNames="id" DataSourceID="EmployeeNameSqlDataSource">
                                <EmptyDataTemplate>
                                </EmptyDataTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="SelectEmployeeLinkButton" OnClick="SelectEmployeeLinkButton_Click" CssClass="nav-link" runat="server">
                            <div class="d-flex justify-content-between"><div class="bd-highlight"><%# Eval("first_name") %>&nbsp;<%# Eval("middle_name") %>&nbsp;<%# Eval("last_name") %></div><div class="bd-highlight"> <%# Eval("payroll_id") %></div></div>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <SelectedItemTemplate>
                                    <asp:LinkButton ID="SelectEmployeeLinkButton" CssClass="nav-link bg-primary rounded text-white" runat="server">
                            <div class="d-flex justify-content-between"><div class="bd-highlight"><%# Eval("first_name") %>&nbsp;<%# Eval("middle_name") %>&nbsp;<%# Eval("last_name") %></div><div class="bd-highlight">  <%# Eval("payroll_id") %></div></div>
                                    </asp:LinkButton>
                                </SelectedItemTemplate>
                                <LayoutTemplate>
                                    <div id="itemPlaceholderContainer" runat="server" style="">
                                        <span runat="server" id="itemPlaceholder" />
                                    </div>
                                </LayoutTemplate>
                            </asp:ListView>
                            <asp:SqlDataSource ID="EmployeeNameSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MarshFormsConnectionString %>" SelectCommand="SELECT * FROM MarshForms.dbo.employees WHERE active = 1 ORDER BY first_name, last_name"></asp:SqlDataSource>
                        </div>
                    </div>
                </div>
                <div class="col-8">
                    <asp:ListView ID="EmployeeEditListView" runat="server" DataKeyNames="id" DataSourceID="EmployeeEditSqlDataSource">
                        <EmptyDataTemplate>
                        </EmptyDataTemplate>
                        <ItemTemplate>
                            <div class="m-3  p-3 bg-white shadow-sm ">
                                <div class="row">
                                    <div class="col-12">
                                        <h5>Employee Information</h5>
                                        <%# Eval("first_name") %>
                                        <%# Eval("nick_name") %>
                                        <%# Eval("middle_name") %>
                                        <%# Eval("last_name") %>
                                        <p>Phone</p>
                                        <%# Eval("cellPhone") %>
                                        <%# Eval("homePhone") %>
                                        <%# Eval("workPhone") %>
                                        <br />
                                        <p>Department</p>
                                        <%# Eval("department_number") %>&nbsp;  <%# Eval("department_desc") %>

                                        <div class="d-flex flex-wrap">
                                            <div class="m-3">
                                                Badge #
                                        <asp:TextBox ID="CardNumberTextBox" AutoPostBack="true" TextMode="Number" OnTextChanged="CardNumberTextBox_TextChanged" CssClass="form-control form-control-sm" Text='<%# Eval("card_number") %>' runat="server" />
                                            </div>
                                            <div class="m-3">
                                                Native Language  
                                        <asp:DropDownList ID="LanguageDropDownList" AutoPostBack="true" OnSelectedIndexChanged="LanguageDropDownList_SelectedIndexChanged" CssClass="form-control form-control-sm" runat="server" DataSourceID="LanguagesSqlDataSource" DataTextField="language" SelectedValue='<%# Eval("default_language") %>' DataValueField="id"></asp:DropDownList>
                                                <asp:SqlDataSource ID="LanguagesSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MarshFormsConnectionString %>" SelectCommand="SELECT * FROM [languages]"></asp:SqlDataSource>
                                            </div>
                                        </div>
                                        <div class="d-flex flex-wrap">
                                            <div class="m-3">
                                                Email Survey Each Morning<br />
                                                <asp:CheckBox ID="EmailSurveyCheckBox" AutoPostBack="true" OnCheckedChanged="EmailSurveyCheckBox_CheckedChanged" Checked='<%# Eval("daily_survey_email") %>' runat="server" />

                                            </div>
                                        </div>
                                        <div class="d-flex flex-wrap">
                                            <div class="m-3">
                                                Email
                                        <asp:TextBox ID="EmailTextBox" AutoPostBack="true" OnTextChanged="EmailTextBox_TextChanged" CssClass="form-control form-control-sm" Text='<%# Eval("email") %>' runat="server" />
                                            </div>
                                            <div class="m-3">
                                                Payroll Email<br />
                                                <%# Eval("emailAddress") %>
                                            </div>
                                        </div>
                                        <hr />
                                        <h5>COVID</h5>
                                        <div class="d-flex flex-wrap">
                                            <div class="m-3">
                                                Covid Positive 
                                                 <asp:CheckBox ID="covid_positiveCheckBox" OnCheckedChanged="covid_positiveCheckBox_CheckedChanged" AutoPostBack="true" Checked='<%# Eval("covid_positive") %>' runat="server" />

                                            </div>
                                            <div class="m-3">
                                                Close Contact
                                                <asp:CheckBox ID="covid_close_contactCheckBox" OnCheckedChanged="covid_close_contactCheckBox_CheckedChanged" AutoPostBack="true" Checked='<%# Eval("covid_close_contact") %>' runat="server" />
                                            </div>
                                            <div class="m-3">
                                                Watch List
                                                  
                                                            <asp:CheckBox ID="covid_watch_listCheckBox" OnCheckedChanged="covid_watch_listCheckBox_CheckedChanged" AutoPostBack="true" Checked='<%# Eval("covid_watch_list") %>' runat="server" />

                                            </div>
                                        </div>


                                        <div class="d-flex flex-wrap">
                                            <div class="m-3">
                                                Covid Test Date                                                     
                                                    <asp:TextBox ID="covid_test_dateTextBox" OnTextChanged="covid_test_dateTextBox_TextChanged" placeholder="mm/dd/yyyy" AutoPostBack="true" CssClass="form-control form-control-sm" Text='<%# Eval("covid_test_date", "{0:d}") %>' runat="server" />
                                            </div>
                                            <div class="m-3">
                                                Covid Result Date
                                              <asp:TextBox ID="covid_resulted_dateTextBox" OnTextChanged="covid_resulted_dateTextBox_TextChanged" placeholder="mm/dd/yyyy" AutoPostBack="true" CssClass="form-control form-control-sm" Text='<%# Eval("covid_resulted_date", "{0:d}") %>' runat="server" />
                                            </div>
                                            <div class="m-3">
                                                Contacted Employee Date
                                              <asp:TextBox ID="covid_contact_result_dateTextBox" OnTextChanged="covid_contact_result_dateTextBox_TextChanged" placeholder="mm/dd/yyyy" AutoPostBack="true" CssClass="form-control form-control-sm" Text='<%# Eval("covid_contact_result_date", "{0:d}") %>' runat="server" />
                                            </div>
                                        </div>
                                        <div class="d-flex flex-wrap">
                                            <div class="m-3">
                                                Symptoms
                                                                                                <asp:DropDownList ID="CovidSymptomsDropDownList" OnSelectedIndexChanged="CovidSymptomsDropDownList_SelectedIndexChanged" CssClass="form-control form-control-sm" runat="server" DataSourceID="SympSqlDataSource" DataTextField="text" DataValueField="value" SelectedValue='<%# Bind("covid_symptoms") %>'></asp:DropDownList>
                                            </div>

                                            <div class="m-3">
                                                Estimate Return Date                                                    
                                                    <asp:TextBox ID="covid_estimate_return_dateTextBox" placeholder="mm/dd/yyyy" OnTextChanged="covid_estimate_return_dateTextBox_TextChanged" AutoPostBack="true" CssClass="form-control form-control-sm" Text='<%# Eval("covid_estimate_return_date", "{0:d}") %>' runat="server" />
                                            </div>
                                            <div class="m-3">
                                                Actual Return Date                                                    
                                                    <asp:TextBox ID="covid_actual_return_dateTextBox" placeholder="mm/dd/yyyy" OnTextChanged="covid_actual_return_dateTextBox_TextChanged" AutoPostBack="true" CssClass="form-control form-control-sm" Text='<%# Eval("covid_actual_return_date", "{0:d}") %>' runat="server" />
                                            </div>
                                        </div>
                                      
                                            <div class="m-3">
                                                Notes
                                                           <asp:TextBox ID="NotesTextBox"   AutoPostBack="true" CssClass="form-control" OnTextChanged="NotesTextBox_TextChanged"   TextMode="MultiLine" Text='<%# Eval("covid_notes") %>' runat="server" />
                                          
                                                </div>
                                            </div>
                                    
                                </div>
                            </div>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <div id="itemPlaceholderContainer" runat="server" style="">
                                <div runat="server" id="itemPlaceholder"></div>
                            </div>
                        </LayoutTemplate>
                    </asp:ListView>

                    <asp:ListView ID="MonitorListView" runat="server" DataKeyNames="id" DataSourceID="EmployeeEditSqlDataSource">
                        <EmptyDataTemplate>
                        </EmptyDataTemplate>
                        <ItemTemplate>
                            <div class="m-3  p-3 bg-white shadow-sm ">
                                <div class="row">
                                    <div class="col-12">
                                        <h5>Monitor</h5>
                                        <%-- Text that describes what this does.--%>
                                        <br />
                                        <div class="d-flex flex-wrap">
                                            <div class="m-3">
                                                Start Date 
                                                <br />
                                                <asp:TextBox ID="monitor_start_dateTextBox" AutoPostBack="true" OnTextChanged="monitor_start_dateTextBox_TextChanged" placeholder="mm/dd/yyyy" CssClass="form-control form-control-sm" Text='<%# Eval("monitor_start_date", "{0:d}") %>' runat="server" />
                                            </div>
                                            <div class="m-3">
                                                End Date 
                                                <br />
                                                <asp:TextBox ID="monitor_end_dateTextBox" AutoPostBack="true" OnTextChanged="monitor_end_dateTextBox_TextChanged" placeholder="mm/dd/yyyy" CssClass="form-control form-control-sm" Text='<%# Eval("monitor_end_date", "{0:d}") %>' runat="server" />
                                            </div>
                                        </div>

                                        <div class="d-flex flex-wrap">
                                            <div class="m-3">
                                                Return To Work
                                                <br />
                                                <asp:TextBox ID="return_to_work_textbox" AutoPostBack="true" OnTextChanged="return_to_work_textbox_TextChanged" placeholder="mm/dd/yyyy" CssClass="form-control form-control-sm" Text='<%# Eval("return_to_work", "{0:d}") %>' runat="server" />
                                            </div>
                                            <div class="m-3">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <div id="itemPlaceholderContainer" runat="server" style="">
                                <span runat="server" id="itemPlaceholder" />
                            </div>
                        </LayoutTemplate>
                    </asp:ListView>
                    <asp:SqlDataSource ID="EmployeeEditSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MarshFormsConnectionString %>" SelectCommand="SELECT e.id, e.card_number, e.payroll_id, e.first_name, e.middle_name, e.last_name, e.nick_name, e.default_language, e.monitor_start_date, e.monitor_end_date, e.audit, e.active, e.phone_number, e.email, e.return_to_work,e.covid_symptoms, e.daily_survey_email, CAST( COALESCE(e.covid_positive, 0) AS BIT) AS covid_positive, CAST(COALESCE(e.covid_close_contact, 0) AS BIT) AS covid_close_contact, CAST(COALESCE(e.covid_watch_list, 0) AS BIT) AS covid_watch_list, e.covid_test_date, e.covid_resulted_date, e.covid_contact_result_date, e.covid_estimate_return_date, e.covid_actual_return_date, e.covid_notes, pe.department_number, pe.department_desc, pe.emailAddress, pe.cellPhone, pe.homePhone, pe.workPhone, pe.job_title, pe.BirthDate, pe.AgeYears, pe.hire_date FROM employees AS e LEFT  JOIN view_payroll_employees AS pe ON e.payroll_id = pe.id WHERE e.active = 1 AND e.id = @id">
                        <SelectParameters>
                            <asp:Parameter Name="id" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:SqlDataSource ID="SympSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MarshFormsConnectionString %>" SelectCommand="select 'None' as text,NULL as value
union all
select 'Mild' as text,'Mild' as value
union all
select 'Moderate' as text,'Moderate' as value
union all
select 'Severe' as text,'Severe' as value"></asp:SqlDataSource>
</asp:Content>
