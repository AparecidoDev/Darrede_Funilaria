using API_Mockada.Contexts;
using API_Mockada.Domains;
using API_Mockada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Mockada.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        MockadaContext ctx = new MockadaContext();

        public Carro ListByPlate(string Plate)
        {
            return ctx.Carros.FirstOrDefault(c => c.Placa == Plate);
        }
    }
}

