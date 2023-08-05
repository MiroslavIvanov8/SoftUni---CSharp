﻿using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private readonly List<IHotel> hotels= new List<IHotel>();
        public void AddNew(IHotel model) => hotels.Add(model);

        public IReadOnlyCollection<IHotel> All() => hotels;

        public IHotel Select(string hotelName) => hotels.FirstOrDefault(h => h.FullName == hotelName); 
    }
}
