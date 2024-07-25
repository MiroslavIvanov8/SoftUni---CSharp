function sumTable() {

    const prices = document.querySelectorAll('table tr td:nth-child(2):not(#sum)')
    let sum = 0;
    for (const price of prices) {
        sum += parseFloat(price.textContent);
    }

    const sumElement = document.getElementById('sum');
    sumElement.textContent = sum;
}
