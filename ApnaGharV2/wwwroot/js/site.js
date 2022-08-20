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
	$('.sub-type').not(this).prop('checked', false);
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


//javascript
function existingMember() {
    let str = '<partial name="ExistingMemberAddProperty" />';
    documemt.getElementById("memberCheck").innerHTML = str;
}

function newMember() {
    let str = '<partial name="NewMemberAddProperty" />';
    documemt.getElementById("memberCheck").innerHTML = str;
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



