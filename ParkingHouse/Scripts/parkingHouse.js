function CheckIn() {
    var url = 'Garage/Create'
    $.ajax({
        url: url,
        Type: 'GET',
        success: function (data) {
            var div = document.getElementById('popup');
            div.innerHTML = data;
            $('#popup').show();
        }
    })
}

function closePopup() {
    $('#popup').hide();
}

function CreateReceipt(id) {
    console.log(id);
    var url = '../Receipt'
    $.ajax({
        url: url,
        type: 'GET',
        data: {id: id},
        success: function (data) {
            var div = document.getElementById("popup");
            div.innerHTML = data;
            $('#popup').show();
        }
    })
}