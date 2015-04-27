$(init);

function init() {
    $('#getCards').click(function () {
        // GET request on the Cards API to get all Cards
        getCards();
    });

    $('#updateButton').click(function () {
        //PUT a single card
        var Id = $('#updateCardId');
        //var card = {
        //    Attack: $('#updateCardAttack').val(),
        //    Health: $('#updateCardHealth').val(),
        //    Cost: $('updateCardMana').val()
        //};
        //console.log("created name/card");
        updateCard(Id);
    });
     
    $('#getCard').click(function () {
        // GET a single Card
        var stuId = $('#cardId').val();
        getCard(stuId);
    });

    $('#saveNewCard').click(function () {

        var stu = {
            Id: $('#newCardId').val(),
            Name: $('#newCardName').val(),
            Attack: $('#newCardAttack').val(),
            Health: $('#newCardHealth').val(),
            Cost: $('#newCardMana').val()
        };

        saveNewCard(stu);
    });

    $('#deleteCard').click(function () {
        var cardId = $('#deleteCardID').val();
        deleteCard(cardId);
    })
}

function deleteCard(cardId)
    {
    $.ajax({
        url: '/api/Card/' + cardId,
        type: 'DELETE',
        data: cardId,
        success: function (result) {
            console.log("Card removed.");

            // Set some confirmation message
        },
        error: function (jqXHR, textStatus, err) {
            $('#updateStatus').text('Error: ' + err);
        }
    });
}

function updateCard(id)
{
    $.ajax({
        url: '/api/Card/' + id,
        type: 'PUT',
        data: id,
        success: function (result) {
            console.log("Card updated.");

            // Set some confirmation message
        },
        error: function (jqXHR, textStatus, err) {
            $('#updateStatus').text('Error: ' + err);
        }
    });
}

function saveNewCard(stu) {
    // POST request: Id=3&Name=Becky+Black&Gpa=4.0
    $.ajax({
        url: '/api/Card',
        type: 'POST',
        data: stu,
        success: function (result) {
            console.log("Becky added.");

            // Set some confirmation message
        },
        error: function (jqXHR, textStatus, err) {
            $('#updateStatus').text('Error: ' + err);
        }
    });

}

function getCard(id) {
    $.getJSON('api/Card/' + id)
    .done(function (data) {
        // Display Card with ID 
        console.log(data.Id + ' ' + data.Name + ' ' + data.Gpa);

        $('#Card').html(data.Id + ' - ' + data.Name + ', Mana Cost - ' + data.Cost +', Attack - ' + data.Attack + ', Health - ' + data.Health);
    })
    .fail(function (jqXHR, textStatus, err) {
        alert('Error: ' + err);
    });

}

function getCards() {
    var $list = $('#CardList');

    $.getJSON('api/Card')
    .done(function (data) {
        // On success, 'data' contains a list of Cards
        $.each(data, function (key, item) {
            // Display each Card
            if (data != null) {
                console.log(item.Id + ' ' + item.Name + ' ' + item.Gpa);

                $('<li>' + item.Id + ' - ' + item.Name + ', Mana Cost - ' + item.Cost + ', Attack - ' + item.Attack + ', Health - ' + item.Health + '</li>').appendTo($list);
            } else {
                console.log("Data was null");
            }
        });
    })
    .fail(function (jqXHR, textStatus, err) {
        alert('Error: ' + err);
    });

}