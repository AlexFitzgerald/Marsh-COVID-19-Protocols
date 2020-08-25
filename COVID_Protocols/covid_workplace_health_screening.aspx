<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="covid_workplace_health_screening.aspx.cs" Inherits="COVID_Protocols.covid_workplace_health_screening" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        input[type='checkbox'] {
            width: 30px;
            height: 30px;
        }
    </style>
    <div class="container">
        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-body">
                        <p>Your badge number is the second number displayed on the back of your badge. The example below shows the badge # in red.</p>
                        <img src="Images/back_of_badge.PNG" style="width: 100%;" />
                    </div>
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="bg-white">
                    <div class="row">
                        <div class="col-12">
                            <asp:HiddenField ID="form_id_HiddenField" runat="server" />

                            <asp:ListView ID="forms_ListView" runat="server" DataKeyNames="id" DataSourceID="forms_SqlDataSource">
                                <ItemTemplate>
                                    <div class="p-4">
                                        <h2 class="text-center" style='font-family: <%# Eval("font") %>;'><%# Eval("form_name") %></h2>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <h5 class="text-center"><strong>
                                <asp:Label ID="MessageLabel" ForeColor="Red" runat="server" /></strong></h5>
                            <asp:Label ID="LastSurveyedLabel" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="row m-1">
                        <div class="col-lg-6">
                            <div class="input-group mb-2 mr-sm-2">
                                <div class="input-group-prepend">
                                    <div class="input-group-text">
                                        <asp:ListView ID="employee_name_fieldListView" runat="server" DataKeyNames="id" DataSourceID="forms_SqlDataSource">
                                            <ItemTemplate>
                                                <asp:Label ID="EmployeeNameLabel" runat="server" Text='<%# Eval("employee_name_field") %>' />
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </div>
                                </div>
                                <asp:TextBox ID="EmployeeNameTextBox" CssClass="form-control form-control-lg" runat="server" />
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="input-group mb-2 mr-sm-2">
                                <div class="input-group-prepend">
                                    <div class="input-group-text">
                                        <asp:ListView ID="EmployeeBadgeListView" runat="server" DataKeyNames="id" DataSourceID="forms_SqlDataSource">
                                            <ItemTemplate>
                                                <a data-toggle="modal" style="border-bottom: 1px dotted;" data-target="#myModal">
                                                    <asp:Label ID="EmployeeBadgeLabel" runat="server" Text='<%# Eval("badge_id_field") %>' />

                                                </a>
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </div>
                                </div>
                                <asp:TextBox ID="BadgeTextBox" TextMode="Number" CssClass="form-control form-control-lg" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row  m-1">
                        <div class="col-lg-3">
                            <div class="input-group mb-2 mr-sm-2">
                                <div class="input-group-prepend">
                                    <div class="input-group-text">
                                        <asp:ListView ID="TempListView" runat="server" DataKeyNames="id" DataSourceID="forms_SqlDataSource">
                                            <ItemTemplate>
                                                <asp:Label ID="TemperatureBadgeLabel" runat="server" Text='<%# Eval("temperature_field") %>' />
                                            </ItemTemplate>
                                        </asp:ListView>
                                    </div>
                                </div>
                                <asp:TextBox ID="TemperatureTextBox" TextMode="Number" CssClass="form-control form-control-lg" runat="server" />
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <asp:DropDownList ID="LangDropDownList" CssClass="form-control form-control-lg" runat="server" OnSelectedIndexChanged="LangDropDownList_SelectedIndexChanged" AutoPostBack="true" DataSourceID="LangSqlDataSource" DataTextField="language" DataValueField="form_id"></asp:DropDownList>
                            <asp:SqlDataSource ID="LangSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MarshFormsConnectionString %>" SelectCommand="SELECT l.id, l.language, f.id AS form_id FROM languages AS l INNER JOIN forms AS f ON l.id = f.language_id ORDER BY l.id"></asp:SqlDataSource>
                        </div>
                    </div>
                    <asp:Image ID="BadgeImage" runat="server" />
                    <asp:SqlDataSource ID="forms_SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MarshFormsConnectionString %>" SelectCommand="SELECT f.*, l.language,l.font FROM forms AS f INNER JOIN languages AS l ON f.language_id = l.id WHERE f.id = @id">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="form_id_HiddenField" Name="id" PropertyName="Value" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <div class="m-4">
                        <asp:ListView ID="question_headings_ListView" runat="server" OnItemDataBound="question_headings_ListView_ItemDataBound" DataKeyNames="id" DataSourceID="question_headings_SqlDataSource">
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-9 p-2    border-dark border border-top-0 border-left-0 border-right-0" style="background-color: #3F4727; color: #DBC99D;">
                                        <strong style='font-family: <%# Eval("font") %>;'><%# Eval("question_heading") %></strong>
                                    </div>
                                    <div class="col-1 p-2  text-center border-dark border border-top-0 border-left-0 border-right-0" style="background-color: #3F4727; color: #DBC99D;">
                                        <strong style='font-family: <%# Eval("font") %>;'><%# Eval("question_heading_2") %></strong>
                                    </div>
                                    <div class="col-1 p-2 text-center border-dark border border-top-0 border-left-0 border-right-0" style="background-color: #3F4727; color: #DBC99D;">
                                        <strong style='font-family: <%# Eval("font") %>;'><%# Eval("question_heading_3") %></strong>
                                    </div>
                                    <div class="col-1 p-2 text-white text-center border-dark border border-top-0 border-left-0 border-right-0" style="background-color: #3F4727; color: #DBC99D;">
                                        <strong style='font-family: <%# Eval("font") %>;'><%# Eval("question_heading_4") %></strong>
                                    </div>
                                </div>
                                <asp:ListView ID="questions_ListView" runat="server" DataKeyNames="id,critical" DataSourceID="questions_SqlDataSource">
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="p-2 text-right col-9 border-dark border border-top-0 border-right-0" style='font-family: <%# Eval("font") %>;'>
                                                <%# Eval("question") %>
                                            </div>
                                            <div class="col-1 border-dark border border-top-0  border-right-0">
                                                <div class="d-flex p-1 justify-content-between">
                                                    <div class="bd-highlight">
                                                        <asp:CheckBox ID="answer1bit" Style='font-family: <%# Eval("font") %>;' Visible='<%# Eval("answer1bit") %>' Text='<%# Eval("yes_button") %>' runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-1 border-dark border border-top-0  border-right-0">
                                                <div class="d-flex p-1 justify-content-between">
                                                    <div class="bd-highlight">
                                                        <asp:CheckBox ID="answer2bit" Style='font-family: <%# Eval("font") %>;' Visible='<%# Eval("answer2bit") %>' Text='<%# Eval("yes_button") %>' runat="server" />
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="col-1 border-dark border border-top-0">
                                                <div class="d-flex p-1 justify-content-between">
                                                    <div class="bd-highlight">
                                                        <asp:CheckBox ID="answer3bit" Style='font-family: <%# Eval("font") %>;' Visible='<%# Eval("answer3bit") %>' Text='<%# Eval("no_button") %>' runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                                <asp:SqlDataSource ID="questions_SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MarshFormsConnectionString %>" SelectCommand="SELECT q.*, f.yes_button, f.no_button, qt.answer1bit, qt.answer2bit, qt.answer3bit, l.font FROM questions q INNER JOIN question_headings qh ON q.question_heading_id = qh.id INNER JOIN question_type qt ON qt.id = qh.question_type_id INNER JOIN forms f ON f.id = qh.form_id INNER JOIN languages l ON l.id = f.language_id WHERE q.active = 1 and question_heading_id = @question_heading_id ORDER BY question_order">
                                    <SelectParameters>
                                        <asp:Parameter Name="question_heading_id" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </ItemTemplate>
                        </asp:ListView>
                        <asp:SqlDataSource ID="question_headings_SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MarshFormsConnectionString %>" SelectCommand="SELECT question_headings.id, question_headings.form_id, question_headings.question_heading, question_headings.question_heading_2, question_headings.question_heading_3, question_headings.question_heading_4, question_type.answer1bit, question_type.answer2bit, question_type.answer3bit, languages.font FROM question_headings INNER JOIN question_type ON question_headings.question_type_id = question_type.id left join forms on forms.id = question_headings.form_id left join languages on languages.id = forms.language_id WHERE form_id = @form_id">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="form_id_HiddenField" Name="form_id" PropertyName="Value" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                    <div class="row m-1 clearfix">
                        <div class="col-md-10">

                            <%--<p>If YES to any of the above, were there any symptoms that you cannot explain?</p>--%>
                        </div>
                        <div class="col-md-2">
                            <asp:ListView ID="no_to_all_ListView" runat="server" DataKeyNames="id" DataSourceID="forms_SqlDataSource">
                                <ItemTemplate>
                                    <div class="p-4">
                                        <asp:LinkButton ID="NoToAllLinkButton" CssClass="btn btn-block btn-outline-dark pull-right" OnClick="NoToAllLinkButton_Click" runat="server"><%# Eval("no_to_all_button") %></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-12">
                            <asp:ListView ID="form_notes_ListView" runat="server" DataKeyNames="id" DataSourceID="form_notes_SqlDataSource">
                                <ItemTemplate>
                                    <h6>
                                        <strong style='font-family: <%# Eval("font") %>;'><%# Eval("note") %></strong></h6>
                                </ItemTemplate>
                                <ItemSeparatorTemplate>
                                    <hr />
                                </ItemSeparatorTemplate>
                            </asp:ListView>
                            <asp:SqlDataSource ID="form_notes_SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MarshFormsConnectionString %>" SelectCommand="SELECT form_notes.*, languages.font FROM form_notes INNER JOIN forms ON form_notes.form_id = forms.id INNER JOIN languages ON languages.id = forms.language_id WHERE form_id = @form_id">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="form_id_HiddenField" Name="form_id" PropertyName="Value" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-12">
                            <p>Additional Comments</p>
                            <asp:TextBox ID="AdditionalCommentsTextBox" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12 p-lg-5">
                            <asp:ListView ID="submit_button_ListView" runat="server" DataKeyNames="id" DataSourceID="forms_SqlDataSource">
                                <ItemTemplate>
                                    <div class="p-4">
                                        <asp:LinkButton ID="SubmitLinkButton" CssClass="btn btn-block btn-outline-dark" OnClick="SubmitLinkButton_Click" runat="server"><%# Eval("submit_button") %> </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
