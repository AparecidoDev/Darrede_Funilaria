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
    public class BrandController : ControllerBase
    {
        private IBrandRepository _brandRepository { get; set; }

        public BrandController()
        {
            _brandRepository = new BrandRepository();
        }

        /// <summary>
        /// This method is responsible for listing all brands registered in the system. Only the administrator has access to this data.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_brandRepository.ListAll());
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// This method is responsible for registering new brands
        /// </summary>
        /// <param name="newBrand"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost("create-brand")]
        public IActionResult Post( Brand newBrand)
        {
            try
            {
                _brandRepository.Register(newBrand);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// This method is responsible for updating the vehicle brands based on the ID that is informed and new parameters for a given brand. Only the administrator can change this information.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="brandUpdated"></param>
        [Authorize(Roles = "1")]
        [HttpPut("{Id}")]
        public IActionResult Update(int Id, Brand brandUpdated)
        {
            try
            {
                _brandRepository.Update(Id, brandUpdated);

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
        [Authorize(Roles = "1")]
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _brandRepository.Delete(Id);

                return StatusCode(202);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
