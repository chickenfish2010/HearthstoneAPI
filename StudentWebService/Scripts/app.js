$(init);

function init() {
    $('#getCards').click(function () {
        // GET request on the Cards API to get all Cards
        getCards();
    });

    $('#updateButton').click(function () {
        //PUT a single card
        var Card = {
            Id: $('#updateCardId').val(),
            Name: $('#updateCardName').val(),
            Attack: $('#updateCardAttack').val(),
            Health: $('#updateCardHealth').val(),
            Cost: $('#updateCardMana').val()
        };
        
        var Id = Card.Id;
        
        updateCard(Id, Card);
    });
     
    $('#getCard').click(function () {
        // GET a single Card
        var cardId = $('#cardId').val();
        getCard(cardId);
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

            $('#deleteStatus').text("Card Removed Successfully")
            // Set some confirmation message
        },
        error: function (jqXHR, textStatus, err) {
            $('#deleteStatus').text('Error: ' + err);
        }

    });
}

function updateCard(Id, Card)
{
    $.ajax({
        url: '/api/Card/' + Card.Id,
        type: 'PUT',
        //dataType: 'json',
        //contentType: 'application/JSON', 
        data: Card,
        success: function (result) {
            console.log("Card updated.");
            $('updateStatus').text("Updated Successfully")
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
            console.log("New Card Saved.");

            $('saveStatus').text("Saved Successfully")
            // Set some confirmation message
        },
        error: function (jqXHR, textStatus, err) {
            $('#saveStatus').text('Error: ' + err);
        }
    });

}

//function saveUpdatedCard() {
//    $.ajax({
//        url: '/api/Card',
//        type: 'POST',
//        data: updatedCard,
//        success: function (result) {
//            console.log("Saved updated card.");

//            // Set some confirmation message
//        },
//        error: function (jqXHR, textStatus, err) {
//            $('#updateStatus').text('Error: ' + err);
//        }
//    });
//}

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

    $('#CardList').html("Searching the Database...");

    $.getJSON('api/Card')
    .done(function (data) {
        $('#CardList').html("");
        if (data != null) {
            // On success, 'data' contains a list of Cards
            $.each(data, function (key, item) {
                // Display each Card
                var tempString = "";
                var string = '<li>' + item.Id + ' - <b>' + item.Name + ' - ' + (item.Cost || '');

                if (item.Cost != null) {
                    tempString = ', ' + 'Mana Cost - ' + item.Cost;
                }
                string += tempString;
                if (item.Attack != null) {
                    tempString = ', ' + 'Attack - ' + item.Attack;
                }
                string += tempString;
                if (item.Health != null) {
                    tempString = ', ' + 'Health - ' + item.Health;
                }
                string += tempString + '</b>';

                console.log(string);
                $(string).appendTo($list);
                //$('<li>' + item.Id + ' - ' + item.Name + ', Mana Cost - ' + item.Cost + ', Attack - ' + item.Attack + ', Health - ' + item.Health + '</li>').appendTo($list);

            });
        }
        else {
            $('#CardList').html("No Entries Found.");
        }
    })
    .fail(function (jqXHR, textStatus, err) {
        alert('Error: ' + err);
    });

}