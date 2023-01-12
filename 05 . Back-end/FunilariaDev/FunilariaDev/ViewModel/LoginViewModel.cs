        using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FunilariaDev.ViewModel
{
    public class LoginViewModel 
    {
        [Required(ErrorMessage = "O Email não pode estar vazio!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha não pode estar vazia!")]
        public string Password { get; set; }
    }
}
