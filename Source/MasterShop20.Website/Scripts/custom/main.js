
$("#logo").on("click", function () {

    window.location = "/Home/Index";

});




function setUserId(idNutzer) {

    var hiddenfield = document.getElementById('currentUserId');
    hiddenfield.value = idNutzer;

}



function removeArticleFromCart(idArticle) {
    
    var userid = document.getElementById('currentUserId').val();

    $.ajax({
        type: "POST",
        url: "/Cart/RemoveArticleFromCart",
        data: {
            idNutzer: userid,
            articleId: articleId
        },
        success: function (result) {

            // if result == true -> article added else article can't be addeded

            // show notification

        }
    });
}