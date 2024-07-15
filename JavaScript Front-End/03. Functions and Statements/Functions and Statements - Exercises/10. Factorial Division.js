function printDivideFactorials(a, b){
    function calculateFactorial (num) {
        let sum = 1;
        for (let i = 1; i <= num; i++) {
            sum *= i;        
        }
        return sum;
    }  

    let factorialA = calculateFactorial(a);
    let factorialB = calculateFactorial(b);      

    console.log((factorialA / factorialB).toFixed(2));
}

printDivideFactorials(6, 2)
