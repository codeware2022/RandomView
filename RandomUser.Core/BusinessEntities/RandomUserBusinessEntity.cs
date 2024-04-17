using Newtonsoft.Json;
using RandomUser.Data.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RandomUser.Core.BusinessEntities
{
    public interface IRandomUserBusinessEntity
    {
         Task<RandomUserDataDto> GetRandomUserDataAsync();
    }
    public class RandomUserBusinessEntity : IRandomUserBusinessEntity
    {
        private readonly IUserDataService _userDataService;

        public RandomUserBusinessEntity(IUserDataService UserDataService)
        {
            _userDataService = UserDataService;
        }

        public async Task <RandomUserDataDto> GetRandomUserDataAsync()
        {
            try
            {
                var Result = await _userDataService.GetRandomUserDataAsync();
                //Convert to DeserializeObject
                var randomUserDataDto = JsonConvert.DeserializeObject<RandomUserDataDto>(Result);

                return randomUserDataDto;
            }
            catch (Exception ex)
            {

                throw;
            }
         
        }
    }
}
