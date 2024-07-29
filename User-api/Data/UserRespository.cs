using Microsoft.EntityFrameworkCore;

namespace User_api.Data
{
    public class UserRespository
    {
        private readonly AppDBContext _appDBContext;
        public UserRespository(AppDBContext appDbContext) {
            _appDBContext = appDbContext;

        }
        public async Task AddUser(User user)
        {
            await _appDBContext.Set<User>().AddAsync(user);
            await _appDBContext.SaveChangesAsync();
        }
        public async Task<List<User>> GetUserList()
        {
            return await _appDBContext.Users.ToListAsync();

        }

        public async Task<User> UserByUser_nam(string user_name)
        {
            return await _appDBContext.Users.FirstOrDefaultAsync(u => u.user_name ==    user_name);
        }
        public async Task UpdateUser(string user_name, User model)
        {
            var user_ = await _appDBContext.Users.FirstOrDefaultAsync(u => u.user_name == user_name);
            if (user_ == null)
            {
                throw new Exception("User not Found");
            }
            user_.user_name = model.user_name;
            user_.first_name = model.first_name;
            user_.last_name= model.last_name;
            user_.user_status = model.user_status;
            user_.department= model.department;
            await _appDBContext.SaveChangesAsync();
        }
        public async Task DeleteUser (string user_name)
        {
            var user__ = await _appDBContext.Users.FirstOrDefaultAsync(u => u.user_name == user_name);
            if (user__ == null)
            {
                throw new Exception("User not Found");
            }
            _appDBContext.Users.Remove(user__);
            await _appDBContext.SaveChangesAsync();
        }
    }
}
