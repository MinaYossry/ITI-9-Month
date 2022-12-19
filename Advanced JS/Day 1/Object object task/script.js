const linkedListObj = {
  data: [{ val: 10 }, { val: 20 }, { val: 30 }],
  push: function (value) {
    /*
     * Ensures only one argument is passed to the funtion and it's a number
     * The value must be greater than the last number in the queue
     */
    if (arguments.length === 1 && typeof value === "number") {
      if (this.data.length === 0 || this.data[this.data.length - 1].val < value) {
        this.data.push({ val: value });
        return this.data.length;
      } else {
        throw new RangeError("new value is smaller than the last number");
      }
    } else {
      throw new TypeError("Incorrect type, must be a number");
    }
  },
  enqueue: function (value) {
    /*
     * Ensures only one argument is passed to the funtion and it's a number
     * The value must be smaller than the first number in the queue
     */
    if (arguments.length === 1 && typeof value === "number") {
      if (this.data.length === 0 || this.data[0].val > value) {
        this.data.unshift({ val: value });
        return this.data.length;
      } else {
        throw new RangeError("new value is larger than the first number");
      }
    } else {
      throw new TypeError("Incorrect type, must be a number");
    }
  },
  insert: function (value) {
    let newIndex = 0;
    if (arguments.length === 1 && typeof value === "number") {
      if (this.findPos(value) === -1) {
        let newIndex = this.findCorrectPosition(value);
        this.data.splice(newIndex, 0, { val: value });
        return this.data.length;
      } else {
        throw new RangeError("number already exists");
      }
    } else {
      throw new TypeError("Incorrect input");
    }
  },
  findCorrectPosition: function (value) {
    newIndex = 0;
    for (newIndex = 0; newIndex < this.data.length; newIndex++) {
      if (this.data[newIndex].val > value) {
        return newIndex;
      }
    }
    return newIndex;
  },
  pop: function () {
    if (this.data.length > 0) {
      return this.data.pop().val;
    } else {
      throw new RangeError("Queue is already empty");
    }
  },
  /**
   *
   * search for the value in the queue
   * remove it if found, otherwise throw an error
   */
  remove: function (value) {
    let index = this.findPos(value);
    if (index !== -1) {
      this.data.splice(index, 1);
    } else {
      throw new RangeError("Value is not found");
    }
  },
  /**
   * remove the last value of the queue and returns it
   * if the queue is empty throw an error
   */
  dequeue: function () {
    if (this.data.length > 0) {
      return this.data.shift().val;
    } else {
      throw new RangeError("Queue is already empty");
    }
  },
  /**
   *
   * return a string containing all the numbers in the queue
   */
  display: function () {
    let output = "[ ";
    for (let i = 0; i < this.data.length; i++) {
      output += this.data[i].val + " ";
    }
    output += "]";
    return output;
  },
  /**
   * Ensures that all the values are unique
   */
  validate: function () {
    console.log(this.data);
    if (this.data.every(this.isUnique)) return true;
    throw new RangeError("Queue contains duplicates");
  },
  findPos: function (value) {
    let start = 0;
    let end = this.data.length - 1;
    let mid = (start + end) / 2;
    while (start <= end) {
      mid = Math.trunc((start + end) / 2);
      if (value > this.data[mid].val) start = mid + 1;
      else if (value < this.data[mid].val) end = mid - 1;
      else return mid;
    }
    return -1;
  },
  /*
   * Checks if a certain value in repeated in the queue or exist in a ceratin ranger
   */
  isUnique: function (value, startIndex, arr) {
    for (let i = startIndex + 1; i < arr.length; i++) {
      if (value.val === arr[i].val) return false;
    }
    return true;
  },
};
