using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.DAL.Repos
{
    public class PostRepo
    {
        private EventflowerexchangeContext? _context;
        public List<Post> GetAllPosts()
        {
            _context = new();
            _context = new EventflowerexchangeContext();
            return _context.Posts.Include("Category").ToList();
        }
        public Post? GetPostById(int id)
        {
            _context = new();
            return _context.Posts.FirstOrDefault(x => x.Id == id);
        }
        public void CreatePost(Post post)
        {
            _context = new();
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
        public bool UpdatePost(Post post)
        {
            _context = new();
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
        public void DeletePost(Post post)
        {
            _context = new EventflowerexchangeContext();
            _context.Remove(post);
            _context.SaveChanges();

        }
    }
}
