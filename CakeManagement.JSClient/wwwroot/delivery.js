let deliveries = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:1165/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("DeliveryCreated", (user, message) => {
        getdata();
    });

    connection.on("DeliveryDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
     fetch('http://localhost:1165/delivery')
        .then(x => x.json())
        .then(y => {
            delivery = y;
            //console.log(actors);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    delivery.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
        + t.person + "</td><td>" +
        + t.income + "</td><td>" +
        + t.mins + "</td><td>" +
        + t.schedule + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:1165/delivery/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('personName').value;
    let income = document.getElementById('income').value;
    let mins = document.getElementById('mins').value;
    let schedule = document.getElementById('schedule').value;
    fetch('http://localhost:1165/cake', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { person: name, income : income, mins:mins, schedule : schedule })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}