
function calculator(operantOne, operantTwo, operation){

    const multiply =  (operantOne, operantTwo) => operantOne * operantTwo;
    const divide = (operantOne, operantTwo) => operantOne / operantTwo;
    const add = (operantOne, operantTwo) => operantOne + operantTwo;
    const subtract = (operantOne, operantTwo) => operantOne - operantTwo;

    if(operation == 'multiply'){
        return multiply(operantOne, operantTwo); 
    } else if (operation == 'divide'){
        return divide(operantOne, operantTwo); 
    } else if (operation == 'add'){
        return add(operantOne, operantTwo);
    } else if (operation == 'subtract'){
        return subtract(operantOne, operantTwo);
    }
}

console.log(calculator(5, 5, 'multiply'));

