using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ERP.UtilityManagement.MailConfiguration
{
    public interface IMailer
    {
        Task SendEmailAsync(string SenderEmail, string SenderName, string email, string subject, string body);
    }
}
