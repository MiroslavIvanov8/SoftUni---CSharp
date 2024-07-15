function modifyNumber(number){

    function calculateNumberAverage(number){

        let numberString = number.toString();
        let result = 0;

        for (let i = 0; i < numberString.length; i++) {
            result += parseInt(numberString[i]);
        }

        result /= numberString.length;

        if(result < 5){
            return true;
        } else {
            return false;
        }
    }

    while(calculateNumberAverage(number)){

        number  = number + '9';
    }

    console.log(number);
}

modifyNumber(5835);
