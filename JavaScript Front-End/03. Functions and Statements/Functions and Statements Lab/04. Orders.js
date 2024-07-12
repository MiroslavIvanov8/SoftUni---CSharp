function orders(product, quantity) {

    let price = 0;
    switch (product) {
        case 'coffee':
            price = 1.50;
            break;
        case 'water':
            price = 1.0;
            break;
        case 'coke':
            price = 1.40;
            break;
        case 'snacks':
            price = 2.0;
            break;
        default:
            break;
    }

    console.log((price * quantity).toFixed(2));
}

orders('water', 5)
