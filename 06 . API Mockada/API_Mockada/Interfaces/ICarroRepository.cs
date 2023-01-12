using API_Mockada.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Mockada.Interfaces
{
    interface ICarroRepository
    {
        public Carro ListByPlate(string Plate);
    }
}
