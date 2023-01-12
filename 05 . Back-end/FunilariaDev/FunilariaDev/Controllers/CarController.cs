using FunilariaDev.Domains;
using FunilariaDev.Interfaces;
using FunilariaDev.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunilariaDev.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private ICarRepository _carRepository { get; set; }

        public CarController()
        {
            _carRepository = new CarRepository();
        }

        /// <summary>
        /// Method responsible for listing all vehicles registered in the system. Only the administrator has access to this data.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_carRepository.ListAll());
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Method responsible for registering users' cars in the database. Only the customer has access to this method.
        /// </summary>
        /// <param name="newCar"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Car newCar)
        {
            try
            {
                _carRepository.registerCar(newCar);

                return StatusCode(200);


            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Method responsible for updating customer vehicle information. Only the customer has access to this method.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="carUpdated"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Car carUpdated)
        {
            try
            {
                _carRepository.Update(Id, carUpdated);

                return StatusCode(201);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Method responsible for delete cars informed by the id that the customer or administrator selects
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _carRepository.Delete(Id);

                return StatusCode(202);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Method responsible for listing cars of the user logged into the system
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("mycar/{idUser}")]
        public IActionResult GetMyCar(int idUser)
        {
            try
            {
              var listCars =  _carRepository.ListWithId(idUser);



                return Ok(listCars);
            }catch(Exception er)
            {
                return BadRequest(er);
            }
        }
    }
}
