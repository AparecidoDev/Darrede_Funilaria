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
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository { get; set; }
        private IPlateAnalysisRepository _plateRepository { get; set; }

        public UserController()
        {
            _userRepository = new UserRepository();
            _plateRepository = new PlateAnalysisRepository();
        }

        /// <summary>
        /// This method is responsible for registering and processing user information and registering in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns>StatusCode 200</returns>
        [HttpPost("create-account"), DisableRequestSizeLimit]
        public IActionResult PostUser(User user)
        {
            try
            {

                _userRepository.Register(user);

                return StatusCode(200);

            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        ///  This method is responsible for listing all users registered in the system. (Only the administrator has access to this information such as: Name, Email and Phone)
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_userRepository.ListAll());

            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// This method is responsible for searching the user image by the ID of the user who is logged in.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpGet("getpath/{id}")]
        public IActionResult GetPath(int id)
        {
            try
            {
                _userRepository.FindImageWithId(id);

                return StatusCode(200);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// This method is responsible for searching the email of the user that was informed at login time.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("getemail/{id}")]
        public IActionResult GetEmail(string email)
        {
            try
            {
                _userRepository.FindForEmail(email);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// This method is responsible for looking up all the information for a particular user. Used to fetch logged user information.
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("account/{idUser}")]
        public IActionResult Account(int idUser)
        {
            try
            {
               var account = _userRepository.FindForId(idUser);

                return Ok(account);
            }catch(Exception er)
            {
                return BadRequest(er);
            }
        }

        /// <summary>
        /// To use the AI ​​method it is necessary to put the credentials in PowerShell or Cmd
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>


        [HttpGet("platePath/{IdUser}")]
        public IActionResult GetPlate(int idUser)
        {
            try
            {
                var response = _plateRepository.Analyze(idUser);

                return Ok(response);

            } catch (Exception er)
            {
                return BadRequest(er);
            }
        }


        /// <summary>
        /// This method is responsible for deleting a user by the ID that is informed by the Administrator or Customer
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("deleteuser/{Id}")]
        public IActionResult DeleteUser(int Id)
        {
            try
            {

                _userRepository.Delete(Id);

                return StatusCode(202);

            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// This method is responsible for updating a user through the ID and the new data that they want to be updated. Only a customer can change their information.
        /// </summary>
        /// <param name="userUpdated"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Update(User userUpdated, int Id)
        {
            try
            {
                _userRepository.Update(Id, userUpdated);

                return StatusCode(200);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("plate")]
        public IActionResult GetPlate()
        {
            try
            {
                int idUser = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

               var plate = _userRepository.FindForId(idUser);

                return Ok(plate.Plate);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
