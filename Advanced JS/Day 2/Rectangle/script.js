var Rectangle = function (_width, _height) {
  this.width = _width;
  this.height = _height;
  this.calcArea = function () {
    return this.width * this.height;
  };
  this.calcPerimeter = function () {
    return 2 * (this.width + this.height)
  };
  this.displayInfo = function () {
    return `Width = ${this.width}, Height = ${this.height}, Area = ${this.calcArea()}, Perimeter = ${this.calcPerimeter()}`;
  }
};

var rec1 = new Rectangle(5, 6);
var rec2 = new Rectangle(10, 20);