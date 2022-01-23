using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration_Class_Library.Tendering.Models
{
    public class EmailMessage
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public EmailMessage(string to, string subject, string content)
        {
            To = to;
            Subject = subject;
            Content = content;
        }
    }
}
