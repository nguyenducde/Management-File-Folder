using managementFile.DAO.Users;
using managementFile.DTO;

namespace managementFile.BLL.Users
{
    public class UserService : IUserService
    {
        private readonly IUserDAO _userDAO;

        public UserService(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            return await _userDAO.GetUsers();
        }
        public UserDTO GetUserById(UserDTO request)
        {
            return _userDAO.GetUserById(request);
        }
        public bool Insert(UserDTO request)
        {
            return _userDAO.Insert(request);
        }

        public async Task<bool> Update(UserDTO request)
        {
            return await _userDAO.Update(request);
        }

        public async Task<bool> Delete(UserDTO request)
        {
            return await _userDAO.Delete(request);
        }

        public async Task<UserDTO> Login(UserDTO request)
        {
            return await _userDAO.Login(request);
        }
    }
}
