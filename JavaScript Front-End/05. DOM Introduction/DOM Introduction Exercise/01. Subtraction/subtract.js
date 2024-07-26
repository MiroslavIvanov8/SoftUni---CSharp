function subtract() {
    const num1 = Number(document.getElementById('firstNumber').value);
    const num2 = Number(document.getElementById('secondNumber').value);
    
    const result = num1 - num2;
    let resultElement = document.getElementById('result');
    resultElement.textContent = result;
}

