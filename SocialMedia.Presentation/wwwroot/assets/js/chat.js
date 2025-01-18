



const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();
const chatArea = document.querySelector(".messages-list");
connection.on("ReceiveMessage", (message) => {
    chatArea.innerHTML += ` <li class="message received">
                                <div class="text">${message.text}</div>
                                <time>${message.createdTime}</time>
                        </li>`;
});
connection.start().catch(err => console.error(err));