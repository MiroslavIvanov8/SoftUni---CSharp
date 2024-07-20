function printOddOccurrences(input){

    let occurrences = {};

    input.split(' ').forEach(word => {
        
        let currWord = word.toLocaleLowerCase();
        if(!occurrences[currWord]){
            occurrences[currWord] = 0;
        }

        occurrences[currWord]++;
    });
    
    debugger;
    let oddOccurrences = [];
    for (const word in occurrences) {
        if(occurrences[word] % 2 == 1){
            oddOccurrences.push(word);
        }
    }

    console.log(oddOccurrences.join(' '));
}

printOddOccurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
