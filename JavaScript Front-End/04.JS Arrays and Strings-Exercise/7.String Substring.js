function solve(searchTerm = ' ', sentence = ' ') {

    let regex = new RegExp(`\\b${searchTerm}\\b`, 'i');
    const result = sentence.match(regex);
    if(result !== null){
        console.log(searchTerm);
    } else{
        console.log(`${searchTerm} not found!`);
    }
}   

solve('javascript',
    'javaScript is the best programming language'
);

