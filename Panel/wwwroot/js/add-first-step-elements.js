$(document).ready(function() {

    $("#addTelephone").click(function(){

        var telephoneNum = parseInt($(this).prev().attr("id").replace("telephone", "")) + 1;

        $("<input/>").addClass("form-control mt-2 required").attr({
            type: "text",
            id: "telephone" + telephoneNum,
            name: "telephone" + telephoneNum
        }).insertBefore("#addTelephone");

    });

    $("#addAddress").click(function(){
        
        var addressNum = parseInt($(this).prev().attr("id").replace("address", "")) + 1;

        var lblState = $("<label></label>").addClass("control-label").attr("for", "state").text("استان");
        var states = $("<select></select>").addClass("form-control select2 required").attr("name", "state").append(
            $("<option></option>").attr("value", "Tehran").text("تهران")
        );

        var state = $("<div></div>").addClass("col-md-6").append(
            $("<div></div>").addClass("form-group").append(lblState).append(states)
        );

        var lblCity = $("<label></label>").addClass("control-label").attr("for", "city").text("شهر");
        var cities = $("<select></select>").addClass("form-control select2 required").attr("name", "city").append(
            $("<option></option>").attr("value", "Tehran").text("تهران")
        );

        var city = $("<div></div>").addClass("col-md-6").append(
            $("<div></div>").addClass("form-group").append(lblCity).append(cities)
        );

        var firstRow = $("<div></div>").addClass("row").append(state).append(city);

        var lblAddress = $("<label></label>").addClass("control-label").attr("for", "address").text("آدرس");
        var txtAddress = $("<textarea></textarea>").addClass("form-control required").attr({
            id: "address",
            name: "address",
            rows: "3"
        });

        var secondRow = $("<div></div>").addClass("row").append(
            $("<div></div>").addClass("form-group col-md-12").append(lblAddress, txtAddress)
        );

        var rightPart = $("<div></div>").addClass("col-md-6").append(firstRow).append(secondRow);

        var lblTelephone = $("<label></label>").addClass("control-label").attr("for", "telephone1").text("تلفن ثابت");
        var inputTelephone = $("<input/>").addClass("form-control required").attr({
            type: "text",
            id: "telephone1",
            name: "telephone1"
        });
        var addTelephone = $("<div></div>").addClass("add d-flex mt-3").attr("id", "addTelephone").append(
            $("<a></a>").attr("href", "javascript:void(0)").text(" افزودن تلفن ثابت").prepend(
                $("<i></i>").addClass("zmdi zmdi-plus zmdi-hc-fw")
            )
        ).click(function() {
            
            var telephoneNum = parseInt($(this).prev().attr("id").replace("telephone", "")) + 1;

            $("<input/>").addClass("form-control mt-2 required").attr({
                type: "text",
                id: "telephone" + telephoneNum,
                name: "telephone" + telephoneNum
            }).insertBefore($(this));

        });

        var leftPart = $("<div></div>").addClass("col-md-6").append(
            $("<div></div>").addClass("form-group").append(lblTelephone).append(inputTelephone).append(addTelephone)
        )

        var address = $("<div></div>").addClass("address").attr("id", "address" + addressNum).append(
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