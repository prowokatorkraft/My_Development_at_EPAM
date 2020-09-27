ModalCategoryCloseBtn.onclick = function () {
    ModalCategory.style.display = "none";
}

ModalCategoryAdd.onclick = function () {
    ModalCategory.style.display = "flex";
    ModalCategoryName.innerText = "";
    ModalCategoryAddBtn.innerText = "Добавить";
}

CategoryTBody.onclick = function () {
    if (event.target.tagName == "BUTTON") {
        if (event.target.name == "changeCategory-btn") {
            ModalCategoryId.value = event.target.parentNode.parentNode.id;
            // подгрузка данных с сервера для отправки формы
            ModalCategoryAddBtn.innerText = "Изменить";
            ModalCategory.style.display = "flex";
        }
        if (event.target.name == "removeCategory-btn") {
            let id = ModalCategoryId.value = event.target.parentNode.parentNode.parentNode.id;
            if (!confirm("Действительно хотите удалить?")) {
                event.preventDefault();
            }
        }
    }
}