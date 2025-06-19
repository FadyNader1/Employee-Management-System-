using Company.BLL.Interfaces;
using Company.DAL.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Repositories
{
    public  class EmailServic : IEmailServic
    {
        private readonly EmailSetting conf;
        public EmailServic(IOptions<EmailSetting> option)
        {
            conf = option.Value;
        }
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var client = new SmtpClient(conf.SmtpHost)
            {
                Port = conf.SmtpPort,
                Credentials = new NetworkCredential(conf.SenderEmail, conf.SenderPassword),
                EnableSsl=true
            };
            var sendmessage = new MailMessage()
            {
                From = new MailAddress(conf.SenderEmail),
                Subject = subject,
                Body = body
            };
            sendmessage.To.Add(to);
            await client.SendMailAsync(sendmessage);
        }
    }
}
