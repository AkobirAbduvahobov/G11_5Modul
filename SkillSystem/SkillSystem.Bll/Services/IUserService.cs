using SkillSystem.Bll.Dtos.UserDto;

namespace SkillSystem.Bll.Services;

public interface IUserService
{
    Task<long> PostAsync(UserCreateDto userCreateDto);
    Task<ICollection<UserGetDto>> GetAllUsersAsync();
    Task DeleteAsync(long userId);
    Task UpdateRoleAsync(long userId, UserRoleDto userRoleDto);
}