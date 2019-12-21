$(document).ready(function myfunction() {

    $("#addTelephone").click(function () {

        var addressNum = parseInt($(this).parent().parent().parent().parent().attr("id").replace("address", "")) - 1;
        var telephoneNum = parseInt($(this).prev().find("input").attr("id").replace("telephone" + addressNum + "_", "")) + 1;

        var input = $("<input/>").addClass("form-control mt-2 required").attr({
            type: "text",
            id: "telephone" + addressNum + "_" + telephoneNum,
            name: "Addresses[" + addressNum + "].phones[" + telephoneNum + "].PhoneValue"
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

    $("#addAddress").click(function () {

        var addressNum = parseInt($(this).prev().attr("id").replace("address", ""));

        var heading = $("<div></div>").addClass("row").append(
            $("<div></div>").addClass("col-md-12 remove-address").append(
                $("<a></a>").attr("href", "javascript:void(0)").attr("id", "removeAddress").text("آدرس " + (addressNum + 1)).click(function () {
                    $(this).parent().parent().parent().remove();
                }).prepend(
                    $("<i></i>").addClass("zmdi zmdi-delete zmdi-hc-fw")
                )
            )
        );

        var lblState = $("<label></label>").addClass("control-label").attr("for", "state" + addressNum).text("استان");
        var states = $("<select></select>").addClass("form-control select2 required").attr("id", "state" + addressNum).attr("name", "Addresses[" + addressNum + "].StateName").append(
            $("<option></option>").attr("value", "Tehran").text("تهران")
        );

        var state = $("<div></div>").addClass("col-md-6").append(
            $("<div></div>").addClass("form-group").append(lblState).append(states)
        );

        var lblCity = $("<label></label>").addClass("control-label").attr("for", "city" + addressNum).text("شهر");
        var cities = $("<select></select>").addClass("form-control select2 required").attr("id", "city" + addressNum).attr("name", "Addresses[" + addressNum + "].CityName").append(
            $("<option></option>").attr("value", "Tehran").text("تهران")
        );

        var city = $("<div></div>").addClass("col-md-6").append(
            $("<div></div>").addClass("form-group").append(lblCity).append(cities)
        );

        var firstRow = $("<div></div>").addClass("row").append(state).append(city);

        var lblAddress = $("<label></label>").addClass("control-label").attr("for", "address" + addressNum).text("آدرس");
        var txtAddress = $("<textarea></textarea>").addClass("form-control required").attr({
            id: "address" + addressNum,
            name: "Addresses[" + addressNum + "].Address",
            rows: "3"
        });

        var secondRow = $("<div></div>").addClass("row").append(
            $("<div></div>").addClass("form-group col-md-12").append(lblAddress, txtAddress)
        );

        var rightPart = $("<div></div>").addClass("col-md-6").append(firstRow).append(secondRow);

        var lblTelephone = $("<label></label>").addClass("control-label").attr("for", "telephone" + addressNum + "_0").text("تلفن ثابت");

        var inputTelephone = $("<input/>").addClass("form-control required").attr({
            type: "text",
            id: "telephone" + addressNum + "_0",
            name: "Addresses[" + addressNum + "].phones[0].PhoneValue"
        });
        var telephone = $("<div></div>").addClass("row").append(
            $("<div></div>").addClass("col-md-12 d-flex telephone").append(inputTelephone)
        );

        var addTelephone = $("<div></div>").addClass("add d-flex mt-3").attr("id", "addTelephone").append(
            $("<a></a>").attr("href", "javascript:void(0)").text(" افزودن تلفن ثابت").prepend(
                $("<i></i>").addClass("zmdi zmdi-plus zmdi-hc-fw")
            )
        ).click(function () {
            var telephoneNum = parseInt($(this).prev().find("input").attr("id").replace("telephone" + addressNum + "_", "")) + 1;

            var input = $("<input/>").addClass("form-control mt-2 required").attr({
                type: "text",
                id: "telephone" + addressNum + "_" + telephoneNum,
                name: "Addresses[" + addressNum + "].phones[" + telephoneNum + "].PhoneValue"
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

        var address = $("<div></div>").addClass("address").attr("id", "address" + (addressNum + 1)).append(heading).append(
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

    $("#ValueAddedCertificate").change(function (e) {
        if ($(this).is(":checked")) {

            var lbl2 = $("<label></label>").addClass("custom-file-label").attr("for", "ValueAddedScan").text("آپلود فایل");
            var input = $("<input/>").attr("type", "file").addClass("custom-file-input required").attr("id", "ValueAddedScan").attr("name", "ValueAddedScan").change(function () {
                if ($(this)[0].files.length > 0) {
                    $(this).prev().text($(this)[0].files[0].name);
                } else {
                    $(this).prev().text("آپلود فایل");
                }
            });

            var lbl = $("<label></label>").addClass("col-md-6 control-label").text("گواهی ارزش افزوده خود را آپلود کنید");
            var div = $("<div></div>").addClass("col-md-6").append(
                $("<div></div>").addClass("custom-file").append(lbl2, input)
            )

            var div2 = $("<div></div>").addClass("form-group row").attr("id", "ValueAdded").append(lbl, div);

            $("#step3").append(div2);

        } else {
            $("#ValueAdded").remove();
        }
    });

    $(".previous").click(function (e) {
        var num = parseInt($(".tab-pane.active").attr("id").replace("tab2-", ""));
        if (num > 1) {
            jumpToPreviousStep(num);
        }
    });

    $(".next").click(function (e) {

        var num = parseInt($(".tab-pane.active").attr("id").replace("tab2-", ""));
        var form = "#step" + num;

        if ($(form).valid()) {

            e.preventDefault();

            switch (form) {
                case "#step1":
                case "#step2":
                case "#step4":

                    $.ajax({
                        url: "/Haghighi/" + $(form).attr("id"),
                        method: "POST",
                        data: $(form).serializeArray(),

                    }).done(function (response) {
                        if (response) {
                            switch (num) {
                                case 1:
                                case 2:
                                    jumpToNextStep(num);
                                    break;
                                case 4:
                                    window.location = '/Haghighi/Result';
                                    break;
                                default:
                                    break;
                            }
                        }
                    });

                    break;

                case "#step3":

                    var $formData = new FormData();

                    if ($('#BirthCertificateScan').length != 0) {
                        $formData.append('files', $('#BirthCertificateScan')[0].files[0]);
                    }

                    if ($('#IdentityNumberScan').length != 0) {
                        $formData.append('files', $('#IdentityNumberScan')[0].files[0]);
                    }

                    if ($('#BusinessLicenseScan').length != 0) {
                        $formData.append('files', $('#BusinessLicenseScan')[0].files[0]);
                    }

                    if ($('#ValueAddedScan').length != 0) {
                        $formData.append('files', $('#ValueAddedScan')[0].files[0]);
                    }

                    $.ajax({
                        url: 'http://api.befoys.com/api/Step/Step3',
                        method: 'POST',
                        data: $formData,
                        headers: { "Authorization": "Bearer " + getCookie("token") },
                        contentType: false,
                        processData: false,
                        success: function ($data) {
                            if ($data) {
                                jumpToNextStep(num);
                            }
                        }
                    });

                    break;

                default:
                    break;
            }

        }

        if (form == "#step1" || form == "#step2") {
            $(".wizard-navbar ul li:nth-child(" + num + ")").removeClass("active");
            $(".wizard-navbar ul li:nth-child(" + num + ") a").removeClass("active show");
            $(".wizard-navbar ul li:nth-child(" + (num + 1) + ")").addClass("active");
            $(".wizard-navbar ul li:nth-child(" + (num + 1) + ") a").addClass("active show");

            $(".tab-pane.active").removeClass("active");
            $("#tab2-" + (num + 1)).addClass("active");

            $(".gx-main-content").scrollTop(0);
        }

    });

    function jumpToNextStep(num) {
        $(".wizard-navbar ul li:nth-child(" + num + ")").removeClass("active");
        $(".wizard-navbar ul li:nth-child(" + num + ") a").removeClass("active show");
        $(".wizard-navbar ul li:nth-child(" + (num + 1) + ")").addClass("active");
        $(".wizard-navbar ul li:nth-child(" + (num + 1) + ") a").addClass("active show");

        $(".tab-pane.active").removeClass("active");
        $("#tab2-" + (num + 1)).addClass("active");

        $(".gx-main-content").scrollTop(0);
    }

    function jumpToPreviousStep(num) {
        $(".wizard-navbar ul li:nth-child(" + num + ")").removeClass("active");
        $(".wizard-navbar ul li:nth-child(" + num + ") a").removeClass("active show");
        $(".wizard-navbar ul li:nth-child(" + (num - 1) + ")").addClass("active");
        $(".wizard-navbar ul li:nth-child(" + (num - 1) + ") a").addClass("active show");

        $(".tab-pane.active").removeClass("active");
        $("#tab2-" + (num - 1)).addClass("active");

        $(".gx-main-content").scrollTop(0);
    }

    $('#step3 input[type=file]').change(function () {
        if (this.files.length > 0) {
            if (this.files[0].size > 5000000) {
                alert("حجم فایل آپلود شده بیشتر از حد مجاز می باشد.");
                return;
            }
            $(this).prev().text($(this)[0].files[0].name);
        } else {
            $(this).prev().text("آپلود فایل");
        }
    });

});