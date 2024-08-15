function solve(count, array){

    let newArray = array.slice(0, count);
    newArray = newArray.reverse();

    console.log(newArray.join(' '));
}

solve(3, [10, 20, 30, 40, 50]);