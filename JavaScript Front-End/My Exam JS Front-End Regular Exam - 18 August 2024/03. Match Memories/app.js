const baseUrl = 'http://localhost:3030/jsonstore/matches';

const loadButton = document.getElementById('load-matches');
const addButton = document.getElementById('add-match');
const editButton = document.getElementById('edit-match');

const gameList = document.getElementById('list');
const formEl = document.getElementById('form');

const hostInput = document.getElementById('host');
const scoreInput = document.getElementById('score');
const guestInput = document.getElementById('guest');

loadButton.addEventListener('click', loadGames);
addButton.addEventListener('click', addGame);
editButton.addEventListener('click', editGame);

async function editGame(){

    // get id from form
    const gameId = formEl.getAttribute('data-game-id');

    // get data from inputs
    const host = hostInput.value;
    const score = scoreInput.value;
    const guest = guestInput.value;

    //clear inputs
    clearInputs();

    // put request
    await fetch(`${baseUrl}/${gameId}`, {
        method: 'PUT',
        headers: {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify({host, score, guest, _id: gameId})
    })

    // load games
    await loadGames();

    // deactivate edit button
        editButton.disabled = true;

    // activate add button
        addButton.disabled = false;

    // remove id from form
    formEl.removeAttribute('data-game-id');
    
}

async function addGame() {

    // get values from inputs
    const host = hostInput.value;
    const score = scoreInput.value;
    const guest = guestInput.value;

    // clear inputs
    clearInputs();

    // post request
    await fetch(baseUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ host, score, guest })
    });

    // load games
    await loadGames();
}

async function loadGames() {

    gameList.innerHTML = '';

    // get request
    const response = await fetch(baseUrl);
    const result = await response.json();

    // create game elements   
    Object.values(result).forEach((game) => {
        const match = createGameEl(game);
        gameList.appendChild(match);
    })

}

function createGameEl(game) {

    const pHost = document.createElement('p');
    pHost.textContent = game.host;

    const pScore = document.createElement('p');
    pScore.textContent = game.score;

    const pGuest = document.createElement('p');
    pGuest.textContent = game.guest;

    const divInfo = document.createElement('div');
    divInfo.classList.add('info');

    divInfo.appendChild(pHost);
    divInfo.appendChild(pScore);
    divInfo.appendChild(pGuest);

    const changeBtn = document.createElement('button');
    changeBtn.classList.add('change-btn');
    changeBtn.textContent = 'Change';
    changeBtn.addEventListener('click', () => {

        // populate inputs with data
            hostInput.value = game.host;
            scoreInput.value = game.score;
            guestInput.value = game.guest;

        // activate edit button
            editButton.disabled = false;

        // deactivate add button
            addButton.disabled = true;

        // set id attribute to form
            formEl.setAttribute('data-game-id', game._id);

    });

    const deleteBtn = document.createElement('button');
    deleteBtn.classList.add('delete-btn');
    deleteBtn.textContent = 'Delete';
    deleteBtn.addEventListener('click', async () => {
        // remove liElement
        await fetch(`${baseUrl}/${game._id}`, {
            method: 'DELETE'
        })

        // load games
        loadGames();
    })

    const divButtons = document.createElement('div');
    divButtons.classList.add('btn-wrapper');

    divButtons.appendChild(changeBtn);
    divButtons.appendChild(deleteBtn);

    const liElement = document.createElement('li');
    liElement.classList.add('match');

    liElement.appendChild(divInfo);
    liElement.appendChild(divButtons);

    return liElement;
}

function clearInputs() {
    hostInput.value = '';
    scoreInput.value = '';
    guestInput.value = '';
}
