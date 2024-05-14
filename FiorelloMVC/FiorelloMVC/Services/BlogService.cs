using FiorelloMVC.Data;
using FiorelloMVC.Models;
using FiorelloMVC.Services.Interfaces;
using FiorelloMVC.ViewModels.Blog;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FiorelloMVC.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDBContext _context;
        public BlogService(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BlogVM>> GetAllAsync()
        {
            IEnumerable<Blog> blogs = await _context.Blogs.ToListAsync();
            //List<BlogVM> datas = new();
            //foreach (var blog in blogs)
            //{
            //    datas.Add(new BlogVM { Title = blog.Title });   
            //}
            
            var datas = blogs.Select(m => new BlogVM { Title = m.Title, Description = m.Description, Image = m.Image, CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy") });
            return datas;
        }
    }
}
