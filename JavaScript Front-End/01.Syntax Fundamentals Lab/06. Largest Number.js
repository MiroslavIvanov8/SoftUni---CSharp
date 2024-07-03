function solve(num1, num2, num3){
    let biggestNum;
    if(num1 > num2 && num1 > num3){
        biggestNum = num1;
    }else if(num2 > num1 && num2 > num3){
        biggestNum = num2;
    }else if(num3 > num1 && num3 > num2){
        biggestNum = num3;
    }
    let result = `The largest number is ${biggestNum}.`;
    console.log(result);
}

solve(5, -3, 16);