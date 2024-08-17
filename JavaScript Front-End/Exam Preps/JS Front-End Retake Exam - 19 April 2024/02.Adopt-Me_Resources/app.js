window.addEventListener("load", solve);

function solve() {
	// get input elements
	const typeInput = document.getElementById('type');
	const ageInput = document.getElementById('age');
	const genderInput = document.getElementById('gender');

	// get ul elements
	const checkUl = document.getElementById('adoption-info');
	const adoptedUl = document.getElementById('adopted-list');

	// get adopt button el
	const adoptButton = document.getElementById('adopt-btn');
	adoptButton.addEventListener('click', (e) => {

		e.preventDefault();

		// get information from the inputs
		const type = typeInput.value;
		const age = ageInput.value;
		const gender = genderInput.value;

		if (emptyValues(type, age, gender)) {
			return;
		}

		// create li element
		const liElement = createLiElement(type, age, gender);
		checkUl.appendChild(liElement);

		clearInputs();
		// clear inputs

	})

	function createLiElement(type, age, gender) {

		//add the data to the info ul element
		const pType = document.createElement('p');
		pType.textContent = `Pet:${type}`;

		const pGender = document.createElement('p');
		pGender.textContent = `Gender:${gender}`;

		const pAge = document.createElement('p');
		pAge.textContent = `Age:${age}`;

		const articleElement = document.createElement('article');
		articleElement.appendChild(pType);
		articleElement.appendChild(pGender);
		articleElement.appendChild(pAge);

		const editBtn = document.createElement('button');
		editBtn.classList.add('edit-btn');
		editBtn.textContent = 'Edit';

		const doneBtn = document.createElement('button');
		doneBtn.classList.add('done-btn');
		doneBtn.textContent = 'Done';

		const buttonsDiv = document.createElement('div');
		buttonsDiv.classList.add('buttons');
		buttonsDiv.appendChild(editBtn);
		buttonsDiv.appendChild(doneBtn);

		const liElement = document.createElement('li');
		liElement.appendChild(articleElement);
		liElement.appendChild(buttonsDiv);

		editBtn.addEventListener('click', () => {

			// send data to the input fields
				typeInput.value = type;
				ageInput.value = age;
				genderInput.value = gender;

			// remove li element
			liElement.remove();
		});

		doneBtn.addEventListener('click', () => {

			// remove edit and done buttons
			buttonsDiv.remove();

			// create clear button
			const clearBtn = document.createElement('button');
			clearBtn.classList.add('clear-btn');
			clearBtn.textContent = 'Clear';
			clearBtn.addEventListener('click', () => {
				liElement.remove();
			});

			liElement.appendChild(clearBtn);

			// move li element to adoptedUl
			adoptedUl.appendChild(liElement);
		});

		return liElement;
	}

	function emptyValues(type, age, gender) {
		if (!type || !age || !gender) {
			return true; // Return true if any value is empty
		} else {
			console.log("All values are provided.");
			return false; // Return false if all values are present
		}
	}
	function clearInputs() {
		typeInput.value = '';
		ageInput.value = '';
		genderInput.value = '';
	}
}
