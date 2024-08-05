function solve() {

  //Get Generate button and add event listener to him
  const [generateBtn, buyBtn] = document.querySelectorAll('button');
  const tbodyEl = document.querySelector('.table tbody');
  const firstTrEl = document.querySelector('.table tbody tr');
  const [inputTextarea, outputTextarea] = document.querySelectorAll('textarea');

  function appendTrForEachData({ img, name, price, decFactor }) {
    const currTrCone = firstTrEl.cloneNode(true);

    currTrCone.children[0].children[0].setAttribute('src', img);
    currTrCone.children[0].innerHtml = currTrCone.children[0].innerHtml.trim();

    currTrCone.children[1].children[0].textContent = name;
    currTrCone.children[1].innerHtml = currTrCone.children[1].innerHtml.trim();

    currTrCone.children[2].children[0].textContent = price;
    currTrCone.children[2].innerHtml = currTrCone.children[2].innerHtml.trim();

    currTrCone.children[3].children[0].textContent = decFactor;
    currTrCone.children[3].innerHtml = currTrCone.children[3].innerHtml.trim();

    const checkboxEl = currTrCone.children[4].children[0];
    currTrCone.children[4].innerHtml = currTrCone.children[4].innerHtml.trim();
    
    checkboxEl.removeAttribute('disabled');
    checkboxEl.setAttribute('name', name);
    checkboxEl.setAttribute('price', price);
    checkboxEl.setAttribute('decFactor', decFactor);

    tbodyEl.appendChild(currTrCone);
  }

  function onGenerateBtnClickHandler() {
    const inputData = JSON.parse(inputTextarea.value);

    inputData.forEach(appendTrForEachData)
  }

  function onBuyBtnClickHandler() {
    const outputData = [...document.querySelectorAll('input[type=checkbox]')]
      .filter((el) => el.checked).reduce((acc, currInputEl) => {

        const name = currInputEl.getAttribute('name');
        const price = currInputEl.getAttribute('price');
        const decFactor = currInputEl.getAttribute('decFactor');

        acc.names.push(name);
        acc.totalPrice += Number(price);
        acc.totalDecFactor += Number(decFactor);
        return acc;
      }, { names: [], totalPrice: 0, totalDecFactor: 0 });

    outputTextarea.value = `Bought furniture: ${outputData.names.join(', ')}\nTotal price: ${outputData.totalPrice.toFixed(2)}\nAverage decoration factor: ${(outputData.decFactor / outputData.names.length).toFixed(2)}`
  }

  generateBtn.addEventListener('click', onGenerateBtnClickHandler)

  buyBtn.addEventListener('click', onBuyBtnClickHandler)

  //Get Buy button and add event listener to him

}
