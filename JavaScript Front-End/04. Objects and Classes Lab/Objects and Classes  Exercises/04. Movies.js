function printMovies(input){
    let Movie = class{
        constructor(name){
            this.name = name;
        }
    }

    let movies = [];

    input.forEach(entry => {

        if(entry.startsWith('addMovie ')){
            const movieName = entry.slice(9);

            let newMovie = new Movie(movieName);

            if(!movies[movieName]){
                movies[movieName] = newMovie;
            }
        } else {
                       
            if(entry.includes('directedBy')){

                const movieInfo = entry.split(' directedBy ');
                const movieName = movieInfo[0];
                const director = movieInfo[1];

                if(movies[movieName]){
                    movies[movieName].director = director;
                }

            } else if (entry.includes('onDate')){
                
                const movieInfo = entry.split(' onDate ');
                const movieName = movieInfo[0];
                const date = movieInfo[1];

                if(movies[movieName]){
                    movies[movieName].date = date;
                }
            }
        }
    })

    for (const movie in movies) {
        
        if(movies[movie].name && movies[movie].date && movies[movie].director){
            const movieInfo = JSON.stringify(movies[movie]);
            console.log(movieInfo);
         }
    }    
}

printMovies([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
    ]
    );
