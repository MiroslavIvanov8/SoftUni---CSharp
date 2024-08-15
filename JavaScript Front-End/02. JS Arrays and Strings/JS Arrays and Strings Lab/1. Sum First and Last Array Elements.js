function solve(array){

    const firstElement = array.shift();
    const lastElement = array.pop();

    const result = firstElement + lastElement;

    console.log(result);
}

solve([20, 30, 40]);