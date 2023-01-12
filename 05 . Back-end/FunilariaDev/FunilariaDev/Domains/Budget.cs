using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FunilariaDev.Domains
{
    public class Budget
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBudget {get;set;}

        public int IdModel { get; set; }

        [ForeignKey("IdModel")]
        public Model model { get; set; }

        public int IdService { get; set; }

        [ForeignKey("IdService")]
        public Service service { get; set; }

        [Column(TypeName = "FLOAT")]
        [Required(ErrorMessage = "O valor total não pode estar vazio")]
        public float TotalValue { get; set; }

    }
}
