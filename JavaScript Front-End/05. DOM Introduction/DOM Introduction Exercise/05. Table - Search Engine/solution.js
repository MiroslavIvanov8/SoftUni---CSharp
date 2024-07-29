function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {

      const tableRowEls = document.querySelectorAll('table.container tbody tr');

      function getMatchedElements(input) {
         return [...tableRowEls]
         .filter((row) => row.textContent.toLocaleLowerCase().includes(input.toLocaleLowerCase()));

      }

      function clearPreviousState(){
         [...tableRowEls].forEach((rowEl) => {
            rowEl.classList.remove('select');
         })
      }

      clearPreviousState();


      const searchFieldEl = document.getElementById('searchField');
      const matchRows = getMatchedElements(searchFieldEl.value);

      matchRows.forEach((matchRow) => {
         matchRow.classList.add('select');
      })


      searchFieldEl.value = '';
   }
}
