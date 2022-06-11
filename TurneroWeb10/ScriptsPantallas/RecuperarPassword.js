$('#button').click(function (e) {
    e.preventDefault();
    console.log("entre");
    sendEmail();
});

function sendEmail() {

    Email.send({
        Host: "smtp.elasticemail.com",
        Username: "rominamerlo07@gmail.com",
        Password: "ADBD816C198A82C3D858A7156B2D24C5CD19",
        To: 'rominamerlo07@gmail.com',
        From: "rominamerlo07@gmail.com",
        Subject: "This is the subject",
        Body: "And this is the body"
    }).then(
        message => alert(message)
    );
}