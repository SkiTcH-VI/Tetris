$(document).ready(function () {

    setInterval(function () {
        $.ajax({
            type: "POST",
            url: "WebForm1.aspx/Timer_Tick",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        });
    }, 1000);
});