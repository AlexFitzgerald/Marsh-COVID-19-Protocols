<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormSubmitted.aspx.cs" Inherits="COVID_Protocols.FormSubmitted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <script>


        window.setTimeout(function () {
            var tablet_mode = '<%= HttpContext.Current.Session["tablet_mode"].ToString() %>';
            //alert(tablet_mode);
            if (tablet_mode == "1") {
                window.location.href = 'ScanBadge.aspx';
            } else {
                window.location.href = 'Default.aspx';
            }
            //alert(someSession);
        }, 4000);

 

    </script>
    <div class="row">
        <div class="col-md-2">
        </div>
        <div class="col-md-8">
            <div class="alert alert-success" role="alert">
                <h4 class="alert-heading">Your form was submitted successfully.</h4>
            </div>
        </div>
        <div class="col-md-2">
        </div>
    </div>
</asp:Content>
