function validatePassword (password){

    let characterNumberRegex = new RegExp(/[\s\S]{6,10}/);
    let onlyLettersAndDigitsRegex = new RegExp(/^[a-zA-Z0-9]+$/);
    let atLeastTwoDigitsRegex = new RegExp(/[\d]{2,}/);
    
    const result1 = characterNumberRegex.test(password);
    const result2 = onlyLettersAndDigitsRegex.test(password);
    const result3 = atLeastTwoDigitsRegex.test(password);

    if(result1 && result2 && result3){
        console.log('Password is valid');
    }
    if(!result1){
        console.log('Password must be between 6 and 10 characters');
    }
    if(!result2){
        console.log('Password must consist only of letters and digits');
    }
    if(!result3){
        console.log('Password must have at least 2 digits');
    }
}

validatePassword('Pa$s$s');



