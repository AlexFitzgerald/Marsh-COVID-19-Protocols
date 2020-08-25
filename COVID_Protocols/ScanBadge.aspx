<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScanBadge.aspx.cs" Inherits="COVID_Protocols.ScanBadge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="d-flex justify-content-center flex-row bd-highlight m-5">
                    <div class="p-2 bd-highlight">
                        <div class="h1">Waiting on badge scan</div>
                    </div>
                    <div class="p-2 bd-highlight">
                        <div class="spinner-grow" style="width: 3.5rem; height: 3.5rem;">
                        </div>
                    </div>
                </div>
                <div class="d-flex justify-content-center flex-row bd-highlight m-5">
                    <div class="p-2 bd-highlight">
                        <div class="h3">
                            <asp:Label ID="BadgeLabel" class="text-center m-5" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="Scripts/jquery-3.5.1.js"></script>
    <script>
        $(document).keypress(function (e) {
            if (e.which == 13) {
                var badge = $("#MainContent_BadgeLabel").text();
                set_session(badge);

            } else {
                $('#MainContent_BadgeLabel').append(e.key);
            }
        });
        function set_session(badge) {
            $.ajax({
                type: "POST",
                url: "ScanBadge.aspx/set_session",
                data: "{'badge_id':'" + badge + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    redirect_forms();
                },
                error: function (err) {
                    var responseText = JSON.parse(err.responseText);
                    alert(err.responseText);
                }
            });
        }
        function redirect_forms() {
            var form = window.location.href.replace("ScanBadge.aspx", "") + "covid_workplace_health_screening.aspx";
            window.location.href = form;
        };
    </script>
</asp:Content>
