let cake = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:1165/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CakeCreated", (user, message) => {
        getdata();
    });

    connection.on("CakeDeleted", (user, message) => {
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
     fetch('http://localhost:1165/cake')
        .then(x => x.json())
        .then(y => {
            cake = y;
            //console.log(actors);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    cake.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
        + t.name + "</td><td>" +
        + t.shape + "</td><td>" +
        + t.color + "</td><td>" +
        + t.price + "</td><td>" +
        + t.bakerid + "</td><td>" +
        + t.deliveryid + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:1165/cake/' + id, {
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
    let name = document.getElementById('cakename').value;
    let shape = document.getElementById('cakeshape').value;
    let color = document.getElementById('cakecolor').value;
    let price = document.getElementById('cakeprice').value;
    let bakerid = document.getElementById('bakerid').value;
    let deliveryid = document.getElementById('deliveryid').value;
    fetch('http://localhost:1165/cake', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, shape : shape,color:color, price : price, bakerid : bakerid, deliveryid : deliveryid })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
