using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace RandomUser.Data.DataService
{
    public interface IUserDataService
    {
        Task<string> GetRandomUserDataAsync();        

    }

    public class UserDataService : IUserDataService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public UserDataService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> GetRandomUserDataAsync()
        {
            try
            {
                //Get Data from Api
                var response = await _httpClient.GetAsync("https://randomuser.me/api");     
                response.EnsureSuccessStatusCode();
                // Throw if not a success status code
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching random user data: {ex.Message}");
                return null;
            }
        }

    }


}
