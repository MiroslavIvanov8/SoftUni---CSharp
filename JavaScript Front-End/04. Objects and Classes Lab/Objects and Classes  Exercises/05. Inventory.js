function storeHeroes(input){

    let heroes = input.reduce((acc, cur) => {
        
        const [name, level, items] = cur.split(' / ');  
        acc.push({
            name: name,
            level : Number(level),
            items : items.split(', ')    
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
