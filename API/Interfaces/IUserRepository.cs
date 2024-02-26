using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        // Update users - edit user info??
        void Update(AppUser user);
        // save all existing users asynchronously
        Task<bool> SaveAllAsync();
        // get users asynchronously
        Task<IEnumerable<AppUser>> GetUsersAsync();
        // get user by id asynchronously
        Task<AppUser> GetUserByIdAsync(int id);
        // 
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<IEnumerable<MemberDto>> GetMembersAsync();
        Task<MemberDto> GetMemberAsync(string username);
    }
}