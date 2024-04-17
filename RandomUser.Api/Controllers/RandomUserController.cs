using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomUser.Core.BusinessEntities;
using RandomUser.Data.DataService;


namespace RandomUser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   
    public class RandomUserController : ControllerBase
    {        
        private readonly IRandomUserBusinessEntity _randomUserBusinessEntity;
       

        public RandomUserController(IRandomUserBusinessEntity RandomUserBusinessEntity)
        {            
            _randomUserBusinessEntity = RandomUserBusinessEntity;           
        }

        [HttpGet("GetRandomUser"), Authorize]
        public async Task<IActionResult> GetRandomUser()
        {
            var randomUserData = await _randomUserBusinessEntity.GetRandomUserDataAsync();
            if (randomUserData != null)
            {                
                return Ok(randomUserData);
            }
            else
            {
                return StatusCode(500, "Error fetching random user data");
            }
        }
 
    }
}
