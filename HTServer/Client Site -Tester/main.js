// Main.js - JavaScript code for AJAX calls to the server API and front-end management

// Set URI shorthand
var port = 53302; // Change port number to match your IIS Express
var uri = 'http://localhost:' + port + '/service/tradeinfo/fetch/';

// Document ready trigger
$(document).ready(function ()
{
	// Do an AJAX request upon load
    fetchTradeInfo();
	
	// Do an AJAX request every 1 second
	setInterval(function() { fetchTradeInfo(); }, 1000);
});

// Fetch trade info (Average response time: 37ms)
function fetchTradeInfo()
{
	$.post(uri).done(function (response) {
		var json_parsed = JSON.parse(response);
		var new_rows = null;
		
		$('#data_table tbody tr:not(:first)').remove();
		
		for (var index in json_parsed)
		{
			new_rows += '<tr>' + 
						'	<td>' + json_parsed[index].CurrencyID + '</td>' + 
						'	<td>' + json_parsed[index].AverageValue + '</td>' + 
						'	<td>' + json_parsed[index].MinValue + '</td>' + 
						'	<td>' + json_parsed[index].MaxValue + '</td>' + 
						'	<td>' + json_parsed[index].LastValue + '</td>' + 
						'	<td>' + json_parsed[index].LastUpdateTime + '</td>' + 
						'</tr>'
		}
		
		
		
		$('#data_table').append(new_rows);
	});
}
