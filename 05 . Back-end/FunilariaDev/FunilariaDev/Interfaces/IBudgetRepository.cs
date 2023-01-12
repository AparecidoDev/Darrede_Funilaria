using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunilariaDev.Domains;

namespace FunilariaDev.Interfaces
{
    interface IBudgetRepository
    {
        public List<Budget> ListAll();

        void RegisterBudget(Budget newBudget);

        void Update(int Id, Budget newBudget);

        void Delete(int Id);

        public List<Budget> RecomentedBudget(int idUser);

        public Budget FindForId(int id);
    }
}
