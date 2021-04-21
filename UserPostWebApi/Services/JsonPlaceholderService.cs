using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using UserPostWebApi.Models;

namespace UserPostWebApi.Services
{
    public interface IJsonPlaceholderService
    {
        Task<IEnumerable<UserPost>> GetUsersWithPosts();
    }

    public class JsonPlaceholderService : IJsonPlaceholderService
    {
        private readonly ILogger<JsonPlaceholderService> _logger;
        private readonly IConfiguration _configuration;

        public JsonPlaceholderService(ILogger<JsonPlaceholderService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserPost>> GetUsersWithPosts()
        {
            var userPosts = new List<UserPost>();
            try
            {
                using var client = new HttpClient();
                var userResp = await client.GetStringAsync($"{_configuration["UserPostApiBaseUrl"]}/users");
                var users = JsonSerializer.Deserialize<User[]>(userResp);

                if (users == null) return userPosts;

                foreach (var user in users.ToList())
                {
                    var postResp = await client.GetStringAsync($"{_configuration["UserPostApiBaseUrl"]}/posts?userId={user.Id}");
                    var posts = JsonSerializer.Deserialize<Post[]>(postResp);

                    userPosts.Add(new UserPost {User = user, Posts = (posts ?? Array.Empty<Post>()).ToList()});
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            
            return userPosts;
        }
    }
}
