using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Commands;

namespace TaskManagement.Common.Validators
{
    public class MessageValidator : ICommandHandler
    {
        public void Handle()
        {
            throw new NotImplementedException();
        }

        public class Message
        {
            public string Content { get; set; }
            public string Content_AZ { get; set; }
            public string Content_EN { get; set; }
            public string Content_RU { get; set; }

            public string GetMessageContent(string lang)
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

                if (string.IsNullOrEmpty(content))
                {
                    content = Content;
                }

                return content;
            }

            public bool Validate()
            {
                // Validate that all the required fields for each language are filled
                return !string.IsNullOrEmpty(Content_AZ) && !string.IsNullOrEmpty(Content_EN) &&
                    !string.IsNullOrEmpty(Content_RU);
            }
        }

    }
}
