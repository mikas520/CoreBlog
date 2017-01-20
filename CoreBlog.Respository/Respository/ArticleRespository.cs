﻿using CoreBlog.Model;
using CoreBlog.Respository.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Respository.Respository
{
  
    public sealed class ArticleRespository : BaseRespository, IArticleRespository
    {
        private static readonly ArticleRespository _respository = new ArticleRespository();

        public static ArticleRespository GetInstance()
        {
            return _respository;
        }
        public void InsertArticle(Article obj)
        {
            MongoDBHelper.InsertOne(obj);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="obj"></param>
        public long DeleteArticleByID(string id)
        {
           return MongoDBHelper.DeleteOne<Article>(id).DeletedCount;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="obj"></param>
        public long UpdateArticle(Article obj)
        {
           return MongoDBHelper.UpdateOne(obj).ModifiedCount;
        }

        /// <summary>
        /// 使用ID查询
        /// </summary>
        public Article FindArticleByID(string id)
        {
            return MongoDBHelper.FindByID<Article>(id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        public KeyValuePair<long,IList<Article>> FindArticleByPage(int size,int page)
        {
           return MongoDBHelper.FindByPage<Article>(size:size,page:page);
        }
    }

}
