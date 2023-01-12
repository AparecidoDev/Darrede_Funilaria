using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using FunilariaDev.Domains;
using FunilariaDev.Interfaces;
using FunilariaDev.Repositories;
using FunilariaDev.ViewModel;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;
using FunilariaDev.Utils;
using Microsoft.AspNetCore.Http;


namespace FunilariaDev.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyzeController : ControllerBase
    {
        private IUserRepository _userRepository { get; set; }
        private IPlateAnalysisRepository _plateRepository { get; set; }

        public AnalyzeController()
        {
            _userRepository = new UserRepository();
            _plateRepository = new PlateAnalysisRepository();
        }

        /// <summary>
        /// Method responsible for analyzing the image that the user registered in the system, thus returning the plate value
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet, DisableRequestSizeLimit]
        public IActionResult AnalyzeImage()
        {
            try
            {
                int idUser = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _plateRepository.Analyze(idUser);


                var image = _plateRepository;

                

                return Ok(
                    image.DeleteImage(idUser)
                    );

            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        
    }
}