function printTowns(input) {
    let Town = class {
        constructor(name, latitude, longitude) {
                this.name = name,
                this.latitude = latitude,
                this.longitude = longitude
        }

        print() {
            console.log(`{ town: '${this.name}', latitude: '${Number(this.latitude).toFixed(2)}', longitude: '${Number(this.longitude).toFixed(2)}' }`);
        }
    }

    let towns = input.reduce((acc, cur) => {

        const [townName, latitude, longitude] = cur.split(' | ')
        acc.push(new Town(townName, latitude, longitude))
        return acc;
    } , []);

    for (const town of towns) {
        town.print();
    }
}

printTowns(['Sofia | 42.696552 | 23.32601',
    'Beijing | 39.913818 | 116.363625']);
