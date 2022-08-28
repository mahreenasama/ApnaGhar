// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//---------------------------Add property page----------------

//limit only one checkbox to be selected at a time
$('.purpose').on('change', function () {
	$('.purpose').not(this).prop('checked', false);
});
$('.type').on('change', function () {
	$('.type').not(this).prop('checked', false);
});
function SubtypeChange() {
	/*alert('subtype');*/
	//$('.sub-type').not(this).prop('checked', false);
}

//display in respective divs
$(document).ready(function () {
	$('.type').click(function () {
		var iid = $(this).attr('id');
		$.get('/Property/GetSubCategories', { id: iid }, function (result) {
			$('#sub-categories').html(result);
		});
	});
	$('#select-city').change(function () {
		var cityy = $(this).val();
		//alert(cityy);
		$.get('/Property/GetCityLocations', { city: cityy }, function (result) {
			let str = "<option disabled selected>Select Area</option>";
			for (let i = 0; i < result.length; i++) {
				//str += `<option value="${result[i]}">`
				str += "<option>" + result[i] + "</option>";
			}
			//alert(str);
			$('#citylocations').html(str);
		});
	});
});
/*$(document).ready(function () {
	
})*/


//---------------------------function to be called on property submit form----------------
function submitProperty() {
	var data = $("#addPropertyForm").serialize();
	console.log(data);
	alert(data);
	$.ajax({
		type: 'POST',
		url: '/Property/AddProperty',
		contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
		// when we use .serialize() 
		// this generates the data in query string format. 
		// this needs the default contentType 
		// (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') 
		// so it is optional, you can remove it
		data: data,
		success: function (result) {
			alert('Successfully received Data ');
			console.log(result);
		},
		error: function () {
			alert('Failed to receive the Data');
			console.log('Failed ');
		}
	})
}
function registerUser() {
	var data = $("#RegistrationForm").serialize();
	console.log(data);
	alert(data);
	$.ajax({
		type: 'POST',
		url: '/User/Register',
		contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
		// when we use .serialize() 
		// this generates the data in query string format. 
		// this needs the default contentType 
		// (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') 
		// so it is optional, you can remove it
		data: data,
		success: function (result) {
			alert('Successfully received Data ');
			console.log(result);
		},
		error: function () {
			alert('Failed to receive the Data');
			console.log('Failed ');
		}
	})
}

//------------------------------Query form-----------------
function SubmitEnquiry() {
	var data = $("#enquiry-form").serialize();
	console.log(data);
	alert(data);
	$.ajax({
		type: 'POST',
		url: '/Enquiry/SubmitEnquiry',
		contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
		// when we use .serialize() 
		// this generates the data in query string format. 
		// this needs the default contentType 
		// (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') 
		// so it is optional, you can remove it
		data: data,
		success: function (result) {
			alert('Successfully submitted enquiry');
			console.log(result);
		},
		error: function () {
			alert('Failed to receive the Data');
			console.log('Failed ');
		}
	})
}




function sendmail() {

	var name = $('#sender_name').val();
	var email = $('#sender_email').val();
	var pnum = $('#sender_phone').val();
	var subject = $('#sender_subject').val();
	var message = $('#sender_message').val();

	// var body = $('#body').val();

	var Body = 'Name: ' + name + '<br>Email: ' + email + '<br>Email: '+pnum+ '<br>Subject: ' + subject + '<br>Message: ' + message;
	//console.log(name, phone, email, message);

	Email.send({
		Host: "smtp.gmail.com",
		Username: "mahreenmehar202@gmail.com",
		Password: "MEHAR2002",
		To: 'mahreenmehar202@gmail.com',
		From: email,
		Subject: "New message on contact from " + name,
		Body: message
	}).then(
		message => {
			console.log (message);
			if (message == 'OK') {
				alert('Your mail has been send. Thank you for connecting.');
			}
			else {
				console.error(message);
				alert('There is error at sending message. ')

			}

		}
	);



}



