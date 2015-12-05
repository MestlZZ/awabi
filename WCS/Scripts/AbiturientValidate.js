$(function () {
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
            error_obj.css({ display: 'none' });
            $(this).children(".text-box").attr("data-original-title", error_obj.text());
        }
    });
    $("form").validate();
});