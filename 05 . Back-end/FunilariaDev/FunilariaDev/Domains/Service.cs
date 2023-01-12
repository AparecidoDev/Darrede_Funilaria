using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FunilariaDev.Domains
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdService { get; set; }
        
        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "O problema não pode ser vazio!")]
        public string Problem { get; set; }

    }
}
