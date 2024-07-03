function solve(number, type, day) {
    let price;
    if (type == 'Students') {

        if (day == 'Friday') {
            price = 8.45;
        } else if (day == 'Saturday') {
            price = 9.80;
        } else if (day == 'Sunday') {
            price = 10.46;
        }

        if (number >= 30) {
            price = (number * price) * 0.85;
        } else {
            price = number * price;
        }

    } else if (type == 'Business') {

        if (day == 'Friday') {
            price = 10.90;
        } else if (day == 'Saturday') {
            price = 15.60;
        } else if (day == 'Sunday') {
            price = 16;
        }

        if (number >= 100) {
            price = (number - 10) * price;
        } else {
            price = number * price;
        }

    } else if (type == 'Regular') {

        if (day == 'Friday') {
            price = 15;
        } else if (day == 'Saturday') {
            price = 20;
        } else if (day == 'Sunday') {
            price = 22.50;
        }

        if (number >= 10 && number <= 20) {
            price = (number * price) * 0.95;
        } else {
            price = number * price;
        }
    }
    console.log(`Total price: ${price.toFixed(2)}`);
}

solve(40,
    "Regular",
    "Saturday"
    );