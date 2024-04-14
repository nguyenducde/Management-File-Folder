using managementFile.DAO.Database.MongoDBs;
using managementFile.DTO;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace managementFile.DAO.Users
{
    public class UserDAO : IUserDAO
    {
        private readonly IMongoDBDatabase _mongoDatabase;
        private readonly IMongoCollection<UserDTO> _collection;

        public UserDAO(IMongoDBDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;

            var database = _mongoDatabase.ConnectMongoDb();
            _collection = database.GetCollection<UserDTO>("Users");
           
        }

        public async Task<bool> Delete(UserDTO request)
        {
            var filter = Builders<UserDTO>.Filter.Eq(u => u.Id, request.Id);
            var result = await _collection.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public UserDTO GetUserById(UserDTO request)
        {

            Expression<Func<UserDTO, bool>> filter = u => u.Id == request.Id;
            return _collection.Find(filter).FirstOrDefault();

        }

        public async Task<UserDTO?> Login(UserDTO request)
        {
            var filter = Builders<UserDTO>.Filter.Eq(u => u.Email, request.Email);
            var user = await _collection.Find(filter).FirstOrDefaultAsync();

            if (user != null && BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return user;
            }

            return null; // Không tìm thấy người dùng hoặc mật khẩu không khớp
        }

     

        public async Task<List<UserDTO>> GetUsers()
        {
            var users = await _collection.Find(_ => true).ToListAsync();
            return users;
            
        }

        public bool Insert(UserDTO request)
        {

            try {
                var user = new UserDTO()
                {
                    Name = request.Name,
                    Address = request.Address,
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password) 
                };

                _collection.InsertOne(user);

                return true;
            } catch(Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
           
     
        }

        public async Task<bool> Update(UserDTO request)
        {
            var filter = Builders<UserDTO>.Filter.Eq(u => u.Id, request.Id);
            var update = Builders<UserDTO>.Update
                .Set(u => u.Name, request.Name)
                .Set(u => u.Password, BCrypt.Net.BCrypt.HashPassword(request.Password))
                .Set(u => u.Address, request.Address)
                ;
            var result = await _collection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }
    }
}
