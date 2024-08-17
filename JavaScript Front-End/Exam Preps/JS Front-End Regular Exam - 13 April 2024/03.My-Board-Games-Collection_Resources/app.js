const baseUrl = `http://localhost:3030/jsonstore/games/`;

//get load button element
const loadButton = document.getElementById('load-games');
const addButton = document.getElementById('add-game');
const editButton = document.getElementById('edit-game');
const gamesListDiv = document.getElementById('games-list');
const formElement = document.querySelector('#form form');

const nameInput = document.getElementById('g-name');
const typeInput = document.getElementById('type');
const playersInput = document.getElementById('players');

// load games
loadButton.addEventListener('click', loadGames);
//add game
addButton.addEventListener('click', addGame);

editButton.addEventListener('click', editGame);

function clearInputs() {
    nameInput.value = '';
    typeInput.value = '';
    playersInput.value = '';
}

function addGame() {
    const name = nameInput.value;
    const type = typeInput.value;
    const players = playersInput.value;

    fetch(baseUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ name, players, type, id: null }),
    })
        .then(newGame => {
            loadGames();
            clearInputs();
        })
        .catch(error => console.error('Error adding game:', error));
}

function editGame() {
    const newName = nameInput.value;
    const newType = typeInput.value;
    const newPlayers = playersInput.value;
    const gameId = formElement.getAttribute('data-game-id');

    fetch(`${baseUrl}/${gameId}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ name: newName, type: newType, players: newPlayers, _id: gameId }),
    })
        .then(updatedGame => {
            loadGames();
            clearInputs();
            editButton.disabled = true;
            addButton.disabled = false;
            formElement.removeAttribute('data-game-id');
        })
        .catch(error => console.error('Error updating game:', error));
}

function deleteGame(gameId) {
    fetch(`${baseUrl}/${gameId}`, {
        method: 'DELETE',
    })
        .then(res => loadGames())
        .catch(error => console.error('Error deleting game:', error));
}

function loadGames() {
    gamesListDiv.innerHTML = '';

    fetch(baseUrl)
        .then(res => res.json())
        .then(games => {
            for (const key in games) {
                if (games.hasOwnProperty(key)) {
                    const game = games[key];
                    const gameEl = createGameEl(game);
                    gamesListDiv.appendChild(gameEl);
                }
            }
        })
        .catch(error => console.error('Error loading games:', error));
}

function createGameEl(game) {
    const pNameElement = document.createElement('p');
    pNameElement.textContent = game.name;

    const pPlayersElement = document.createElement('p');
    pPlayersElement.textContent = game.players;

    const pCategoryElement = document.createElement('p');
    pCategoryElement.textContent = game.type;

    const divGamesContent = document.createElement('div');
    divGamesContent.classList.add('content');
    divGamesContent.appendChild(pNameElement);
    divGamesContent.appendChild(pPlayersElement);
    divGamesContent.appendChild(pCategoryElement);

    const changeButton = document.createElement('button');
    changeButton.classList.add('change-btn');
    changeButton.textContent = 'Change';
    changeButton.addEventListener('click', () => {
        
        nameInput.value = game.name;
        typeInput.value = game.type;
        playersInput.value = game.players;

        editButton.disabled = false;
        addButton.disabled = true;

        formElement.setAttribute('data-game-id', game._id);
    });

    const deleteButton = document.createElement('button');
    deleteButton.classList.add('delete-btn');
    deleteButton.textContent = 'Delete';
    deleteButton.addEventListener('click', () => deleteGame(game._id));

    const divButtonsContainer = document.createElement('div');
    divButtonsContainer.classList.add('buttons-container');
    divButtonsContainer.appendChild(changeButton);
    divButtonsContainer.appendChild(deleteButton);

    const divBoardGameContainer = document.createElement('div');
    divBoardGameContainer.classList.add('board-game');
    divBoardGameContainer.appendChild(divGamesContent);
    divBoardGameContainer.appendChild(divButtonsContainer);

    return divBoardGameContainer;
}
