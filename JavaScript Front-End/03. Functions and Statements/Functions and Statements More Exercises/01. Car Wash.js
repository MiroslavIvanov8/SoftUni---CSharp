function calculateCarWashValue(cmdArr = []){

    let washValue = 10;
    cmdArr.shift();

    while(cmdArr.length > 0){
        const currentCmd = cmdArr.shift();
        if(currentCmd == 'water'){
            washValue += washValue * 0.20;
        } else if (currentCmd == 'vacuum cleaner'){
            washValue += washValue * 0.25;
        } else if (currentCmd == 'mud'){
            washValue -= washValue * 0.10;
        } else if (currentCmd == 'soap'){
            washValue += 10;
        }
    }

    console.log(`The car is ${washValue.toFixed(2)}% clean.`);
}

calculateCarWashValue(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']);

