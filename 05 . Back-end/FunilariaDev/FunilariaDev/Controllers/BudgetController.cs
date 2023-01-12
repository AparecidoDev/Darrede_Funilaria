using FunilariaDev.Domains;
using FunilariaDev.Interfaces;
using FunilariaDev.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace FunilariaDev.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private IBudgetRepository _budgetRepository { get; set; }
        private ICarRepository _carRepository { get; set; }

        public BudgetController()
        {
            _budgetRepository = new BudgetRepository();
            _carRepository = new CarRepository();
        }
        /// <summary>
        /// This method is responsible for listing all budgets registered in the system. Only the administrator has access to this data.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_budgetRepository.ListAll());

            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Method responsible for registering new budgets, having as a parameter a previously registered service, vehicle model and estimated value
        /// </summary>
        /// <param name="newBudget"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost("create-budget")]
        public IActionResult Post(Budget newBudget)
        {
            try
            {
                _budgetRepository.RegisterBudget(newBudget);

                return StatusCode(200);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Method responsible for updating registered budgets. Only the administrator has access to this method.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="budgetUpdated"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Budget budgetUpdated)
        {
            try
            {
                _budgetRepository.Update(Id, budgetUpdated);

                return StatusCode(201);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        
        }

        /// <summary>
        /// This method must delete a budget based on the id provided by the administrator
        /// </summary>
        [Authorize(Roles = "1")]
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _budgetRepository.Delete(Id);

                return StatusCode(202);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// In theory this method should return a budget based on the customer's car model, making a search in the database and returning the object with the value and the problem
        /// </summary>
        [Authorize]
        [HttpGet("mybudgets/{id}")]
        public IActionResult GetBudget(int id)
        {
            try
            {

                var budgetModel =_budgetRepository.RecomentedBudget(id);

                return Ok(budgetModel);

            }
            catch (Exception er)
            {
                return BadRequest(er);
            }

        }
    }
}
