"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messageHub").build();

// Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function(message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = message;
});

connection.start().then(function() {
    document.getElementById("sendButton").disabled = false;
}).catch(function(err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function(event) {
    var message = document.getElementById("messageInput").value;

    $.ajax({
        url: "/api/messages",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ message: message }),
        success: function() {
            document.getElementById("messageInput").value = "";
        },
        error: function (err) {
            return console.error(err.toString());
        }
    });

    event.preventDefault();
});