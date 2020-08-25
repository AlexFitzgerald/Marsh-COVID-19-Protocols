<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Marsh_Temperature_Screening.Default" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <style>
        .stop-sign {
            background-image: url('http://intranet/MTS/Images/red_octagon.png');
            background-position: center;
            background-repeat: no-repeat;
            background-size: contain;
        }
    </style>
    <div class="container h-100">
        <div class="row align-items-center h-100">
            <div class="col-8 mx-auto">
                <div class="bg-light p-5 rounded display">
                    <%--<svg style="border:1px solid red"><polygon points="0,7.5 7.5,0 22.5,0 30,7.5 30,22.5 22.5,30 7.5,30 0,22.5" style="fill: #cc3333; stroke: white; stroke-width: 3px" /></svg>--%>

                    <div class="d-flex bd-highlight">
                        <div class="p-2 w-100 bd-highlight">
                            <p id="text_label" class="h1" />
                        </div>
                        <div class="p-2 flex-shrink-1 bd-highlight">
                            <div id="spinner" class="spinner-grow" role="status">
                            </div>
                        </div>
                    </div>
                    <p class="text-center" id="badge_id"></p>
                    <p class="h4" id="policy_text"></p>
                    <div class="progress">
                        <div class="progress-bar" id="progress_bar" aria-valuemin="0" aria-valuemax="100" style="width: 0%" />
                    </div>
                </div>
            </div>
        </div>

    </div>
    <script>
        //$('body').css('cursor', 'none');
        var scannable;

        var ob1;
        var amb;
        var dist;
        var mac;
        var badge_id;

        var lockout_time = 5; // TIME OUT IN MINUTES

        var fever_status_count;
        var temp_status = "";

        var return_value;

        var body = document.getElementById("body");
        var progress_bar = document.getElementById("progress_bar");
        var spinner = document.getElementById("spinner");

        function set_state(x) {
            switch (x) {
                case 1: 
                    $('#text_label').text("Waiting on badge scan.");
                    body.className = "bg-dark";
                    progress_bar.className = "progress-bar bg-secondary";
                    spinner.className = "spinner-grow";
                    policy_text.innerHTML = "";
                    scannable = 1;
                    break;
                case 2:
                    $('#text_label').text("Place your hand under the Sensor.");
                    body.className = "bg-secondary";
                    progress_bar.className = "progress-bar bg-secondary";
                    spinner.className = "";
                    policy_text.innerHTML = "";
                    scannable = 0;
                    break;
                case 3:
                    $('#text_label').text("Success!");
                    body.className = "bg-success";
                    progress_bar.className = "progress-bar bg-success";
                    spinner.className = "";
                    policy_text.innerHTML = "";
                    scannable = 0;
                    break;
                case 4:
                    $('#text_label').text("Your temperature may be high.");
                    body.className = "bg-warning";
                    progress_bar.className = "progress-bar bg-warning";
                    spinner.className = "";
                    policy_text.innerHTML = "Please wait 5 minutes before scanning again.";
                    scannable = 0;
                    break;
                case 5:
                    $('#text_label').text("Your temperature may be high.");
                    body.className = "bg-danger stop-sign";
                    progress_bar.className = "progress-bar bg-danger";
                    spinner.className = "";
                    policy_text.innerHTML = "Please report to your supervisor and provide a cell phone number where we can reach you. Once you have informed your supervisor, please wait in your car until further instruction.";
                    scannable = 0;
                    break;
                case 6:
                    $('#text_label').text("Error");
                    body.className = "bg-info";
                    progress_bar.className = "progress-bar bg-info";
                    spinner.className = "";
                    policy_text.innerHTML = "Station needs to be reset. Please restart.";
                    scannable = 0;
                    break;
                default:
                    break;
            }
        }

        $(document).ready(function () {
            set_state(1);
        });

        $(document).keypress(function (e) {
            if (e.which == 13 && scannable == 1) {//IF THE ENTER KEY IS PRESSED
             
                badge_id = document.getElementById("badge_id").innerHTML;   //SET BADGE
                document.getElementById("badge_id").innerHTML = "";         //CLEAR BADGE FROM SCREEN

                //IF BADGE IS LOCKED OUT THEN SHOW LOCK OUT SCREEN;
                get_fever_status_count(badge_id, "MINUTE", -1 * lockout_time);             //CHECK THE LAST 5 MINUTES
                if (fever_status_count > 0) {
                    //LOCK OUT - SHOW WARNING
                    var warning_time = 50;
                    set_state(4);
                    var warning_timer = setInterval(warning_screen, 250);
                    function warning_screen() {

                        if (warning_time >= 0) {

                            $("#progress_bar").css({ "width": warning_time * 2 + "%" });
                        }
                        else {
                            abort_warning_screen();
                        }
                        warning_time--;
                    }
                    function abort_warning_screen() {
                        clearInterval(warning_timer);
                        set_state(1);
                    }
                }
                else {

                    set_state(2);

                    var x = 20;
                    var listen_timer = setInterval(listen_for_badge, 500);
                    function listen_for_badge() {

                        $("#progress_bar").css({ "width": x * 5 + "%" });
                        get_pi_info();
                        if (x < 19) {

                            if (dist <= 5 && dist>0) {
                                write_to_db(mac, badge_id, ob1, amb, dist);
                                console.log(return_value);

                                if (return_value) {
                                    get_fever_status_count(badge_id, "DAY", -1);
                                    if (fever_status_count == 1) {
                                        //HOT TEMPERATURE //DISPLAY POLICY
                                        var warning_time = 50;
                                        set_state(4);
                                        var warning_timer = setInterval(warning_screen, 250);
                                        function warning_screen() {

                                            if (warning_time >= 0) {

                                                $("#progress_bar").css({ "width": warning_time * 2 + "%" });
                                            }
                                            else {
                                                abort_warning_screen();
                                            }
                                            warning_time--;
                                        }
                                        function abort_warning_screen() {
                                            clearInterval(warning_timer);
                                            set_state(1);
                                        }
                                    }
                                    else if (fever_status_count > 1) {
                                        //HOT TEMPERATURE //DISPLAY POLICY
                                        var policy_time = 50;
                                        set_state(5);
                                        var policy_timer = setInterval(success_screen, 250);
                                        function success_screen() {

                                            if (policy_time >= 0) {

                                                $("#progress_bar").css({ "width": policy_time * 2 + "%" });
                                            }
                                            else {
                                                abort_success_screen();
                                            }
                                            policy_time--;
                                        }
                                        function abort_success_screen() {
                                            clearInterval(policy_timer);
                                            set_state(1);
                                        }
                                    }
                                }
                                else if (return_value == false) {
                                    //GOOD TEMPERATURE
                                    var success_time = 5;
                                    set_state(3);
                                    var success_timer = setInterval(success_screen, 500);
                                    function success_screen() {

                                        if (success_time >= 0) {

                                            $("#progress_bar").css({ "width": success_time * 20 + "%" });
                                        }
                                        else {
                                            abort_success_screen();
                                        }
                                        success_time--;
                                    }
                                    function abort_success_screen() {
                                        clearInterval(success_timer);
                                        set_state(1);
                                    }
                                }
                                else {

                                }
                                abortTimer();
                            }
                        }
                        if (x == 0) {
                            abortTimer();
                            set_state(1);
                        }
                        x--;
                    }
                    function abortTimer() {
                        clearInterval(listen_timer);
                    }
                }
     
            } else if (scannable == 1) {
                $('#badge_id').append(e.key);
            }
        });

        function get_pi_info() {
            $.ajax({
                url: "http://localhost:8080",
                dataType: "json",
                success: function (response) {
                    ob1 = response['ob1'];
                    amb = response['amb'];
                    dist = response['dist'];
                    mac = response['mac'];
                    console.log(response);
                },
                error: function (xhr, status, error) {
                    set_state(6);
                    console.log("Error: could not connect to node.js");                    
                }
            });
            //ob1 = 200;
            //amb = 27;
            //dist = 3;
            //mac = 'b827eb915cba';
           // console.log(response);
        }

        function write_to_db(mac, badge_id, ob1, amb, dist) {
            mac = mac.replace(/:/g, "");
            $.ajax({
                type: "POST",
                async: false,
                url: "Default.aspx/WritePiInformation",
                data: "{ mac_address: '" + mac + "', badge_id: " + badge_id + ",object_temperature_c: " + ob1 + ",ambient_temperature_c: " + amb + ",distance_centimeters: " + dist + "}",
                beforeSend: function (jqXHR, Settings) { console.log(Settings.data); },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (rv) {
                    return_value = rv.d;
                    console.log("write_to_db : " + return_value);
                },
                error: function (e) {
                    console.log(e);
                }
            })
        }

        function get_fever_status_count(badge_id, interval, interval_value) {
            $.ajax({
                type: "POST",
                async: false,
                url: "Default.aspx/GetFeverStatusCount",
                data: "{  badge_id: " + badge_id + ", interval: '" + interval + "', interval_value: " + interval_value + "}",
                beforeSend: function (jqXHR, Settings) { console.log(Settings.data); },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (rv) {
                    fever_status_count = rv.d;
                    console.log("fever_status_count : " + fever_status_count);
                },
                error: function (e) {
                    console.log(e);
                }
            })
        }




    </script>
</asp:Content>
