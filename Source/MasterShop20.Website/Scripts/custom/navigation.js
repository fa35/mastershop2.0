

$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "/Home/GetNavigationGroups",
        success: function (msg) {
            $("#navigationContent").html(msg);
        }
    });
});


function toggleVisibilityUntergruppe(element) {
    var $untergruppen = jQuery('#unter_' + $(element).text());
    $untergruppen.fadeToggle("slow");
}
