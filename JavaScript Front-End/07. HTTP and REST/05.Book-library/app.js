function attachEvents() {
  
    const baseUrl = 'http://localhost:3030/jsonstore/collections/books';
    const loadBooksBtn = document.getElementById('loadBooks');
    const tableTbodyEl = document.querySelector('table tbody');
    const fromSubmitBtn = document.querySelector('#form button:last-of-type');

    loadBooksBtn.addEventListener('click', (e) => {

      tableTbodyEl.innerHTML = '';
      
      //fetch all books
      fetch(baseUrl)
        .then(response => response.json())
        .then(result => {
            const books = Object.values(result);
            const bookEls = books.map(createBookEl);           
            tableTbodyEl.append(...bookEls);     
        });
    });
        
    fromSubmitBtn.addEventListener('click', (e) => {
        e.preventDefault();
      
        //get inputs
        const titleInput = document.querySelector('#form input[name=title]');
        const authorInput = document.querySelector('#form input[name=author]');

        //send data to the server api
        fetch(baseUrl, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            title : titleInput.value,
             author : authorInput.value
            }),
        })
            .then(response => response.json())
            .then(result => {
              
              const bookEl = createBookEl(result);
              tableTbodyEl.append(bookEl);

              titleInput.value = '';
              authorInput.value = '';
            });
        
    })
  
}

function createBookEl(book){
  const tdAuthor = document.createElement('td');
              const tdTitle = document.createElement('td');
              tdTitle.textContent = book.title;
              tdAuthor.textContent = book.author;

              const trEl = document.createElement('tr');
              trEl.append(tdTitle, tdAuthor);

              const tdBtns = document.createElement('td');
              const editBtn = document.createElement('button');
              const deleteBtn = document.createElement('button');
              editBtn.textContent = 'Edit';
              deleteBtn.textContent = 'Delete';

              tdBtns.append(editBtn, deleteBtn);
              trEl.append(tdBtns);
              
              //append each tr element to  the table
        return trEl;
}
attachEvents();

/*<tr>
                <td>Book 1</td>
                <td>Author 1</td>
                <td>
                    <button>Edit</button>
                    <button>Delete</button>
                </td>
</tr>*/
