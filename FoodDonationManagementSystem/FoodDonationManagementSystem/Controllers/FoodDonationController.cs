using FoodDonationManagementSystem.Core.Interface;
using FoodDonationManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationManagementSystem.Controllers
{
    [ApiController]
    public class FoodDonationController : Controller
    {
        private readonly IFoodDonation ifood;
        public FoodDonationController(IFoodDonation ifood)
        {
            this.ifood = ifood;
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = ifood.Get();
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] FoodDonationModel foodDonationModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = ifood.Post(foodDonationModel);
                    Ok("Inserted");
                    return StatusCode(200, result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
