$(document).ready(function() {
	emailjs.init("PbWANJmnqX9D3Ig-Q");
});

const btn = document.getElementById('submitButton');
const formContainer = document.getElementById('form-container');


document.getElementById('emailForm').addEventListener('submit', function(event) {
   event.preventDefault();

   btn.value = 'Sending...';

   const serviceID = 'service_83avsc7';
   const templateID = 'template_6i9hxpr';

   emailjs.sendForm(serviceID, templateID, this)
    .then(() => {
      formContainer.innerHTML = '<div class="fs-3 text-black text-center col">Thank you for reaching out. We have recieved your message and will be in touch soon.</div>';
    }, (err) => {
      btn.value = 'Submit';
      alert(JSON.stringify(err));
    });
});

