function solve(words = '', template) {

    let finalSentence = template;
    words.split(', ').forEach((word) =>{
        let searchTerm = '*'.repeat(word.length);
        finalSentence = finalSentence.replace(searchTerm, word);
    })

    console.log(finalSentence);
}

solve('great, learning','softuni is ***** place for ******** new programming languages');