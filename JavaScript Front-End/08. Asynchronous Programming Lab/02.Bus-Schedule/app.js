function solve() {
    let baseUrl = 'http://localhost:3030/jsonstore/bus/schedule/';
    let currentStop = 'depot';
    const infoEl = document.getElementById('info');
    const departEl = document.getElementById('depart');
    const arriveEl = document.getElementById('arrive');

    function depart() {
        fetch(`${baseUrl}${currentStop}`)
            .then(response => response.json())
            .then(result => {
                
                infoEl.textContent = `Next stop ${result.name}`;
                departEl.disabled = true;
                arriveEl.disabled = false;              
            })
                .catch(handleError)
    }

    async function arrive() {
        fetch(`${baseUrl}${currentStop}`)
            .then(response => response.json())
            .then(result => {
                
                infoEl.textContent = `Arriving at ${result.name}`;
                departEl.disabled = false;
                arriveEl.disabled = true;
                currentStop = result.next;
            })
                .catch(handleError)
    }

    function handleError() {
        infoEl.textContent = 'Error';
        departEl.disabled = true;
        arriveEl.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();
