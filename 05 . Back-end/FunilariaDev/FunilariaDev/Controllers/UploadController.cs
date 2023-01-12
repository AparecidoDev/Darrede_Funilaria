using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunilariaDev.Repositories;
using FunilariaDev.Interfaces;
using FunilariaDev.Domains;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace FunilariaDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {

        private IUserRepository _userRepository { get; set; }

        public UploadController()
        {
            _userRepository = new UserRepository();
        }

        [Authorize(Roles = "2")]
        [HttpPut("upload-image"), DisableRequestSizeLimit]
        public IActionResult PutImage()
        {
            try
            {

                //recuperar id do usuario logado a partir do token.
                int idUser = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                   var imagem = _userRepository.UpdateImage(idUser, Request.Form.Files[0]);

                    return Ok(imagem);

            
              
            }
            catch(Exception er)
            {
                return BadRequest(er.Message);
            }
        }
        

    }
}
