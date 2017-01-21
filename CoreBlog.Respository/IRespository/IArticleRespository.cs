using CoreBlog.Model;
using CoreBlog.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Respository.IRespository
{
    public interface IArticleRespository
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
        long DeleteArticleByID(long id);
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="obj"></param>
        long UpdateArticle(Article obj);
        
        /// <summary>
        /// 使用ID查询
        /// </summary>
        Article FindArticleByID(long id);
        
        /// <summary>
        /// 分页查询
        /// </summary>
        KeyValuePair<long, IList<Article>> FindArticleByPage(BaseQuery query);
    }

}
