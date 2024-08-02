const lbl_houseJoined = document.getElementById("lbl_houseJoined");


const btn_un_gryffindor = document.getElementById("btn_un_gryffindor");
const btn_un_slytherin = document.getElementById("btn_un_slytherin");
const btn_un_hufflepuff = document.getElementById("btn_un_hufflepuff");
const btn_un_ravenclaw = document.getElementById("btn_un_ravenclaw");
const btn_gryffindor = document.getElementById("btn_gryffindor");
const btn_slytherin = document.getElementById("btn_slytherin");
const btn_hufflepuff = document.getElementById("btn_hufflepuff");
const btn_ravenclaw = document.getElementById("btn_ravenclaw");

const trigger_gryffindor = document.getElementById("trigger_gryffindor");
const trigger_slytherin = document.getElementById("trigger_slytherin");
const trigger_hufflepuff = document.getElementById("trigger_hufflepuff");
const trigger_ravenclaw = document.getElementById("trigger_ravenclaw");


//create connection
var connectionHouse = new signalR.HubConnectionBuilder()
    //.configureLogging(signalR.LogLevel.Information)
    .withUrl("/hubs/houseGroup").build();

btn_gryffindor.addEventListener("click", function (event) {
    connectionHouse.send("JoinHouse", "Gryffindor");
    event.preventDefault();
});
btn_hufflepuff.addEventListener("click", function (event) {
    connectionHouse.send("JoinHouse", "Hufflepuff");
    event.preventDefault();
});
btn_ravenclaw.addEventListener("click", function (event) {
    connectionHouse.send("JoinHouse", "Ravenclaw");
    event.preventDefault();
});
btn_slytherin.addEventListener("click", function (event) {
    connectionHouse.send("JoinHouse", "Slytherin");
    event.preventDefault();
});


trigger_gryffindor.addEventListener("click", function (event) {
    connectionHouse.send("TriggerHouseNotify", "Gryffindor");
    event.preventDefault();
});
trigger_hufflepuff.addEventListener("click", function (event) {
    connectionHouse.send("TriggerHouseNotify", "Hufflepuff");
    event.preventDefault();
});
trigger_ravenclaw.addEventListener("click", function (event) {
    connectionHouse.send("TriggerHouseNotify", "Ravenclaw");
    event.preventDefault();
});
trigger_slytherin.addEventListener("click", function (event) {
    connectionHouse.send("TriggerHouseNotify", "Slytherin");
    event.preventDefault();
});

trigger_gryffindor.addEventListener("click", function (event) {
    connectionHouse.send("TriggerHouseNotify", "Gryffindor");
    event.preventDefault();
});
trigger_hufflepuff.addEventListener("click", function (event) {
    connectionHouse.send("TriggerHouseNotify", "Hufflepuff");
    event.preventDefault();
});
trigger_ravenclaw.addEventListener("click", function (event) {
    connectionHouse.send("TriggerHouseNotify", "Ravenclaw");
    event.preventDefault();
});
trigger_slytherin.addEventListener("click", function (event) {
    connectionHouse.send("TriggerHouseNotify", "Slytherin");
    event.preventDefault();
});

btn_un_gryffindor.addEventListener("click", function (event) {
    connectionHouse.send("LeaveHouse", "Gryffindor");
    event.preventDefault();
});
btn_un_hufflepuff.addEventListener("click", function (event) {
    connectionHouse.send("LeaveHouse", "Hufflepuff");
    event.preventDefault();
});
btn_un_ravenclaw.addEventListener("click", function (event) {
    connectionHouse.send("LeaveHouse", "Ravenclaw");
    event.preventDefault();
});
btn_un_slytherin.addEventListener("click", function (event) {
    connectionHouse.send("LeaveHouse", "Slytherin");
    event.preventDefault();
});

connectionHouse.on("triggerHouseNotification", (houseName) => {
    toastr.success(`A new notification for ${houseName} has been launched.`);
});

connectionHouse.on("newMemberAddedToHouse", (houseName) => {
    toastr.success(`Member has subscribed to ${houseName}`);
});

connectionHouse.on("newMemberRemovedFromHouse", (houseName) => {
    toastr.warning(`Member has unsubscribed from ${houseName}`);
});

connectionHouse.on("newMemberAddedToHouse", (houseName) => {
    toastr.success(`Member has subscribed to ${houseName}`);
});

connectionHouse.on("newMemberRemovedFromHouse", (houseName) => {
    toastr.warning(`Member has unsubscribed from ${houseName}`);
});

connectionHouse.on("triggerHouseNotification", (houseName) => {
    toastr.success(`A new notification for ${houseName} has been launched.`);
});

connectionHouse.on("subscriptionStatus", (strGroupsJoined, houseName, hasSubscribed) => {
    lbl_houseJoined.innerText = strGroupsJoined;

    if (hasSubscribed) {

        switch (houseName) {
            case 'slytherin':
                btn_slytherin.style.display = "none";
                btn_un_slytherin.style.display = "";
                break;
            case 'gryffindor':
                btn_gryffindor.style.display = "none";
                btn_un_gryffindor.style.display = "";
                break;
            case 'hufflepuff':
                btn_hufflepuff.style.display = "none";
                btn_un_hufflepuff.style.display = "";
                break;
            case 'ravenclaw':
                btn_ravenclaw.style.display = "none";
                btn_un_ravenclaw.style.display = "";
                break;
            default:
                break;
        }

        toastr.success(`You have Subscribed Successfully. ${houseName}`);
    }
    else {
        switch (houseName) {
            case 'slytherin':
                btn_slytherin.style.display = "";
                btn_un_slytherin.style.display = "none";
                break;
            case 'gryffindor':
                btn_gryffindor.style.display = "";
                btn_un_gryffindor.style.display = "none";
                break;
            case 'hufflepuff':
                btn_hufflepuff.style.display = "";
                btn_un_hufflepuff.style.display = "none";
                break;
            case 'ravenclaw':
                btn_ravenclaw.style.display = "";
                btn_un_ravenclaw.style.display = "none";
                break;
            default:
                break;
        }

        toastr.success(`You have Unsubscribed Successfully. ${houseName}`);
    }

})
function fullfilled() {
    console.log("Connection to House Hub Successful");
}

function rejected() {
}


connectionHouse.start().then(fullfilled, rejected);


