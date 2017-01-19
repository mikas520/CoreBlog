using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDB.Driver;

namespace CoreBlog.Respository
{
    public class MongoDBConnection
    { 
        public static readonly string configconnectionString = "";
        public static readonly string configDBName = "";

        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <returns></returns>
        public static IMongoDatabase GetDatabase()
        {
           return GetDatabase(configconnectionString,configDBName);
        }

        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <returns></returns>
        public static IMongoDatabase GetDatabase(string connectionString,string dbName)
        {
            var client = new MongoClient(connectionString);
            if (client == null)
                return null;
            return client.GetDatabase(dbName);
        }
    }
}
