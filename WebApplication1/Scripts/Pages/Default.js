$('button').click(function () {
    setInterval(function () {
        var gField = document.getElementById("GameField");
        var fShow = document.getElementById("FigureShow");
        var lab = document.getElementById("Label1");
        var dataValue = { "GameField": gField, "FigureShow": fShow, "Label1": lab };
        //console.log(dataValue);
        $.ajax({
            type: "POST",
            url: "WebForm1.aspx/Timer_Tick",
            data: dataValue,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
        });
    }, 1000);
});