function getInfo() {
    let baseUrl = 'http://localhost:3030/jsonstore/bus/businfo/';
    const infoEl = document.getElementById('stopInfo');       
    const stopId = infoEl.querySelector('input#stopId').value;
    const outputEl = infoEl.querySelector('div#result');
   
    baseUrl+= stopId;
    
        fetch(baseUrl)
            .then(response => response.json())
            .then(result => {            
            const stopNameEl = outputEl.children[0];
            const ulEl = outputEl.children[1];
            
            stopNameEl.textContent = result.name;
            
            const busses = Object.entries(result.buses);
            busses.forEach((bus) => {         
                console.log(bus);
                       
                const liEl = document.createElement('li');
                liEl.textContent = `Bus ${bus[0]} arrives in ${bus[1]} minutes`;
                ulEl.appendChild(liEl);
            })           
        })
            .catch(error => {
                const stopNameEl = outputEl.children[0];
                stopNameEl.textContent = 'Error';
            })    
}
