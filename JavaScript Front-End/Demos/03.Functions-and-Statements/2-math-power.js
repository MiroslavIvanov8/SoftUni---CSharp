function iterativePower(base, radix) {
    let result = 1;

    for (let i = 0; i < radix; i++) {
        result *= base;
    }

    return result;
}

function recursivePower(base, radix) {
    if (radix === 1) {
        return base;
    }

    return base * recursivePower(base, radix - 1);
}

function simpleCalculator(base, radix) {
    // console.log(base ** radix);
    // let result = Math.pow(base, radix);

    // const res = iterativePower(base, radix);
    const res = recursivePower(base, radix);

    console.log(res);
}

simpleCalculator(2, 8);
