<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="COVID_Protocols.Reports" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bg-white">
        <div class="row">
            <div class="col-md-4">
                <asp:DropDownList ID="ReportDropDownList" CssClass="form-control" runat="server" DataSourceID="ReportListDataSource" DataTextField="Name" DataValueField="Path" AutoPostBack="True">
                </asp:DropDownList>
                <asp:SqlDataSource ID="ReportListDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ReportServerConnectionString %>" SelectCommand="SELECT '' AS Path, 'Select' AS Name UNION ALL SELECT C.Path, C.Name FROM ReportServer.dbo.Catalog AS C WHERE C.Type NOT IN(1, 5, 3) AND C.Path LIKE '/MarshFormsReports/%' ORDER BY Path, Name"></asp:SqlDataSource>
            </div>
            <div class="col-md-8">
                <asp:Label ID="ReportErrorLabel" runat="server"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <rsweb:reportviewer id="FTReportViewer" runat="server" processingmode="Remote" style="width: 100%" showbackbutton="True" showcredentialprompts="False" showdocumentmapbutton="False" showfindcontrols="False" showpromptareabutton="False" showrefreshbutton="False" showzoomcontrol="False" sizetoreportcontent="True" onreportrefresh="FTReportViewer_ReportRefresh">
                    <ServerReport ReportServerUrl="http://marshsql5/reportserver" />
                </rsweb:reportviewer>
            </div>
        </div>
    </div>

</asp:Content>
