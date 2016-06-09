/// <reference path="../AdminLTE-2.3.0/plugins/jQuery/jQuery-2.1.4.min.js" />



///GetData Using json
///Parameter : model,url

function GetData(model,url) {
    if (obj != '') {
        jQuery.ajax({
            url: url,
            type: 'GET',
            cache: false,
            datatype: 'json',
            data: obj,
            success: function (result) {
                return result;
            },
            error: function (xhr) {
                alert("Something seems Wrong");
                console.log(xhr);
            }
        });
    }
}