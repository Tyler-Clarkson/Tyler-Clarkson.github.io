var attempt = 3; // Variable to count number of attempts.
var creds = { data: [
	{username: 'Tyler',
	password: 'Tyler1'},
	{username: 'Drake',
	pawword: 'Drake1'},
	{username: 'Fransico',
	pawword: 'Fransico1'},
	{username: 'Noah',
	pawword: 'Noah1'},
	{username: 'Gabriel',
	pawword: 'Gabriel1'}
]};
	

// Below function Executes on click of login button.
function validate() {
	var username = document.getElementById("username").value;
	var password = document.getElementById("password").value;
	if ( username == "test" && password == "test1") {
		alert ("Login successfully");
		window.location = "home.html"; // Redirecting to other page.
		return false;
	}
	else {
		attempt --;// Decrementing by one.
		alert("You have left "+attempt+" attempt;");
		// Disabling fields after 3 attempts.
		if ( attempt == 0) {
			document.getElementById("username").disabled = true;
			document.getElementById("password").disabled = true;
			document.getElementById("submit").disabled = true;
			return false;
		}
	}
}