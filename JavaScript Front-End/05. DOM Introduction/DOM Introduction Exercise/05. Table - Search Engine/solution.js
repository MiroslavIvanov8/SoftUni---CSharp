function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      
      const tdRows = document.getElementsByTagName('td');
      const rows = document.getElementsByTagName('tr');
      const searchTerm = document.getElementById('searchField').value;
      
      const rowsArr = Array.from(tdRows)
      .slice(1)
      .map(content => content.textContent);

      for (let i = 2; i < rows.length; i++) {     
          
         rows[i].classList.remove('select');
      }

      let resultArr = [];

      for (let i = 0; i < rowsArr.length; i+=3) {
         
         const name = rowsArr[i];
         const email = rowsArr[i + 1];
         const course = rowsArr[i + 2];


         if(name.includes(searchTerm) ||
            email.includes(searchTerm) ||
            course.includes(searchTerm)){
               resultArr.push(name);
            }
      }

      if(searchTerm){
         for (let i = 2; i < rows.length; i++) {
         
            const currElementStudentName = rows[i].textContent
                                                  .split('\n')[1]
                                                  .trim();
            debugger;
   
            for (let j = 0; j < resultArr.length; j++) {
               const matchedStudent = resultArr[j];
   
               if(currElementStudentName == matchedStudent){
                  rows[i].classList.add('select');
               }
            }         
         }    
      } else {
         for (let i = 2; i < rows.length; i++) {     
            //debugger;    
            rows[i].classList.remove('select');
         }
      }       
   }
}
