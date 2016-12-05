using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Utils.Services.Email
{
    public interface IEmailService
    {
        void Send(EmailParam param);
    }
}
