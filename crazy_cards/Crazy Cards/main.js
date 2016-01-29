// Main.js - JavaScript code for AJAX calls to the server API and front-end management

// Set URI shorthand
var uri = 'api/cards';
var total_credit = 0;

// Document ready trigger (For future usage)
$(document).ready(function ()
{
    
});

/// Format fetched card
function formatCard(cardID, cardValue)
{
    var result = '<div id="card_' + cardValue.ID + '" data-credit="' + cardValue.CreditAvailable + '" class="card">' +
                     '<div class="info title">' + cardValue.Name + '</div>' +
                     '<div class="info">APR: ' + cardValue.APR + '%</div>' +
                     '<div class="info">Balance Transfer Offer Duration: ' + cardValue.BTOD + ' months</div>' +
                     '<div class="info">Purchase Offer Duration: ' + cardValue.POD + ' months</div>' +
                     '<div class="info">Credit Available: £' + cardValue.CreditAvailable + '</div>' +
                 '</div>';

    return result;
}

// Select/Unselect clicked card and update total credit
function selectCard(e)
{
    if (e.target.id === '')
    {
        if ($('#' + e.target.parentNode.id).attr('class') == 'card clicked') {
            $('#' + e.target.parentNode.id).attr('class', 'card');
            total_credit -= Number(e.target.parentNode.attributes[1].value);
        }
        else {
            $('#' + e.target.parentNode.id).attr('class', 'card clicked');
            total_credit += Number(e.target.parentNode.attributes[1].value);
        }
    }
    else
    {
        if ($('#' + e.target.id).attr('class') == 'card clicked') {
            $('#' + e.target.id).attr('class', 'card');
            total_credit -= Number(e.target.attributes[1].value);
        }
        else {
            $('#' + e.target.id).attr('class', 'card clicked');
            total_credit += Number(e.target.attributes[1].value);
        }
    }

    $('#total_credit').text(total_credit);
}

// Fetch available corresponding cards
function fetchCards()
{
    var annual_income = $('#annual_income').val();
    var employment_status = $('#employment_status option:selected').attr('id');

    if (annual_income === '' || employment_status === '0')
    {
        // Do an AJAX request and respond accordingly
        $.getJSON(uri + '/')
       .done(function (data) {
           total_credit = 0;
           $('#total_credit').text(total_credit);
           $('#error').html('');
           $('#cards').html('<div class="error1">:: No cards are available - Please fill in the details ::</div>');
       })
       .fail(function (jqXHR, textStatus, err) {
           total_credit = 0;
           $('#total_credit').text(total_credit);
           $('#error').html('<div class="error2">Error: ' + err + '</div>');
       });
    }
    else
    {
        // Organize as JSON object for future processing
        var req_model = { "annual_income": annual_income, "status": employment_status };

        // Calculate monthly income
        var income = annual_income / 12;

        // Do an AJAX request and respond accordingly
        $.getJSON(uri + '/' + income + '/' + req_model.status + '/')
            .done(function (data) {
                total_credit = 0;
                $('#total_credit').text(total_credit);
                $('#error').html('');
                $('#cards').text('');
                $.each(data, function (key, value) {
                    $('#cards').append(formatCard(key, value));
                    document.getElementById('card_' + value.ID).addEventListener('click', selectCard, false);
                });
            })
            .fail(function (jqXHR, textStatus, err) {
                total_credit = 0;
                $('#total_credit').text(total_credit);
                $('#error').html('<div class="error2">Error: ' + err + '</div>');
            });
    }
}
