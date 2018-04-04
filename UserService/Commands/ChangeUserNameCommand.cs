using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Commands
{
    public class ChangeUserNameCommand : IRequest<bool>
    {
        public long UserId { get; private set; }

        public string UserName { get; private set; }

        public ChangeUserNameCommand(long userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }
    }
}
