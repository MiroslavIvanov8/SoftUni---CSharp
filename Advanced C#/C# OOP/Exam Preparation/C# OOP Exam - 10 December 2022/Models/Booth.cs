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

namespace ChristmasPastryShop.Models
{
    public class Booth : IBooth
    {
        private int capacity;
        
        private double currentBill;
        private double turnover;
        private readonly IRepository<IDelicacy> delicacyMenu;
        private readonly IRepository<ICocktail> cocktailMenu;
        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;

            delicacyMenu = new DelicacyRepository();
            cocktailMenu = new CocktailRepository();

            CurrentBill = 0;
            turnover = 0;
            IsReserved = false;
        }
        public int BoothId { get; private set; }
        public int Capacity 
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => this.delicacyMenu; 

        public IRepository<ICocktail> CocktailMenu => this.cocktailMenu; 

        public double CurrentBill 
        {
            get => currentBill;
            private set
            {
                currentBill = value;
            }
        }

        public double Turnover 
        {
            get => turnover;
            private set
            {
                turnover = value;
            }
        }

        public bool IsReserved { get; private set; }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }
        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }
        public void ChangeStatus()
        {
            IsReserved = !IsReserved;
        }

        public override string ToString()
        {
            //!!!! 

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");

            if (CocktailMenu.Models.Any())
            {
                foreach (var item in CocktailMenu.Models)
                    sb.AppendLine($"--{item.ToString()}");
            }           
            sb.AppendLine($"-Delicacy menu:");
            if (DelicacyMenu.Models.Any())
            {
                foreach (var item in DelicacyMenu.Models)
                    sb.AppendLine($"--{item.ToString()}");
            }
            return sb.ToString().TrimEnd(); ;

        }

    }
}
