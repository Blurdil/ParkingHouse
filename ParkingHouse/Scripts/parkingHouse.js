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

$('.garageDropDown').change(function () {
    var id = $('option:selected', this).val();
    $.ajax({
        url: '/page/ChangeID',
        type: 'POST',
        data: { Id: id },
        success: function () {
            location.reload();
        }
    });
})
}

$(document).click(function (event) {
    var div = $(event.target).closest('form');
    console.log(div)
    if (!$(event.target).hasClass('popup')) {
        if (!$(event.target).closest('form').hasClass('postForm')) {
            $(".popup").hide();
        }
    }
});