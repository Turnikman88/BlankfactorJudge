function TogglePlaceholder() {

    var elements = document.getElementsByClassName("placeholder-elements");
    for (const x of elements) {
        if (x.style.display === "none") {
            x.style.display = "block";
        } else {
            x.style.display = "none";
        }
    }    
}