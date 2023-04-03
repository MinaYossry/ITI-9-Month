const Tickets = require("./TicketModule.js");

let t01 = new Tickets.Ticket(20, 4897, "Cairo", "JFK", new Date(2023, 2, 29))


console.log(t01.displayInfo());

let t02 = new Tickets.Ticket(45, 1597, "JFK", "Cairo", new Date(2023, 3, 1));

console.log(t02.displayInfo());

t01.flightNum = 985;
console.log(t01.displayInfo());