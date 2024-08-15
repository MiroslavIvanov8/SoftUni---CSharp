function solve(text){
    
    let regex = /(?=[A-Z])/;
    let arr = text.split(regex);
    console.log(arr)
}

solve('SplitMeIfYouCanHaHaYouCantOrYouCan');

