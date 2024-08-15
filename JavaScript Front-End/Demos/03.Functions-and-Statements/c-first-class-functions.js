// Function can be passed as an argument
function executeOperation(operation, firstOperand, secondOperand) {
    const result = operation(firstOperand, secondOperand);

    return result;
}

function sum(a, b) {
    return a + b;
}

//* pass function by refference
const operationResult = executeOperation(sum, 10, 20);
console.log(operationResult);

//* pass anonimous function as an argument
const operationResult2 = executeOperation(function (a, b) {
    return a - b;
}, 10, 2);
console.log(operationResult2);

//* pass arrow function as an argument
const operationResult3 = executeOperation((a, b) => a * b, 2, 5);
console.log(operationResult3);

// Function can be assigned as a value to a variable
//* using function expression (anonimous function)
const multiply = function (a, b) {
    return a * b;
};
console.log(multiply(2, 3));

//* using arrow function
const divide = (a, b) => a / b;
console.log(divide(10, 5));

// Returned by another function
function buildOperation(operationName) {
    switch (operationName) {
        case 'sum':
            return function(a, b) {
                return a + b;
            }
        case 'multiplication':
            return function(a, b) {
                return a * b;
            }
    }
}

const sumOperation = buildOperation('sum');
console.log(sumOperation(20, 40));
const multiplicationOperation = buildOperation('multiplication');
console.log(multiplicationOperation(20, 40));
