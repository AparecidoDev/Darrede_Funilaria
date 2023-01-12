using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunilariaDev.Domains;
using Microsoft.AspNetCore.Http;

namespace FunilariaDev.Interfaces
{
    interface IUserRepository
    {

        public List<User> ListAll();

        void Register(User newUser);

        void Update(int IdUser, User userUpdated);

        public string UpdateImage(int id, IFormFile file);

        public void UpdatePlate(int idUser, string Description);

        public User FindForId(int Id);

        public User FindImageWithId(int Id);

        public User FindForEmail(string email);

        void Delete(int Id);


        /// <summary>
        /// Valida um Usuario de acordo com o e-mail e senha
        /// </summary>
        /// <param name="email">E-mail do Usuario que deseja fazer o Login</param>
        /// <param name="password">Senha do Usuario que deseja fazer o Login</param>
        /// <returns></returns>
        User Login(string email, string password);
    }
}
