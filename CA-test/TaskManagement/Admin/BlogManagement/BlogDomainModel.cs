using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManagement.Common.Commands;

namespace TaskManagement.Admin.BlogManagement
{
    public class BlogDomainModel : ICommandHandler
    {

        public void Handle()
        {
            throw new NotImplementedException();
        }

        public class Blog
        {
            public string Title_AZ { get; set; }
            public string Title_EN { get; set; }
            public string Title_RU { get; set; }
            public string Content_AZ { get; set; }
            public string Content_EN { get; set; }
            public string Content_RU { get; set; }

            public string GetTitle(string lang)
            {
                string title = "";

                switch (lang)
                {
                    case "az":
                        title = Title_AZ;
                        break;
                    case "en":
                        title = Title_EN;
                        break;
                    case "ru":
                        title = Title_RU;
                        break;
                }

                return title;
            }

            public string GetContent(string lang)
            {
                string content = "";

                switch (lang)
                {
                    case "az":
                        content = Content_AZ;
                        break;
                    case "en":
                        content = Content_EN;
                        break;
                    case "ru":
                        content = Content_RU;
                        break;
                }

                return content;
            }

            public bool Validate()
            {
                // Validate that all the required fields for each language are filled
                return !string.IsNullOrEmpty(Title_AZ) && !string.IsNullOrEmpty(Title_EN) &&
                    !string.IsNullOrEmpty(Title_RU) && !string.IsNullOrEmpty(Content_AZ) &&
                    !string.IsNullOrEmpty(Content_EN) && !string.IsNullOrEmpty(Content_RU);
            }
        }



        //public class Blog
        //{
        //    public string Title { get; set; }
        //    public string Content { get; set; }

        //    public string LocalizedTitle(string language)
        //    {
        //        var rm = new ResourceManager(typeof(BlogTitle));
        //        var localizedTitle = rm.GetString("Title_" + language.ToUpper());
        //        return localizedTitle;
        //    }

        //    public string LocalizedContent(string language)
        //    {
        //        var rm = new ResourceManager(typeof(BlogContent));
        //        var localizedContent = rm.GetString("Content_" + language.ToUpper());
        //        return localizedContent;
        //    }
        //}

        //public class BlogTitle
        //{
        //    public static string Title_AZ { get { return "AZ Title"; } }
        //    public static string Title_EN { get { return "EN Title"; } }
        //    public static string Title_RU { get { return "RU Title"; } }
        //}

        //public class BlogContent
        //{
        //    public static string Content_AZ { get { return "AZ Content"; } }
        //    public static string Content_EN { get { return "EN Content"; } }
        //    public static string Content_RU { get { return "RU Content"; } }
        //}

    }
}
