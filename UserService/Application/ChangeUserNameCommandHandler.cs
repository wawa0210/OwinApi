using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserService.Commands;

namespace UserService.Application
{
    public class ChangeUserNameCommandHandler : IRequestHandler<ChangeUserNameCommand, bool>
    {
        public async Task<bool> Handle(ChangeUserNameCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
