
$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "/Home/GetArticleViewModels",
        data: {
            page: $("#selectedPage").val()
        },
        success: function (msg) {
            $("#articleListResult").html(msg);
        }
    });
});


function showArticleDescription(articleId) {
    $.ajax({
        type: "POST",
        url: "/Home/GetArticleDescription",
        data: {
            articleId: articleId,
        },
        success: function (result) {

            var text = result;
            text += '<a href="#" onclick="reduceArticleDescription(' + articleId + ')"><strong><<</strong></a>';

            $("#" + articleId).html(text);

        }
    });
}

function reduceArticleDescription(articleId) {

    var text = document.getElementById(articleId).innerHTML;

    var test = text.substring(0, 100);
    test += '<a href="#" onclick="showArticleDescription(' + articleId + ')"><strong>...</strong></a>';

    $("#" + articleId).html(test);

}



$(document).ready(function () {
    $('table#articleListResult').DataTable(
    {
        bJQueryUI: true,
        sPaginationType: "full_numbers"
    });
});