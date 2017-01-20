using CoreBlog.Business.IClient;
using CoreBlog.Model;
using CoreBlog.Respository.IRespository;
using CoreBlog.Respository.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Business.Client
{
    public class ArticleClient: IArticleClient
    {
        private IArticleRespository GetRespository()
        {
            return ArticleRespository.GetInstance();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        public void InsertArticle(Article obj)
        {
            if (obj == null)
                return;
            GetRespository().InsertArticle(obj);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public long DeleteArticleByID(string id)
        {
           return GetRespository().DeleteArticleByID(id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="obj"></param>
        public long UpdateArticle(Article obj)
        {
            return GetRespository().UpdateArticle(obj);
        }

        /// <summary>
        /// 使用ID查询
        /// </summary>
        public Article FindArticleByID(string id)
        {
            return GetRespository().FindArticleByID(id);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        public KeyValuePair<long, IList<Article>> FindArticleByPage(int size, int page)
        {
            return GetRespository().FindArticleByPage(size,page);
        }
    }
}
