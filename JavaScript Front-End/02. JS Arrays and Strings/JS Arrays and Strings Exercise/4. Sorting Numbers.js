function solve(arr =[]){

    const sortedArr = arr.sort((a,b) => a - b);
    let outputArr = new Array(sortedArr.length);

    for (let i = 0; i < arr.length; i++) {
        if(i % 2 ==0){
            outputArr[i] = sortedArr[i / 2];
        }
        else if (i % 2 != 0){

            outputArr[i] = sortedArr[sortedArr.length - Math.ceil(i / 2)];
        }
    }

    return outputArr;
}
solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);
// expected [-3, 65, 1, 63, 3, 56, 18, 52, 31, 48]