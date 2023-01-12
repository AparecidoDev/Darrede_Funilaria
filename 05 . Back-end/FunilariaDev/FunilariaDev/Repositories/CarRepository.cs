using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunilariaDev.Context;
using FunilariaDev.Interfaces;
using FunilariaDev.Domains;
using Microsoft.EntityFrameworkCore;

namespace FunilariaDev.Repositories
{
    public class CarRepository : ICarRepository
    {

        FunilariaContext ctx = new FunilariaContext();

        public void Delete(int Id)
        {
            Car searched = ctx.Cars.Find(Id);

            if(searched != null)
            {
                ctx.Cars.Remove(searched);
            }

            ctx.SaveChanges();
        }

        Car ICarRepository.FindForId(int id)
        {
            return ctx.Cars.FirstOrDefault(i => i.IdUser == id);
        }

        public List<Car> ListWithId(int id)
        {
            return ctx.Cars.Include(c => c.user).Where(c => c.IdUser == id).ToList();
        }

        Car ICarRepository.FindForPlate(string plate)
        {
            return ctx.Cars.FirstOrDefault(c => c.Plate == plate);
        }

        public List<Car> ListAll()
        {
            return ctx.Cars.ToList();
        }

        public void registerCar(Car newCar)
        {
            ctx.Cars.Add(newCar);
            ctx.SaveChanges();
        }

        public void Update(int IdCar, Car carUpdated)
        {
            Car searched = ctx.Cars.Find(IdCar);

            if(searched != null)
            {
                searched.Plate = carUpdated.Plate;
                searched.Color = carUpdated.Color;
                searched.City = carUpdated.City;
                searched.Brand = carUpdated.Brand;
                searched.Model = carUpdated.Model;
            }

            ctx.Cars.Update(searched);

            ctx.SaveChanges();
        }

        
    }
}
