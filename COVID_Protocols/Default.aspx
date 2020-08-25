<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="COVID_Protocols._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12 m-0 p-0">
                <div class="jumbotron jumbotron-fluid p-3 p-md-5 mt-3  marsh-jumbo rounded ">
                    <div class="col-md-12 px-0">
                        <div class="row m-0 p-0">
                            <div class="col-lg-4 m-0 p-0">
                                <img src="Images/marsh_logo_tan.png" style="width: 100%;" />
                            </div>
                            <div class="col-lg-8 m-0 pl-4">
                                <h1 class="">COVID Protocols</h1>
                                <h4 class="display-9 ">What to do if ...</h4>
                                <%--<p class="lead my-3">Get all your COVID Protocol answers here.</p>--%>
                                <p class="lead mb-0"><a class="text-white font-weight-bold" href="Documentation/Marsh_COVID-19_Protocols.pdf">View the PDF &raquo;</a></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 ">
                <div class="row  border rounded  mb-4 shadow-sm ">
                    <div class="col p-4 ">
                        <h4 class="mb-0">CORONAVIRUS (COVID-19) WORKPLACE HEALTH SCREENING</h4>
                        <br />
                        <asp:LinkButton ID="HeathScreenLinkButton" OnClick="HeathScreenLinkButton_Click" class="text-dark font-weight-bold" runat="server">Take the survey online &raquo;</asp:LinkButton>
                        <hr />
                        <asp:LinkButton ID="TabletHeathScreenLinkButton" OnClick="TabletHeathScreenLinkButton_Click" class="text-dark font-weight-bold" runat="server">Conduct this survey on a tablet &raquo;</asp:LinkButton>
                    </div>

                    <svg class="bd-placeholder-img" width="100" height="295" xmlns="http://www.w3.org/2000/svg" preserveAspectRatio="xMidYMid slice" focusable="false" role="img" aria-label="Placeholder: Thumbnail">
                        <title>Placeholder</title>
                        <rect width="100%" height="100%" fill="#f0e8d3" />
                    </svg>
                </div>
            </div>
            <div class="col-md-6 ">
                <div class="row  border rounded  mb-4 shadow-sm ">
                    <div class="col p-4 ">
                        <h4 class="mb-0">CRUCIAL VISITOR COVID-19 HEALTH SCREENING QUESTIONNAIRE</h4>
                        <br />
                        <p class="mb-auto"></p>
                        <a class="text-dark  font-weight-bold" href="crucial_visitor_covid19_health_screening_questionnaire.aspx">Conduct with a visitor online &raquo;</a>
                    </div>

                    <svg class="bd-placeholder-img" width="100" height="295" xmlns="http://www.w3.org/2000/svg" preserveAspectRatio="xMidYMid slice" focusable="false" role="img" aria-label="Placeholder: Thumbnail">
                        <title>Placeholder</title>
                        <rect width="100%" height="100%" fill="#876479" />
                    </svg>

                </div>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-md-6 ">
                <div class="row  border rounded  mb-4 shadow-sm ">
                    <div class="col p-4 ">
                        <h4 class="mb-0">HOME ENTRY AUTHORIZATION: OCCUPIED HOMES</h4>
                        <br />
                        <p class="mb-auto"></p>
                        <a class="text-dark font-weight-bold" href="home_entry_authorization_occupied_homes.aspx">Conduct with the homeowner online &raquo;</a>
                    </div>

                    <svg class="bd-placeholder-img" width="100" height="295" xmlns="http://www.w3.org/2000/svg" preserveAspectRatio="xMidYMid slice" focusable="false" role="img" aria-label="Placeholder: Thumbnail">
                        <title>Placeholder</title>
                        <rect width="100%" height="100%" fill="#f0e8d3" />
                    </svg>

                </div>
            </div>
            <div class="col-md-6 ">
            </div>
        </div>
    </div>
    </div>
</asp:Content>
