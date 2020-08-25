<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="COVID_Protocols.Maintenance.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <asp:Label ID="MessageLabel" runat="server" ForeColor="Red"/>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-8">
                <asp:ListView ID="UserListView" runat="server" DataKeyNames="email" DataSourceID="UserSqlDataSource">
                    <EditItemTemplate>
                        <div class="border shadow-sm p-3 m-3 rounded">
                            <div class="text-white border-bottom mb-3">
                                <div class="d-flex justify-content-between">
                                    <div class="d-flex p-2 bd-highlight">
                                        <asp:LinkButton ID="UpdateLinkButton" OnClick="UpdateLinkButton_Click" runat="server"><i class="fa fa-2x fa-floppy-o text-success"></i></asp:LinkButton>
                                    </div>
                                    <div class="d-flex p-2 bd-highlight">
                                        <asp:Label ID="emailLabel" class="form-control-plaintext" runat="server" Text='<%# Eval("email") %>' />
                                    </div>
                                    <div class="d-flex p-2 bd-highlight">
                                        <asp:LinkButton ID="CancelLinkButton" CommandName="Cancel" runat="server"><i class="fa fa-2x fa-undo"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="passwordTextBox" class="col-sm-4 col-form-label">Password</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="passwordTextBox" CssClass="form-control" runat="server" Text='<%# Bind("password") %>' />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="reportsCheckBox" class="col-sm-4 col-form-label">Report Access</label>
                                <div class="col-sm-8">
                                    <asp:CheckBox ID="reportsCheckBox" runat="server" Checked='<%# Bind("reports") %>' />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="maintenanceCheckBox" class="col-sm-4 col-form-label">Maintenance Access</label>
                                <div class="col-sm-8">
                                    <asp:CheckBox ID="maintenanceCheckBox" runat="server" Checked='<%# Bind("maintenance") %>' />
                                </div>
                            </div>
                        </div>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <span>No data was returned.</span>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <div class="border shadow-sm p-3 m-3 rounded">
                            <div class="text-white border-bottom mb-3">
                                <div class="d-flex justify-content-between">
                                    <div class="d-flex p-2 bd-highlight">
                                        <asp:LinkButton ID="EditLinkButton" CommandName="Edit" runat="server"><i class="fa fa-2x fa-pencil"></i></asp:LinkButton>
                                    </div>
                                    <div class="d-flex p-2 bd-highlight">
                                        <asp:Label ID="emailLabel" class="form-control-plaintext" runat="server" Text='<%# Eval("email") %>' />
                                    </div>
                                    <div class="d-flex p-2 bd-highlight">
                                        <asp:LinkButton ID="DeleteLinkButton" OnClientClick="return confirm('Are you sure you want to delete this email?')" OnClick="DeleteLinkButton_Click" runat="server"><i class="fa fa-2x fa-trash text-danger"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="reportsCheckBox" class="col-sm-4 col-form-label">Report Access</label>
                                <div class="col-sm-8">
                                    <asp:CheckBox ID="reportsCheckBox" runat="server" Checked='<%# Eval("reports") %>' Enabled="false" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="maintenanceCheckBox" class="col-sm-4 col-form-label">Maintenance Access</label>
                                <div class="col-sm-8">
                                    <asp:CheckBox ID="maintenanceCheckBox" runat="server" Checked='<%# Eval("maintenance") %>' Enabled="false" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <div id="itemPlaceholderContainer" runat="server" style="">
                            <div runat="server" id="itemPlaceholder" />
                        </div>
                    </LayoutTemplate>
                </asp:ListView>
                <asp:SqlDataSource ID="UserSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MarshFormsConnectionString %>" SelectCommand="SELECT * FROM [users]"></asp:SqlDataSource>
            </div>
            <div class="col-lg-4">
                <div class="border shadow-sm p-3 m-3 rounded">
                    <div class="form-label-group">
                        <asp:TextBox ID="AddEmailTextBox" TextMode="Email" class="form-control" placeholder="Email address" runat="server"></asp:TextBox>
                        <label for="AddEmailTextBox">Email address</label>
                    </div>
                    <div class="form-label-group">
                        <asp:TextBox ID="AddPasswordTextBox" TextMode="Password" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                        <label for="AddPasswordTextBox">Password</label>
                    </div>
                    <label class="small text-muted">Leave password blank to use windows password for Marsh email addresses.</label>
                    <asp:CheckBox ID="ReportsCheckBox" Text="Report Access" runat="server" />
                    <br />
                    <asp:CheckBox ID="MaintenanceCheckBox" Text="Maintenance Access" runat="server" />

                    <asp:LinkButton ID="AddUserLinkButton" CssClass="btn btn-success btn-block" OnClick="AddUserLinkButton_Click" runat="server">Add User</asp:LinkButton>

                </div>
            </div>
        </div>



    </div>
</asp:Content>
