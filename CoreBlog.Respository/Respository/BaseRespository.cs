using CoreBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Respository.Respository
{
    public class BaseRespository
    {
        public BaseRespository()
        {
            MongoDBHelper.SetConllectionName<Article>("TArticle");
        }
    }
}
