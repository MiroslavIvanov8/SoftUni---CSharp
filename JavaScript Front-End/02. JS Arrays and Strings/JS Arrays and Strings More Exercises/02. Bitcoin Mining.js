function bitCoinMining(arr){

        let money = 0.00;
        let bitcoins = 0;
        let days = 0;
        let firstBitCoinDay = 0;
        for (let i = 0; i < arr.length; i++) {
            days++;

            let minedGold = parseFloat(arr[i]);
            
            if(days % 3 ==0){
                minedGold = minedGold * 0.70;
            }
            
            money += minedGold * 67.51;

            if(money >= 11949.16){
                let bitCountsBought = Math.floor(money / 11949.16);
                bitcoins +=  bitCountsBought;
                money = money - bitCountsBought * 11949.16;

                if(firstBitCoinDay == 0)
                    firstBitCoinDay = days;
            }
        }
        console.log(`Bought bitcoins: ${bitcoins}`);
        if(bitcoins > 0)
            console.log(`Day of the first purchased bitcoin: ${firstBitCoinDay}`);
        console.log(`Left money: ${money.toFixed(2)} lv.`);
}

bitCoinMining([3124.15, 504.212, 2511.124]);