using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Entity;

namespace UserService.Application
{

    public interface IUserService
    {
        Task<List<EntityUsers>> GetUsersListAsync();
    }

    public class UserService : IUserService
    {
        private readonly ILoggerService LogerService;

        public UserService(ILoggerService _logerService)
        {
            LogerService = _logerService;
        }

        public async Task<List<EntityUsers>> GetUsersListAsync()
        {
            LogerService.WriteLog();

            var result = new List<EntityUsers>
            {
                new EntityUsers
                {
                    UserName = "wawa0210",
                    Gender = "M"
                }
            };
            return result;
        }
    }
}
