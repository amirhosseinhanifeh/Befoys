$('.layout-sidebar-body-top1-drop').slideUp()

function showDashboardDropdown() {
    $('.layout-sidebar-body-top1-drop').css({ opacity: 1 })
    $('.layout-sidebar-body-top1-drop').slideToggle(100)
    $('.layout-sidebar-body-top1-left-icon').toggleClass('layout-sidebar-body-top1-left-icon-toggle')
    $('.dashboard-orange-line').toggleClass('dashboard-orange-line-toggle')

    $('.contract-orange-line').removeClass('contract-orange-line-toggle')
    $('.chat-orange-line').removeClass('chat-orange-line-toggle')
}

$('.layout-sidebar-body-top2').on('click', function() {
    $('.layout-sidebar-body-top1-drop').css({ opacity: 0 })
    $('.layout-sidebar-body-top1-drop').slideUp(100)
    $('.layout-sidebar-body-top1-left-icon').removeClass('layout-sidebar-body-top1-left-icon-toggle')
    $('.dashboard-orange-line').removeClass('dashboard-orange-line-toggle')

    $('.contract-orange-line').addClass('contract-orange-line-toggle')
    $('.chat-orange-line').removeClass('chat-orange-line-toggle')
})
$('.layout-sidebar-body-top3').on('click', function() {
    $('.layout-sidebar-body-top1-drop').css({ opacity: 0 })
    $('.layout-sidebar-body-top1-drop').slideUp(100)
    $('.layout-sidebar-body-top1-left-icon').removeClass('layout-sidebar-body-top1-left-icon-toggle')
    $('.dashboard-orange-line').removeClass('dashboard-orange-line-toggle')

    $('.chat-orange-line').addClass('chat-orange-line-toggle')
    $('.contract-orange-line').removeClass('contract-orange-line-toggle')
})

function showMessageBox() {
    $('.message-box').toggleClass('message-box-toggle')
    $('.bell-box').removeClass('bell-box-toggle')
}

function showBellBox() {
    $('.bell-box').toggleClass('bell-box-toggle')
    $('.message-box').removeClass('message-box-toggle')
}

$(document).on('click', function(event) {
    if (!$(event.target).closest('.bell-box-toggle').length && !$(event.target).closest('.layout-header-notificatins-box').length) {
        $('.bell-box').removeClass('bell-box-toggle')
    }
});
$(document).on('click', function(event) {
    if (!$(event.target).closest('.message-box-toggle').length && !$(event.target).closest('.bell-box-toggle').length && !$(event.target).closest('.layout-header-notificatins-box').length) {
        $('.message-box').removeClass('message-box-toggle')
    }
});

$('.layout-sidebar-top-modal').slideUp()

function showSettingModal() {
    $('.layout-sidebar-top-modal').css({ opacity: 1 })
    $('.layout-sidebar-top-modal').slideToggle(100)
    $('.layout-sidebar-top-dropdown-icon').toggleClass('layout-sidebar-top-dropdown-icon-toggle')
}

$(document).on('click', function(event) {
    if (!$(event.target).closest('.layout-sidebar-top').length && !$(event.target).closest('.layout-header-notificatins-box').length) {
        $('.layout-sidebar-top-modal').slideUp()
        $('.layout-sidebar-top-dropdown-icon').removeClass('layout-sidebar-top-dropdown-icon-toggle')
    }
});

$('.layout-sidebar-body-top1-drop-link').on('click', function(e) {
    $(this).addClass('active-link')
    $('.layout-sidebar-body-top1-drop-link').removeClass('active-link');
})

$('.layout-sidebar-body-top1-drop').on('click', 'a', function() {
    $('.layout-sidebar-body-top1-drop a.active-link').removeClass('active-link');
    $(this).addClass('active-link');
});

$('.layout-sidebar-body').on('click', 'div.toggle-back', function() {
    $('.toggle-back').removeClass('layout-sidebar-body-clicked');
    $(this).addClass('layout-sidebar-body-clicked');
});

$('.layout-sidebar-body').on('click', 'div.toggle-back', function() {
    $('.toggle-back').removeClass('toggle-back-befored');
    $(this).addClass('toggle-back-befored');
});

$('.layout-sidebar-body-top1').on('click', function() {
    $(this).removeClass('layout-sidebar-body-top1-befored')
    $(this).toggleClass('layout-sidebar-body-top1-befored')
})


function showHamburgerMenu() {
    $('.layout-backdrop').css({ display: 'block' })
    $('.layout-sidebar').animate({
        right: 50
    }, 350).animate({
        right: 0
    }, 150)
}

$('.layout-backdrop').on('click', () => {
    $('.layout-backdrop').css({ display: 'none' })
    $('.layout-sidebar').animate({
        right: 50
    }, 500).animate({
        right: -300
    }, 100)
})

// perfect scroll 
const messageBox = new
PerfectScrollbar('.message-box-body', {
    wheelSpeed: 0.3,
    wheelPropagation: false,
    minScrollbarLength: 20,
});

const bellBox = new
PerfectScrollbar('.bell-box-body', {
    wheelSpeed: 0.3,
    wheelPropagation: false,
    minScrollbarLength: 20,
});

const sidebarBody = new
PerfectScrollbar('.layout-sidebar-body', {
    wheelSpeed: 0.3,
    wheelPropagation: false,
    minScrollbarLength: 20,
    useBothWheelAxes: false,
    suppressScrollX: true,
    useBothWheelAxes: true
});

const mainSection = new
PerfectScrollbar('.main-section', {
    wheelSpeed: 1,
    wheelPropagation: false,
    minScrollbarLength: 20,
    useBothWheelAxes: false,
    suppressScrollX: true,
    useBothWheelAxes: true
});


// perfect scroll
$(window).on('unload', function() {
    $('.loader').css({ display: 'block' })
    $('.blue-logo-spinner').css({ display: 'block' })
    $('.spinner-backdrop').css({ display: 'block' })

});

$(window).on('load', function() {
    $('.loader').css({ display: 'none' })
    $('.blue-logo-spinner').css({ display: 'none' })
    $('.spinner-backdrop').css({ display: 'none' })


})

function showHeaderDropdown() {
    $('.main-section-header-dropdown').fadeToggle(200).css({ display: 'flex' })
}

$(document).on('click', function(event) {
    if (!$(event.target).closest('.main-section-header-icons').length && !$(event.target).closest('.main-section-header-dropdown').length) {
        $('.main-section-header-dropdown').fadeOut()
    }
});
