function solve(number){
    let sum = 0;
    let sequence = number.toString();
    for (let i = 0; i < sequence.length; i++) {
        let currentNumber = parseInt(sequence[i]);
        sum += currentNumber; 
    }

    console.log(sum);
}

solve(245678);