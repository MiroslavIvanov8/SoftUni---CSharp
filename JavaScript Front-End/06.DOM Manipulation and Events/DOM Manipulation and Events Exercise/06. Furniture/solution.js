function solve() {

    //Get generate and buy buttons
    const [generateBtn, buyBtn] = document.querySelectorAll('button');
    const [inputTextareaEl, outputTextareaEl] = document.querySelectorAll('textarea');
    const tableRowEl = document.querySelector('tbody');
    
    //Attach eventlistener to generate button
    function generateFurniture(e) {    
          
      //Parse the data from the array and create dom row object
      const inputData = JSON.parse(inputTextareaEl.value);
      inputData.forEach((obj) => {
        const trEl = document.createElement('tr');

        //create img td
        const tdImg = document.createElement('td');
        const imgEl = document.createElement('img');
        imgEl.src = obj.img;
        tdImg.appendChild(imgEl);
        trEl.appendChild(tdImg);

        //create tdName
        const tdName = document.createElement('td');
        const pNameEl = document.createElement('p');
        pNameEl.textContent = obj.name;
        tdName.appendChild(pNameEl);
        trEl.appendChild(tdName);

        //create tdPrice
        const tdPrice = document.createElement('td');
        const pPriceEl = document.createElement('p');
        pPriceEl.textContent = obj.price;
        tdPrice.appendChild(pPriceEl);
        trEl.appendChild(tdPrice);

        //create tdDecFactor
        const tdDecFactor = document.createElement('td');
        const pDecFactorEl = document.createElement('p');
        pDecFactorEl.textContent = obj.decFactor;
        tdDecFactor.appendChild(pDecFactorEl);
        trEl.appendChild(tdDecFactor);

        
        //create tdCheckbox
        const tdCheckBox = document.createElement('td');
        const inputCheckBoxEl  = document.createElement('input');
        inputCheckBoxEl.setAttribute('type', 'checkbox');
        tdCheckBox.appendChild(inputCheckBoxEl);
        trEl.appendChild(tdCheckBox);

        tableRowEl.appendChild(trEl);

      })
      
  }
    
    generateBtn.addEventListener('click', generateFurniture)
    
    //Attach eventlistener to buy button
    buyBtn.addEventListener('click', (e) => {
      
      //Get all checked items
        const checked = [...document.querySelectorAll('input[type=checkbox]')]
        .filter((e) => e.checked);
        
        //Output
        const bought = checked.map((input) => input.closest('tr').children[1].children[0].textContent);
        const totalPrice = checked.reduce((acc, curr) => {
            const price = Number(curr.closest('tr').children[2].children[0].textContent);
          return acc += price;
        }, 0)
        
        const avgDecFactor = (checked.reduce((acc, curr) => {
              const decFactor = Number(curr.closest('tr').children[3].children[0].textContent);
              return acc += decFactor;
            }, 0)) / checked.length;
        
        outputTextareaEl.value = `Bought furniture: ${bought.join(', ')}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${avgDecFactor}`;
    })
    
  }
  