const connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount").build();

connectionUserCount.on("updateTotalViews", (value) => {
    const newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value.toString();
});

connectionUserCount.on("updateTotalusers", (totalUsers) => {
    const newCountSpan = document.getElementById("totalUsersCounter");
    newCountSpan.innerText = totalUsers.toString();
});

function newWindowLoadedOnClient() {
    connectionUserCount.send("OnNewWindowLoaded");
}

function fullfilled() {
    console.log("Connection to user hub seccessful");
    newWindowLoadedOnClient();
}

function rejected() {
    console.log("Rejected");
}


connectionUserCount.start().then(fullfilled, rejected);


