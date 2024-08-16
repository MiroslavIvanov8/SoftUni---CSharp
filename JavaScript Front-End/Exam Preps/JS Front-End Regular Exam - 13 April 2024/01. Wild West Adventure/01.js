function solve(input) {
    const numberOfCharacters = Number(input.shift());
    let posse = {};

    for (let i = 0; i < numberOfCharacters; i++) {
        [charName, hp, bulletsCount] = input.shift().split(' ');
        posse[charName] = {
            hp: Number(hp),
            bullets: Number(bulletsCount)
        };
    }

    const commands = {
        FireShot(characterName, target) {
            if (posse[characterName].bullets > 0) {
                posse[characterName].bullets--; 
                console.log(`${characterName} has successfully hit ${target} and now has ${posse[characterName].bullets} bullets!`);
            } else {
                console.log(`${characterName} doesn't have enough bullets to shoot at ${target}!`);
            }
        },
        TakeHit(characterName, damage, attacker) {
            damage = Number(damage);
            posse[characterName].hp -= damage;
            if (posse[characterName].hp <= 0) {
                console.log(`${characterName} was gunned down by ${attacker}!`);
                delete posse[characterName];
            } else {
                console.log(`${characterName} took a hit for ${damage} HP from ${attacker} and now has ${posse[characterName].hp} HP!`);
            }
        },
        Reload(characterName) {
            if (posse[characterName].bullets < 6) {
                const bulletsToReload = 6 - posse[characterName].bullets;
                posse[characterName].bullets = 6;
                console.log(`${characterName} reloaded ${bulletsToReload} bullets!`);
            } else {
                console.log(`${characterName}'s pistol is fully loaded!`);
            }
        },
        PatchUp(characterName, amount) {
            amount = Number(amount);
            if (posse[characterName].hp >= 100) {
                console.log(`${characterName} is in full health!`);
            } else {
                let hpBeforePatch = posse[characterName].hp;
                let hpAfterPatch = Math.min(posse[characterName].hp + amount, 100);
                let amountRecovered = hpAfterPatch - hpBeforePatch;

                posse[characterName].hp = hpAfterPatch;
                console.log(`${characterName} patched up and recovered ${amountRecovered} HP!`);
            }
        }
    };

    let commandLine = input.shift();
    while (commandLine !== 'Ride Off Into Sunset') {
        const [command, characterName, ...args] = commandLine.split(' - ');
        if (commands[command]) {
            commands[command](characterName, ...args);
        }
        commandLine = input.shift();
    }

    for (let char in posse) {
        console.log(`${char}\n HP: ${posse[char].hp}\n Bullets: ${posse[char].bullets}`);
    }
}

solve([
    "2",
    "Gus 100 0",
    "Walt 100 6",
    "FireShot - Gus - Bandit",
    "TakeHit - Gus - 100 - Bandit",
    "Reload - Walt",
    "Ride Off Into Sunset"
]);
