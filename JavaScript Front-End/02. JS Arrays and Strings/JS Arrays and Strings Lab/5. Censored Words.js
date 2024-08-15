function solve(text = ' ', word){

    let newText = text.replaceAll(word, '*'.repeat(word.length))
    console.log(newText);
}

solve('A small sentence with some small words', 'small');