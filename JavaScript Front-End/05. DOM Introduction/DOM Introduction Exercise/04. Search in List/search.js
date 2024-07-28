function search() {
   const townEls = document.querySelectorAll('#towns li');
   
   function getMatchElements(input){
      return [...townEls].filter((x) => 
      x.textContent.toLocaleLowerCase().includes(input.toLocaleLowerCase()));
   }

   function clearPreviousState(){
      townEls.forEach((el) => {
         el.style.fontWeight = 'normal';
         el.style.textDecoration = 'none';
      })
   }

   clearPreviousState();
   const [inputEl] = document.getElementsByTagName('input');

   const matchElements = getMatchElements(inputEl.value);

   matchElements.forEach((matchedEl) => {
      matchedEl.style.fontWeight = 'bold';
      matchedEl.style.textDecoration = 'underline';
      }
   );

   let resultEl = document.getElementById('result');
   resultEl.textContent = `${matchElements.length} matches found`

}
