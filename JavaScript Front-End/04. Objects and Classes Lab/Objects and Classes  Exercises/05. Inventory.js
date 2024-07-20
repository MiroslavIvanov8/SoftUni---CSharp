function storeHeroes(input){

    let heroes = input.reduce((acc, cur) => {
        
        const heroInfo = cur.split(' / ');
        const heroName = heroInfo[0];
        const heroLevel = parseInt(heroInfo[1]);
        const items = heroInfo[2].split(', ');

        acc.push({
            name: heroName,
            level : Number(heroLevel),
            items : items    
        });
        
        return acc
    },[]);

    
    heroes.sort((a,b) => a.level - b.level);
    
    debugger;
    for (const hero of heroes) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items.join(', ')}`);
    }    
}

storeHeroes([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]
    );
