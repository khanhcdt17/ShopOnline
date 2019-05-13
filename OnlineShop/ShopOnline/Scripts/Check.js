$(document).ready(function () {

    //Khi bàn phím được nhấn và thả ra thì sẽ chạy phương thức này
    $("#formDemo").validate({
        rules: {
            userName: "required",
            passWord: "required"
            
        },
        messages: {
            userName: "Vui lòng nhập họ",
            passWord: "Vui lòng nhập tên"
           
        }
    });
});