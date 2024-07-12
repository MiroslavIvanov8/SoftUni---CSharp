console.log(repeatString('abc', 3));
function repeatString(text, count){

    if(count === 1){
        return text;
    }

    return text + repeatString(text, count - 1);
}
