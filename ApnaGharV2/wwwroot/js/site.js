// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


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
		Username: "arhammubeen2004@gmail.com",
		Password: "arhammian1406",
		To: 'arhammubeen2004@gmail.com',
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



