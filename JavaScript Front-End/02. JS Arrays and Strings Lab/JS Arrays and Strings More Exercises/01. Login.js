function login(arr){

    let userName = arr[0];
    let passwordMatch = '';

    for (let i = userName.length - 1; i >= 0; i--) {
        passwordMatch += userName[i];
    }

    let counter = 0;
    for (let i = 1; i < arr.length; i++) {      
        counter++;

        if(arr[i] === passwordMatch){
            console.log(`User ${userName} logged in.`);
            return;
        }
        
        
        if (arr[i] !== passwordMatch){
            if(counter === 4){
                console.log(`User ${userName} blocked!`);
                return;
            }
            console.log('Incorrect password. Try again.');
        }       
    }
}

login(['sunny','rainy','cloudy','sunny','not sunny']);