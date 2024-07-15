function printMatrix(number){

    for (let i = 0; i < number; i++) {
        
        const numberString = `${number} `.repeat(number).trimEnd();
        console.log(numberString);       
        //console.log('\n');        
    }
}

printMatrix(2);
