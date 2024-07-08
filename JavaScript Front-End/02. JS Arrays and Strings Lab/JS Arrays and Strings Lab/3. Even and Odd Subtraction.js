function solve(array = []){

    let evenArr = array.filter(ele => ele % 2 == 0);
    let oddArr = array.filter(ele => ele % 2 != 0);

    let evenSum = 0;
    let oddSum = 0;

    for(let number of evenArr){
        evenSum += parseInt(number);
    }
    for(let number of oddArr){
        oddSum += parseInt(number);
    }

    console.log(evenSum - oddSum);
}

solve([1,2,3,4,5,6]);