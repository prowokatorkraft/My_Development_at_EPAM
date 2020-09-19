const section = document.getElementById("section-column");

const modalFormName = document.getElementById("name-form");
const modalId = document.getElementById("text-id");
const modalJson = document.getElementById("json-string");
const modalWindow = document.getElementById("modal-window");
const modalName = modalWindow.children.namedItem("text-name");
const modalTitle = modalWindow.children.namedItem("text-title");
const modalDateOfBirth = modalWindow.children.namedItem("dateOfBirth");

const btnModalClose = modalWindow.children.namedItem("btn-close");
const btnModalSubmit = modalWindow.children.namedItem("btn-submit");