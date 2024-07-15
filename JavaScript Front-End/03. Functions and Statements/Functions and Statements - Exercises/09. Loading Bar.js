function printLoadingBar(number){

    if(number == 100){
        console.log('100% Complete!');
    } else {
        let  dotNumber = (100 - number) / 10;
        let numberTimes = number / 10;

        console.log(`${number}%` + ' [' + `${'%'}`.repeat(numberTimes) + `.`.repeat(dotNumber) + ']');
        console.log('Still loading...');
    }
}

printLoadingBar(90);
