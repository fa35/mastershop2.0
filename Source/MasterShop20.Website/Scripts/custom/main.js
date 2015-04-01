
$("#logo").on("click", function () {

    window.location = "/Home/Index";

});


function removeArticleFromCart(idArticle) {
    
    $.ajax({
        type: "POST",
        url: "/Cart/RemoveArticleFromCart",
        data: {
            articleId: articleId
        },
        success: function () {
            // show notification
        }
    });
}