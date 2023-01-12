using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunilariaDev.Domains;

namespace FunilariaDev.Interfaces
{
    interface IPlateAnalysisRepository
    {
        public string Analyze(int IdUser);

        public string DeleteImage(int idUser);
    }
}
