$(document).ready(function myfunction() {

    $(".next").click(function (e) {
        var form = "#step" + $(".tab-pane.active").attr("id").replace("tab2-", "");
        if ($(form).valid()) {

            e.preventDefault();
            console.log($(form).serializeArray());

            $.ajax({
                url: "/Haghighi/" + $(form).attr("id"),
                method: "POST",
                data: $(form).serializeArray(),

            }).done(function (response) {
                console.log(response);
            });

        }
    })
});