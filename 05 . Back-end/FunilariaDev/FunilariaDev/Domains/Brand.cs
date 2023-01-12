using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FunilariaDev.Domains
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBrand { get; set; }
        
        [Column(TypeName= "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome da marca não pode ser vazio")]
        public string NameBrand { get; set; }
    }
}
