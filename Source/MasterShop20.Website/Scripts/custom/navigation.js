

$(document).on('load', function () {
    $.ajax({
        type: "POST",
        url: "/Home/GetGroupesFormMenu",
        success: function (msg) {
            $("#navigationContent").html(msg);
        }
    });
});


function toggleVisibilityUntergruppe(element) {
    var untergruppen = document.getElementById('unter_' + $(element).text());
    $(untergruppen).fadeToggle("slow");
};
