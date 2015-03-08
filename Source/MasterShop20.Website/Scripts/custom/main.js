
$("#logo").on("click", function () {

    window.location = "/Home/Index";

});




function setUserId(idNutzer) {

    var hiddenfield = document.getElementById('currentUserId');
    hiddenfield.value = idNutzer;

}