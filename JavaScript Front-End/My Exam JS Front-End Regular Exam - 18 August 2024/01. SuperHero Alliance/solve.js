function solve(input) {

    const numberOfHeroes = Number(input.shift());
    let heroes = {};

    for (let i = 0; i < numberOfHeroes; i++) {
        [heroName, skills, energy] = input.shift().split('-');  
        heroes[heroName] = {
            skills : skills.split(','),
            energy: Number(energy)
        }        
    }    

    const commands = {
        UsePower(heroName, superPower, energyRequired){
                if(heroes[heroName].energy >= energyRequired && heroes[heroName].skills.includes(superPower)){
                    heroes[heroName].energy = heroes[heroName].energy - energyRequired;
                    console.log(`${heroName} has used ${superPower} and now has ${heroes[heroName].energy} energy!`);                    
                } else {
                    console.log(`${heroName} is unable to use ${superPower} or lacks energy!`);                    
                }
        },
        Train(heroName, trainingEnergy) {
            trainingEnergy = Number(trainingEnergy); 
            let newEnergy = 0;
            const currEnergy = heroes[heroName].energy;
                if(currEnergy === 100){
                    console.log(`${heroName} is already at full energy!`);                    
                } else {
                    newEnergy = currEnergy + trainingEnergy;
                    if(newEnergy > 100){
                        newEnergy = 100 - currEnergy;
                        heroes[heroName].energy = 100;        
                        console.log(`${heroName} has trained and gained ${newEnergy} energy!`);           
                    } else {
                        heroes[heroName].energy = newEnergy;
                        console.log(`${heroName} has trained and gained ${trainingEnergy} energy!`);   
                    }                   
                                 
                }  
        },
    
        Learn(heroName, newSuperPower) {
            if(heroes[heroName].skills.includes(newSuperPower)){
                console.log(`${heroName} already knows ${newSuperPower}.`);                
            } else {
                heroes[heroName].skills.push(newSuperPower);
                console.log(`${heroName} has learned ${newSuperPower}!`);
            }
        }
    };
    
    let commandLine = input.shift();
    while(commandLine !== 'Evil Defeated!'){
        let[command, heroName, ...args] = commandLine.split(' * ');
            command = command.replace(' ', '')
            if(commands[command]){
                commands[command](heroName, ...args);
            }
        

        commandLine = input.shift();
    }

    for (const hero in heroes) {
        console.log(`Superhero: ${hero}`);
        console.log(`- Superpowers: ${heroes[hero].skills.join(', ')}`);
        console.log(`- Energy: ${heroes[hero].energy}`);               
    }
}

solve(([
    "3",
    "Iron Man-Repulsor Beams,Flight-80",
    "Thor-Lightning Strike,Hammer Throw-10",
    "Hulk-Super Strength-60",
    "Use Power * Iron Man * Flight * 30",
    "Train * Thor * 20",
    "Train * Hulk * 50",
    "Learn * Hulk * Thunderclap",
    "Use Power * Hulk * Thunderclap * 70",
    "Evil Defeated!"
])
);
