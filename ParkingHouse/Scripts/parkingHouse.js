function CheckIn() {
    $.ajax({
        url: 'Garage/Create',
        Type: 'GET',
        success: function (data) {
            var div = document.getElementById('popup');
            div.innerHTML = data;
            $('#popup').toggle();
        }
    })
}

function closePopup() {
    $('#popup').toggle();
}