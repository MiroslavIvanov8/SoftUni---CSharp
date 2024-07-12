console.log(mathPower(2, 8));

function mathPower(number, power){

    if(power == 1){
        return number;
    }

    return number * mathPower(number, power - 1);
}

