function printSongs(input) {

    let Song = class {
        constructor(name, duration) {
            this.name = name;
            this.duration = duration;
        }

        print(){
            console.log(this.name);
        }
    }
    let count = input.shift();
    let playLists = {};
    const allSongs = [];

    for (let i = 0; i < count; i++) {
        let [type, name, duration] = input[i].split("_");

        if (!playLists[type]) {
            playLists[type] = [];
        }

        const song = new Song(name, duration)
        playLists[type].push(song);
        allSongs.push(song);
    }

    const typeList = input[input.length - 1];

    if(typeList === 'all'){
        for (const key in playLists) {
            allSongs.forEach(song => song.print());
        }
    } else if(playLists[typeList]){
        playLists[typeList].forEach(song => song.print());
    }
}

printSongs([4,
    'ban_hey_3:48',
    'programming_ban_3:42',
    'ban_hello_3:29',
    'like_like_3:05',
    'all']      
);
