using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunilariaDev.Domains;
using FunilariaDev.Context;
using FunilariaDev.Interfaces;
using FunilariaDev.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;

namespace FunilariaDev.Repositories
{
    public class UserRepository : IUserRepository
    {

        FunilariaContext ctx = new FunilariaContext();
        public void Delete(int id)
        {
            User searchedUser = ctx.Users.Find(id);

            if (searchedUser != null)
            {
                ctx.Users.Remove(searchedUser);
            }

            ctx.SaveChanges();
        }

        public User FindForEmail(string email)
        {
            return ctx.Users.FirstOrDefault(em => em.Email == email);
        }

        public User FindForId(int id)
        {
            return ctx.Users.FirstOrDefault(i => i.IdUser == id);
        }

        public User FindImageWithId(int id)
        {
            return ctx.Users
                .FirstOrDefault(u => u.IdUser == id);
        }

        public List<User> ListAll()
        {
            return ctx.Users.Select(u => new User
            {
                IdUser = u.IdUser,
                Name = u.Name,
                Email = u.Email,
                Phone = u.Phone,
                ImagePlate = u.ImagePlate,
                Plate = u.Plate,
                TypeUser = u.TypeUser
            }).ToList();
        }

        public User Login(string email, string password)
        {

            return ctx.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public void Register(User newUser)
        {

            PasswordVerify passVefrify = new PasswordVerify();

            var passwordCrip = passVefrify.Criptografar(newUser.Password);
            

            if (passwordCrip != null)
            {
                newUser.Password = passwordCrip;
                
            }


            ctx.Users.Add(newUser);
            ctx.SaveChanges();
        }


        public void Update(int id, User userUpdated)
        {
            User searchedUser = ctx.Users.Find(id);

            if(searchedUser != null)
            {
                searchedUser.Name = userUpdated.Name;
                searchedUser.Password = userUpdated.Password;
                searchedUser.Phone = userUpdated.Phone;
                searchedUser.ImagePlate = userUpdated.ImagePlate;
                searchedUser.Plate = userUpdated.Plate;
            }

            ctx.Users.Update(searchedUser);
            ctx.SaveChanges();
        }

        public string UpdateImage(int id, IFormFile file)
        {

            if (file.Length > 500000000)
            {
                return "O tamanho máximo da imagem foi atingido." ;
            }
                

            //analise da extensao do arquivo
            //Split = retorna uma matriz de caracteres
            //Last = recupera a ultima posição da matriz.
            string extensao = file.FileName.Split('.').Last();

          
                    var folderName = Path.Combine("Resources", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                    User userFinded = ctx.Users.Find(id);

                    if (userFinded != null)
                    {
                        userFinded.ImagePlate = fileName;
                    }

                    ctx.Users.Update(userFinded);
                    ctx.SaveChanges();

                return fileName;
                }
                else
                {
                    return "";
                }

            }

        public void UpdatePlate(int idUser, string Description)
        {
            User userFinded = ctx.Users.Find(idUser);

            if(userFinded != null)
            {
                userFinded.Plate = Description;
            }

            ctx.Users.Update(userFinded);
            ctx.SaveChanges();
        }
    }
    }
