using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Respository
{
    internal class MongoDBConnection
    {
        private static readonly string configconnectionString = "mongodb://127.0.0.1:27017";
        private static readonly string configDBName = "CoreBlog";

        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <returns></returns>
        public static IMongoDatabase GetDatabase()
        {
            return GetDatabase(configconnectionString, configDBName);
        }

        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <returns></returns>
        public static IMongoDatabase GetDatabase(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            if (client == null)
                return null;
            return client.GetDatabase(dbName);
        }
    }

}
