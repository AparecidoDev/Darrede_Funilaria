using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FunilariaDev.Domains
{
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdModel { get; set; }

        public int IdBrand { get; set; }

        [ForeignKey("IdBrand")]
        public Brand brand { get; set; }



        [Column(TypeName = "VARCAHAR(100)")]
        public string NameModel { get; set; }
    }
}
