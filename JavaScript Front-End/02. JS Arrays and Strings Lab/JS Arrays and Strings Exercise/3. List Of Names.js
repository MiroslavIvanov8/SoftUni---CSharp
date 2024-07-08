function solve(arr){
    return arr.sort((a, b) => a.localeCompare(b))
             .map((x, i) => `${i + 1}.${x}`)
             .join("\n");
}

const arr = solve([1,]);
console.log(arr);