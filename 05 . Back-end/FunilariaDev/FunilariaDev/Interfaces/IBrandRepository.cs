using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunilariaDev.Domains;

namespace FunilariaDev.Interfaces
{
    interface IBrandRepository
    {
        public List<Brand> ListAll();

        void Register(Brand newBrand);

        void Update(int Id, Brand brandUpdated);

        void Delete(int Id);

        public Brand FindForNameBrand(string brand);
    }
}
