//#region Task1
function genCourse(course) {
    var defaultCourse = {
        courseName: "ES6",
        courseDuration: "3days",
        courseOwner: "JavaScript"
    };

    var result = Object.assign({}, defaultCourse, course)

    if (Object.keys(result).length != Object.keys(defaultCourse).length)
        throw new Error("Invalid properties")

    return result;
}

console.log("Task 1");
console.log(genCourse({
    courseName: "Course",
    courseDuration: "Duration",
    courseOwner: "Owner"
}));

console.log(genCourse({
    courseName: "Name",
}));

// console.log(genCourse({
//     cn: "Name",
// }));

//#endregion

//#region Task 2A
function* fibA(n) {
    var first = 0, second = 1, i = 0;
    while (i < n) {
        var output = first;
        var temp = first + second
        first = second;
        second = temp;
        i++;
        yield output;
    }
}

console.log("Task 2A");
var iterA = fibA(6);
console.log(iterA.next());
console.log(iterA.next());
console.log(iterA.next());
console.log(iterA.next());
console.log(iterA.next());
console.log(iterA.next());
console.log(iterA.next());
//#endregion

//#region Task 2B
function* fibB(n) {
    var first = 0, second = 1;
    while (first <= n) {
        var output = first;
        var temp = first + second
        first = second;
        second = temp;
        yield output;
    }
}

console.log("Task 2B");
var iterB = fibB(5);
console.log(iterB.next());
console.log(iterB.next());
console.log(iterB.next());
console.log(iterB.next());
console.log(iterB.next());
console.log(iterB.next());
console.log(iterB.next());
//#endregion

//#region Task 3
var replaceObj = {
    [Symbol.replace]: function (str, length) {
        if (str.length > length) {
            return str.substring(0, length) + "...";
        }
        else
            return str;
    }
}

console.log("Task 3");


console.log("AAAAAAAAAAAAAA".replace(replaceObj, 15));
console.log("AAAAAAAAAAAAAAAAAAAAA".replace(replaceObj, 15));
//#endregion

//#region Task 4
var iterObj = {
    prop1: "value1",
    prop2: "value2",
    prop3: "value3",
    prop4: "value4",
    prop5: "value5",

    genFun: function* () {
        var keys = Object.keys(this);
        for (const key of keys) {
            if (key != "genFun")
                yield [key, this[key]];
        }
    }
}

console.log("Task 4");
for (const iterator of iterObj.genFun()) {
    console.log(iterator);
}
//#endregion