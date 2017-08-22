using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discover_WebAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public string Title { get; set; }
         [Required]
        public string Body { get; set; }
        [EmailAddress]
         public string Email { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
    }

    public interface IPostRepository
    {
        IQueryable<Post> GetAll();
        IQueryable<Author> GetAllAuthor();

        Post Get(int id);
        Author GetAuhtor(int id);

        void Create(Post post);
        void Update(Post post);
        void Delete(int id);
        IQueryable<Post> Search(int year, int month, int day);
    }

    public class PostRepository : IPostRepository
    {
        public static List<Post> _posts = new List<Post>();
        public static List<Author> _authors = new List<Author>();

        public PostRepository()
        {
            if(_posts.Count==0)
            {
                _posts.Add(new Post { Id = 1, Date = new DateTime(2010, 04, 09), Title = "An introduction to the web api", Body = "..." });
                _posts.Add(new Post { Id = 2, Date = new DateTime(2010, 04, 11), Title = "REST is BEST", Body = "..." });
                _posts.Add(new Post { Id = 3, Date = new DateTime(2010, 11, 28), Title = "Build your web app", Body = "..." });
                _posts.Add(new Post { Id = 4, Date = new DateTime(2010, 11, 28), Title = "Check ODATA et authenticate", Body = "..." ,Email="fhcoulibaly@gs2e.ci"});
            }

            if (_authors.Count == 0)
            {
                _authors.Add(new Author { Id = 44, Name = "Tom", PhotoUrl = "/api/author/photos/tom.png" });
                _authors.Add(new Author { Id = 45, Name = "Jules", PhotoUrl = "/api/author/photos/jules.png" });
                _authors.Add(new Author { Id = 46, Name = "Dino", PhotoUrl = "/api/author/photos/dino.png" });
            }
        }

        public IQueryable<Post> GetAll()
        {
            return _posts.AsQueryable();//Convertit un IEnumerable à un IQueryable
        }

        public IQueryable<Author> GetAllAuthor()
        {
            return _authors.AsQueryable();//Convertit un IEnumerable à un IQueryable
        }

        public Post Get(int id)
        {
            Post _p = null; ;
            try
            {
                _p = _posts.Single(p => p.Id == id);
            }
            catch (InvalidOperationException ex)
            {
                //throw;
            }
            return _p;
        }

        public Author GetAuhtor(int id)
        {
            Author aut = null; ;
            try
            {
                aut = _authors.Single(p => p.Id == id);
            }
            catch (InvalidOperationException ex)
            {
                //throw;
            }
            return aut;
        }

        public void Create(Post post)
        {
            post.Id = _posts.Count() + 1;
            _posts.Add(post);
        }

        public void Update(Post post)
        {
            Post oldPost = _posts.Single(p => p.Id == post.Id);
            oldPost.Title = post.Title;
            oldPost.Date = post.Date;
            oldPost.Body = post.Body;
        }

        public void Delete(int id)
        {
            Post post = _posts.Single(p => p.Id == id);
            _posts.Remove(post);
        }

        public IQueryable<Post> Search(int year, int month, int day)
        {
            return _posts.Where(p => (p.Date.Year == year) && (month == 0 || p.Date.Month == month) && (day == 0 || p.Date.Day == day)).AsQueryable();
        }
    }
}
