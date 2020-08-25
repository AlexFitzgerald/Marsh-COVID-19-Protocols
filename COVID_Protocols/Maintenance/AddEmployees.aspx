<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmployees.aspx.cs" Inherits="COVID_Protocols.Maintenance.AddEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="payroll_id" DataSourceID="SqlDataSource1">
        <EmptyDataTemplate>
            <span>No data was returned.</span>
        </EmptyDataTemplate>
        <ItemTemplate>
            <div class="row">
                <div class="col-4">
                    Payroll ID:
        <%# Eval("payroll_id") %>
                    <br />
                    Name: <%# Eval("last_name") %>, <%# Eval("first_name") %> <%# Eval("middle_name") %>
                </div>
                <div class="col-4">
                    Badge #:<asp:TextBox ID="BadgeTextBox" runat="server"></asp:TextBox>
                </div>
                <div class="col-4">
                    <asp:LinkButton ID="SubmitLinkButton" OnClick="SubmitLinkButton_Click" CssClass="btn btn-success" runat="server">ADD</asp:LinkButton>
                </div>
            </div>
        </ItemTemplate>
        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>
        <LayoutTemplate>
            <div id="itemPlaceholderContainer" runat="server" style="">
                <span runat="server" id="itemPlaceholder" />
            </div>
        </LayoutTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MarshFormsConnectionString %>" SelectCommand="SELECT pe.id AS payroll_id, pe.lastName AS last_name, pe.firstName AS first_name, pe.middleName AS middle_name, pe.nickname AS nick_name FROM view_payroll_employees AS pe LEFT OUTER JOIN employees AS e ON pe.id = e.payroll_id WHERE (e.id IS NULL) ORDER BY last_name,first_name"></asp:SqlDataSource>
</asp:Content>
