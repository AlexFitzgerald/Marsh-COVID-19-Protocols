<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"   AutoEventWireup="true" CodeBehind="home_entry_authorization_occupied_homes.aspx.cs" Inherits="COVID_Protocols.home_entry_authorization_occupied_homes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <style>
        .hide{
            width:0;
            height:0;
            border:white;
            color:white;
        }
    </style>

    <link href="Content/signature.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/signature_pad@2.3.2/dist/signature_pad.min.js"></script>
    <div class="container">
        <div class="row">
            <div class="col-12">
                <h2 class="text-center m-4">HOME ENTRY AUTHORIZATION: OCCUPIED HOMES</h2>
                <asp:Label ID="MessageLabel" ForeColor="Red" runat="server" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-12">
                <p>In response to COVID-19, Marsh Furniture Company and Marsh Kitchen & Bath (“Marsh”) have implemented new procedures for installing cabinets in your home. These procedures are designed to minimize the spread of the virus.</p>
                <p>First, Marsh team members may not come to work or enter a customer’s home if they are experiencing any COVID-19 symptoms. To the best of our knowledge no team member entering your home has a confirmed case of COVID-19. We also conduct daily checks to confirm that no team member is exhibiting symptoms or has recently been exposed to anyone with COVID-19 symptoms. Upon entry into your home, our team members will try to maintain a 6’ distance from you and your family, will wear a mask, gloves and shoe covers.</p>
                <p>Second, before coming into your home, we likewise ask about the health of your family to ensure that we are doing our best to protect the health of our team members. We will not schedule a visit or complete an installation or service if the customer or someone in the household is experiencing any COVID-19 related symptoms.</p>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <div style="background-color: #F0E8D3" class="p-3 mt-3 mb-3">
                    <p><strong>PLEASE ANSWER THE QUESTIONS BELOW</strong></p>
                    <div class="form-label-group">
                        <asp:TextBox ID="customer_name_textbox" CssClass="form-control" placeholder="Customer Name" autocomplete="off" runat="server"></asp:TextBox>
                        <label for="customer_name_textbox">Customer Name</label>
                    </div>
                    <div class="form-label-group">
                        <asp:TextBox ID="customer_address_textbox" CssClass="form-control" placeholder="Customer Address" autocomplete="off" runat="server"></asp:TextBox>
                        <label for="customer_address_textbox">Customer Address</label>
                    </div>
                    <div class="row">
                        <div class="col-10">
                            <p><strong>Is anyone in the home under quarantine or self-isolation due to COVID-19?</strong></p>
                        </div>
                        <div class="col-md-1">
                            <strong>
                                <asp:RadioButton ID="yes_rb_1" GroupName="one" Text="YES" runat="server" /></strong>
                        </div>
                        <div class="col-md-1">
                            <strong>
                                <asp:RadioButton ID="no_rb_1" GroupName="one" Text="NO" runat="server" />
                            </strong>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-10">
                            <p><strong>Has anyone living in the home had a confirmed case of COVID-19?</strong></p>
                        </div>
                        <div class="col-md-1">
                            <strong>
                                <asp:RadioButton ID="yes_rb_2" GroupName="two" Text="YES" runat="server" /></strong>
                        </div>
                        <div class="col-md-1">
                            <strong>
                                <asp:RadioButton ID="no_rb_2" GroupName="two" Text="NO" runat="server" />
                            </strong>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-9">
                            <p>If YES, what was the date of diagnosis? </p>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="DiagnosisDateTextBox" CssClass="form-control" TextMode="Date" autocomplete="off" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-10">
                            <p>If YES, has the case been resolved?</p>
                        </div>
                        <div class="col-md-1">
                            <asp:RadioButton ID="yes_rb_3" GroupName="three" Text="YES" runat="server" />
                        </div>
                        <div class="col-md-1">
                            <asp:RadioButton ID="no_rb_3" GroupName="three" Text="NO" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-10">
                            <p><strong>Is there anyone in the home that currently has, or in the past 14 days had, COVID-19 symptoms?</strong> <small><em>(Fever, dry cough, breathing difficulty, loss of taste or smell, etc.)</em></small></p>
                        </div>
                        <div class="col-md-1">
                            <strong>
                                <asp:RadioButton ID="yes_rb_4" GroupName="four" Text="YES" runat="server" /></strong>
                        </div>
                        <div class="col-md-1">
                            <strong>
                                <asp:RadioButton ID="no_rb_4" GroupName="four" Text="NO" runat="server" />
                            </strong>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <p>
                    <em>If you answer YES to any of the <strong>bolded</strong> questions, we will reschedule your installation at a later date. Further, by signing this authorization you: 1) certify to Marsh that the information you have provided is accurate, and 2) you authorize Marsh team members to enter your home with the knowledge that an inherent risk of exposure to COVID-19 exists and that you assume all risks related to exposure and agree not to hold Marsh, or any of its directors, officers, employees, agents, or contractors liable for possible exposure or illness.</em>
                </p>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6">
                <p>Customer Signature </p>
                <div class="wrapper">
                    <canvas id="signature_pad1" runat="server" class="signature-pad"></canvas>
                </div>
                <%--<button id="clear1" onclick="signaturePad1.clear()">Clear</button>--%>
            </div>
            <div class="col-lg-6">
                <p>Marsh Kitchen & Bath Representative</p>
                <div class="wrapper">
                    <canvas id="signature_pad2" runat="server" class="signature-pad"></canvas>
                </div>
                <%--<button id="clear2" onclick="signaturePad2.clear()">Clear</button>--%>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-12">
                <asp:TextBox ID="sig1TextBox" CssClass="hide" runat="server"></asp:TextBox>
                <asp:TextBox ID="sig2TextBox" CssClass="hide" runat="server"></asp:TextBox>
                <asp:LinkButton ID="SubmitLinkButton" CssClass="btn btn-block btn-outline-dark" OnClientClick="pull_data()" OnClick="SubmitLinkButton_Click" runat="server">Submit</asp:LinkButton>
            </div>
        </div>
        <br />
    </div>
    <script src="Scripts/signature.js"></script>
    <%--<script src="Scripts/signature2.js"></script>--%>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
