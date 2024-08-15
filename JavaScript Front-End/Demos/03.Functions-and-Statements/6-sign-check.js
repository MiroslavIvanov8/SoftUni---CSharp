function solve(first, second, third) {
    const multipy = (a, b) => a * b;

    const product = multipy(first, multipy(second, third));

    if (product >= 0) {
        console.log('Positive');
    } else {
        console.log('Negative');
    }
}

solve(5,
    12,
    -15
);
