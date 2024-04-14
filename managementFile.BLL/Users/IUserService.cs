using managementFile.DTO;

namespace managementFile.BLL.Users
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsers();
        UserDTO GetUserById(UserDTO request);
        bool Insert(UserDTO request);
        Task<bool> Update(UserDTO request);
        Task<bool> Delete(UserDTO request);
        Task<UserDTO> Login(UserDTO request);
    }
}
