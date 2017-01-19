using CoreBlog.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreBlog.Respository
{
    internal class MongoDBHelper
    {
        #region 查找
        public IFindFluent<T, T> Find<T>( Expression<Func<T, bool>> expression = null, FindOptions options = null)
        {
            return GetCollection<T>().Find(expression, options);
        }
        public IFindFluent<T,T> Find<T>(string name, Expression<Func<T, bool>> expression=null, FindOptions options = null)
        {
           return GetCollection<T>(name).Find(expression, options);
        }
        public KeyValuePair<long, IList<T>> FindByPage<T>(string name, Expression<Func<T, bool>> expression = null, FindOptions options = null,bool count=true,int size=1,int page=20)
        {
            var list = Find<T>(name, expression,options);
            long num = 0;
            if (count)
            {
                num = list.Count();
            }
            return new KeyValuePair<long, IList<T>>(num,list.Skip(size*page).Limit(page).ToList());
        }

        #endregion

        #region 增加
        public void InsertOne<T>(T t)
        {
            GetCollection<T>().InsertOne(t);
        }
        public void InsertOne<T>(T t,string name)
        {
            GetCollection<T>(name).InsertOne(t);
        }
        public void InsertOneAsync<T>(T t)
        {
            GetCollection<T>().InsertOneAsync(t);
        }
        public void InsertOneAsync<T>(T t,string name)
        {
            GetCollection<T>(name).InsertOneAsync(t);
        }
        public void InsertMany<T>(IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            GetCollection<T>().InsertMany(documents, options, cancellationToken);
        }

        public void InsertMany<T>(string name, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            GetCollection<T>(name).InsertMany(documents, options, cancellationToken);
        }

        public void InsertManyAsync<T>(IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            GetCollection<T>().InsertManyAsync(documents, options, cancellationToken);
        }
        public void InsertManyAsync<T>(string name, IEnumerable<T> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            GetCollection<T>(name).InsertManyAsync(documents, options, cancellationToken);
        }
        #endregion

        #region 修改
        public UpdateResult UpdateOne<T>(T t) where T : MongoObject
        {
            var filter = Builders<T>.Filter.Eq("_id", t._id);
            var update = t.ToBsonDocument();
            return GetCollection<T>().UpdateOne(filter, update);
        }

        public UpdateResult UpdateOne<T>(string name, FilterDefinition<T> filter, UpdateDefinition<T> update, UpdateOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
           return GetCollection<T>(name).UpdateOne(filter, update,options, cancellationToken);
        }
        #endregion

        #region 删除

        public DeleteResult DeleteOne<T>(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return GetCollection<T>().DeleteOne(filter);
        }

        public DeleteResult DeleteOne<T>(string name,string id)
        {
            var filter = Builders<T>.Filter.Eq("_id",id);
            return GetCollection<T>(name).DeleteOne(filter);
        }
        #endregion

        #region 获取集合
        public IMongoCollection<T> GetCollection<T>()
        {
           return GetCollection<T>(typeof(T).GetType().Name); 
        }
      
        public IMongoCollection<T> GetCollection<T>(string name)
        {
           return MongoDBConnection.GetDatabase().GetCollection<T>(name);
        }
        #endregion
    }
}
