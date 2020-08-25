var canvas = document.getElementById('MainContent_signature_pad');

function resizecanvas() {
    var ratio = Math.max(window.devicePixelRatio || 1, 1);
    canvas.width = canvas.offsetWidth * ratio;
    canvas.height = canvas.offsetHeight * ratio;
    canvas.getContext("2d").scale(ratio, ratio);
}



window.onresize = resizecanvas;
resizecanvas();


var signaturePad = new SignaturePad(canvas, { backgroundColor: 'rgb(255, 255, 255)' });




function pull_data() {
    if (!signaturePad.isEmpty()) {
        document.getElementById('MainContent_sigTextBox').value = signaturePad.toDataURL();
    }

}
