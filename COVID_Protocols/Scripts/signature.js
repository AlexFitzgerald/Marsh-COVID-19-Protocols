var canvas1 = document.getElementById('MainContent_signature_pad1');
var canvas2 = document.getElementById('MainContent_signature_pad2');

function resizecanvas1() {
    var ratio = Math.max(window.devicePixelRatio || 1, 1);
    canvas1.width = canvas1.offsetWidth * ratio;
    canvas1.height = canvas1.offsetHeight * ratio;
    canvas1.getContext("2d").scale(ratio, ratio);
}

function resizecanvas2() {
    var ratio = Math.max(window.devicePixelRatio || 1, 1);
    canvas2.width = canvas2.offsetWidth * ratio;
    canvas2.height = canvas2.offsetHeight * ratio;
    canvas2.getContext("2d").scale(ratio, ratio);
}

window.onresize = resizecanvas1;
resizecanvas1();

window.onresize = resizecanvas2;
resizecanvas2();

var signaturePad1 = new SignaturePad(canvas1, { backgroundColor: 'rgb(255, 255, 255)' });
var signaturePad2 = new SignaturePad(canvas2, { backgroundColor: 'rgb(255, 255, 255)' });

//document.getElementById('clear2').addEventListener('click', function () { signaturePad2.clear(); });


function pull_data() {
    if (!signaturePad1.isEmpty()) {
        document.getElementById('MainContent_sig1TextBox').value = signaturePad1.toDataURL();  
    }

    if (!signaturePad2.isEmpty()) {
        document.getElementById('MainContent_sig2TextBox').value = signaturePad2.toDataURL();
    }
}
