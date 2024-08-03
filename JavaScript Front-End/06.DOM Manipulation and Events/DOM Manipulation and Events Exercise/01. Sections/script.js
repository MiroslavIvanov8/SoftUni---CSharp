function create(words) {

   const divResultEl = document.querySelector('div#content');
   words.forEach((word) => {
      const divEl = document.createElement('div');
      const paragraphEl = document.createElement('p');
      
      paragraphEl.textContent = word;
      paragraphEl.style.display = 'none';     

      divEl.appendChild(paragraphEl);
      divResultEl.appendChild(divEl);
   })

   divResultEl.addEventListener('click', (e) => {      
      if(e.target.tagName == 'DIV'){
         e.target.children[0].style.display = 'block';
      }
   })
}
