function search() {

    var input, filter, article, tr, item, i, txtValue;

    input = document.getElementById("Searchbar");
    filter = input.value.toUpperCase();
    article = document.getElementById("ArticleItem");
    h = article.getElementsByTagName("h5");

    for (i = 0; i < article.length; i++) {
        item = h;
        if (item) {
            txtValue = item.textContent || item.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                article.style.display = "";
            } else {
                article.style.display = "none";
            }
        }
    }
}