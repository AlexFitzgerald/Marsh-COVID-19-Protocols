<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="home_entry_symptomatic.aspx.cs" Inherits="COVID_Protocols.home_entry_symptomatic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-2">
        </div>
        <div class="col-md-8">
            <div class="alert alert-danger" role="alert">
                <h4 class="alert-heading">Because you answered yes to one or more questions.</h4>
                <strong>Please reschedule your appointment with a Marsh representative.</strong>
            </div>
        </div>
        <div class="col-md-2">
        </div>
    </div>
</asp:Content>
