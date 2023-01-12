using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunilariaDev.Domains;

namespace FunilariaDev.Interfaces
{
    interface IModelRepository
    {
        public List<Model> ListAll();

        void Register(Model newModel);

        void Update(int Id, Model modelUpdated);

        void Delete(int Id);

        public Model FindForId(int Id);

        public Model FindForNameModel(string nameModel);
    }
}
