function Toggle(id) {

    var elements = document.getElementsByClassName(id);
    for (const x of elements) {
        if (x.style.display === "none") {
            x.style.display = "block";
        } else {
            x.style.display = "none";
        }
    }    
}