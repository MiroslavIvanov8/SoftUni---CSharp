function printCharactersBetweenTwo(first, second) {
    let result = '';
    let aNumber = first.charCodeAt();
    let bNumber = second.charCodeAt();

    if (aNumber < bNumber) {
        for (let i = aNumber + 1; i < bNumber; i++) {
            result += `${String.fromCharCode(i)} `;
        }
    } else {
        for (let i = bNumber + 1; i < aNumber; i++) {
            result += `${String.fromCharCode(i)} `;
        }
    }

    console.log(result.trimEnd());
}

printCharactersBetweenTwo('C', '#');
