function solve(fruit, grams, price){
    let kilos = grams / 1000;
    price = price * kilos;

    console.log(`I need $${price.toFixed(2)} to buy ${kilos.toFixed(2)} kilograms ${fruit}.`);
}

solve('orange', 2500, 1.80);