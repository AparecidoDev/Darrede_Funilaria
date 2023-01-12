using System;
using System.Collections.Generic;

#nullable disable

namespace API_Mockada.Domains
{
    public class Carro
    {
        public int IdCarro { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public string Municipio { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
    }
}
