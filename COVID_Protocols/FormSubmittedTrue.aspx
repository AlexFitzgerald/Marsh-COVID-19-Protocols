<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormSubmittedTrue.aspx.cs" Inherits="COVID_Protocols.FormSubmittedTrue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="row">
        <div class="col-md-2">
        </div>
        <div class="col-md-8">
            <asp:HiddenField ID="guid_HiddenField" runat="server" />
            <div class="alert alert-danger" role="alert">
                <h4 class="alert-heading">Because you answered yes to one or more questions you must do one of the following:</h4>

                <ul>
                    <li>Leave the building quickly and go home immediately if this happens before 7:30am. Supervisors are asked to get the affected employee’s phone number before they leave and pass it along to HR for follow up. HR will have our Nurse Practitioner (NP) call the affected employee and decide into which protocol they will be placed.</li>
                    <li>If this happens at 7:30am or later, the supervisor will get the cell number of the affected employee and pass it along to HR. The affected employee will be asked to immediately go sit in their car. The NP will call them right away to decide into which protocol they will be placed. If they do not have a car, they will be asked to go sit in the sheltered bus stop on Centennial and wait for the NP to call. The NP will place them into the correct protocol.</li>
                </ul>
                <strong>Employees cannot return to work without clearance of the Wake Forest Baptist Hospital Nurse Practitioner.</strong>
                <hr />
                <p>Please enter your phone number below so that we can contact you.</p>
                <asp:TextBox ID="PhoneTextBox" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                <br />
                <asp:LinkButton ID="SubmitLinkButton" OnClick="SubmitLinkButton_Click" runat="server">Submit &raquo;</asp:LinkButton>
                <%--<asp:LinkButton ID="MarshFormsLinkButton" CssClass="btn btn-secondary" OnClick="MarshFormsLinkButton_Click" runat="server">Scan Another Badge? &raquo;</asp:LinkButton>--%>
            </div>
        </div>
        <div class="col-md-2">
        </div>
    </div>
</asp:Content>
