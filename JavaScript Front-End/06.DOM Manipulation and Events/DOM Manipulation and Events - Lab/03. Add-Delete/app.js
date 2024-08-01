function addItem() {
    //Get elements reference
    const itemsElement = document.getElementById('items');
    const newItemTextElement = document.querySelector('input[type=text]');

    //Create new li item
    const liElement = document.createElement('li');
    liElement.textContent = newItemTextElement.value;
    
    //Create the delete button
    const deleteButton = document.createElement('a');
    deleteButton.textContent = '[Delete]';
    deleteButton.href = '#';
    
    //Attach event listener to the button
    deleteButton.addEventListener('click', (e) => {
        e.currentTarget.parentElement.remove(); // cleaner way  than elElement.remove() ** tight coupling;
    });

    liElement.append(deleteButton);
    itemsElement.appendChild(liElement);
    
    newItemTextElement.value = '';
}
