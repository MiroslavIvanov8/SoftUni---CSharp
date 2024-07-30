function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   const inputTextArea = document.querySelector('#inputs textarea');
   const bestRestaurantEl = document.querySelector('#outputs #bestRestaurant p');
   const workersEl = document.querySelector('#outputs #workers p');

   function onClick() {
      const restaurants = JSON.parse(inputTextArea.value).reduce((acc, data) => {
         const [restaurantName, workersData] = data.split(' - ');

         const workers = workersData.split(', ').map((workerData => {
            const [name, salary] = workerData.split(' ');
            return {
               name,
               salary: Number(salary)
            }
         }))

         if (!acc.hasOwnProperty(restaurantName)) {
            acc[restaurantName] = {
               workers: []
            }
         }

         acc[restaurantName].workers.push(...workers);

         return acc;
      }, {});


      function getAvgSalary(restaurantData) {
         debugger;
         return (
            restaurantData.workers.reduce((acc, currSalary) => acc + currSalary.salary, 0) / 
            restaurantData.workers.length);
      }

      const [bestRestaurant] = Object.keys(restaurants).sort(
         (a, b) => getAvgSalary(restaurants[b]) - getAvgSalary(restaurants[a]))
      
      const bestWorkers = restaurants[bestRestaurant].workers
      .slice()
      .sort((a, b) => b.salary - a.salary);
      
      bestRestaurantEl.textContent = `Name: ${bestRestaurant} Average Salary: ${getAvgSalary(restaurants[bestRestaurant]).toFixed(2)} Best Salary: ${(bestWorkers[0].salary).toFixed(2)}`;
            
      workersEl.textContent = bestWorkers.map((x) => `Name: ${x.name} With Salary: ${x.salary}`).join(' ');
   }
}
