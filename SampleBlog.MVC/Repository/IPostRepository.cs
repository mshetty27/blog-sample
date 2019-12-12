using SampleBlog.MVC.Models;
using System.Collections.Generic;
namespace  SampleBlog.MVC.Repository
{
    public interface IPostRepository
    {
        List<PostViewModel> GetPosts();
    }
}