function AddToCart(id, msg1, msg2) {
    var numday = document.getElementById('numdays_' + id).value;
    var numdays = parseInt(numday);
    var token = document.getElementById('token').value;

    //if (!Number.isInteger(numdays)) {
    if (!isFinite(numdays) || numdays <= 0) {
        $("#result").html(msg1);
    } else {

        var jsondata = { inventory_id: id, numdays: numdays, token: token };
        var options = {};
        options.url = "/ApiInventory/post";
        options.type = "POST";
        options.contentType = "application/json;charset=utf-8";
        options.dataType = "json";
        options.data = JSON.stringify(jsondata);
        options.crossDomain = false;
        options.beforeSend = function () {
            document.getElementById('preload').style.display = '';
        };
        options.success = function (json) {
            result = json.msg;
            if (json.countOrdered != 0) document.getElementById('cart_total').innerHTML = json.countOrdered;

            $("#result").html(result);
            document.getElementById('preload').style.display = 'none';
        };
        options.error = function () {
            $("#result").html(msg2);
            document.getElementById('preload').style.display = 'none';
        };
        $.ajax(options);
    }
}

function isInteger(n) {
    return n === +n && n === (n | 0);
}