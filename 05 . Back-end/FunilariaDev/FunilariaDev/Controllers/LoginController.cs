using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using FunilariaDev.Domains;
using FunilariaDev.Interfaces;
using FunilariaDev.Repositories;
using FunilariaDev.ViewModel;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FunilariaDev.Utils;

namespace FunilariaDev.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private IUserRepository _userRepository { get; set; }

        public LoginController()
        {
            _userRepository = new UserRepository();
        }

        /// <summary>
        /// Validate a User according to email and password
        /// </summary>
        /// <param name="login"></param>
        /// <returns>A Token with User information or a NotFound(400) status code with a custom error message</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                //Verificação e autenticação dos dados
                bool passwordCrip;

                PasswordVerify pass = new PasswordVerify();

                var usuarioexiste = _userRepository.FindForEmail(login.Email);

                if(usuarioexiste == null)
                {
                    return BadRequest("O email não existe");
                }
                else
                {

                     passwordCrip = pass.ValidarSenha(login.Password, usuarioexiste.Password);
                }


                //Verificação e autenticação dos dados

                if (passwordCrip == true)
                {
                    User userLogin = _userRepository.Login(login.Email, usuarioexiste.Password);

                    var claims = new[]
              {
                    new Claim (JwtRegisteredClaimNames.Jti, userLogin.IdUser.ToString()),
                    new Claim (JwtRegisteredClaimNames.Email, userLogin.Email),
                    new Claim (ClaimTypes.Role, userLogin.TypeUser.ToString()),
                    new Claim("role", userLogin.TypeUser.ToString()),
                    new Claim("Name", userLogin.Name),
                    new Claim("phone", userLogin.Phone.ToString())
                };

                    // Define a chave de acesso do Token
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("funilariaDev-chave-acesso"));

                    // Header -> Define as credenciais do Token
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Define a composição do Token
                    var token = new JwtSecurityToken(
                        issuer: "FunilariaDev",
                        audience: "FunilariaDev",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(40),
                        signingCredentials: creds
                    );

                    // Retorna um status code Ok(200) com o token criado
                    return Ok(new
                    {
                        // Gera o token com base nas informações definidas anteriormente e retorna junto com o status code
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }


                return BadRequest("Dados incorretos");
              

            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest(400)
                return BadRequest(erro);
            }
        }  
    }
}
