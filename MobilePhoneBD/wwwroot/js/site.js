// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function GetMan() {
    const url = "/api/Api/GetMan?"
    const xhr = new XMLHttpRequest()
    var Id = document.getElementById("cat").value
    xhr.open("GET", url + "catId=" + Id)
    xhr.onload = () => {
        if (xhr.status == 200) {
            var list = JSON.parse(xhr.response)
            console.log(list)
            var sel = document.getElementById("man")
            while (sel.childNodes.length) {
                if (sel.firstChild.tagName == 'option') {
                    while (sel.firstChild.childNodes.length) {
                        sel.firstChild.removeChild(sel.firstChild.firstChild);
                    }
                }
                sel.removeChild(sel.firstChild);
            }
             list.forEach(function (lt) {
                let opt = document.createElement("option");
                opt.value = lt["id"]
                opt.text = lt["name"]
                sel.add(opt)
            })
        }
    }
    xhr.send()
}


