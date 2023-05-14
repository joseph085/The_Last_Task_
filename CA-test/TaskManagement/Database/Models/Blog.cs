using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Contants;
using TaskManagement.Database.Models.Common;

namespace TaskManagement.Database.Models
{
    public class Blog : BaseEntity<decimal>
    {
        private User currentUser;
        private BlogStatus created;

        public string Code { get; set; }
        public static int IdCounter { get; private set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public User Owner { get; set; }
        public DateTime PublishDate { get; set; }
        public BlogStatus Status { get; set; }
        public List<string> Comments { get; set; }

        public Blog(string code,string title, string content, User owner, DateTime PublishDate, BlogStatus status,List<string> Comments)
        {
            
            Id = ++IdCounter;
            Title = title;
            Content = content; 
            Owner = owner;
            DateTime dateTime = PublishDate;
            CreatedAt = DateTime.Now;
            List<string> CommentsList = Comments.ToList();
            Status = status;
        }

        public Blog(string? code, string? title, string? content, User currentUser, BlogStatus created)
        {
            Code = code;
            Title = title;
            Content = content;
            this.currentUser = currentUser;
            this.created = created;
        }

        public static implicit operator Blog(List<Blog> v)
        {
            throw new NotImplementedException();
        }
    }
}
