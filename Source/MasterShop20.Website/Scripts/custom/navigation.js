

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

function showArticles(element) {
    var unter = $(element).text();
    window.location = "/Home/GetArticleViewModels?page=0&amount=10&subgroup=" + unter;
    /*
    $.ajax({
        type: "POST",
        url: "/Home/GetArticleViewModels",
        data: {
            page: 0,
            amount: 10,
            subgroup: unter
        },
        success: function (result) {

            // foo

        }
    });*/

}