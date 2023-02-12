class Polygon {
    constructor(x, y, width, height) {
        if (this.constructor != Polygon) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }

    calcArea() {
        return this.width * this.height;
    }
}

class Rectangle extends Polygon {
    constructor(x, y, width, height) {
        super(x, y, width, height);
    }

    draw(context) {
        context.rect(this.x, this.y, this.width, this.height);

        context.lineWidth = 10;
        context.strokeStyle = '#666666';
        context.stroke();

        context.fillStyle = "#FFCC00";
        context.fill();
    }

    toString() {
        console.log(` Rectangle
        Origin Point (${this.x}, ${this.y})
        Width: ${this.width}
        height: ${this.height}
        Area: ${this.calcArea()}
        `);
    }
}

class Square extends Rectangle {
    constructor(x, y, length) {
        super(x, y, length, length);
    }

    toString() {
        console.log(` Square
        Origin Point (${this.x}, ${this.y})
        Length: ${this.width}
        Area: ${this.calcArea()}
        `);
    }
}

class Triangle extends Polygon {
    constructor(x, y, width, height) {
        super(x, y, width, height);
    }

    draw(context) {
        context.beginPath();
        context.moveTo(this.x, this.y);
        context.lineTo(this.x, this.y + this.height);
        context.lineTo(this.x + this.width, this.y + this.height);
        context.closePath();

        context.lineWidth = 10;
        context.strokeStyle = '#666666';
        context.stroke();

        context.fillStyle = "#FFCC00";
        context.fill();
    }

    calcArea() {
        return super.calcArea() * 0.5;
    }

    toString() {
        console.log(` Triangle
        Origin Point (${this.x}, ${this.y})
        Base: ${this.width}
        Height: ${this.height}
        Area: ${this.calcArea()}
        `);
    }
}

class Cricle extends Polygon {
    constructor(x, y, diameter) {
        super(x, y, diameter, diameter);
    }

    draw(context) {
        context.beginPath();
        context.arc(this.x, this.y, this.width / 2, 0, 2 * Math.PI);
        context.stroke();

        context.fillStyle = "#FFCC00";
        context.fill();
    }

    calcArea() {
        return Math.PI * Math.pow(this.width, 2) / 4;
    }
    toString() {
        console.log(` Cricle
        Origin Point (${this.x}, ${this.y})
        Diameter: ${this.width}
        Area: ${this.calcArea()}
        `);
    }
}

var canvas = document.querySelector("#canvas");
var context = canvas.getContext("2d");



var sq = new Square(250, 250, 150);
sq.toString();
sq.draw(context);

var rec = new Rectangle(250, 10, 150, 200);
rec.toString();
rec.draw(context);

var tri = new Triangle(10, 10, 150, 200);
tri.toString();
tri.draw(context);

var cir = new Cricle(150, 500, 200);
cir.toString();
cir.draw(context);

