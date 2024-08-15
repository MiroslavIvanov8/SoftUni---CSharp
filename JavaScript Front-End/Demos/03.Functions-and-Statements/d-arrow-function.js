// Function to be converted to arrow function
const doubleExpression = function (number) {
    return number * 2;
}

// Arrow function with statement body
const doubleStatementBody = (number) => {
    return number * 2;
}

// Arrow function with expression body
const doubleExpressionBody = (number) => number * 2;

// Arrow function with expression body with single parameter
const doubleSingleParameterExpressionBody = number => number * 2;

console.log(doubleExpression(10));
console.log(doubleStatementBody(10));
console.log(doubleExpressionBody(10));
console.log(doubleSingleParameterExpressionBody(10));
