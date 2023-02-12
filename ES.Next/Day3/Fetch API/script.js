function insertData(data) {
    var tableBody = document.querySelector(".table > tbody")
    data.forEach(row => {
        tableBody.appendChild(createRow(row));
    });
}

function createRow(data) {
    var row = document.createElement("tr");

    row.appendChild(createCell("th", data.id));
    row.appendChild(createCell("td", data.name));
    row.appendChild(createCell("td", data.username));
    row.appendChild(createCell("td", data.phone));
    row.appendChild(createCell("td", data.email));
    row.appendChild(createCell("td", data.website));
    row.appendChild(createCell("td", data.company.name));
    row.appendChild(createCell("td", data.address.city));

    return row;
}

function createCell(element, text) {
    var newElem = document.createElement(element);
    newElem.innerText = text;
    return newElem;
}



fetch("https://jsonplaceholder.typicode.com/users")
    .then((response) => response.json()
        .then((data) => insertData(data)))
    .catch((error) => console.log(error));