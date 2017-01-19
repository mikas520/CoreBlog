using CoreBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Respository.Respository
{
    public class ArticleRespository
    {
        public void InsertArticle(Article obj)
        {
            var type = obj.GetType();
            MongoDBConnection.GetDatabase().GetCollection<Article>(obj.GetType().Name).InsertOne(obj);
        }
    }
}
