var dataField;
var submit;
var to;

onload = function() {
    this.alert("you have 30 seconds to enter you data");

    dataField = this.document.getElementById("data");
    submit = this.document.getElementById("submit");

    submit.addEventListener("click", function () {
        if (dataField.value == "")
            this.alert("data can't be empty");
        else {
            var conf = confirm("Do you want to submit?");
            if (conf)
                location.assign("https://www.google.com/");
        }
    })

    to = setTimeout(() => {
        if (dataField.value == "") {
            this.alert("you haven't entered any data .. aborted");
            this.location.assign("https://www.google.com/");
        }
    }, 5000);
}