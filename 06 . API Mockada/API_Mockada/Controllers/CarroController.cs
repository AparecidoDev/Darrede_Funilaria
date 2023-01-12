using API_Mockada.Interfaces;
using API_Mockada.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Mockada.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private ICarroRepository _carroRepository { get; set; }

        public CarroController()
        {
            _carroRepository = new CarroRepository();
        }

        /// <summary>
        /// This Method is responsible for Listing the cars based on the Plate parameter
        /// </summary>
        /// <param name="plate"></param>
        /// <returns></returns>
        ///

        [HttpGet("/v1/consulta/{plate}")]
        public IActionResult GetCarsWithPlate(string plate)
        {
            try
            {
                var carsPlate = _carroRepository.ListByPlate(plate);

                return Ok(carsPlate);
            }catch(Exception er)
            {
                return BadRequest(er);
            }
        }
    }
}
