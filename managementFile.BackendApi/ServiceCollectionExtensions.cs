using managementFile.BLL.Auths;
using managementFile.BLL.Users;
using managementFile.DAO.Database.MongoDBs;
using managementFile.DAO.Users;

namespace managementFile.BackendApi
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServicesDI(this IServiceCollection services)
        {
            /*============      Database       =============*/
            services.AddSingleton<IMongoDBDatabase, MongoDBDatabase>();

            /*============      Users       =============*/

            services.AddScoped<IUserDAO, UserDAO>();
            services.AddScoped<IUserService, UserService>();

            /*==========================================*/

            /*============      Auths       =============*/

            services.AddScoped<IAuthService, AuthService>();

            /*===========================================*/


        }
    }
}
