var obj = {
    Name: "AAAAAAA",
    Address: "AAA",
    Age: 30
}

var handler = {
    set(target, prop, value) {
        if (target.hasOwnProperty(prop)) {
            if (prop == "Name" && typeof value == "string" && value.length >= 7)
                target[prop] = value.substring(0, 8);
            else if (prop == "Address" && typeof value == "string")
                target[prop] = value;
            else if (prop == "Age" && isFinite(value) && value >= 25 && value <= 60)
                target[prop] = value;
            else
                console.log(`Invalid value of ${prop}: ${value}`);
        }
        else
            console.log(`Invalid Property: ${prop}`);
    }
}

var ProxyObj = new Proxy(obj, handler)

//Invalid 
ProxyObj.Address = 456454654;
ProxyObj.Name = "dsdsd";
ProxyObj.Age = 65;

// Valid
ProxyObj.Address = "Valid Address";
ProxyObj.Name = "Valid Name";
ProxyObj.Age = 45;

console.log(ProxyObj);