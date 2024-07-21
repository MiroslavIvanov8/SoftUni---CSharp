function trackWords(input){
    
    const[specialWords, ...restOfTheWords] = input;

    const words = specialWords.split(' ').reduce((acc, word) =>{
        acc[word] = 0;
        return acc;
    }, {});

    restOfTheWords.forEach(word => {
        if(words.hasOwnProperty(word)){
            words[word] += 1;
        }
    })

    Object.keys(words)
    .sort((a, b) => words[b] - words[a])
    .forEach(word => console.log(`${word} - ${words[word]}`));
}

trackWords([
    'this sentence', 
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]
    );
