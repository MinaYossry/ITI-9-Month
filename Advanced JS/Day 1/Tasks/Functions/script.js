function reverseParams1() {
  return Array.prototype.reverse.call(arguments);
}

function reverseParams2() {
  return Array.prototype.reverse.bind(arguments);
}

function onlyTwo(a, b) {
  if (arguments.length === 2) {
    console.log("Correct");
  } else {
    throw new Error("Incorrect number of argumnets");
  }
}

function adding() {
  if (arguments.length !== 0) {
    var sum = 0;
    for (var i = 0; i < arguments.length; i++) {
      if (typeof arguments[i] === "number") sum += arguments[i];
      else throw new TypeError("Incorrect type");
    }
    return sum;
  } else throw Error("Arguments cant be empty");
}

var reverse = reverseParams2(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

console.log(reverseParams1(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
console.log(reverse());
