// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$(document).ready(function () {
	/*$('#filter-btn').click(function () {

		alert("f b click");

		var cityy = $("#filter-city").val(),
		var	purposee = $("#filter-purpose").val(),
		var	typee = $("#filter-type").val(),

			$.post('Property/FilterProperties', { city: cityy, purpose: purposee, type:typee }, function (result) {
				alert(result);

			$('#seacrh-bar-result-div').html(str);
		})

	})*/

	$('#select-city').change(function () {

		var cityy = $(this).val();

		$.get('/Property/GetCityLocations', { city: cityy }, function (result) {
			let str = '<option selected value="' + result[0] + '">' + result[0] + '</option>';
			for (let i = 1; i < result.length; i++) {
				str += '<option value="' + result[i] + '">' + result[i] + '</option>';
			}
			$('#citylocations').html(str);
		});
	});
});


//---------------------------filter btn----------------
function filterAll() {
	var data = $("#all-prop-filter-form").serialize();
	alert(data)
	$.ajax({
		type: 'POST',
		url: '/Property/FilterProperties',
		contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
		// when we use .serialize() 
		// this generates the data in query string format. 
		// this needs the default contentType 
		// (default content type is: contentType: 'application/x-www-form-urlencoded; charset=UTF-8') 
		// so it is optional, you can remove it
		data: data,
		success: function (result) {
			alert(result);
			//$("#filter-div").html = "";
			//$("#filter-div").html = result;
			console.log(document.getElementById('filter-div').innerHTML);
			document.getElementById('filter-div').innerHTML = result;
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



