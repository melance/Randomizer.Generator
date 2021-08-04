// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function CopyToClipboard(element) {
    var $temp = $('<input>');
    $("body").append($temp);
    $temp.val($(element).text()).select();
    document.execCommand("copy");
    $temp.remove();
}

function SwapClasses(element, class1, class2) {
    if ($(element).hasClass(class1)) {
        $(element).removeClass(class1);
        $(element).addClass(class2);
    }
    else {
        $(element).removeClass(class2);
        $(element).addClass(class1);
    }
}