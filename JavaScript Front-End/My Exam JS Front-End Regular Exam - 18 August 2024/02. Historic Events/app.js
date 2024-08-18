window.addEventListener("load", solve);

function solve() {
  const addButton = document.getElementById('add-btn');
  const previewList = document.getElementById('preview-list');
  const archiveList = document.getElementById('archive-list');

  const nameInput = document.getElementById('name');
  const timeInput = document.getElementById('time');
  const descriptionInput = document.getElementById('description');

  addButton.addEventListener('click', (e) => {

    e.preventDefault();

    const name = nameInput.value;
    const time = timeInput.value;
    const description = descriptionInput.value;

    if (!name || !time || !description) {
      return;
    }

    const liElement = createLiElement(name, time, description);
    previewList.appendChild(liElement);

    addButton.disabled = true;

    clearInputs();
  });

  function createLiElement(name, time, description) {
    // Paragraphs
    const pName = document.createElement('p');
    pName.textContent = name;

    const pTime = document.createElement('p');
    pTime.textContent = time;

    const pDescription = document.createElement('p');
    pDescription.textContent = description;

    const articleElement = document.createElement('article');
    articleElement.appendChild(pName);
    articleElement.appendChild(pTime);
    articleElement.appendChild(pDescription);

    // Buttons
    const editBtn = document.createElement('button');
    editBtn.classList.add('edit-btn');
    editBtn.textContent = "Edit";


    const nextBtn = document.createElement('button');
    nextBtn.classList.add('next-btn');
    nextBtn.textContent = 'Next';

    const divButtons = document.createElement('div');
    divButtons.classList.add('buttons');
    divButtons.appendChild(editBtn);
    divButtons.appendChild(nextBtn);

    const liElement = document.createElement('li');
    liElement.appendChild(articleElement);
    liElement.appendChild(divButtons);

    editBtn.addEventListener('click', () => {

      nameInput.value = name;
      timeInput.value = time;
      descriptionInput.value = description;

      liElement.remove();

      addButton.disabled = false;
    });

    nextBtn.addEventListener('click', () => {
      
      // remove buttons
      divButtons.remove();

      // create archive button
      const archiveBtn = document.createElement('button');
      archiveBtn.classList.add('archive-btn');
      archiveBtn.textContent = 'Archive';
      archiveBtn.addEventListener('click', () => {

        liElement.remove();
        addButton.disabled = false;
      })

      liElement.appendChild(archiveBtn);

      // move li element
      archiveList.appendChild(liElement);
    })

    // Return the created li element
    return liElement;
  }

  function clearInputs() {
    nameInput.value = '';
    timeInput.value = '';
    descriptionInput.value = '';
  }
}
