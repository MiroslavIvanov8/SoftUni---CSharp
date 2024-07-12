function signCheck(numOne, numTwo, numThree){
    let result = false;
    if(numOne < 0 || numTwo < 0 || numThree < 0){
        if((numOne  < 0 && numTwo < 0 && numThree > 0) ||
           (numOne < 0 && numThree < 0 && numTwo > 0) ||
           (numTwo < 0 && numThree < 0 && numOne > 0)){
                result = true;
        } else{
            result = false;
        }
    } else {
        result = true;
    }

    return result ? 'Positive' : 'Negative';
}


console.log(signCheck(-1, -2, -3));
