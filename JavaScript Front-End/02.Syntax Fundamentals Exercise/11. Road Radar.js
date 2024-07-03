function solve(speed, area) {
    let message;
    if (area == 'motorway') {

        let difference = speed - 130;
        if (speed <= 130) {
            message = `Driving ${speed} km/h in a 130 zone`;
        }
        else if (difference <= 20) {
            message = `The speed is ${difference} km/h faster than the allowed speed of 130 - speeding`;
        } 
        else if (difference <= 40) {
            message = `The speed is ${difference} km/h faster than the allowed speed of 130 - excessive speeding`;
        }               
        else {
            message = `The speed is ${difference} km/h faster than the allowed speed of 130 - reckless driving`;
        }
    }
    else if (area == 'interstate') {

        let difference = speed - 90;
        if (speed <= 90) {
            message = `Driving ${speed} km/h in a 90 zone`;
        }
        else if (difference <= 20) {
            message = `The speed is ${speed - 90} km/h faster than the allowed speed of 90 - speeding`;
        } 
        else if (difference <= 40) {
            message = `The speed is ${speed - 90} km/h faster than the allowed speed of 90 - excessive speeding`;
        }               
        else {
            message = `The speed is ${speed - 90} km/h faster than the allowed speed of 90 - reckless driving`;
        }
    }
    else if (area == 'city') {

        let difference = speed - 50;
        if (speed <= 50) {
            message = `Driving ${speed} km/h in a 50 zone`;
        }
        else if (difference <= 20) {
            message = `The speed is ${speed - 50} km/h faster than the allowed speed of 50 - speeding`;
        }
        else if (difference <= 40) {
            message = `The speed is ${speed - 50} km/h faster than the allowed speed of 50 - excessive speeding`;
        }               
        else {
            message = `The speed is ${speed - 50} km/h faster than the allowed speed of 50 - reckless driving`;
        }
    }
    else if (area == 'residential') {

        let difference = speed - 20;
        if (speed <= 20) {
            message = `Driving ${speed} km/h in a 20 zone`;
        }
        else if (difference <= 20) {
            message = `The speed is ${speed - 20} km/h faster than the allowed speed of 20 - speeding`;
        }
        else if (difference <= 40) {
            message = `The speed is ${speed - 20} km/h faster than the allowed speed of 20 - excessive speeding`;
        }        
        else {
            message = `The speed is ${speed - 20} km/h faster than the allowed speed of 20 - reckless driving`;
        }
    }
    console.log(message);
}

solve(21, 'residential');