using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Runtime;
using TaskManagement.Common.Commands;

namespace TaskManagement.Client 
{
    public class ClientAddBlogComments : ICommandHandler
    {
        static Dictionary<string, Blog> blogs = new Dictionary<string, Blog>();
        static void Main(string[] args)
        {
            // burada login və register funksiyaları əlavə olunaraq

            // show-blogs-with-comments funksiyası olur
            Console.WriteLine("Blogs with comments:\n");
            foreach (Blog blog in blogs.Values)
            {
                Console.WriteLine(blog.GetBlogInfo());
                Console.WriteLine(blog.GetComments());
            }

            // add-blog funksiyası
            AddBlog();

            // add-comment funksiyası
            AddComment();
        }

        static void AddBlog()
        {
            Console.WriteLine("\nAdding a new blog:");

            // unique blog code yaradılır
            Random rnd = new Random();
            string blogCode = "BL" + rnd.Next(10000, 99999).ToString();

            Console.Write("Enter blog title: ");
            string title = Console.ReadLine();
            Console.Write("Enter blog content: ");
            string content = Console.ReadLine();
            Blog newBlog = new Blog(title, content, blogCode);
            blogs.Add(blogCode, newBlog);

            Console.WriteLine($"New blog with code {blogCode} has been added.");
        }

        static void AddComment()
        {
            Console.WriteLine("\nAdding a new comment:");

            Console.Write("Enter blog code: ");
            string blogCode = Console.ReadLine();

            // blog kodu tapılır və yoxlanır
            if (!blogs.ContainsKey(blogCode))
            {
                Console.WriteLine($"Blog with code {blogCode} does not exist.");
                return;
            }

            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter comment content: ");
            string content = Console.ReadLine();
            Comment newComment = new Comment(firstName, lastName, content);
            blogs[blogCode].AddComment(newComment);

            Console.WriteLine($"Comment has been successfully added to blog with code {blogCode}.");
            Console.WriteLine($"Blog owner has been notified.");
            Console.WriteLine($"{blogCode} kodlu blogunuza {firstName} {lastName} tərəfindən comment əlavə olundu.");
        }

        public void Handle()
        {
            throw new NotImplementedException();
        }
    }

    class Blog
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Code { get; set; }
        private List<Comment> comments = new List<Comment>();

        public Blog(string title, string content, string code, Database.Models.User currentUser, Contants.BlogStatus created)
        {
            Title = title;
            Content = content;
            Code = code;
        }

        public string GetBlogInfo()
        {
            return $"[{DateTime.Today.ToString("dd.MM.yyyy")}] [{Code}] {nameof()}\n=== {Title} ===\n{Content}\n";
        }

        private object nameof()
        {
            throw new NotImplementedException();
        }

        public string GetComments()
        {
            if (comments.Count == 0)
            {
                return "No comments.\n";
            }
            else
            {
                string result = "Comments:\n";
                for (int i = 0; i < comments.Count; i++)
                {
                    result += $"{i + 1}. {comments[i].GetCommentInfo()}\n";
                }
                return result;
            }
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
            // burada blog sahibinə mesaj gönd
        }
    }
}
