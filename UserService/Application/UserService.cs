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
        public async Task<List<EntityUsers>> GetUsersListAsync()
        {
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
