function solve(text  = ' ', specialWord){

    const textArr = text.split(' ');
    let wordCount = 0;
    for (const word of textArr) {
        if(word == specialWord){
            wordCount++;
        }
    }

    console.log(wordCount);
}

solve('This is a word and it also is a sentence','is');