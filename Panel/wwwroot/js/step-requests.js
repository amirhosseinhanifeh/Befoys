$(document).ready(function myfunction() {

    $(".next").click(function (e) {
        var form = "#step" + $(".tab-pane.active").attr("id").replace("tab2-", "");
        if ($(form).valid()) {
            if ($(form).attr("id") == "step1") {

                e.preventDefault();

                $.ajax({
                    url: "/Haghighi/Step1",
                    method: "POST",
                    data: getFormData($(form)),

                }).done(function (response) {
                    alert(response);
                });

            } else if ($(form).attr("id") == "step2") {

            } else if ($(form).attr("id") == "step3") {

            } else if ($(form).attr("id") == "step4") {

            } 
        }
    })

    function getFormData($form) {
        var unindexed_array = $form.serializeArray();
        var indexed_array = {};

        $.map(unindexed_array, function (n, i) {
            indexed_array[n['name']] = n['value'];
        });

        console.log(unindexed_array);

        return indexed_array;
    }

});