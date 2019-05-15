$(document).ready(function (){
    CKEDITOR.replace("noiDung");
    $("#selectImg").click(function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $("#txtImage").val(fileUrl);
        };
        finder.popup();
    });
});