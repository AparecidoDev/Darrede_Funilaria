
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FunilariaDev.Domains
{
    //Define o nome da tabela que será criada no banco de dados
    [Table("Cars")]
    public class Car
    {
        //Define que será uma chave primária
        [Key]

        //Define o auto-incremento no banco de dados
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCar { get; set; }

        [Column(TypeName = "VARCHAR(11)")]
        [Required(ErrorMessage = "A Placa do veículo é necessária!")]
        public string Plate { get; set; } //Placa   

        [Column(TypeName = "VARCHAR(30)")]
        public string Color { get; set; } //Cor

        [Column(TypeName = "INT(4)")]
        [Required(ErrorMessage = "O Ano do veículo é necessário!")]
        public string Year { get; set; } //Ano

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A Cidade do veículo Não pode ser vazia!")]
        public string City { get; set; } //Cidade

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O modelo do veículo não pode ser vazio!")]
        public string Model { get; set; } //Modelo

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "A Marca não pode estar vazio!")]
        public string Brand { get; set; } //Marca

        public  int IdUser { get; set; }

        [ForeignKey("IdUser")]
        public User user { get; set; }
    }
}
