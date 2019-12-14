$(document).ready(function() {

    $("#addTelephone").click(function(){

        var addressNum = $(this).parent().parent().parent().parent().attr("id").replace("address", "");
        var telephoneNum = parseInt($(this).prev().find("input").attr("id").replace("telephone", "")) + 1;

        var input = $("<input/>").addClass("form-control mt-2 required").attr({
            type: "text",
            id: "telephone" + telephoneNum,
            name: "Addresses[" + (addressNum - 1) + "].phones[" + telephoneNum + "].PhoneValue"
        });

        var a = $("<a></a>").attr("href", "javascript:void(0)").attr("id", "removeTelephone").click(function () {
            $(this).parent().parent().remove();
        }).append(
            $("<i></i>").addClass("zmdi zmdi-delete zmdi-hc-fw")
        )

        $("<div></div>").addClass("row").append(
            $("<div></div>").addClass("col-md-12 d-flex telephone").append(input, a)
        ).insertBefore("#addTelephone");

    });

    $("#removeTelephone").click(function () {
        //$(this).parent().parent().remove();
    });

    $("#removeAddress").click(function () {
        //$(this).parent().parent().parent().remove();
    });

    $("#addAddress").click(function(){
        
        var addressNum = parseInt($(this).prev().attr("id").replace("address", "")) + 1;

        var heading = $("<div></div>").addClass("row").append(
            $("<div></div>").addClass("col-md-12 remove-address").append(
                $("<a></a>").attr("href", "javascript:void(0)").attr("id", "removeAddress").text("آدرس " + addressNum).click(function () {
                    $(this).parent().parent().parent().remove();
                }).prepend(
                    $("<i></i>").addClass("zmdi zmdi-delete zmdi-hc-fw")
                )
            )
        );

        var lblState = $("<label></label>").addClass("control-label").attr("for", "state").text("استان");
        var states = $("<select></select>").addClass("form-control select2 required").attr("name", "Addresses[" + (addressNum - 1) + "].StateName").append(
            $("<option></option>").attr("value", "Tehran").text("تهران")
        );

        var state = $("<div></div>").addClass("col-md-6").append(
            $("<div></div>").addClass("form-group").append(lblState).append(states)
        );

        var lblCity = $("<label></label>").addClass("control-label").attr("for", "city").text("شهر");
        var cities = $("<select></select>").addClass("form-control select2 required").attr("name", "Addresses[" + (addressNum - 1) + "].CityName").append(
            $("<option></option>").attr("value", "Tehran").text("تهران")
        );

        var city = $("<div></div>").addClass("col-md-6").append(
            $("<div></div>").addClass("form-group").append(lblCity).append(cities)
        );

        var firstRow = $("<div></div>").addClass("row").append(state).append(city);

        var lblAddress = $("<label></label>").addClass("control-label").attr("for", "address").text("آدرس");
        var txtAddress = $("<textarea></textarea>").addClass("form-control required").attr({
            id: "address",
            name: "Addresses[" + (addressNum - 1) + "].Address",
            rows: "3"
        });

        var secondRow = $("<div></div>").addClass("row").append(
            $("<div></div>").addClass("form-group col-md-12").append(lblAddress, txtAddress)
        );

        var rightPart = $("<div></div>").addClass("col-md-6").append(firstRow).append(secondRow);

        var lblTelephone = $("<label></label>").addClass("control-label").attr("for", "telephone1").text("تلفن ثابت");

        var inputTelephone = $("<input/>").addClass("form-control required").attr({
            type: "text",
            id: "telephone0",
            name: "Addresses[" + (addressNum - 1) +"].phones[0].PhoneValue"
        });
        var telephone = $("<div></div>").addClass("row").append(
            $("<div></div>").addClass("col-md-12 d-flex telephone").append(inputTelephone)
        );

        var addTelephone = $("<div></div>").addClass("add d-flex mt-3").attr("id", "addTelephone").append(
            $("<a></a>").attr("href", "javascript:void(0)").text(" افزودن تلفن ثابت").prepend(
                $("<i></i>").addClass("zmdi zmdi-plus zmdi-hc-fw")
            )
        ).click(function() {

            var telephoneNum = parseInt($(this).prev().find("input").attr("id").replace("telephone", "")) + 1;

            var input = $("<input/>").addClass("form-control mt-2 required").attr({
                type: "text",
                id: "telephone" + telephoneNum,
                name: "Addresses[" + (addressNum - 1) + "].phones[" + telephoneNum + "].PhoneValue"
            });

            var a = $("<a></a>").attr("href", "javascript:void(0)").attr("id", "removeTelephone").click(function () {
                $(this).parent().parent().remove();
            }).append(
                $("<i></i>").addClass("zmdi zmdi-delete zmdi-hc-fw")
            )

            $("<div></div>").addClass("row").append(
                $("<div></div>").addClass("col-md-12 d-flex telephone").append(input, a)
            ).insertBefore($(this));

        });

        var leftPart = $("<div></div>").addClass("col-md-6").append(
            $("<div></div>").addClass("form-group").append(lblTelephone).append(telephone).append(addTelephone)
        )

        var address = $("<div></div>").addClass("address").attr("id", "address" + addressNum).append(heading).append(
            $("<div></div>").addClass("row").append(rightPart).append(leftPart)
        );

        address.insertBefore("#addAddress");

        
        $(".select2").select2({
            theme: "bootstrap",
            language: "fa",
            dir: "rtl",
            minimumResultsForSearch: -1,
            placeholder: "انتخاب کنید",
        });
        
        $(".select2-search").select2({
            theme: "bootstrap",
            language: "fa",
            dir: "rtl",
            minimumResultsForSearch: 6,
            placeholder: "انتخاب کنید",
        });
    });

});