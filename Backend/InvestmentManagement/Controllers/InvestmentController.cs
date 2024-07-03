using InvestmentManagement.BusinessLayer.Interfaces;
using InvestmentManagement.BusinessLayer.ViewModels;
using InvestmentManagement.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentManagement.Controllers
{
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;
        
        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        [HttpPost]
        [Route("create-investment")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateInvestment([FromBody] Investment model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Response { Status = "Error", Message = "Invalid data!" });

           // var investmentExists = await _investmentService.GetInvestmentById(model.InvestmentId);
            //if (investmentExists != null)
               // return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Investment already exists!" });

            var result = await _investmentService.CreateInvestment(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Investment creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Investment created successfully!" });
        }

        [HttpPut]
        [Route("update-investment")]
        public async Task<IActionResult> UpdateInvestment([FromBody] InvestmentViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Response { Status = "Error", Message = "Invalid data!" });

            var investment = await _investmentService.GetInvestmentById(model.InvestmentId);
            if (investment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = $"Investment with Id = {model.InvestmentId} cannot be found" });
            }

            var result = await _investmentService.UpdateInvestment(model);
            return Ok(new Response { Status = "Success", Message = "Investment updated successfully!" });
        }

        [HttpDelete]
        [Route("delete-investment")]
        public async Task<IActionResult> DeleteInvestment(long id)
        {
            var investment = await _investmentService.GetInvestmentById(id);
            if (investment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = $"Investment with Id = {id} cannot be found" });
            }

            var result = await _investmentService.DeleteInvestmentById(id);
            return Ok(new Response { Status = "Success", Message = "Investment deleted successfully!" });
        }

        [HttpGet]
        [Route("get-investment-by-id")]
        public async Task<IActionResult> GetInvestmentById(long id)
        {
            var investment = await _investmentService.GetInvestmentById(id);
            if (investment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = $"Investment with Id = {id} cannot be found" });
            }

            return Ok(investment);
        }

        [HttpGet]
        [Route("get-all-investments")]
        public async Task<IEnumerable<Investment>> GetAllInvestments()
        {
            return _investmentService.GetAllInvestments();
        }
    }
}
