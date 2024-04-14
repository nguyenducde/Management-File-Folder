using managementFile.DTO;

namespace managementFile.BLL.Auths
{
    public interface IAuthService
    {
        Task<string> Login(UserDTO request);
    }
}
