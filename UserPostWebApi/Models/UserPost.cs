using System.Collections.Generic;

namespace UserPostWebApi.Models
{
    public class UserPost
    {
        public User User { get; set; }
        public List<Post> Posts { get; set; }
        public int Count => Posts.Count;
    }
}
