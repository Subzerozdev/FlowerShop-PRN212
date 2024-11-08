using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.DAL.Entities;
using FlowerShop.DAL.Repos;

namespace FlowerShop.BLL
{
    public class PostService
    {
        private static PostRepo _repo = new();
        public void CreatePost(Post post)
        {
            _repo.CreatePost(post);
        }
        public List<Post> GetAllPosts()
        {
            return _repo.GetAllPosts();
        }
        public Post? GetPostById(int id)
        {
            return _repo.GetPostById(id);
        }
        public bool UpdatePost(Post post)
        {
            return _repo.UpdatePost(post);
        }
        public void DeletePost(Post post)
        {
            _repo.DeletePost(post);
        }
    }
}
