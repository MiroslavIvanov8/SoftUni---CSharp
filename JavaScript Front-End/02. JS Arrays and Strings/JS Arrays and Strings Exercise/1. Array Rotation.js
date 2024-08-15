function solve(arr = [], count){
    for (let i = 0; i < count; i++) {
        const element = arr.shift();
        arr.push(element);
    }
    console.log(arr.join(' '));
}

solve([51, 47, 32, 61, 21], 2);