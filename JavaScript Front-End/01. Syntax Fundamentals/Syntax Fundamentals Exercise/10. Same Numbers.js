function solve(input){
    let inputString = input.toString();
    let flagSame = true;
    let sum = 0;
    for (let i = 0; i < inputString.length; i++) {
        let currentNumber = parseInt(inputString[i])
        if(inputString[i] != inputString[i + 1] && i + 1 < inputString.length){
            flagSame = false;
        }

        sum+= currentNumber;
            
    }
    console.log(flagSame);
    console.log(sum);
}

solve(2222222);