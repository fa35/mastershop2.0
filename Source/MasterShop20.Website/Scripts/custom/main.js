
$("#logo").on("click", function () {

    window.location = "/Home/Index";

});


function removeArticleFromCart(idArticle) {
    
    var userid = document.getElementById('currentUserId').val();

    $.ajax({
        type: "POST",
        url: "/Cart/RemoveArticleFromCart",
        data: {
            articleId: articleId
        },
        success: function (result) {

            // if result == true -> article added else article can't be addeded

            // show notification

        }
    });
}