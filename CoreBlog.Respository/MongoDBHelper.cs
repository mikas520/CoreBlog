using CoreBlog.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CoreBlog.Respository
{
    internal class MongoDBHelper
    {
        #region 查找
        public static T FindByID<T>(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return GetCollection<T>().Find(filter).FirstOrDefault();
        }

        public static IFindFluent<T, T> Find<T>(Expression<Func<T, bool>> expression = null, FindOptions options = null)
        {
            return GetCollection<T>().Find(expression, options);
        }
       
        public static KeyValuePair<long, IList<T>> FindByPage<T>(Expression<Func<T, bool>> expression = null, FindOptions options = null, bool count = true, int size = 1, int page = 20)
        {
            var list = Find<T>(expression, options);
            long num = 0;
            if (count)
            {
                num = list.Count();
            }
            return new KeyValuePair<long, IList<T>>(num, list.Skip(size * page).Limit(page).ToList());
        }

        #endregion

        #region 增加
        public static void InsertOne<T>(T t)
        {
            GetCollection<T>().InsertOne(t);
        }
      
        public static void InsertOneAsync<T>(T t)
        {
            GetCollection<T>().InsertOneAsync(t);
        }
      
        public static void InsertMany<T>(IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            GetCollection<T>().InsertMany(documents, options, cancellationToken);
        }

        public static void InsertManyAsync<T>(IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            GetCollection<T>().InsertManyAsync(documents, options, cancellationToken);
        }
       
        #endregion

        #region 修改
        public static UpdateResult UpdateOne<T>(T t) where T : BaseModel
        {
            var filter = Builders<T>.Filter.Eq("_id", t._id);
            var update = t.ToBsonDocument();
            return GetCollection<T>().UpdateOne(filter, update);
        }

        public static UpdateResult UpdateOne<T>(FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetCollection<T>().UpdateOne(filter, update, options, cancellationToken);
        }
        #endregion

        #region 删除

        public static DeleteResult DeleteOne<T>(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return GetCollection<T>().DeleteOne(filter);
        }

        public static DeleteResult DeleteOne<T>(T t)
        {
            return GetCollection<T>().DeleteOne(t.ToBsonDocument());
        }

        #endregion

        #region 获取集合
        public static IMongoCollection<T> GetCollection<T>()
        {
            var typeName = typeof(T).Name;
            if (_conllectionName.ContainsKey(typeName))
                return GetCollection<T>(_conllectionName[typeName]);
            else
                return GetCollection<T>(typeName);
        }

        public static IMongoCollection<T> GetCollection<T>(string name)
        {
            return MongoDBConnection.GetDatabase().GetCollection<T>(name);
        }
        #endregion


        #region 设置集合名称
        private static IDictionary<string, string> _conllectionName = new Dictionary<string, string>();
        public static void SetConllectionName<T>(string name)
        {
            var typeName = typeof(T).Name;
            if (!_conllectionName.ContainsKey(typeName))
            {
                _conllectionName.Add(typeName, name);
                return;
            }
            _conllectionName[typeName] = name;
        }
        #endregion

    }

}
