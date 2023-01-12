using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunilariaDev.Utils
{
    public class PasswordVerify
    {
       public string passwordHash = BCrypt.Net.BCrypt.HashPassword("funilaria-dev");

        public  string Criptografar(string senha)
        {
            //passa a senha para o banco de dados já criptografada com Hash
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public  bool ValidarSenha(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}
