<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="crucial_visitor_covid19_health_screening_questionnaire.aspx.cs" Inherits="COVID_Protocols.crucial_visitor_covid19_health_screening_questionnaire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .hide {
            width: 0;
            height: 0;
            border: white;
            color: white;
        }
    </style>
    <link href="Content/signature.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/signature_pad@2.3.2/dist/signature_pad.min.js"></script>
    <div class="container">
        <div class="row">
            <div class="col-12">
                <h2 class="text-center m-4">CRUCIAL VISITOR COVID-19 HEALTH SCREENING QUESTIONNAIRE </h2>
                <asp:Label ID="MessageLabel" ForeColor="Red" runat="server" />
            </div>
        </div>
        <p>The safety of our employees, supplier partners, customers, families and visitors remain Marsh’s priority. As COVID-19 continues to evolve, Marsh is monitoring the situation closely and will update company guidance as needed based on current recommendations from the Centers for Disease Control and our on-site medical professionals from Wake Forest Baptist Health. At this time, only business critical visitors are permitted at Marsh. </p>
        <p>To prevent the spread of COVID-19 and reduce the potential risk of exposure to our workforce and visitors, we are requiring that all visitors complete a health screening questionnaire. Your participation is important to help us take precautionary measures to protect the health and well-being of you and our employees. </p>
        <div class="row">
            <div class="col-md-6">
                <div class="form-label-group">
                    <asp:TextBox ID="visitor_name_textbox" MaxLength="100" CssClass="form-control" placeholder="Visitor's Name" autocomplete="off" runat="server" />
                    <label for="visitor_name_textbox">Visitor's Name</label>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-label-group">
                    <asp:TextBox ID="visitor_phone_textbox" MaxLength="100" CssClass="form-control" placeholder="Visitor's Phone Number" autocomplete="off" runat="server" />
                    <label for="visitor_phone_textbox">Visitor's Phone Number</label>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="form-label-group">
                    <asp:TextBox ID="visitor_company_textbox" MaxLength="100" CssClass="form-control" placeholder="Visitor's Company/Organization" autocomplete="off" runat="server" />
                    <label for="visitor_company_textbox">Visitor's Company/Organization </label>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-label-group">
                    <asp:TextBox ID="visitor_host_textbox" MaxLength="100" CssClass="form-control" placeholder="Name of Marsh Employee Host" autocomplete="off" runat="server" />
                    <label for="visitor_host_textbox">Name of Marsh Employee Host </label>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-label-group">
                    <asp:TextBox ID="visitor_purpose_textbox" MaxLength="255" CssClass="form-control" placeholder="Purpose of Visit" autocomplete="off" runat="server" />
                    <label for="visitor_purpose_textbox">Purpose of Visit</label>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="text-white text-center p-1" style="background: #876479;">
                    SELF DECLARATION BY VISITOR 
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="border border-dark" style="background-color: #F7F4E9;">
                    <div class="row m-2">
                        <div class="col-1 text-center">
                            1.
                        </div>
                        <div class="col-9">
                            Have you experienced any cold or flu-like symptoms in the last 14 days?<br />
                            <small>(to include fever, cough, sore throat, respiratory illness, difficulty breathing, loss of taste or smell)</small>
                        </div>
                        <div class="col-md-1">
                            <strong>
                                <asp:RadioButton ID="yes_rb_1" OnCheckedChanged="yes_rb_1_CheckedChanged" AutoPostBack="true" GroupName="one" Text="YES" runat="server" /></strong>
                        </div>
                        <div class="col-md-1">
                            <strong>
                                <asp:RadioButton ID="no_rb_1" OnCheckedChanged="no_rb_1_CheckedChanged" AutoPostBack="true" GroupName="one" Text="NO" runat="server" /></strong>
                        </div>
                    </div>
                    <div class="row m-2">
                        <div class="col-1 text-center">
                            2.
                        </div>
                        <div class="col-9">
                            Have you had close contact with or cared for someone diagnosed with COVID-19 within the last 14 days? 
                        </div>
                        <div class="col-md-1">
                            <strong>
                                <asp:RadioButton ID="yes_rb_2" OnCheckedChanged="yes_rb_2_CheckedChanged" AutoPostBack="true" GroupName="two" Text="YES" runat="server" /></strong>
                        </div>
                        <div class="col-md-1">
                            <strong>
                                <asp:RadioButton ID="no_rb_2" OnCheckedChanged="no_rb_2_CheckedChanged" AutoPostBack="true" GroupName="two" Text="NO" runat="server" /></strong>
                        </div>
                    </div>
                    <div class="row m-2">
                        <div class="col-1 text-center">
                            3.
                        </div>
                        <div class="col-9">
                            Have you been in close contact with anyone who has traveled internationally within the last 14 days?
                        </div>
                        <div class="col-md-1">
                            <strong>
                                <asp:RadioButton ID="yes_rb_3" OnCheckedChanged="yes_rb_3_CheckedChanged" AutoPostBack="true" GroupName="three" Text="YES" runat="server" /></strong>
                        </div>
                        <div class="col-md-1">
                            <strong>
                                <asp:RadioButton ID="no_rb_3" OnCheckedChanged="no_rb_3_CheckedChanged" AutoPostBack="true" GroupName="three" Text="NO" runat="server" /></strong>
                        </div>
                    </div>
                    <div class="row m-2">
                        <div class="col-1 text-center">
                            4.
                        </div>
                        <div class="col-9">
                            Temperature at time of visit? 
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="temperature_textbox" OnTextChanged="temperature_textbox_TextChanged" AutoPostBack="true" MaxLength="100" CssClass="form-control" autocomplete="off" runat="server" />
                        </div>
                    </div>
                    <p class="text-center"><strong>If the answer is “yes” to any of the questions, access to the facility will be denied.</strong></p>
                </div>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-12">
                <p>
                    Signature (visitor): 
                </p>
                <div class="wrapper">
                    <canvas id="signature_pad" runat="server" class="signature-pad"></canvas>
                </div>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-12">
                <p><strong>Note: If you plan to be on-site for consecutive days, please immediately advise your Marsh host if any of your responses change during your time with us. The information collected on this form will be used to determine your access to Marsh facilities.</strong></p>
                Access to Marsh facility
                <div class="btn-group btn-group-toggle mb-3" data-toggle="buttons">
                    <label class="btn btn-outline-success">
                        <asp:RadioButton ID="ApprovedRadioButton" Checked="true" Enabled="false" GroupName="option1" Text="Approved" runat="server" />
                    </label>
                    <label class="btn btn-outline-danger">
                        <asp:RadioButton ID="DeniedRadioButton" Enabled="false" GroupName="option1" Text="Denied" runat="server" />
                    </label>
                </div>
                <p><em>In response to any visitors violating our safety protocols, the Company may discontinue business with that visitor or, in its discretion, take a credit of up to 5% against future invoices as a means to deter future violations.</em></p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:TextBox ID="sigTextBox" CssClass="hide" runat="server"></asp:TextBox>
                <asp:LinkButton ID="SubmitLinkButton" OnClientClick="pull_data()" OnClick="SubmitLinkButton_Click" CssClass="btn btn-block btn-outline-dark mb-3" runat="server">Submit</asp:LinkButton>
            </div>
        </div>
    </div>
    <script src="Scripts/one_signature.js"></script>
</asp:Content>
