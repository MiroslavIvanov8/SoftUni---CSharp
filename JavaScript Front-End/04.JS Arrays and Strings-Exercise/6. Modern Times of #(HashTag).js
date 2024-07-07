function solve(input){

    let sentence = input.split(' ');
    sentence = sentence.filter((word) => {
        if(word[0] == '#' && word.length > 1){
            let substring = word.substring(1);
            let pattern = /\d+/;
            if(!pattern.test(substring))
                console.log(substring);
            
        }
    })
}



solve('The symbol # is known #1variously in English-speaking #regions as the #number sign');