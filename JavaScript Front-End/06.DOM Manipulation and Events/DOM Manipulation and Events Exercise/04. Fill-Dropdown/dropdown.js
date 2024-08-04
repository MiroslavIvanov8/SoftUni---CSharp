function addItem() {
    
    //Get newItemText and newItemValue values
    const selectMenuEl = document.getElementById('menu');
    const newItemTextEl = document.getElementById('newItemText');
    const newItemValueEl = document.getElementById('newItemValue');    

    //Create new options object with given values
    const optionEl = document.createElement('option');
    optionEl.text = newItemTextEl.value;
    optionEl.value = newItemValueEl.value;

    //Append it to select object with id menu
    selectMenuEl.appendChild(optionEl);

    //Clear their values
    newItemTextEl.value = '';
    newItemValueEl.value = '';

}
