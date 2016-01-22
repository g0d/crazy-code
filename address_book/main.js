/*
	Address Book - DEMO
	File: main.js
	Description: This is the app's main JS file
	Author: George Delaportas
	Copyright (C) 2016
*/

// Load JS only after full document has been loaded to avoid inconsistencies
window.onload = function()
{
	// Construct the address book class
	function address_book_class()
	{
		var ab = this;

		// Utilities
		function utilities_class()
		{
			var me = this;

			// Trace selected record
			this.selectedRecord = null;

			// Get HTML element details
			this.getElement = function(id)
			{
				return document.getElementById(id);
			};

			// Clear text fields
			this.clearFields = function()
			{
				var inputNodes = me.getElement('controls_side').getElementsByTagName('input');
				var i = 0;

				for (i = 0; i < inputNodes.length; i++)
				{
					inputNodes[i].className = '';
					inputNodes[i].value = '';
				}
			};

			// Validate form fields
			this.validateFields = function()
			{
				var fieldContents = null;
				var pattern = null;
				var result = false;
				var inputNodes = me.getElement('controls_side').getElementsByTagName('input');
				var i = 0;

				for (i = 0; i < inputNodes.length; i++)
				{
					inputNodes[i].className = '';
					fieldContents = inputNodes[i].value;

					switch (i)
					{
						case 0:
						case 1:
							// First & last name (Only English letters)
							pattern = new RegExp("^[a-z ,.'-]+$", "gi");
							break;
						case 2:
							// Email (Very simple approach)
							pattern = new RegExp("^\\S+@\\S+$", "gi");
							break;
						case 3:
							// Address (Only English letters)
							pattern = new RegExp("[A-Za-z0-9'\\.\\-\\s\\,]", "gi");
							break;
						case 4:
							// City (Only English letters)
							pattern = new RegExp("^[a-zA-Z]+(?:[\\s-][a-zA-Z]+)*$", "gi");
							break;
						case 5:
							// Zip (Very simple approach)
							pattern = new RegExp("^\\d{5}(?:[-\\s]\\d{4})?$", "gi");
							break;
						case 6:
							// Country (Only English letters)
							pattern = new RegExp("^[a-zA-Z ]*", "gi");
							break;
					}
					
					// Do not check optional fields if not filled by the user
					if (i > 2 && fieldContents === '')
						continue;

					// Test pattern
					result = pattern.test(fieldContents);

					if (!result)
					{
						alert('Validation error: Field is in wrong format!');

						inputNodes[i].className = 'validation_error';

						return false;
					}
				}

				return true;
			};

			// Clear selected records (Unselect all)
			this.clearSelected = function()
			{
				var liNodes = me.getElement('records').getElementsByTagName('li');
				var i = 0;

				for (i = 0; i < liNodes.length; i++)
					liNodes[i].className = '';
			};

			// Deselect all previously selected records and exit edit/delete mode
			this.deselectAll = function()
			{
				me.clearFields();
				me.clearSelected();

				me.getElement('button_add').removeAttribute('disabled');
				me.getElement('button_save').setAttribute('disabled', '');
				me.getElement('button_delete').setAttribute('disabled', '');
				me.getElement('button_deselect').setAttribute('style', 'visibility: hidden');
			};

			// Check for duplicate emails
			this.checkDuplicates = function()
			{
				var i = 0;
				var inputNodes = me.getElement('controls_side').getElementsByTagName('input');

				for (i = 0; i < ab.model.recordsDB.records.length; i++)
				{
					if (ab.model.recordsDB.records[i].Email == inputNodes[2].value && 
						me.selectedRecord != ab.model.recordsDB.records[i].ID)
					{
						alert('Error: The provided email already exists!');

						return true;
					}
				}

				return false;
			};
		}

		// Model
		function model_class()
		{
			// Initialize records DB
			this.recordsDB = {"records" : []};
		}

		// View
		function view_class()
		{
			var me = this;

			// Reload data inside the records list if local storage has previously saved data
			this.reloadData = function()
			{
				var records = localStorage.getItem('abRecords');

				if (records)
				{
					// Populate records DB
					ab.model.recordsDB = JSON.parse(records);

					var i = 0;
					var abDBRecords = ab.model.recordsDB.records;
					
					for (i = 0; i < abDBRecords.length; i++)
					{
						ab.utilities.getElement('records').innerHTML += '<li id="' + 'record-' + abDBRecords[i].ID + 
																		'" ' + 'data-id="' + abDBRecords[i].ID + '">' + 
																	    'ID: ' + abDBRecords[i].ID + ' - ' + 
																	    abDBRecords[i].Name + ' ' + 
																	    abDBRecords[i].Surname + '</li>';
					}

					for (i = 0; i < abDBRecords.length; i++)
					{
						ab.utilities.getElement('record-' + abDBRecords[i].ID).addEventListener("click", 
											 	ab.view.fetchSelectedRecord, false);
					}
				}
				else
					ab.utilities.getElement('records').innerHTML = '';
			};

			// Fetch information about the selected record
			this.fetchSelectedRecord = function(e)
			{
				var inputNodes = ab.utilities.getElement('controls_side').getElementsByTagName('input');
				var i = 0;

				ab.utilities.selectedRecord = ab.utilities.getElement(e.target.id).getAttribute('data-id');

				ab.utilities.clearFields();
				ab.utilities.clearSelected();

				ab.utilities.getElement(e.target.id).className = 'clicked';

				for (i = 0; i < ab.model.recordsDB.records.length; i++)
				{
					if (ab.model.recordsDB.records[i].ID == ab.utilities.selectedRecord)
					{
						inputNodes[0].value = ab.model.recordsDB.records[i].Name;
						inputNodes[1].value = ab.model.recordsDB.records[i].Surname;
						inputNodes[2].value = ab.model.recordsDB.records[i].Email;
						inputNodes[3].value = ab.model.recordsDB.records[i].Address;
						inputNodes[4].value = ab.model.recordsDB.records[i].City;
						inputNodes[5].value = ab.model.recordsDB.records[i].Zip;
						inputNodes[6].value = ab.model.recordsDB.records[i].Country;

						break;
					}
				}

				ab.utilities.getElement('button_add').setAttribute('disabled', '');
				ab.utilities.getElement('button_save').removeAttribute('disabled');
				ab.utilities.getElement('button_delete').removeAttribute('disabled');
				ab.utilities.getElement('button_deselect').setAttribute('style', 'visibility: visible');
			};
		}

		// Controller
		function controller_class()
		{
			var me = this;

			// Add new records
		 	this.addRecord = function()
			{
				if (!ab.utilities.validateFields())
					return false;

				if (ab.utilities.checkDuplicates())
					return false;			

				var newRecordID = 1;
				var maxRecordID = ab.model.recordsDB.records.length - 1;

				if (ab.model.recordsDB.records.length > 0)
					newRecordID = ab.model.recordsDB.records[maxRecordID].ID + 1;

				var newRecord = {"ID" 		: 	newRecordID,
								 "Name" 	: 	ab.utilities.getElement('first_name').value,
								 "Surname" 	: 	ab.utilities.getElement('last_name').value,
								 "Email" 	: 	ab.utilities.getElement('email').value,
								 "Address" 	: 	ab.utilities.getElement('address').value,
								 "City" 	: 	ab.utilities.getElement('city').value,
								 "Zip" 		: 	ab.utilities.getElement('zip').value,
								 "Country" 	: 	ab.utilities.getElement('country').value
								};
				ab.model.recordsDB.records.push(newRecord);

				localStorage.setItem('abRecords', JSON.stringify(ab.model.recordsDB));
				
				ab.utilities.clearFields();

				ab.utilities.getElement('records').innerHTML = '';
				ab.view.reloadData();

				alert('Record created!');
			};

			// Save records
			this.saveRecord = function()
			{
				if (!ab.utilities.validateFields())
					return false;

				if (ab.utilities.checkDuplicates())
					return false;	

				var i = 0;
				var updatedRecord = null;
				var success = false;

				for (i = 0; i < ab.model.recordsDB.records.length; i++)
				{
					if (ab.model.recordsDB.records[i].ID == ab.utilities.selectedRecord)
					{
						updatedRecord = {"ID" 		: 	ab.model.recordsDB.records[i].ID,
										 "Name" 	: 	ab.utilities.getElement('first_name').value,
										 "Surname" 	: 	ab.utilities.getElement('last_name').value,
										 "Email" 	: 	ab.utilities.getElement('email').value,
										 "Address" 	: 	ab.utilities.getElement('address').value,
										 "City" 	: 	ab.utilities.getElement('city').value,
										 "Zip" 		: 	ab.utilities.getElement('zip').value,
										 "Country" 	: 	ab.utilities.getElement('country').value
										};

						ab.model.recordsDB.records[i] = updatedRecord;
						
						localStorage.setItem('abRecords', JSON.stringify(ab.model.recordsDB));

						ab.utilities.getElement('records').innerHTML = '';
						ab.view.reloadData();

						ab.utilities.deselectAll();

						success = true;
						
						alert('Record saved!');
						
						break;
					}
				}

				if (!success)
					alert('Error: Record was not saved!');
			};

			// Delete existing records
			this.deleteRecord = function()
			{
				var i = 0;
				var success = false;

				for (i = 0; i < ab.model.recordsDB.records.length; i++)
				{
					if (ab.model.recordsDB.records[i].ID == ab.utilities.selectedRecord)
					{
						localStorage.clear();

						ab.model.recordsDB.records.splice(i, 1);
						
						localStorage.setItem('abRecords', JSON.stringify(ab.model.recordsDB));

						ab.utilities.getElement('records').innerHTML = '';
						ab.view.reloadData();

						ab.utilities.deselectAll();

						success = true;

						alert('Record deleted!');

						break;
					}
				}

				if (!success)
					alert('Error: Record was not deleted!');
			};

			// Initialize and check for Local Storage support (Edge & IE are buggy - Firefox, Chrome & Opera are fine)
			this.init = function()
			{
				if (typeof(Storage) === "undefined")
				{
					alert("Error: Incompatible or old browser!");

					ab.utilities.getElement('ab_frame').innerHTML = 
					'<div class="error">We are sorry but your browser does not support all technologies ' + 
					'for this app to run!</div>';

					return false;
				}

				ab.utilities.getElement('button_add').addEventListener("click", me.addRecord, false);
				ab.utilities.getElement('button_save').addEventListener("click", me.saveRecord, false);
				ab.utilities.getElement('button_delete').addEventListener("click", me.deleteRecord, false);
				ab.utilities.getElement('button_deselect').addEventListener("click", ab.utilities.deselectAll, false);

				ab.view.reloadData();

				return true;
			};
		}

		// Get MVC API calls ready
		this.utilities = new utilities_class();
		this.model = new model_class();
		this.view = new view_class();
		this.controller = new controller_class();
	}

	// Create Address Book object
	var addressBook = new address_book_class();

	// Intialize
	addressBook.controller.init();
};

/* - - - - - */
