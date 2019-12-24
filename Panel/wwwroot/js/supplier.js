$(document).ready(function myfunction() {

    $.ajax({
        url: "http://api.befoys.com/api/Step/GetInformation",
        method: "POST",
        headers: { "Authorization": "Bearer " + getCookie("token") }

    }).done(function (response) {
        $.each(response.value.infoes, function (index, value) {
            console.log(value.typeCodeId);
            //$("input[name=" + value.typeCodeId + "]").val(value.value);
            $(`input[name=${value.typeCodeId}]`).val(value.value);
            $("input[name=FirstName]").val(value.value);
        });
        
        //var obj = $.parseJSON(response);
        //console.log(obj);
    });

    $("#addTelephone").click(function () {

        var addressNum = parseInt($(this).parent().parent().parent().parent().attr("id").replace("address-info", "")) - 1;
        var telephoneNum = parseInt($(this).prev().find("input").attr("id").replace("telephone" + addressNum + "_", "")) + 1;

        var input = $("<input/>").addClass("form-control mt-2 required").attr({
            type: "text",
            id: "telephone" + addressNum + "_" + telephoneNum,
            name: "Addresses[" + addressNum + "].phones[" + telephoneNum + "].PhoneValue"
        }).on('input', function () {
            $(this).parent().next().remove();
            var digitsPattern = /^\d+$/;
            if ($(this).val() == '') {
                var span = $("<span></span>").addClass("d-block text-danger").text("لطفا مقداری را وارد کنید");
                var div = $("<div></div>").addClass("col-md-12").append(span);
                $(this).parent().parent().append(div);
            }
            else if (!digitsPattern.test($(this).val())) {
                var span = $("<span></span>").addClass("d-block text-danger").text("شماره تلفن نامعتبر است");
                var div = $("<div></div>").addClass("col-md-12").append(span);
                $(this).parent().parent().append(div);
            }
            else if ($(this).val().length > 11 || $(this).val().length < 11) {
                var span = $("<span></span>").addClass("d-block text-danger").text("طول شماره تلفن صحیح نمی باشد");
                var div = $("<div></div>").addClass("col-md-12").append(span);
                $(this).parent().parent().append(div);
            }
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

        var addressNum = parseInt($(this).prev().attr("id").replace("address-info", ""));

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
        var txtAddress = $("<textarea></textarea>").addClass("form-control required address").attr({
            id: "address" + addressNum,
            name: "Addresses[" + addressNum + "].Address",
            rows: "3"
        }).on('input', function () {
            $(this).next().remove();
            if ($(this).val() == '') {
                var span = $("<span></span>").addClass("d-block text-danger").text("لطفا آدرس خود را وارد کنید");
                $(this).parent().append(span);
            }
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
        }).on('input', function () {
            $(this).parent().next().remove();
            var digitsPattern = /^\d+$/;
            if ($(this).val() == '') {
                var span = $("<span></span>").addClass("d-block text-danger").text("لطفا مقداری را وارد کنید");
                var div = $("<div></div>").addClass("col-md-12").append(span);
                $(this).parent().parent().append(div);
            }
            else if (!digitsPattern.test($(this).val())) {
                var span = $("<span></span>").addClass("d-block text-danger").text("شماره تلفن نامعتبر است");
                var div = $("<div></div>").addClass("col-md-12").append(span);
                $(this).parent().parent().append(div);
            }
            else if ($(this).val().length > 11 || $(this).val().length < 11) {
                var span = $("<span></span>").addClass("d-block text-danger").text("طول شماره تلفن صحیح نمی باشد");
                var div = $("<div></div>").addClass("col-md-12").append(span);
                $(this).parent().parent().append(div);
            }
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
            }).on('input', function () {
                $(this).parent().next().remove();
                var digitsPattern = /^\d+$/;
                if ($(this).val() == '') {
                    var span = $("<span></span>").addClass("d-block text-danger").text("لطفا مقداری را وارد کنید");
                    var div = $("<div></div>").addClass("col-md-12").append(span);
                    $(this).parent().parent().append(div);
                }
                else if (!digitsPattern.test($(this).val())) {
                    var span = $("<span></span>").addClass("d-block text-danger").text("شماره تلفن نامعتبر است");
                    var div = $("<div></div>").addClass("col-md-12").append(span);
                    $(this).parent().parent().append(div);
                }
                else if ($(this).val().length > 11 || $(this).val().length < 11) {
                    var span = $("<span></span>").addClass("d-block text-danger").text("طول شماره تلفن صحیح نمی باشد");
                    var div = $("<div></div>").addClass("col-md-12").append(span);
                    $(this).parent().parent().append(div);
                }
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

        var address = $("<div></div>").addClass("address-info").attr("id", "address-info" + (addressNum + 1)).append(heading).append(
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

    $("#ValueAddedCertificate").change(function () {
        if ($(this).is(":checked")) {

            var lbl2 = $("<label></label>").addClass("custom-file-label").attr("for", "ValueAddedScan").text("آپلود فایل");
            var input = $("<input/>").attr("type", "file").addClass("custom-file-input required").attr("id", "ValueAddedScan").attr("name", "ValueAddedScan").change(function () {
                if ($(this)[0].files.length > 0) {
                    $(this).prev().text($(this)[0].files[0].name);
                } else {
                    $(this).prev().text("آپلود فایل");
                }
            });

            var lbl = $("<label></label>").addClass("col-md-6 control-label").text("گواهی ارزش افزوده");
            var div = $("<div></div>").addClass("col-md-6").append(
                $("<div></div>").addClass("custom-file").append(lbl2, input)
            );

            var div2 = $("<div></div>").addClass("form-group row").attr("id", "ValueAdded").append(lbl, div);

            $("#step3").append(div2);

        } else {
            $("#ValueAdded").remove();
        }
    });

    $(".previous").click(function () {
        var num = parseInt($(".tab-pane.active").attr("id").replace("tab2-", ""));
        if (num > 1) {
            jumpToPreviousStep(num);
        }
    });

    $(".next").click(function () {

        var num = parseInt($(".tab-pane.active").attr("id").replace("tab2-", ""));
        var form = "#step" + num;

        if (Validate() == 0) {
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

                    $formData.append('files', $('#BirthCertificateScan')[0].files[0]);
                    $formData.append('files', $('#IdentityNumberScan')[0].files[0]);
                    $formData.append('files', $('#BusinessLicenseScan')[0].files[0]);

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

        if (form == "#step1" || form == "#step2" || form == "#step3") {
            $(".wizard-navbar ul li:nth-child(" + num + ")").removeClass("active");
            $(".wizard-navbar ul li:nth-child(" + num + ") a").removeClass("active show");
            $(".wizard-navbar ul li:nth-child(" + (num + 1) + ")").addClass("active");
            $(".wizard-navbar ul li:nth-child(" + (num + 1) + ") a").addClass("active show");

            $(".tab-pane.active").removeClass("active");
            $("#tab2-" + (num + 1)).addClass("active");

            $(".gx-main-content").scrollTop(0);
        }

    });

    $('#FirstName').on('input', function () {
        $(this).next().remove();
        var persianPattern = /^[\u0600-\u06FF\s]+$/;
        if ($(this).val() == '') {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا نام خود را وارد کنید");
            $(this).parent().append(span);
        } else if (!persianPattern.test($(this).val())) {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا فارسی تایپ کنید");
            $(this).parent().append(span);
        }
    });

    $('#LastName').on('input', function () {
        $(this).next().remove();
        var persianPattern = /^[\u0600-\u06FF\s]+$/;
        if ($(this).val() == '') {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا نام خانوادگی خود را وارد کنید");
            $(this).parent().append(span);
        } else if (!persianPattern.test($(this).val())) {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا فارسی تایپ کنید");
            $(this).parent().append(span);
        }
    });

    $('#Email').on('input', function () {
        $(this).next().remove();
        var emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
        if ($(this).val() == '') {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا ایمیل خود را وارد کنید");
            $(this).parent().append(span);
        } else if (!emailPattern.test(String($(this).val()).toLowerCase())) {
            var span = $("<span></span>").addClass("d-block text-danger").text("ایمیل نامعتبر است");
            $(this).parent().append(span);
        }
    });

    $('#Password').on('input', function () {
        $(this).next().remove();
        if ($(this).val() == '') {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا رمز عبور خود را وارد کنید");
            $(this).parent().append(span);
        }
    });

    $('#NationalCode').on('input', function () {
        $(this).next().remove();
        var digitsPattern = /^\d+$/;
        if ($(this).val() == '') {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا کد ملی خود را وارد کنید");
            $(this).parent().append(span);
        } else if (!digitsPattern.test($(this).val())) {
            var span = $("<span></span>").addClass("d-block text-danger").text("کد ملی نامعتبر است");
            $(this).parent().append(span);
        } else if ($(this).val().length > 10 || $(this).val().length < 10) {
            var span = $("<span></span>").addClass("d-block text-danger").text("طول کد ملی صحیح نمی باشد");
            $(this).parent().append(span);
        }
    });

    $('.telephone input').each(function () {
        $(this).on('input', function () {
            $(this).parent().next().remove();
            var digitsPattern = /^\d+$/;
            if ($(this).val() == '') {
                var span = $("<span></span>").addClass("d-block text-danger").text("لطفا مقداری را وارد کنید");
                var div = $("<div></div>").addClass("col-md-12").append(span);
                $(this).parent().parent().append(div);
            }
            else if (!digitsPattern.test($(this).val())) {
                var span = $("<span></span>").addClass("d-block text-danger").text("شماره تلفن نامعتبر است");
                var div = $("<div></div>").addClass("col-md-12").append(span);
                $(this).parent().parent().append(div);
            }
            else if ($(this).val().length > 11 || $(this).val().length < 11) {
                var span = $("<span></span>").addClass("d-block text-danger").text("طول شماره تلفن صحیح نمی باشد");
                var div = $("<div></div>").addClass("col-md-12").append(span);
                $(this).parent().parent().append(div);
            }
        });
    });

    $('.address').each(function () {
        $(this).on('input', function () {
            $(this).next().remove();
            var persianPattern = /^[\u0600-\u06FF\s]+$/;
            if ($(this).val() == '') {
                var span = $("<span></span>").addClass("d-block text-danger").text("لطفا آدرس خود را وارد کنید");
                $(this).parent().append(span);
            } else if (!persianPattern.test($(this).val())) {
                var span = $("<span></span>").addClass("d-block text-danger").text("لطفا فارسی تایپ کنید");
                $(this).parent().append(span);
            }
        });
    });

    $('#OrganizationName').on('input', function () {
        $(this).next().remove();
        var persianPattern = /^[\u0600-\u06FF\s]+$/;
        if ($(this).val() == '') {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا نام تجاری خود را وارد کنید");
            $(this).parent().append(span);
        } else if (!persianPattern.test($(this).val())) {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا فارسی تایپ کنید");
            $(this).parent().append(span);
        }
    });

    $('#IRCode').on('input', function () {
        $(this).next().remove();
        var digitsPattern = /^\d+$/;
        if ($(this).val() == '') {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا شماره شبا خود را وارد کنید");
            $(this).parent().append(span);
        } else if (!$(this).val().startsWith("IR") && !$(this).val().startsWith("ir") || !digitsPattern.test($(this).val().substring(2, $(this).val().length))) {
            var span = $("<span></span>").addClass("d-block text-danger").text("شماره شبا نامعتبر است");
            $(this).parent().append(span);
        } else if ($(this).val().length < 26 || $(this).val().length > 26) {
            var span = $("<span></span>").addClass("d-block text-danger").text("طول شماره شبا صحیح نمی باشد");
            $(this).parent().append(span);
        }
    });

    $('#AccountNumber').on('input', function () {
        $(this).next().remove();
        var digitsPattern = /^\d+$/;
        if ($(this).val() == '') {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا شماره حساب خود را وارد کنید");
            $(this).parent().append(span);
        } else if (!digitsPattern.test($(this).val())) {
            var span = $("<span></span>").addClass("d-block text-danger").text("شماره حساب نامعتبر است");
            $(this).parent().append(span);
        }
    });

    $('#AccountOwner').on('input', function () {
        $(this).next().remove();
        var persianPattern = /^[\u0600-\u06FF\s]+$/;
        if ($(this).val() == '') {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا نام دارنده حساب خود را وارد کنید");
            $(this).parent().append(span);
        } else if (!persianPattern.test($(this).val())) {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا فارسی تایپ کنید");
            $(this).parent().append(span);
        }
    });

    $('#BirthCertificateScan').on('input', function () {
        $(this).next().remove();
        if ($(this).val() == "") {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا اسکن از صفحه اول شناسنامه خود را آپلود کنید");
            $(this).parent().append(span);
        }
    });

    $('#IdentityNumberScan').on('input', function () {
        $(this).next().remove();
        if ($(this).val() == "") {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا اسکن کارت ملی خود را آپلود کنید");
            $(this).parent().append(span);
        }
    });

    $('#BusinessLicenseScan').on('input', function () {
        $(this).next().remove();
        if ($(this).val() == "") {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا اسکن جواز کسب خود را آپلود کنید");
            $(this).parent().append(span);
        }
    });

    $('#ValueAddedScan').on('input', function () {
        $(this).next().remove();
        if ($('#ValueAddedCertificate').is(":checked") && $(this).val() == "") {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا گواهی ارزش افزوده خود را آپلود کنید");
            $(this).parent().append(span);
        }
    });

    $('#select1').on('input', function () {
        $(this).next().next().remove();
        if ($(this).val() == "") {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا دسته بندی خود را انتخاب کنید");
            $(this).parent().append(span);
        }
    });

    $('#select2').on('input', function () {
        $(this).next().next().remove();
        if ($(this).val() == "") {
            var span = $("<span></span>").addClass("d-block text-danger").text("لطفا دسته بندی خود را انتخاب کنید");
            $(this).parent().append(span);
        }
    });

    function Validate() {

        $('span.d-block.text-danger').remove();

        var num = parseInt($(".tab-pane.active").attr("id").replace("tab2-", ""));
        var form = "#step" + num;

        switch (form) {

            case "#step1":

                $('#FirstName').trigger("input");
                $('#LastName').trigger("input");
                $('#Email').trigger("input");
                $('#Password').trigger("input");
                $('#NationalCode').trigger("input");
                $('.telephone input').each(function () { $(this).trigger("input"); });
                $('.address').each(function () { $(this).trigger("input"); });

                break;

            case "#step2":

                $('#OrganizationName').trigger("input");
                $('#IRCode').trigger("input");
                $('#AccountNumber').trigger("input");
                $('#AccountOwner').trigger("input");
                
                break;

            case "#step3":

                $('#BirthCertificateScan').trigger("input");
                $('#IdentityNumberScan').trigger("input");
                $('#BusinessLicenseScan').trigger("input");
                $('#ValueAddedScan').trigger("input");

                break;

            case "#step4":

                $('#select1').trigger("input");
                $('#select2').trigger("input");
                
                break;

            default:
                break;

        }

        return $('span.d-block.text-danger').length;

    }

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
                reset_form_element($(this));
                $(this).prev().text("آپلود فایل");
                alert("حجم فایل آپلود شده بیشتر از حد مجاز می باشد.");
                $(this).trigger("input");
                return;
            }
            $(this).prev().text($(this)[0].files[0].name);
        } else {
            $(this).prev().text("آپلود فایل");
        }
    });

    function reset_form_element(e) {
        e.wrap('<form>').parent('form').trigger('reset');
        e.unwrap();
    }

});