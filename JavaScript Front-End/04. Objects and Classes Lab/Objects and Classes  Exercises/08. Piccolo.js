function trackParkingLot(input){
    
    let parking = [];
    input.forEach(entry => {
        
        const cmd = entry.split(', ');
        const direction = cmd[0];
        const plate = cmd[1];

        if(direction == 'IN'){
            parking[plate] = true;

        } else {
            delete parking[plate];
        }
    })    

    let carEntries = Object.entries(parking);
    carEntries = carEntries.sort((a, b) => a[0].localeCompare(b[0]));
    const sortedCars = Object.fromEntries(carEntries);
    
    if(carEntries.length > 0){

        for (const car in sortedCars) {
            console.log(car);       
        }

    } else {
        console.log('Parking Lot is Empty');
    }
}

trackParkingLot(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU']
      
    )
