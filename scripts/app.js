/*$(function(){
    $("body").delay(500).fadeIn(1000);
    $(window).on('beforeunload', function(){
        $("body").fadeOut(1000);
    });
});*/

window.onresize = function() {
    document.body.height = window.innerHeight;
}

window.onresize();

function fadeIn(){
    $(".page-body").fadeIn(200);
}

function fadeOut(){
    $(".page-body").fadeOut(200);
}