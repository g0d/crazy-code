// Initialize
function bootstrap()
{
	// Initialize libraries
	var my_bull = new bull();
	var my_vulcan = new vulcan();
	var my_lava = new lava();
	
	// Initialize models
	var sponsorships = [];
	var sponsorship_model = {
								uid : '',
								name : '',
								descr : '',
								duration : 0,
								expenses : 0.0
							};
	
	// Sort based on selected option
	function sort_criteria(criteria)
	{
		function compare(a, b)
		{console.log(a[criteria]);
			if (a[criteria] < b[criteria])
				return -1;
			
			if (a[criteria] > b[criteria])
				return 1;
			
			return 0;
		}
		
		sponsorships.sort(compare);
	}
	
	// Sort sponsorship delegate
	function sort_it()
	{
		var sort_by = my_vulcan.objects.by_id('sort_by');
		var selected_option = sort_by.options[sort_by.options.selectedIndex].value;
		
		sort_criteria(selected_option);
		
		clean_sponsoships();
		
		var index;
		for (index = 0; index < sponsorships.length; index++)
			draw_sponsoship(sponsorships[index]);
		
		return true;
	}

	// Filter sponsorship delegate
	function filter_it(key_event)
	{
		if (key_event.keyCode === 13) // Enter button
		{
			clean_sponsoships();
			
			var search_name = my_vulcan.objects.by_id('search').value;
			var index;
			for (index = 0; index < sponsorships.length; index++)
			{
				if (sponsorships[index].name.indexOf(search_name))
					draw_sponsoship(sponsorships[index]);
			}
			
			return true;
		}
		
		return false;
	}

	// Open popup delegate
	function open_popup()
	{
		var pop_up_object = my_vulcan.objects.by_id('pop_up');
		pop_up_object.style.visibility = 'visible';
		
		return true;
	}

	// Close popup delegate
	function close_popup()
	{
		var pop_up_object = my_vulcan.objects.by_id('pop_up');
		pop_up_object.style.visibility = 'hidden';
		
		return true;
	}

	// Add new sponsorship delegate
	function add_new_sponsorship()
	{
		var validate_inputs = [
								{
									key:
											{
												id:	'name',
												optional: false
											},
									value:
											{
												type: 'string',	
												length:	20
											},
								},
								{
									key:
											{
												id:	'descr',
												optional: true
											},
									value:
											{
												type: 'string',	
												length:	50
											},
								},
								{
									key:
											{
												id:	'duration',
												optional: false
											},
									value:
											{
												type: 'string',	
												length:	3,
												regex: /^[0-9]+$/
											},
								},
								{
									key:
											{
												id:	'expenses',
												optional: false
											},
									value:
											{
												type: 'string',	
												length:	9,
												regex: /^[+-]?\d+(\.\d+)?$/
											},
								}
							  ];
		
		my_lava.define(validate_inputs);
		
		if (my_lava.validate() && my_vulcan.objects.by_id('name').value !== '')
		{
			var new_random_id = (Math.random() * (255 - 2) + 2).toString();
			var new_sponsorship_model = {
											uid : new_random_id,
											name : my_vulcan.objects.by_id('name'),
											descr : my_vulcan.objects.by_id('descr'),
											duration : parseInt(my_vulcan.objects.by_id('duration')),
											expenses : parseFloat(my_vulcan.objects.by_id('expenses'))
										};
			
			draw_sponsoship(new_sponsorship_model);
			
			var json_data = JSON.stringify(new_sponsorship_model);
			
			// Send new record to the server (Asynchronous POST request)
			my_bull.request('/server.php', 'sponsorship=' + json_data + '&add=1', 1, 
                        function(response)
                        {
                            if (!my_vulcan.validation.misc.is_nothing(response) && response !== '0')
                            {
                                alert('Success: New sponsorship added!');

                                return true;
                            }
                            else
                            {
                                // SERVER ERROR RESPONSE

                                return false;
                            }
                        }, 60000, null, 
                        function(response)
                        {
                            // CONNECTION ISSUES RESPONSE

                            return false;
                        });
			
			return true;
		}
		
		alert("Error: Some fields are inconsistent!");
		return false;
	}
	
	// Draw sponsorships
	function draw_sponsoship(sponsorship_model)
	{
		// --- NOT IMPLEMENTED: DESIGN HTML5 ELEMENTS AND DRAW BASED ON THE DESIGNED MODEL AT LINE: 35 OF "dashboard.html" ---
		
		return true;
	}
	
	// Clean sponsorships
	function clean_sponsoships()
	{
		// --- NOT IMPLEMENTED: CLEAN ALLA SPONSORSHIPS TO ENABLE REDAW BASED ON CRITERIA ---
		
		return true;
	}
	
	// Preload test sponsorships
/* 	var spons_test = {
						uid : '1',
						name : 'Sportex Shoes',
						descr : 'Sportex shoes for the local team of Hamburg',
						duration : 0,
						expenses : 42.000
					 };
	sponsorships.push(spons_test);

	spons_test = {
					uid : '2',
					name : 'T-Shirts',
					descr : 'T-Shirts for the local team of Hamburg',
					duration : 0,
					expenses : 11.200
				 };
	sponsorships.push(spons_test);
	
	spons_test = {
					uid : '3',
					name : 'Just a Test',
					descr : 'Testing...',
					duration : 8,
					expenses : 7000
				 };
	sponsorships.push(spons_test);
	*/
	
	// Attach events to tools/controls
	var sort_by_object = my_vulcan.objects.by_id('sort_by');
	my_vulcan.events.attach('sort_by', sort_by_object, 'change', sort_it);
	
    var search_object = my_vulcan.objects.by_id('search');
	my_vulcan.events.attach('search', search_object, 'keydown', function(event) { filter_it(event); });
	
    var new_sponsorship_button_object = my_vulcan.objects.by_id('new_sponsorship');
	my_vulcan.events.attach('new_sponsorship', new_sponsorship_button_object, 'click', open_popup);
	
    var new_sponsorship_button_object = my_vulcan.objects.by_id('add_sponsorship');
	my_vulcan.events.attach('add_sponsorship', new_sponsorship_button_object, 'click', add_new_sponsorship);
	
	var close_sponsorship_button_object = my_vulcan.objects.by_id('close_sponsorship');
	my_vulcan.events.attach('close_sponsorship', close_sponsorship_button_object, 'click', close_popup);
	
	// Fetch all records from the server (Asynchronous POST request)
	my_bull.request('/server.php', 'list=1', 1, 
				function(response)
				{
					if (!my_vulcan.validation.misc.is_nothing(response) && response !== '0')
					{
						sponsorships.push(JSON.parse(JSON.stringify(response)));
						
						// Draw all available sponsorships
						var index;
						for (index = 0; index < sponsorships.length; index++)
							draw_sponsoship(sponsorships[index]);
						
						console.log(sponsorships);
						alert('Success: All sponsorships retrieved!');

						return true;
					}
					else
					{
						// SERVER ERROR RESPONSE

						return false;
					}
				}, 60000, null, 
				function(response)
				{
					// CONNECTION ISSUES RESPONSE

					return false;
				});
	
	return true;
}

// Execute bootstraping
document.addEventListener("DOMContentLoaded", function(event) { (bootstrap)(event); });
