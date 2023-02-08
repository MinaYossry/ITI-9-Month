let x = 5;
let y = 6;
console.log(`Old Values: x:${x} y:${y}`);
[x, y] = [y, x];
console.log(`New Values: x:${x} y:${y}`);

// =============================== //

function minAndMax(arr) {
    if (arr != undefined && arr.length !== 0)
        return [Math.min(...arr), Math.max(...arr)];
    else
        return [0, 0]
}

const arr = [5, 3, 7, 9, 8, 6, 2, 10, 1, 0, 45, -5];
[min, max] = minAndMax(arr);
console.log(`Min: ${min}, Max: ${max}`);
[min, max] = minAndMax();
console.log(`Min: ${min}, Max: ${max}`);
// =================================== //

var fruits = ["apple", "strawberry", "banana", "orange",
    "mango"];

console.log(fruits.every(
    (current) => typeof current === "string"
));

console.log(fruits.some(
    (current) => current.charAt(0) == 'a'
));

console.log(fruits.filter(
    (current) => current.charAt(0) == 'b' || current.charAt(0) == 's'
));

const newArr = fruits.map(
    (current) => `I like ${current}`
);

newArr.forEach(
    (current) => console.log(current)
);
