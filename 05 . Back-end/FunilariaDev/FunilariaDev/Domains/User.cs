
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace FunilariaDev.Domains
{

    //Define o nome da tabela que será criada no banco de dados
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [FromQuery]
        public int IdUser { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O Nome não pode estar vazio!")]

        public string Name { get;  set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "O Email não pode estar vazio!")]
        public string Email { get;  set; }

        [Column(TypeName = "VARCHAR(150)")]
        
        [StringLength(30, MinimumLength = 8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres e no máximo 30")]
        public string Password { get;  set; }

        [Column(TypeName = "BIGINT")]
        [Required(ErrorMessage = "O número de telefone não pode estar vazio!")]
        public int Phone { get;  set; }

        
        [Column(TypeName = "VARCHAR(255)")]
     
        public string ImagePlate { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string Plate { get; set; }

        [Column(TypeName = "INT")]
        
        public int TypeUser { get;  set; }

    }
}
