window.addEventListener("load", solve);

function solve() {
  //Get add button
  const addBtn = document.getElementById('add-btn');
  const checkUl = document.getElementById('check-list');
  const contactUl = document.getElementById('contact-list');

  //Get info form input fields
  const nameInput = document.getElementById('name');
  const phoneInput = document.getElementById('phone');
  const categoryInput = document.getElementById('category');



  //Attach event listener to add btn
  addBtn.addEventListener('click', () => {

    const name = nameInput.value;
    const phoneNumber = phoneInput.value;
    const category = categoryInput.value;  

    //Create new li item
    const liElement = createCheckLiElement(name, phoneNumber, category);

    checkUl.append(liElement);

    //Clear input fields
    clearInputs();
  });

  function clearInputs() {
    nameInput.value = '';
    phoneInput.value = '';
    categoryInput.value = '';
  }

  function createCheckLiElement(name, phoneNumber, category) {
    const pName = document.createElement('p');
    pName.textContent = `name:${name}`;

    const pPhoneNumber = document.createElement('p');
    pPhoneNumber.textContent = `phone:${phoneNumber}`;

    const pCategory = document.createElement('p');
    pCategory.textContent = `category:${category}`;
    
    const articleEl = document.createElement('article');
    articleEl.appendChild(pName);
    articleEl.appendChild(pPhoneNumber);
    articleEl.appendChild(pCategory);

    const editBtn = document.createElement('button');
    editBtn.classList.add('edit-btn');

    const saveBtn = document.createElement('button');
    saveBtn.classList.add('save-btn');

    const divButtons = document.createElement('div');
    divButtons.classList.add('buttons');
    divButtons.appendChild(editBtn);
    divButtons.appendChild(saveBtn);

    const liElement = document.createElement('li');
    liElement.appendChild(articleEl);
    liElement.appendChild(divButtons);

    editBtn.addEventListener('click', () => {

      nameInput.value = name;
      phoneInput.value = phoneNumber;
      categoryInput.value = category;

      liElement.remove();
    });

    saveBtn.addEventListener('click', () => {

      //Remove Edit and Save buttons
      divButtons.remove();

      //Create delete button
      const deleteBtn = document.createElement('button');
      deleteBtn.classList.add('del-btn');

      deleteBtn.addEventListener('click', deleteContact);

      liElement.appendChild(deleteBtn);

      //Move li item
      contactUl.appendChild(liElement);      
    });

    return liElement;
  }

  function deleteContact(e) {
    e.target.parentElement.remove();
  }
}
