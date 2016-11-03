<?php
	// Sponsorship model
	class Sponsorship
	{
		public function listSponsoships()
		{
			// --- NOT IMPLEMENTED: Fetch sponsorships from DB in JSON format ---
			// SAMPLE CODE: $sponsorships = DB:Fetch_Content('sponsorships_field');
			// Reference: http://php.net/manual/en/function.json-decode.php
			// JSON in DB is like:
				/*
				[
					{
						uid : '1',
						name : 'Sportex Shoes',
						descr : 'Sportex shoes for the local team of Hamburg',
						duration : 0,
						expenses : 42.000
					 },
					 ... more ...
				 ]
				*/
			// -----
			
			// For test purposes I will fill the variable with the above test JSON
			$sponsorships = "{uid:'1',name:'Sportex Shoes',descr:'Sportex shoes for the local team of Hamburg',duration:0,expenses:42.000}";
			
			return $sponsorships;
		}
		
		public function addSponsorship($sponsorship_JSON)
		{
			if (empty($sponsorship_JSON))
				return false;
			
			$sponsorships = array();
			
			// --- NOT IMPLEMENTED: 
			// 1. Fetch sponsorships from DB in JSON format
			// 2. SAMPLE CODE: $sponsorships = json_decode(DB:Fetch_Content('sponsorships_field'));
			// 3. Convert $sponsorship_JSON to a PHP variable - $new_sponsorship = json_decode($sponsorship_JSON); 
			// 4. PUSH NEW sponsorship to the table: array_push($sponsorships, $new_sponsorship);
			// 5. ENCODE to JSON format: $updated_sponsorships_JSON = json_encode($sponsorships);
			// 6. Add $updated_sponsorships_JSON to DB in sponsorships table as JSON ---
			// 7. CHECK FOR ERRORS and reuturn false;
			
			// If OK
			return true;
		}
	}
?>
