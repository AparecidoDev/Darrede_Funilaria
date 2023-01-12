using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunilariaDev.Context;
using FunilariaDev.Interfaces;
using FunilariaDev.Domains;

namespace FunilariaDev.Repositories
{
    public class ServiceRepository : IServiceRepository
    {

        FunilariaContext ctx = new FunilariaContext();

        public void Delete(int Id)
        {
            Service searched = ctx.Services.Find(Id);

            if(searched != null)
            {
                ctx.Services.Remove(searched);
            }

            ctx.SaveChanges();
        }

        Service IServiceRepository.FindForId(int Id)
        {
            return ctx.Services.FirstOrDefault(s => s.IdService == Id);
        }

        Service IServiceRepository.FindForName(string nameService)
        {
            return ctx.Services.FirstOrDefault(s => s.Problem == nameService);
        }

        public List<Service> ListAll()
        {
            return ctx.Services.ToList();
        }

        public void Register(Service newService)
        {
            ctx.Services.Add(newService);
            ctx.SaveChanges();
        }

        public void Update(int Id, Service serviceUpdated)
        {
            Service searched = ctx.Services.Find(Id);

            if(searched != null)
            {
                searched.Problem = serviceUpdated.Problem;
            }

            ctx.Services.Update(searched);

            ctx.SaveChanges();
        }
    }
}
