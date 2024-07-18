function printTowns(input){
    let Town = class{
        constructor(name, latitude, longitude){
            this.name = name,
            this.latitude = latitude,
            this.longitude = longitude
        }

        print(){
            console.log(`{ town: '${this.name}', latitude: '${Number(this.latitude).toFixed(2)}', longitude: '${Number(this.longitude).toFixed(2)}' }`);
        }
    }

    let towns =[];
    input.forEach(entry => {
        const [name, latitude, longitude] = entry.split(' | ');
        let newTown = new Town(name, latitude, longitude);
        towns.push(newTown);
    })

    for (const town of towns) {
        town.print();
    }
}

printTowns(['Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625']);
