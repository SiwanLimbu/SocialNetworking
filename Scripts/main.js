$(document).on('submit', 'form.ajaxSubmit', function (e) {

    //console.log('checking....', $(this).valid());
    //if (!$(this).valid()) {
    //    //validation failed
    //    return false;
    //}

    $(this).addClass('Submitting');
    var callBack = window[$(this).data('callback')];
    console.log("callback=" + typeof callBack);
    var form = $(this)[0];
    $postURL = $(this).attr('action');
    var data = new FormData(form);
    //data = $(this).serialize();
    $.ajax({
        type: "POST",
        enctype: 'multipart/form-data',
        url: $postURL,
        data: data,
        processData: false,
        contentType: false,
        cache: false,
        timeout: 600000,
        success: function (response) {
            console.log(response);
            var stat = response.Status || true;
            console.log("stat=" + stat);
            if (stat) {
                //$(".ajaxSubmit")[0].reset();
                console.log("check");
                console.log("callback=" + typeof callBack);

                if (typeof callBack == "function") {
                    callBack(response);
                }
            }
        }, error: function (err) {
            console.log("error", err);
        }
    });

    $(this).addClass('showingConfirmation');
    console.log('showing modal');
    $('#myModal').modal("show");
    e.preventDefault();
    return false;

});

function RefreshChat()
{
    $("#ChatHistory").load($("#ChatHistory").data("url"));
}