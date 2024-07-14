function checkForPalindromeNumbers(numbersArr){

    function isPalindrome (number){
        let numberString = number.toString();
        let result = true;
    
        for (let i = 0; i < numberString.length; i++) {
    
            if(numberString[i] == numberString[numberString.length - i - 1]){
                continue;            
            } else {
                result = false;
                break;
            }
            
        }
    
        return result;
    }
    for (let i = 0; i < numbersArr.length; i++) {

        console.log(isPalindrome(numbersArr[i]));        

    }
}

checkForPalindromeNumbers([123,323,421,121]);

