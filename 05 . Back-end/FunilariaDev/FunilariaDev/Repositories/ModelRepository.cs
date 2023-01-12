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
    public class ModelRepository : IModelRepository
    {

        FunilariaContext ctx = new FunilariaContext();

        public void Delete(int Id)
        {
            Model searched = ctx.Templates.Find(Id);

            if(searched != null)
            {
                ctx.Templates.Remove(searched);
            }

            ctx.SaveChanges();
        }

        Model IModelRepository.FindForId(int Id)
        {
            return ctx.Templates.FirstOrDefault(m => m.IdModel == Id);
        }

        Model IModelRepository.FindForNameModel(string nameModel)
        {
            return ctx.Templates.FirstOrDefault(m => m.NameModel == nameModel);
        }

        public List<Model> ListAll()
        {
            return ctx.Templates.Include(c => c.brand).ToList();
        }

        public void Register(Model newModel)
        {
            ctx.Templates.Add(newModel);
            ctx.SaveChanges();
        }

        public void Update(int Id, Model modelUpdated)
        {
            Model searched = ctx.Templates.Find(Id);

            if(searched != null)
            {
                searched.NameModel = modelUpdated.NameModel;
            }

            ctx.Templates.Update(searched);

            ctx.SaveChanges();
        }
    }
}
