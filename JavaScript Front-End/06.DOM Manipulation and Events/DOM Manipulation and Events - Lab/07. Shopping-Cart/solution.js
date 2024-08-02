function solve() {

   //Get references of textarea and checkout button
   const textareaElement = document.querySelector('textarea');
   const checkoutButton = document.querySelector('button.checkout');

   const productsCatalog = document.querySelector('div.shopping-cart');
   let productList = [];

   //Add event listener to add button
   productsCatalog.addEventListener('click', (e) => {
      if(e.target.tagName !== 'BUTTON' || e.target.textContent.trim() === 'Checkout'){
         return;
      }

      //Get name and price of product
      const product = e.target.closest('.product');
      const name = product.querySelector('.product-title').textContent;
      const price = Number(product.querySelector('.product-line-price').textContent);

      productList.push({
         name,
         price
      });

      //Print the added product
      textareaElement.value += `Added ${name} for ${price.toFixed(2)} to the cart.\n`
   })


   checkoutButton.addEventListener('click', (e) => {

      //Printing a unique list of all products with total sum fixed(2)
      
      const prices = productList.map((x) => x.price);
      const totalPrice = prices.reduce((price,sum) => price + sum, 0).toFixed(2);
      const products = Array.from(new Set((productList).map((x) => x.name))).join(', ');
      
      textareaElement.value += (`You bought ${products} for ${totalPrice}.`);

      //Disabling all other buttons
      const buttons = document.querySelectorAll('button');
      buttons.forEach((x) => {
         x.setAttribute('disabled', 'disabled');
      });
   })  
}
