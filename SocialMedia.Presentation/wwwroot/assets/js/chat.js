//const connection = new signalR.HubConnectionBuilder()
//    .withUrl("/chatHub")
//    .build();
//const chatArea = document.querySelector(".messages-list");
//connection.on("ReceiveMessage", (message) => {
//    console.log("Received message:", message);

//    const utcDateString = message.createdTime;
//    const date = new Date(utcDateString);

//    if (isNaN(date.getTime())) {
//        console.error("Invalid date format:", utcDateString);
//        return;
//    }

//    const hours = date.getUTCHours();
//    const minutes = date.getUTCMinutes().toString().padStart(2, "0");

//    const ampm = hours >= 12 ? "PM" : "AM";
//    const formattedHours = hours % 12 || 12;
//    const formattedTime = `${formattedHours}:${minutes} ${ampm}`;

//    chatArea.innerHTML += `<li class="message received">
//                                <div class="text">${message.text}</div>
//                                <time>${formattedTime}</time>
//                            </li>`;
//    console.log(message.createdTime);
//});

