﻿using DEVinCar.Service.Interfaces.Repositories;
using DEVinCar.Service.Models;

namespace DEVinCar.Repository.Data.Repositories
{
    public class CarRepository : BaseRepository<Car, int>, ICarRepository
    {
        public CarRepository(DevInCarDbContext context) : base(context)
        {
        }
    }
}