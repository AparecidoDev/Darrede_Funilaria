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
    public class ModelController : ControllerBase
    {
        private IModelRepository _modelRepository { get; set; }

        public ModelController()
        {
            _modelRepository = new ModelRepository();
        }

        /// <summary>
        /// This method is responsible for listing all models registered in the system. Only the administrator has access to this data.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                return Ok(_modelRepository.ListAll());

            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// This method is responsible for registering new models based on the brands previously registered by the administrator
        /// </summary>
        /// <param name="newModel"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost("create-model")]
        public IActionResult Post(Model newModel)
        {
            try
            {
                _modelRepository.Register(newModel);

                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// This method is responsible for updating the vehicle models based on the ID that is informed and new parameters for a given model. Only the administrator can change this information.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="modelUpdated"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, Model modelUpdated)
        {
            try
            {

                _modelRepository.Update(Id, modelUpdated);

                return StatusCode(201);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// This method is responsible for deleting a model by the ID informed by the administrator. Only the System Administrator has access.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{Id}")]

        public IActionResult Delete(int Id)

        {
            try
            {
                _modelRepository.Delete(Id);

                return StatusCode(202);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
