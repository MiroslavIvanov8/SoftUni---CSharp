function cats(input){

    let Cat = class{
        constructor(name, age){
            this.name = name;
            this.age = age;
        }

        meow(){
            console.log(`${this.name}, age ${this.age} says Meow`);
        };
    };

    input.forEach(entry => {
        let [name, age] = entry.split(' ');
        let cat = new Cat(name, age);
        cat.meow();
    });
}

cats(['Mellow 2', 'Tom 5']);
