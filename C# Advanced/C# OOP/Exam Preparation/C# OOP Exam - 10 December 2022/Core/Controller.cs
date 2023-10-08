using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IBooth> booths = new BoothRepository();
        
        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(booths.Models.Count + 1, capacity);

            booths.AddModel(booth);
            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);

            if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IDelicacy delicacy;
            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else
            {
                delicacy = new Stolen(delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
            
        }
        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != nameof(MulledWine) && cocktailTypeName != nameof(Hibernation))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);

            if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail;
            if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            else
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);

        }
        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = booths.Models // can make it right here only one  !!!
                .Where(b => b.IsReserved == false && b.Capacity>=countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth is null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            

            booth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderInfo = order.Split("/",StringSplitOptions.RemoveEmptyEntries);

            string itemTypeName = orderInfo[0];
            string itemName = orderInfo[1];
            int count = int.Parse(orderInfo[2]);
            string size = string.Empty;

            IBooth booth = booths.Models.First(m => m.BoothId == boothId);

            if (itemTypeName == nameof(Hibernation) || itemTypeName == nameof(MulledWine))
            {
                size = orderInfo[3];
            }

            if (itemTypeName != nameof(Stolen)
            && itemTypeName != nameof(Gingerbread)
            && itemTypeName != nameof(Hibernation)
            && itemTypeName != nameof(MulledWine))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if    (!booth.CocktailMenu.Models.Any(i=>i.GetType().Name == itemTypeName)
                && !booth.DelicacyMenu.Models.Any(i=> i.GetType().Name == itemTypeName))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            

            if (itemTypeName == nameof(Gingerbread) || itemTypeName == nameof(Stolen)) // might need to refactor this part here
            {
                if (!booth.DelicacyMenu.Models.Any(d => d.Name == itemName && d.GetType().Name == itemTypeName))
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded,itemTypeName,itemName);
                }

                IDelicacy delicacy = booth.DelicacyMenu.Models.First(d => d.Name == itemName);
                // check if you need this GetType here and at cocktail aswell

                booth.UpdateCurrentBill(delicacy.Price * count);
                
            }
            else
            {
                if (!booth.CocktailMenu.Models.Any(c => c.Name == itemName && c.Size == size && c.GetType().Name == itemTypeName))
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                ICocktail cocktail = booth.CocktailMenu.Models.First(c => c.Name == itemName && c.Size == size);
                // check if you need this GetType here and at cocktail aswell

                booth.UpdateCurrentBill(cocktail.Price * count);
                
            }

            return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, count, itemName);
        }
        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);

            double currBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {currBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().TrimEnd();
        }
        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.First(b => b.BoothId == boothId);

            return booth.ToString();
        }



    }
}
