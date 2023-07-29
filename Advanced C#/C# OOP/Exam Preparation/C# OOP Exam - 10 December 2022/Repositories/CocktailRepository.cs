﻿using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private readonly List<ICocktail> cocktails = new List<ICocktail>();
        public IReadOnlyCollection<ICocktail> Models => this.cocktails;

        public void AddModel(ICocktail model) => this.cocktails.Add(model);
    }
}
