function sumOddAndEven(sequence){
    let sequenceString = sequence.toString();
    let oddSum = 0;
    let evenSum = 0;


    for (const number of sequenceString) {
        
        let currentNum = parseInt(number);

        if(currentNum % 2 ==0){
            evenSum += currentNum;
        } else {
            oddSum += currentNum;
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

sumOddAndEven(3495892137259234);

