<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signature.aspx.cs" Inherits="COVID_Protocols.signature" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/signature.css" rel="stylesheet" />
</head>
<body>
   <script src="https://cdn.jsdelivr.net/npm/signature_pad@2.3.2/dist/signature_pad.min.js"></script>
    <div class="wrapper">
        <canvas id="signature-pad" class="signature-pad" width="800" height="200"></canvas>
    </div>

    <button id="save-png">Save as PNG</button>
    <button id="save-jpeg">Save as JPEG</button>
    <button id="save-svg">Save as SVG</button>
    <button id="undo">Undo</button>
    <button id="clear">Clear</button>

</body>
<script src="Scripts/signature.js"></script>
</html>
