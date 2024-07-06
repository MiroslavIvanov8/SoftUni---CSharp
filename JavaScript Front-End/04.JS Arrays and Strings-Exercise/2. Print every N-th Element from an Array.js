function solve(arr = [], step) {

    let newArr = [];
    arr.forEach((element, index) => {
        if(index % step === 0){
            newArr.push(element);
        }
    })

    
    return newArr;
    //console.log(arr.filter((_, i) => i % step ===0));

}

solve(['5', '20', '31', '4', '20'], 2);