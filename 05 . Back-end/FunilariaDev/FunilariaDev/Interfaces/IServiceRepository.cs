using FunilariaDev.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunilariaDev.Interfaces
{
    interface IServiceRepository
    {
        public List<Service> ListAll();

        void Register(Service newUser);

        void Update(int Id, Service serviceUpdated);

        public Service FindForId(int Id);

        public Service FindForName(string nameService);

        void Delete(int Id);
    }
}
