using System;
namespace TemplateMethod
{
    /// <summary>
    /// Abstract Class
    /// </summary>
    public abstract class MailParser
    {
        public abstract void AuthenticateToServer();

        public virtual void FindServer()
        {
            Console.WriteLine("Finding server...");
        }

        public string ParseHtmlMailBody(string id)
        {
            Console.WriteLine("Parsing...");
            return $"This is body with id: {id}";
        }

        public string ParseMailBody(string id)
        {
            Console.WriteLine("Parsing in template method...");
            FindServer();
            AuthenticateToServer();
            return ParseHtmlMailBody(id);
        }
    }

    /// <summary>
    /// Concrete Class 1
    /// </summary>
    public class GmailMailParser : MailParser
    {
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connected to Gmail.");
        }
    }

    /// <summary>
    /// Concrete Class 2
    /// </summary>
    public class OutlookMailParser : MailParser
    {
        public override void FindServer()
        {
            Console.WriteLine("Finding server with custom algorithm for Outlook...");
        }
        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connected to Outlook.");
        }
    }
}

