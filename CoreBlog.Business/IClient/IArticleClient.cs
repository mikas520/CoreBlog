using CoreBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Business.IClient
{
    public interface IArticleClient
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        void InsertArticle(Article obj);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        long DeleteArticleByID(string id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="obj"></param>
        long UpdateArticle(Article obj);

        /// <summary>
        /// 使用ID查询
        /// </summary>
        Article FindArticleByID(string id);

        /// <summary>
        /// 分页查询
        /// </summary>
        KeyValuePair<long, IList<Article>> FindArticleByPage(int size, int page);
    }
}
