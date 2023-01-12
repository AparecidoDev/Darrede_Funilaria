using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunilariaDev.Domains;

namespace FunilariaDev.Interfaces
{
    interface ICarRepository
    {
        public List<Car> ListAll();

        public List<Car> ListWithId(int id);

        void registerCar(Car newCar);

        void Update(int IdCar, Car carUpdated);

        public Car FindForPlate(string plate);

        public Car FindForId(int Id);

        void Delete(int Id);
    }
}
