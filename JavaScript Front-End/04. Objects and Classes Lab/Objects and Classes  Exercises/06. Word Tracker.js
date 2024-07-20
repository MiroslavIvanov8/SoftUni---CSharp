function trackWords(input){
    
    let specialWords = input[0].split(' ');
    
    let wordOccurrences = {};
    specialWords.forEach(word => {
        wordOccurrences[word] =  0;
    });


    input.forEach((word) => {
        if(wordOccurrences.hasOwnProperty(word)){
            wordOccurrences[word]++;
        }
    });

    let entries = Object.entries(wordOccurrences);
    entries.sort((a, b) => b[1] - a[1]);

    let sortedWordOccurrences = Object.fromEntries(entries);

    for (const word in sortedWordOccurrences) {
        console.log(`${word} - ${wordOccurrences[word]}`);
    }
}

trackWords([
    'this sentence', 
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]
    );
