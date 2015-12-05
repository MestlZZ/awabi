$(function () {
    var m;
    if ($ && $.browser && (m = (navigator.userAgent).match(/Edge\/(1[2-9]|[2-9]\d|\d{3,})\./))) {
        delete($.browser.mozilla);
        delete($.browser.msie);
        $.browser.edge = true;
        $.browser.version = m[1];
    }
    $(".editor-field").each(function (index) {
        this_input = $(".text-box")[index];
        $(this_input).attr("title", 'Значення від 0 до 5000');
        $(this_input).attr("data-toggle", "tooltip");
        if ($(window).width() > 500)
            $(this_input).attr("data-placement", "right");
    });
    $('[data-toggle="tooltip"]').tooltip();
    $(".editor-field").bind("DOMSubtreeModified", function (index) {
        var error_obj = $(this).children(".field-validation-error");
        if (error_obj.text()) {
            $(this).children(".text-box").attr("data-original-title", error_obj.text());
            if ($.browser.msie || $.browser.edge) error_obj.text("");
            else error_obj.hide();
        }
    });
    $("form").validate();
});