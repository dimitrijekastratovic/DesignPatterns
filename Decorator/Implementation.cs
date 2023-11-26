using System;
namespace Decorator
{
	/// <summary>
	/// Component
	/// </summary>
	public interface IMailService
	{
		bool SendMail(string message);
	}

    /// <summary>
    /// Concrete Component
    /// </summary>
    public class CloudMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message: {message}, sent by {nameof(CloudMailService)}");
            return true;
        }
    }

    /// <summary>
    /// Concrete Component
    /// </summary>
    public class OnPremMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message: {message}, sent by {nameof(OnPremMailService)}");
            return true;
        }
    }

    /// <summary>
    /// Decorator
    /// </summary>
    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;

        public MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }

        public virtual bool SendMail(string message)
        {
            return _mailService.SendMail(message);
        }
    }

    /// <summary>
    /// Concrete Decorator
    /// </summary>
    public class StatisticsDecorator : MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService) : base(mailService)
        {
        }

        public override bool SendMail(string message)
        {
            Console.WriteLine($"Collecting statistics in {nameof(StatisticsDecorator)}");
            return base.SendMail(message);
        }
    }

    /// <summary>
    /// Concrete Decorator
    /// </summary>
    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        public List<string> SentMessages { get; private set; } = new List<string>();
        public MessageDatabaseDecorator(IMailService mailService) : base(mailService)
        {
        }

        public override bool SendMail(string message)
        {
            if(base.SendMail(message))
            {
                SentMessages.Add(message);
                return true;
            }

            return false;
        }
    }
}

