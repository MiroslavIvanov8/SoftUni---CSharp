function solve(param){

    if(typeof param == 'number')
    {
        let result = Math.pow(param, 2) * Math.PI;
        console.log(result.toFixed(2));
    }else {
        console.log(`We can not calculate the circle area, because we receive a ${typeof param}.`);
    }
}

solve(5)