function addItem() {
    
    const ulEl = document.querySelector('ul#items');
    const inputEl = document.querySelector('input#newItemText');

    const newLiEl = document.createElement('li');
    newLiEl.textContent = inputEl.value;

    ulEl.appendChild(newLiEl);
    inputEl.value = '';
}
