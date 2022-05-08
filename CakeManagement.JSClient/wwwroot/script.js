let bakers = [];
let connection = null;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:53910/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BakerCreated", (user, message) => {
        getdata();
    });

    connection.on("BakerDeleted", (user, message) => {
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
    await fetch('http://localhost:53910/baker')
        .then(x => x.json())
        .then(y => {
            actors = y;
            //console.log(actors);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    actors.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.bakerID + "</td><td>"
        + t.bakerName + "</td><td>" +
        + t.salary + "</td><td>" +
        + t.workhours + "</td><td>" +
            `<button type="button" onclick="remove(${t.bakerID})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:53910/actor/' + id, {
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
    let name = document.getElementById('bakername').value;
    fetch('http://localhost:53910/actor', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { bakerName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}