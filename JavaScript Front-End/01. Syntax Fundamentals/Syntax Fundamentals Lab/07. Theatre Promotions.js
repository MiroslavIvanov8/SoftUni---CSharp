function solve(day, age) {
    let price;

    if (day == 'Weekday') {
        if (age >= 0 && age <= 18) {
            price = 12;
        } else if (age > 18 && age <= 64) {
            price = 18;
        } else if (age > 64 && age <= 122) {
            price = 12;
        } else {
            console.log('Error!');
            return;
        }
    }
    else if (day == 'Weekend') {

        if (age >= 0 && age <= 18) {
            price = 15;
        } else if (age > 18 && age <= 64) {
            price = 20;
        } else if (age > 64 && age <= 122) {
            price = 15;
        } else {
            console.log('Error!');
            return;
        }
    } else {
        if (age >= 0 && age <= 18) {
            price = 5;
        } else if (age > 18 && age <= 64) {
            price = 12;
        } else if (age > 64 && age <= 122) {
            price = 10;
        } else {
            console.log('Error!');
            return;
        }
    }
    console.log(`${price}$`);
}

solve('Holiday', -1)