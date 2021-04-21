using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserPostWebApi.Models;
using UserPostWebApi.Services;

namespace UserPostWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPostController : ControllerBase
    {
        private readonly ILogger<UserPostController> _logger;
        private readonly IJsonPlaceholderService _jsonPlaceholderService;

        public UserPostController(ILogger<UserPostController> logger, IJsonPlaceholderService jsonPlaceholderService)
        {
            _logger = logger;
            _jsonPlaceholderService = jsonPlaceholderService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserPost>> Get()
        {
            var usersWithPosts = await _jsonPlaceholderService.GetUsersWithPosts();
            return usersWithPosts;
        }
    }
}
