using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementFile.DAO.Database.MongoDBs
{
    public interface IMongoDBDatabase
    {
        IMongoDatabase ConnectMongoDb();
    }
}
