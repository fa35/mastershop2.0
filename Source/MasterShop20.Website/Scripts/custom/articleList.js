
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


function nextPage(page) {

    // diese Funktion soll nur die Funktionalität testen und ist nicht dauerhaft geplant
    
    $.ajax({
        type: "POST",
        url: "/Home/GetArticleViewModels",
        data: {
            page: page,
        },
        success: function (msg) {
            $("#articleListResult").html(msg);
        }
    });
}

function getArticleViewModelsByGroup(subgroupname) {
    $.ajax({
        type: "POST",
        url: "/Home/GetArticleViewModels",
        data: {
            page: $("#selectedPage").val(),
            subgroupName: $(subgroupname).text()
        },
        success: function (msg) {
            $("#articleListResult").html(msg);
        }
    });
}

function addArticleToCart(articleId) {

    $.ajax({
        type: "POST",
        url: "/Cart/AddArticleToCart",
        data: {
            articleId: articleId
        },
        success: function () {
            // show notification
        }
    });

}


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
