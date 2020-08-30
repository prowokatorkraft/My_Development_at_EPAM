window.onload = function () {
    document.getElementById("img-search").onclick = searchNotes;
    let textSearch = document.getElementById("text-search")
    textSearch.onfocus = onFocusSearch;
    textSearch.onblur = onBlurSearch;
    textSearch.onkeypress = onKeyPressSearch;
    onBlurSearch();

    document.getElementById("btn-add").onclick = addModelNote;

    document.getElementById("btn-close").addEventListener("click", closeModel, true);

    document.getElementById("text-head").onfocus = onFocusTextHead;
    document.getElementById("text-head").onblur = onBlurTextHead;

    document.getElementById("text-content").onfocus = onFocusContent;
    document.getElementById("text-content").onblur = onBlurContent;

    outAllNotes();
};

function addModelNote() {
    openModel();

    document.getElementById("text-head").value = "";
    document.getElementById("text-content").value = "";

    onBlurTextHead();
    onBlurContent();
    let btnCreate = document.getElementById("btn-create");
    btnCreate.textContent = "Создать";
    btnCreate.onclick = createNote;
}

function changeModelNote() {
    openModel();

    let note = libraryObject.getById(this.getAttribute("id"));

    let textHead = document.getElementById("text-head");
    textHead.value = note.head;
    let textContent = document.getElementById("text-content");
    textContent.value = note.content;
    let btnChange = document.getElementById("btn-create");
    btnChange.textContent = "Изменить";
    btnChange.onclick = changeNote;
    btnChange.setAttribute("name", this.getAttribute("id"))
}

function openModel() {
    let modal = document.getElementById("modal");
    modal.style.display = "block";
}

function closeModel() {
    let modal = document.getElementById("modal");
    modal.style.display = "none";
}

function createNote() {
    let textHead = document.getElementById("text-head");
    let textContent = document.getElementById("text-content");
    
    if (textHead.value == "Введите заголовок" && textContent.value == "Введите текст заметки") {
        return;
    }
    else if (textHead.value == "Введите заголовок") {
        let key = libraryObject.add({ head: "", content: textContent.value });
        outNote(key, { head: "", content: textContent.value });
    }
    else if (textContent.value == "Введите текст заметки") {
        let key = libraryObject.add({ head: textHead.value, content: "" });
        outNote(key, { head: textHead.value, content: "" });
    }
    else {
        let key = libraryObject.add({ head: textHead.value, content: textContent.value });
        outNote(key, { head: textHead.value, content: textContent.value });
    }

    textHead.value = "";
    textContent.value = "";

    closeModel();
}

function changeNote() {
    let textHead = document.getElementById("text-head");
    let textContent = document.getElementById("text-content");

    let key = this.getAttribute("name");

    document.getElementById(key).remove();
    libraryObject.deleteById(key);

    key = libraryObject.add({ head: textHead.value, content: textContent.value });
    outNote(key, { head: textHead.value, content: textContent.value });

    //textHead.value = "";
    //textContent.value = "";

    closeModel();
}

function removeNote() {
    if (confirm("Вы хотите удалить заметку?")) {
        let note = this.parentNode;
        libraryObject.deleteById(note.getAttribute('id'));
        note.parentNode.removeChild(note);
    }
    event.stopPropagation();
}

function outNote(id, obj) {
    let content = document.getElementById("content");

    let pre = document.createElement("pre");
    pre.innerHTML = obj.head + "\n\r" + obj.content;
    pre.setAttribute("name", "text");

    let img = document.createElement("img");
    img.onclick = removeNote;
    img.setAttribute("name", "delete");
    img.setAttribute("src", "Images/delete.png");

    let div = document.createElement('div');
    div.setAttribute("id", id);
    div.onclick = changeModelNote;
    div.appendChild(pre);
    div.appendChild(img);

    content.insertBefore(div, content.firstChild);
}

function outAllNotes() {
    let idNotes = libraryObject.getAllId();
    outNotes(idNotes);
}

function outNotes(idNotes) {
    for (var key of idNotes) {
        outNote(key, libraryObject.getById(key))
    }
}

function clearNotes() {
    let content = document.getElementById("content");

    while (content.firstChild) {
        content.removeChild(content.firstChild);
    }
}

function searchNotes() {
    let textSearch = document.getElementById("text-search");

    if (textSearch.value != "") {
        clearNotes();

        let idNotes = libraryObject.getAllId();

        for (let id of idNotes) {
            if (libraryObject.getById(id).head == textSearch.value) {
                outNote(id, libraryObject.getById(id));
            }
        }
    }
    else {
        clearNotes();
        outAllNotes();
    }
}


function onFocusSearch() {
    let search = document.getElementById("text-search");

    if (search.value == "Поиск" && search.style.color == "grey") {
        search.value = "";
        search.style.color = " black";
    }
}

function onBlurSearch() {
    let search = document.getElementById("text-search");

    if (search.value == "") {
        search.value = "Поиск";
        search.style = "color: grey;";
    }
}

function onKeyPressSearch() {
    if (event.keyCode === 13) {
        searchNotes();
    }

}

function onFocusTextHead() {
    let TextHead = document.getElementById("text-head");

    if (TextHead.value == "Введите заголовок" && TextHead.style.color == "grey") {
        TextHead.value = "";
        TextHead.style.color = " black";
    }
}

function onBlurTextHead() {
    let TextHead = document.getElementById("text-head");

    if (TextHead.value == "") {
        TextHead.value = "Введите заголовок";
        TextHead.style = "color: grey;";
    }
}

function onFocusContent() {
    let Content = document.getElementById("text-content");

    if (Content.value == "Введите текст заметки" && Content.style.color == "grey") {
        Content.value = "";
        Content.style.color = " black";
    }
}

function onBlurContent() {
    let Content = document.getElementById("text-content");

    if (Content.value == "") {
        Content.value = "Введите текст заметки";
        Content.style = "color: grey;";
    }
}