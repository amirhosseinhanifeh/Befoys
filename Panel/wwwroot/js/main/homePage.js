function modalEmailLogin() {
    $('#phoneinput').val('')
    $('#passwordInput').val('')
    $('#phoneloginBtn').css({
        display: 'block',
        marginRight: 0
    });
    $('#loginEmail').css({
        display: 'block',
        marginRight: 0
    });
    $('#emailloginBtn').css({
        display: 'none',
        marginRight: 0
    });
    $('#loginPhone').css({
        display: 'none',
        marginRight: 0
    });
    $('#phoneForm').css({
        display: 'none'
    });
    $('#emailForm').css({
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'flex-start'
    });
}

function modalPhponeLogin() {
    $('#emailInput').val('')
    $('#emailloginBtn').css({
        display: 'block',
        marginRight: 0
    });
    $('#loginPhone').css({
        display: 'block',
        marginRight: 0
    });
    $('#phoneloginBtn').css({
        display: 'none',
        marginRight: 0
    });
    $('#loginEmail').css({
        display: 'none',
        marginRight: 0
    });
    $('#emailForm').css({
        display: 'none'
    });
    $('#phoneForm').css({
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'flex-start'
    })
}

// timer

let handleBack = false
let handleRemoveTimer = false

function startTimer() {
    let timer = 60 * 3,
        minutes, seconds;
    let setTime = setInterval(function() {
        minutes = parseInt(timer / 60, 10);
        seconds = parseInt(timer % 60, 10);

        minutes = minutes < 10 ? "0" + minutes : minutes;
        seconds = seconds < 10 ? "0" + seconds : seconds;

        $('#sendCodeTimer').text(minutes + ":" + seconds);

        if (--timer < 0 || handleBack === true) {
            timer = 60 * 3;
            clearInterval(setTime)
            $('#phoneCodeSendInputBox').val('')
            $('#phoneCodeSendInput').css({
                display: 'none'
            })
            $('.home-modal-sencode-buttons').css({
                display: 'none'
            })
            $('.home-modal-buttons').css({
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
                justifyContent: 'center'
            })
            $('#phoneForm').css({
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
            })
        } else if (handleRemoveTimer == true) {
            timer = 60 * 3;
            clearInterval(setTime)
        }
    }, 1000)
}

// timer
//axios.post('http://api.befoys.com/api/register/verify', {
//    mobile: $('#phoneinput').val(),
//    code: $('#phoneCodeSendInputBox').val()
//}).then(req => {
//if (getCookie("token") === null) {
//        $('#sendCodeTimer').css({ display: 'none' })
//        handleRemoveTimer = true

//        $('#phoneCodeSendinputInvalid').fadeOut()
//        $('#phoneCodeSendInput').css({
//            display: 'none'
//        })
//        $('.home-modal-sencode-buttons').css({
//            display: 'none'
//        })
//        $('.registerItemsBox').css({
//            display: 'flex',
//            flexDirection: 'column',
//            alignItems: 'center'
//        })
//    } else {
//        $('#phoneCodeSendinputInvalid').fadeIn()
//        $('#phoneCodeSendinputInvalid').text('کد ۶ رقمی را وراد کنید')
//    }
//})


function phoneloginBegin() {

    let digits = /^\d+$/;

    numValue = $('#phoneinput').val()
    if ($('#phoneinput').val().length === 11 && digits.test($('#phoneinput').val())) {
        $("#loginPhone").text("لطفا صبر کنید");
        $("#loginPhone").prop("disabled", true);
        axios.post('http://api.befoys.com/api/register/registeration', {
            mobile: numValue
        }).then(res => {
            $("#loginPhone").text("ورود");
            $("#loginPhone").prop("disabled", false);
            $('#phoneFormInvalid').fadeOut()

            $('#phoneCodeSendInput').css({
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'flex-start'
            })

            $('#phoneForm').css({
                display: 'none'
            })
            $('.home-modal-buttons').css({
                display: 'none'
            })
            $('.home-modal-sencode-buttons').css({
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center'
            })
            // ***
            $('#sendCodeTimer').css({ display: 'block' })
            handleBack = false;
            handleRemoveTimer = false;
            startTimer();
            // ***
        }).catch(err => console.log(err))

    } else if ($('#phoneinput').val().length > 11 || $('#phoneinput').val().length < 11 &&
        $('#phoneinput').val().length > 0) {
        $('#phoneFormInvalid').text('شماره خود را به درستی وارد کنید')
        $('#phoneFormInvalid').fadeIn()
    } else if ($('#phoneinput').val().length === 0) {
        $('#phoneFormInvalid').text('لطفا شماره خود را وارد کنید')
        $('#phoneFormInvalid').fadeIn()
    } else if (!digits.test($('#phoneinput').val())) {
        $('#phoneFormInvalid').text('شماره تلفن نامعتبر است')
        $('#phoneFormInvalid').fadeIn()
    }
}

function emailloginBegin() {
    let emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/

    let email = $('#emailInput').val()

    if (email.length <= 0) {
        $('#emailInputInvalid').css({
            display: 'block'
        })
        $('#emailInputInvalid').text('ایمیل خود را وارد کنید')
    } else if (emailPattern.test(String(email).toLowerCase())) {
        $('#emailInputInvalid').css({
            display: 'none'
        })
    } else if (!emailPattern.test(String(email).toLowerCase())) {
        $('#emailInputInvalid').css({
            display: 'block'
        })
        $('#emailInputInvalid').text('ایمیل نامعتبر است')
    }

    if ($('#passwordInput').val().length >= 1) {
        $('#passwordInputInvalid').css({
            display: 'none'
        })
        $('#passwordInputInvalid').text('')
    } else {
        $('#passwordInputInvalid').css({
            display: 'block'
        })
        $('#passwordInputInvalid').text('ٰرمز عبور خود را وارد کنید')
    }

    if (emailPattern.test(String(email).toLowerCase()) && $('#passwordInput').val().length >= 1) {
        $('.home-modal-buttons').css({
            display: 'none'
        })
        $('#emailForm').css({
            display: 'none'
        })
        $('.registerItemsBox').css({
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center'
        })
    }
}

function sendCodeCancele() {
    $('#phoneCodeSendInput').css({
        display: 'none'
    })
    $('.home-modal-sencode-buttons').css({
        display: 'none'
    })
    $('.home-modal-buttons').css({
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center'
    })
    $('#phoneForm').css({
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
    })
    $('#phoneinput').val('')
    handleBack = true
}

function sendCodeHandler() {
    let phoneNumber = $('#phoneinput').val()
    let sendedCode = $('#phoneCodeSendInputBox').val()
    //if (sendedCode.length === 6) {
    //    $('#sendCodeTimer').css({ display: 'none' })
    //    handleRemoveTimer = true

    //    $('#phoneCodeSendinputInvalid').fadeOut()
    //    $('#phoneCodeSendInput').css({
    //        display: 'none'
    //    })
    //    $('.home-modal-sencode-buttons').css({
    //        display: 'none'
    //    })
    //    $('.registerItemsBox').css({
    //        display: 'flex',
    //        flexDirection: 'column',
    //        alignItems: 'center'
    //    })
    //} else {
    //    $('#phoneCodeSendinputInvalid').fadeIn()
    //    $('#phoneCodeSendinputInvalid').text('کد ۶ رقمی را وراد کنید')
    //}
    axios.post('http://api.befoys.com/api/register/verify', {
        mobile: $('#phoneinput').val(),
        code: $('#phoneCodeSendInputBox').val()
    }).then(req => {
        console.log(req);
        if (req.data.token !== null) {
            document.cookie = "token=" + req.data.token;
            $('#sendCodeTimer').css({ display: 'none' })
            handleRemoveTimer = true

            $('#phoneCodeSendinputInvalid').fadeOut()
            $('#phoneCodeSendInput').css({
                display: 'none'
            })
            $('.home-modal-sencode-buttons').css({
                display: 'none'
            })
            $('.registerItemsBox').css({
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center'
            })
        } else {
            $('#phoneCodeSendinputInvalid').fadeIn()
            $('#phoneCodeSendinputInvalid').text('کد ۶ رقمی را وراد کنید')
        }
        console.log(req.data.token)
    })
}

function employeRegister() {
    $('.registerItemsBox').css({
        display: 'none'
    })
    $('.employeFirstStepBox').css({
        display: 'block'
    })
}

function employeRegisterCancele() {
    $('#employeCodeinput').val('')
    $('#employeCodeInvalid').fadeOut()
    $('#employeCodeInvalid').text('')
    $('.employeFirstStepBox').css({
        display: 'none'
    })
    $('.registerItemsBox').css({
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center'
    })
}

function employeRegisterBegin() {
    let employeCode = $('#employeCodeinput').val()
    if (employeCode.length === 6) {
        // $('#sendCodeTimer').css({ display: 'none' })
        // handleBack = true
        $('#employeCodeInvalid').fadeOut()
        $('#employeCodeInvalid').text('')
        $('.employeFirstStepBox').css({
            display: 'none'
        })
        $('.employeSecondStepInputBox').css({
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center'
        })
        $('#employeCodeinput').val('')
    } else {
        $('#employeCodeInvalid').fadeIn()
        $('#employeCodeInvalid').text('کد ۶ رقمی را وارد کنید')
    }
}


function employeRegisterFinal() {
    let employeName = $('#employeNameInput').val()
    let employeLastname = $('#employeLastnameInput').val()
    let employeDay = $('#daySelect').val()
    let employeMonth = $('#monthSelect').val()
    let employeYear = $('#yearSelect').val()
    let employeBirthday = {
        employeDay,
        employeMonth,
        employeYear
    }
    let employeGender = $('#genderSelect').val()
    let employeEmail = $('#employeEmailInput').val()
    let employePassword = $('#employePasswordInput').val()

    let emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/

    if (employeName.length >= 1) {
        $('#employeNameInputInvalid').fadeOut()
    } else {
        $('#employeNameInputInvalid').fadeIn()
        $('#employeNameInputInvalid').text('الزامیست')
    }

    if (employeLastname.length >= 1) {
        $('#employeLastnameInputInvalid').fadeOut()
    } else {
        $('#employeLastnameInputInvalid').fadeIn()
        $('#employeLastnameInputInvalid').text('الزامیست')
    }

    if (employeEmail.length >= 1) {
        $('#employeEmailInputInvalid').fadeOut()
    } else if (!emailPattern.test(employeEmail)) {
        $('#employeEmailInputInvalid').fadeIn()
        $('#employeEmailInputInvalid').text('ایمیل نامعتبر است')
    } else {
        $('#employeEmailInputInvalid').fadeIn()
        $('#employeEmailInputInvalid').text('الزامیست')
    }

    if (employePassword.length >= 1) {
        $('#employePasswordInputInvalid').fadeOut()
    } else {
        $('#employePasswordInputInvalid').fadeIn()
        $('#employePasswordInputInvalid').text('الزامیست')
    }

    if (employeName.length > 0 && employeLastname.length > 0 && employeEmail.length > 0 && employePassword.length > 0) {
        window.location.href = "pannel.html";
    }

}

function employeRegisterFinalCancele() {
    $('.employeSecondStepInputBox').css({ display: 'none' })
    $('.registerItemsBox').css({
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center'
    })
    $('#employeCodeinput').val('')
}


// create options with array

function Range(start, end) {
    return Array(end - start + 1).fill().map((_, idx) => start + idx)
}

let daysResult = Range(1, 31);
for (let day in daysResult) {
    let dayOptions = document.createElement('option');
    dayOptions.value = daysResult[day];
    dayOptions.innerHTML = daysResult[day];
    $("#daySelect").append(dayOptions);
}

let yearResult = Range(1300, 1400);
for (let year in yearResult) {
    let yearOptions = document.createElement('option');
    yearOptions.value = yearResult[year];
    yearOptions.innerHTML = yearResult[year];
    $("#yearSelect").append(yearOptions);
}