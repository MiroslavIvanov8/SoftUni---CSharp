function printSmallestNumber(a, b, c){
    let smallestNum;

    if(a < b && a < c){
        smallestNum = a;
    } else if (b < c && b < a){
        smallestNum = b;
    } else if (c < a && c < b){
        smallestNum = c;
    } else {
        smallestNum = a;
    }

    console.log(smallestNum);
}

printSmallestNumber(1, 2, 3)
