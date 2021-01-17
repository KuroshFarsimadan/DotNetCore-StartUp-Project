using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Services
{
    public interface IEmailService
    {
        void SendEmail(string to, string cc, string subject, string body);
    }
}
