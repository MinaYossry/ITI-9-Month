class Ticket {
    constructor(seatNum, flightNum, departAirport, arrivalAirport, travelDate) {
        this.seatNum = seatNum;
        this.flightNum = flightNum;
        this.departAirport = departAirport;
        this.arrivalAirport = arrivalAirport;
        this.travelDate = travelDate;
    }

    displayInfo() {
        return `Seat Number: ${this.seatNum}
Flight Number: ${this.flightNum}
Departure Airport: ${this.departAirport}
Arrival Airport: ${this.arrivalAirport}
Travel Date: ${this.travelDate}`;
    }
}

module.exports = {
    Ticket
}