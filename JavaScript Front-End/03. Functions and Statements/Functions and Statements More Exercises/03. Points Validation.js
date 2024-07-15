function validatePoints(pointsArr){

    let x1 = pointsArr[0];
    let y1 = pointsArr[1];
    let x2 = pointsArr[2];
    let y2 = pointsArr[3];

    const validatePoint = function (x1, y1, x2, y2){
        let result = Math.sqrt(Math.pow((x2 - x1), 2) + Math.pow((y2 - y1), 2));

        if(Number.isInteger(result)){
            return true;
        } else {
            return false;
        }
    }

    if(validatePoint(x1, y1, 0, 0)){
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }
    
    if(validatePoint(x2, y2, 0, 0)){
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    } else {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }

    if (validatePoint(x1, y1, x2, y2)){
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    } else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }

}

validatePoints([2, 1, 1, 1])
