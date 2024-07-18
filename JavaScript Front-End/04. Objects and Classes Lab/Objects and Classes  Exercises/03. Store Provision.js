function printStoreProvisions(firstArr, secondArr) {

    let provisions = {};

    function fillProvisions(input){
        for (let i = 0; i < input.length; i++) {

            let product = input[i];
            let quantity = input[i + 1];
            i++;
    
            if(!provisions[product]){
                provisions[product] = parseInt(quantity);
            } else {
                provisions[product] += parseInt(quantity);
            }       
        }

    }
    
    fillProvisions(firstArr);
    fillProvisions(secondArr);  

    for (const product in provisions) {
        console.log(`${product} -> ${provisions[product]}`);
    }
}

printStoreProvisions([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
);
