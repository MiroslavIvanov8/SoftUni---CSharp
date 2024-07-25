function calc() {
    const num1 = document.getElementById('num1');
    const num2 = document.getElementById('num2');
    const sum = document.getElementById('sum');

    const resultSum = parseInt(num1.value) + parseInt(num2.value);
    sum.value = resultSum;
}
