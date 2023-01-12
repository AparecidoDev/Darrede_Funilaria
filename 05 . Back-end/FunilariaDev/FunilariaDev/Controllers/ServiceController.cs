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
    public class ServiceController : ControllerBase
    {
        private IServiceRepository _serviceRepository { get; set; }

        public ServiceController()
        {
            _serviceRepository = new ServiceRepository();
        }



        /// <summary>
        /// This method is responsible for registering a service to be used as a parameter for the Pre-Budget. Only the Administrator has access to this method.
        /// </summary>
        /// <param name="newService"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost("create-service")]
        public IActionResult Post(Service newService)
        {
            try
            {
                _serviceRepository.Register(newService);

                return StatusCode(200);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// This method is responsible for updating a previously registered service and is identified by the ID and its new past data callable inputs. Only the Administrator can update.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="newService"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{Id}")]
        public IActionResult Update( int Id ,Service newService)
        {
            try
            {
                _serviceRepository.Update(Id, newService);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// This method is responsible for deleting a registered service that is identified through the ID that is informed. Only the Administrator has access to this method.
        /// </summary>
        /// <param name="newService"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{Id}")]
        public IActionResult Delete(Service newService)
        {
            try
            {
                _serviceRepository.Register(newService);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// This method is responsible for listing all services registered in the system. Only the administrator has access to this data.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            { 
                return Ok(_serviceRepository.ListAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
