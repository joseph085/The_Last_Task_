using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Commands;
using TaskManagement.Database.Models;

namespace TaskManagement.Client.Commands
{
    public class ShowBlogswithComments : ICommandHandler
    {
        private static List<Blog> _blogs = new List<Blog>();

        public static void AddBlog()
        {

            Random rnd = new Random();
            int code = rnd.Next(10000, 99999);
            string blogCode = "BL" + code; 

            Console.WriteLine($"Your blog code is {blogCode}");
            Console.WriteLine("Please enter blog title:");
            string title = Console.ReadLine();
            Console.WriteLine("Please enter blog content:");
            string content = Console.ReadLine();


            //Blog newBlog = new Blog
            //{
            //    CreatedAt = DateTime.Now,
            //    Code = blogCode,
            //    Title = title,
            //    Content = content,
            //    PublishDate = DateTime.Now,
            //    Comments = new List<string>()
            //};
            
            //_blogs.Add(newBlog);

            Console.WriteLine($"Blog with code {blogCode} has been successfully added.");
        }

        public static void AddComment()
        {
            Console.WriteLine("Please enter blog code:");
            string blogCode = Console.ReadLine();

            Blog selectedBlog = _blogs.FirstOrDefault(b => b.Code == blogCode);

            if (selectedBlog == null)
            {
                Console.WriteLine("Invalid blog code, please try again.");
                return;
            }

            Console.WriteLine("Please enter your first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Please enter your comment:");
            string comment = Console.ReadLine();
            ShowBlogsWithComments();
            string newComment = $"[{DateTime.Now.ToString("dd.MM.yyyy")}] [{firstName} {lastName}] - {comment}";
            selectedBlog.Comments.Add(newComment);

            Console.WriteLine($"Comment has been successfully added to blog with code {blogCode}.");
            Console.WriteLine($"Blog with code {blogCode} has a new comment from {firstName} {lastName}.");
        }

        public static void ShowBlogsWithComments()
        {
            foreach (Blog blog in _blogs)
            { 
                Console.WriteLine($"[{blog.PublishDate.ToString("dd.MM.yyyy")}] [{blog.Code}] [{blog.Id} {blog}]");
                Console.WriteLine($"=== {blog.Title} ===");
                Console.WriteLine(blog.Content);
                Console.WriteLine();
                Console.WriteLine("Comments:");

                int rowNumber = 1;
                foreach (string comment in blog.Comments)
                {
                    Console.WriteLine($"{rowNumber}. {comment}");
                    rowNumber++;
                }

                Console.WriteLine();
            }
        }

        public void Handle()
        {
            throw new NotImplementedException();
        }
    }
}
