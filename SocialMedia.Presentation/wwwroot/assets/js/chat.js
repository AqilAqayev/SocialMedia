const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

const chatArea = document.querySelector(".messages-list");

connection.on("ReceiveMessage", (message) => {
    try {
        // Tarix obyektini yarat və formatla
        const date = new Date(message.createdTime);
        if (isNaN(date.getTime())) {
            console.error("Invalid date format:", message.createdTime);
            return; // Tarix düzgün deyilsə, mesajı əlavə etmirik
        }

        const formattedTime = date.toLocaleTimeString('en-US', {
            hour: 'numeric',
            minute: 'numeric',
            hour12: true
        });

        // Mesajı HTML-ə əlavə et
        chatArea.innerHTML += ` <li class="message received">
                                    <div class="text">${message.text}</div>  
                                    <time>${formattedTime}</time>
                                </li>`;
    } catch (err) {
        console.error("Error formatting message:", err);
    }
});

connection.start().catch(err => console.error("SignalR connection error:", err));
