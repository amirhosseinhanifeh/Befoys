$(document).ready(function myfunction() {

    $("#ValueAddedCertificate").change(function (e) {
        if ($(this).is(":checked")) {

            var lbl2 = $("<label></label>").addClass("custom-file-label").attr("for", "ValueAddedScan").text("آپلود فایل");
            var input = $("<input/>").attr("type", "file").addClass("custom-file-input required").attr("id", "ValueAddedScan").attr("name", "ValueAddedScan");

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

            if (form == "#step1" || form == "#step2" || form == "#step4") {

                $.ajax({
                    url: "/Haghighi/" + $(form).attr("id"),
                    method: "POST",
                    data: $(form).serializeArray(),

                }).done(function (response) {
                    jumpToNextStep(num);
                });

            } else if (form == "#step3") {

                var $formData = new FormData();

                if ($('#BirthCertificateScan').length != 0) {
                    $formData.append('ValueAdded', $('#BirthCertificateScan')[0].files[0]);
                }

                if ($('#IdentityNumberScan').length != 0) {
                    $formData.append('ValueAdded', $('#IdentityNumberScan')[0].files[0]);
                }

                if ($('#BusinessLicenseScan').length != 0) {
                    $formData.append('ValueAdded', $('#BusinessLicenseScan')[0].files[0]);
                }

                if ($('#ValueAddedScan').length != 0) {
                    $formData.append('ValueAdded', $('#ValueAddedScan')[0].files[0]);
                }

                $.ajax({
                    url: '/Haghighi/' + $(form).attr('id'),
                    method: 'POST',
                    data: $formData,
                    dataType: 'json',
                    contentType: false,
                    processData: false,
                    success: function ($data) {
                        jumpToNextStep(num);
                    }
                });

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
        if ($(this)[0].files.length > 0) {
            $(this).prev().text($(this)[0].files[0].name);
        } else {
            $(this).prev().text("آپلود فایل");
        }
    });

});