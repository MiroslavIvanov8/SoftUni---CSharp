function driveVehicle() {

    class Vehicle {

        parts = {};
        constructor(type, model, parts, fuel) {
            this.type = type,
                this.model = model,
                this.fuel = fuel,
                this.parts = this._loadParts(parts);
            this.parts.quality = this.parts['engine'] * this.parts['power'];
        }

        drive(fuel) {
            this.fuel -= fuel;
        }

        _loadParts(parts) {
            let loadedParts = {};
            for (const part in parts) {
                if (!loadedParts[part]) {
                    loadedParts[part] = Number(parts[part]);
                }
            }

            return loadedParts;
        }
    }

    let parts = { engine: 9, power: 500 };
    let vehicle = new Vehicle('l', 'k', parts, 840);
    vehicle.drive(20);
    console.log(vehicle.fuel);

}

driveVehicle();
