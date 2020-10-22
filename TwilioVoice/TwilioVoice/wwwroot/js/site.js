$(document).ready(function () {
    $.post("/Token/Generate", { page: window.location.pathname }, function (data) {
        Twilio.Device.setup(data.token);
    });
});

function hangUp() {
    Twilio.Device.disconnectAll();
}

function callCustomer() {
    var phoneNumber = $('#txtphnNumber').val();
    var params = { "phoneNumber": phoneNumber };
    Twilio.Device.connect(params);
}

Twilio.Device.disconnect(function (connection) {
    alert('call disconnected');
});

Twilio.Device.connect(function (connection) {
    if ("phoneNumber" in connection.message) {
        alert('Call started');
    }
});

Twilio.Device.error(function (error) {
    alert('Error - Unable to connect');
});