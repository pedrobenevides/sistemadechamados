$(function() {

    (function montarBreadCrumb() {
        var urlPathArray = window.location.pathname.split("/");
        var controller = urlPathArray[1];
        var action = urlPathArray[2];

        if (action === undefined)
            action = "Index";

        if (controller !== "Home" && controller !== "") {
            $('ol').append('<li><a href="/' + controller + '">' + controller + '</a></li>');
            $('ol').append('<li>' + action + '</li>');
        }
    })();
});