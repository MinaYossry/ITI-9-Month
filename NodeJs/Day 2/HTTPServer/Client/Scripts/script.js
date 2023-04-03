function createTableRow(client) {
    const row = document.createElement("tr");

    const nameCell = document.createElement("td");
    nameCell.textContent = client.Name;
    row.appendChild(nameCell);

    const phoneCell = document.createElement("td");
    phoneCell.textContent = client.Phone;
    row.appendChild(phoneCell);

    const emailCell = document.createElement("td");
    emailCell.textContent = client.Email;
    row.appendChild(emailCell);

    const addressCell = document.createElement("td");
    addressCell.textContent = client.Address;
    row.appendChild(addressCell);

    return row;
}

function insertClientsData(clients) {
    const tableBody = document.querySelector("tbody");
    clients.forEach(client => {
        const row = createTableRow(client);
        tableBody.appendChild(row);
    });
}

fetch("clients.json")
    .then(response => {
        if (!response.ok) {
            throw new Error("Network response was not ok");
        }
        return response.json();
    })
    .then(data => {
        console.log(data);
        insertClientsData(data);
    })
    .catch(error => {
        console.error("Error fetching data:", error);
    });