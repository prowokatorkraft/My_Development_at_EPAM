ModalCloseBtn.onclick = function () {
    Modal.style.display = "none";
}

ModalAdd.onclick = function () {
    Modal.style.display = "flex";
    ModalName.innerText = "";
    ModalAddBtn.innerText = "Добавить";
}

TBody.onclick = function () {
    if (event.target.tagName == "BUTTON") {
        if (event.target.name == "changeProduct-btn") {
            ModalId.value = event.target.parentNode.parentNode.id;
            // подгрузка данных с сервера для отправки формы
            ModalAddBtn.innerText = "Изменить";
            Modal.style.display = "flex";
        }
        if (event.target.name == "removeProduct-btn") {
            let id = ModalId.value = event.target.parentNode.parentNode.parentNode.id;
            if (!confirm("Действительно хотите удалить?")) {
                event.preventDefault();
            }
        }
    }
}