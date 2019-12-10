var BaseUrl = "http://localhost:26123/";
$(document).ready(function () {

    $("button[befoys-ajax=true][type=submit]").click(function (e) {
        e.preventDefault();
        var $form = $("form[befoys-ajax=true]");
        var url = BaseUrl+$form.attr("befoys-url");
        var method = $form.attr("befoys-method");
        var onSuccess = $form.attr("befoys-OnSuccess");

        $.ajax({
            url: url,
            method: method,
            data: JSON.stringify(getFormData($form)),
            contentType: "application/json",
            headers: { "Authorization": "Bearer " + getCookie("token") },
            beforeSend: OnBefore()
            
        }).done(function (response) {
            OnSuccess(response);
        });

    });
});
function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}
//get parameter from url
function GetParameterValues(param) {
    var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < url.length; i++) {
        var urlparam = url[i].split('=');
        if (urlparam[0] === param) {
            return urlparam[1];
        }
    }
}  

function GetDataFromLocalStorage(data) {
    return window.localStorage.getItem(data);
}
function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}