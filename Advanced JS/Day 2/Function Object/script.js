var CustomObject = function (_id, _location, _addr) {
  this.id = _id;
  this.location = _location;
  this.addr = _addr;

  this.getSetGen = function () {
    // Get all properties of the caller object
    var allProps = Object.keys(this);

    for (var prop = 0; prop < allProps.length; prop++) {
      if (typeof this[allProps[prop]] !== "function") {
        // create property key for the setter and getter
        var set = `set${allProps[prop]}`;
        var get = `get${allProps[prop]}`;

        this[set] = function (prop) {
          return function (value) {
            this[allProps[prop]] = value;
          }
        }(prop);

        this[get] = function (prop) {
          return function () {
            return this[allProps[prop]];
          }
        }(prop);

      }
    }
  };
};

var user = {
  name: "Ali",
  age: 10,
};

var obj = new CustomObject(1, "loc", "add");
console.log(Object.keys(obj));
obj.getSetGen();
console.log(Object.keys(obj));

console.log(Object.keys(user));
obj.getSetGen.apply(user);
console.log(Object.keys(user));