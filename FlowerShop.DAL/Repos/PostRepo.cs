using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.DAL.Entities;

namespace FlowerShop.DAL.Repos
{
    public class PostRepo
    {
        private static ExContext _context;
        public PostRepo()
        {
            _context = new ExContext();
        }
        public List<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }
        public Post? GetPostById(int id)
        {
            return _context.Posts.FirstOrDefault(x => x.Id == id);
        }
        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
        public bool UpdatePost(Post post)
        {
            bool result = false;
            Post? postExisted = _context.Posts.FirstOrDefault(p => p.Id == post.Id);
            if (postExisted != null)
            {
                postExisted.Name = post.Name;
                postExisted.Address = post.Address;
                postExisted.Description = post.Description;
                postExisted.Thumbnail = post.Thumbnail;
                postExisted.Price = post.Price;
                postExisted.StartDate = post.StartDate;
                postExisted.EndDate = post.EndDate;
                _context.SaveChanges(true);
                result = true;
            }
            return result;
        }
        public bool DeletePost(int id)
        {
            bool result = false;
            Post? postExisted = GetPostById(id);
            if (postExisted != null)
            {
                _context.Remove(postExisted);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
