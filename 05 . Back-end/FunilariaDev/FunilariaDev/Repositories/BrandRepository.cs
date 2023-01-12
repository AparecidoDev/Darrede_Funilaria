using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunilariaDev.Context;
using FunilariaDev.Interfaces;
using FunilariaDev.Domains;

namespace FunilariaDev.Repositories
{
    public class BrandRepository : IBrandRepository
    {

        FunilariaContext ctx = new FunilariaContext();

        public void Delete(int Id)
        {
            Brand Searched = ctx.Brands.Find(Id);

            ctx.Brands.Remove(Searched);
            ctx.SaveChanges();
        }

        public Brand FindForNameBrand(string brand)
        {
            return ctx.Brands.FirstOrDefault(b => b.NameBrand == brand);
        }

        public List<Brand> ListAll()
        {
            return ctx.Brands.ToList();
        }

        public void Register(Brand newBrand)
        {


            ctx.Brands.Add(newBrand);

            ctx.SaveChanges();
        }

        public void Update(int Id, Brand brandUpdated)
        {
            Brand Searched = ctx.Brands.Find(Id);

            if(Searched != null)
            {
                Searched.NameBrand = brandUpdated.NameBrand;
            }

            ctx.Brands.Update(Searched);

            ctx.SaveChanges();
        }
    }
}
