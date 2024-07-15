function isNumberPerfect(num){

    let numberArr = [];

    for (let i = 1; i < num; i++) {
        
        if(num % i == 0){
            numberArr.push(i);
        }
        
    }

    let sum = 0;
    while(numberArr.length > 0){
        sum += numberArr.pop();
    }

    if(sum == num){
        console.log('We have a perfect number!');
    } else {
        console.log('It\'s not so perfect.');
    }
}


isNumberPerfect(1236498);

