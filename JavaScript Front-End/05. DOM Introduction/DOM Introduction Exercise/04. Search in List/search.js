function search() {
   const towns = document.getElementById('towns').textContent.split('\n');
   let townsElements = document.getElementsByTagName('li');
   const searchTerm = document.getElementById('searchText').value.toLowerCase();
 
   debugger;
   let townsElementsArr = Array.from(townsElements);
   let resultElement = document.getElementById('result');

   for (let i = 0; i < townsElementsArr.length; i++) {
      townsElements[i].style.fontWeight = 300;
      townsElements[i].style.textDecoration = 'none';
   }

   const townsArr = Array.from(towns)
   .filter(town => town.trim().toLowerCase().includes(searchTerm));

   for (let i = 0; i < townsElementsArr.length; i++) {
      let currTown = townsElements[i].textContent

      for (let j = 0; j < townsArr.length; j++) {
         const matchTown = townsArr[j].trim();;

         if (currTown == matchTown) {
            townsElements[i].style.fontWeight = 'bold';
            townsElements[i].style.textDecoration = 'underline';
         }
      }
   }    
   
   resultElement.textContent = `${townsArr.length} matches found`;
}
