﻿using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private readonly List<IDelicacy> delicacies = new List<IDelicacy>();
        public IReadOnlyCollection<IDelicacy> Models => this.delicacies;

        public void AddModel(IDelicacy model) => this.delicacies.Add(model);
    }
}
