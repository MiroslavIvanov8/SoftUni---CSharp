function sumOddAndEven(sequence) {

    const getEvenAndOddDigits = (x) => {

        let evenDigits = [];
        let oddDigits = [];

        let currentNumber = x;


        while (currentNumber > 0) {
            const lastDigit = currentNumber % 10;

            if (lastDigit % 2 == 0) {
                evenDigits.push(lastDigit);
            } else {
                oddDigits.push(lastDigit);
            }

            currentNumber = parseInt(currentNumber / 10);
        }

        return [evenDigits, oddDigits];
    }

    const [evenDigits, oddDigits] = getEvenAndOddDigits(sequence)
    const getSumOfDigits = (array) => array.reduce((a, b) => a + b, 0);

    const evenSum = getSumOfDigits(evenDigits);
    const oddSum = getSumOfDigits(oddDigits);


    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

sumOddAndEven(3495892137259234);

