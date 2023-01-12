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
    public class BudgetRepository : IBudgetRepository
    {

        FunilariaContext ctx = new FunilariaContext();

        public void Delete(int Id)
        {
            Budget SEARCHED = ctx.Budgets.Find(Id);

            ctx.Budgets.Remove(SEARCHED);

            ctx.SaveChanges();

        }

        Budget IBudgetRepository.FindForId(int id)
        {
            return ctx.Budgets.FirstOrDefault(i => i.IdBudget == id);
        }

        public List<Budget> ListAll()
        {
            return ctx.Budgets
                .Include(p => p.model)
                .Include(p => p.service)
                .ToList();
        }

        public void RegisterBudget(Budget newBudget)
        {
            ctx.Budgets.Add(newBudget);
            ctx.SaveChanges();
        }

        public void Update(int Id, Budget newBudget)
        {
            Budget Searched = ctx.Budgets.Find(Id);

            if(Searched != null)
            {
                Searched.IdModel = newBudget.IdModel;
                Searched.IdService = newBudget.IdService;
                Searched.TotalValue = newBudget.TotalValue;
            }

            ctx.Budgets.Update(Searched);

            ctx.SaveChanges();
        }

        //In theory this method should return a budget based on the customer's car model, making a search in the database and returning the object with the value and the problem
        public List<Budget> RecomentedBudget(int id)
        {

            ICarRepository cars = new CarRepository();

             var carFinded = cars.FindForId(id);

           
             return ctx.Budgets.Include(c => c.model).Include(c => c.service).Where(c => c.model.NameModel == carFinded.Model).ToList();
            

       
        }
    }
}
