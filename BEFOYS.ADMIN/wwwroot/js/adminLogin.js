// $(".admin-login-right-button").click(function(event) {



// });

function sendData() {
    let emailPattern = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/

    let emailInput = $('.admin-login-right-email')
    let passInput = $('.admin-login-right-password')

    if (emailInput.val() === '' || emailInput.val() === null) {
        $('.admin-login-right-email-invalid').fadeIn()
        $('.admin-login-right-email-invalid').text('الزامیست')
    } else if (!emailPattern.test(emailInput.val())) {
        $('.admin-login-right-email-invalid').fadeIn()
        $('.admin-login-right-email-invalid').text('نامعتبر است')
    } else {
        $('.admin-login-right-email-invalid').fadeOut()
        $('.admin-login-right-email-invalid').text('')
    }

    if (passInput.val() === '' || passInput.val() === null) {
        $('.admin-login-right-password-invalid').fadeIn()
        $('.admin-login-right-password-invalid').text('الزامیست')
    } else if (passInput.val().length < 2) {
        $('.admin-login-right-password-invalid').fadeIn()
        $('.admin-login-right-password-invalid').text('کوتاه است')
    } else {
        $('.admin-login-right-password-invalid').fadeOut()
        $('.admin-login-right-password-invalid').text('')
    }

    if (passInput.val().length > 2 && (passInput.val() !== null || passInput.val() !== '') && emailPattern.test(emailInput.val())) {
        $('.admin-login-right-button').text('صبور باشید')
        $('.admin-login-right-button').attr('disabled', true)
        $('.spinner-block').css('display', 'block')

        let em = emailInput.val()
        let pass = passInput.val()

        axios.post('http://api.befoys.com/api/account/login', {
            UserName: em,
            Password: pass
        }).then(res => {
            if (res.data.token !== '') {
                $('.admin-login-toaster').animate({
                    top: 0
                }, 500)
                $('.admin-login-toaster').text(res.data.message)
                $('.admin-login-toaster').css({
                    backgroundColor: '#1961ac'
                })

                setTimeout(() => {
                    window.location.href = "/Home/Index"
                    $('.admin-login-toaster').animate({
                        top: '-50%'
                    }, 300)
                    $('.admin-login-toaster').text(res.data.message)
                }, 1000)
            } else {
                $('.admin-login-toaster').animate({
                    top: 0
                }, 500)
                $('.admin-login-toaster').text(res.data.message)
                $('.admin-login-toaster').css({
                    backgroundColor: '#f44336'
                })
                setTimeout(() => {
                    $('.admin-login-toaster').animate({
                        top: '-50%'
                    }, 500)
                    $('.admin-login-right-button').attr('disabled', false)
                }, 3000)

                $('.admin-login-right-button').text('ورود')

                $('.spinner-block').css('display', 'none')
            }

            console.log(res.data)
        }).catch(err => {
            $('.admin-login-toaster').animate({
                top: 0
            }, 500)
            $('.admin-login-toaster').text('خطایی رخ داده است')
            $('.admin-login-toaster').css({
                backgroundColor: '#f44336'
            })
            setTimeout(() => {
                $('.admin-login-toaster').animate({
                    top: '-50%'
                }, 500)
                $('.admin-login-right-button').attr('disabled', false)
            }, 3000)

            $('.admin-login-right-button').text('ورود')
            $('.spinner-block').css('display', 'none')
        })
    }


    // let em = $('.admin-login-right-email').val()
    // let pass = $('.admin-login-right-password').val()

    // $('.admin-login-right-button').text('صبور باشید')
    // $('.admin-login-right-button').attr('disabled', true)
    // $('.spinner-block').css('display', 'block')

    // axios.post('http://api.befoys.com/api/account/login', {
    //     UserName: em,
    //     Password: pass
    // }).then(res => {
    //     if (res.data.token !== '') {
    //         $('.admin-login-toaster').animate({
    //             top: 0
    //         }, 500)
    //         $('.admin-login-toaster').text(res.data.message)
    //         $('.admin-login-toaster').css({
    //             backgroundColor: '#1961ac'
    //         })

    //         setTimeout(() => {
    //             window.location.href = 'file:///C:/Users/SkySystem/Desktop/desc/work%20projects/layout/index.html'
    //             $('.admin-login-toaster').animate({
    //                 top: '-50%'
    //             }, 300)
    //             $('.admin-login-toaster').text(res.data.message)
    //         }, 1000)
    //     } else {
    //         $('.admin-login-toaster').animate({
    //             top: 0
    //         }, 500)
    //         $('.admin-login-toaster').text(res.data.message)
    //         $('.admin-login-toaster').css({
    //             backgroundColor: '#f44336'
    //         })
    //         setTimeout(() => {
    //             $('.admin-login-toaster').animate({
    //                 top: '-50%'
    //             }, 500)
    //             $('.admin-login-right-button').attr('disabled', false)
    //         }, 3000)

    //         $('.admin-login-right-button').text('ورود')

    //         $('.spinner-block').css('display', 'none')
    //     }

    //     console.log(res.data)
    // }).catch(err => {
    //     console.log(err)
    // })
}