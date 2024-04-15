$(document).ready(function() {
	recentWorkDoneHover();
	emailjs.init("PbWANJmnqX9D3Ig-Q");
});
function recentWorkDoneHover() {
	$('#recent-repair-1-before').on("click tap", function() {
		$('#recent-repair-1-after').removeClass('d-none');
		$('#recent-repair-1-before').addClass('d-none');
	});
	$('#recent-repair-1-after').on("click tap", function() {
		$('#recent-repair-1-before').removeClass('d-none');
		$('#recent-repair-1-after').addClass('d-none');
	});
	$('#recent-repair-2-before').on("click tap", function() {
		$('#recent-repair-2-after').removeClass('d-none');
		$('#recent-repair-2-before').addClass('d-none');
	});
	$('#recent-repair-2-after').on("click tap", function() {
		$('#recent-repair-2-before').removeClass('d-none');
		$('#recent-repair-2-after').addClass('d-none');
	});
	$('#recent-repair-3-before').on("click tap", function() {
		$('#recent-repair-3-after').removeClass('d-none');
		$('#recent-repair-3-before').addClass('d-none');
	});
	$('#recent-repair-3-after').on("click tap", function() {
		$('#recent-repair-3-before').removeClass('d-none');
		$('#recent-repair-3-after').addClass('d-none');
	});
}
	
const btn = document.getElementById('sendBtn');
const apptAside = document.getElementById('appt-aside');


document.getElementById('emailForm').addEventListener('submit', function(event) {
   event.preventDefault();

   btn.value = 'Sending...';

   const serviceID = 'service_83avsc7';
   const templateID = 'template_jl5cn3m';

   emailjs.sendForm(serviceID, templateID, this)
    .then(() => {
      apptAside.innerHTML = '<div class="fs-3 text-white text-center col">Thank you for requesting an appointment! We will be in touch soon!</div>';
    }, (err) => {
      btn.value = 'Request Appointment';
      alert(JSON.stringify(err));
    });
});

