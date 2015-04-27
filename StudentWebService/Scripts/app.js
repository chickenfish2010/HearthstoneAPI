$(init);

function init() {
    $('#getCards').click(function () {
        // GET request on the Cards API to get all Cards
        getCards();
    });

    $('#getCard').click(function () {
        // GET a single Card
        var stuId = $('#stuId').val();
        getCard(stuId);
    });

    $('#saveNewCard').click(function () {

        var stu = {
            Id: $('#newCardId').val(),
            Name: $('#newCardName').val(),
            Attack: $('#newCardAttack').val(),
            Health: $('#newCardHealth').val()
        };

        saveNewCard(stu);
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

        $('#Card').html(data.Id + ' - ' + data.Name + ' GPA = '
            + data.Gpa);
    })
    .fail(function (jqXHR, textStatus, err) {
        alert('Error: ' + err);
    });

}

function getCards() {
    var $list = $('#CardList');

    $('#CardList').html("");

    $.getJSON('api/Card')
    .done(function (data) {
        // On success, 'data' contains a list of Cards
        $.each(data, function (key, item) {
            // Display each Card
            if (data != null) {
                //console.log(item.Id + ' ' + item.Name + ' ' + item.Gpa);
                var string = '<li>' + item.Id + ' - <b>' + item.Name + ' - ' + (item.Cost || '');

                if (item.Cost != null)
                {
                    tempString = ', ' + 'Mana Cost - ' + item.Cost;
                }
                string += tempString;
                if (item.Attack != null) {
                    tempString =', ' + 'Attack - ' + item.Attack;
                }
                string += tempString;
                if (item.Health != null) {
                    tempString = ', ' + 'Health - ' + item.Health;
                }
                string += tempString + '</b>';

                console.log(string);
                $(string).appendTo($list);
                //$('<li>' + item.Id + ' - ' + item.Name + ', Mana Cost - ' + item.Cost + ', Attack - ' + item.Attack + ', Health - ' + item.Health + '</li>').appendTo($list);
            } else {
                console.log("Data was null");
            }
        });
    })
    .fail(function (jqXHR, textStatus, err) {
        alert('Error: ' + err);
    });

}