using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Model.Query
{
    public abstract class BaseQuery
    {
        /// <summary>
        /// 排序字段
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// 排序顺序
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// 是否计算总数
        /// </summary>
        public bool Count { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int Size { get; set; }
        
        /// <summary>
        /// 页码
        /// </summary>
        public int PageNum { get; set; }

        /// <summary>
        /// 获取排序查询Json
        /// </summary>
        /// <returns></returns>
        public virtual string GetSortJson()
        {
            return "{'CreateOn':-1}";
        }

        /// <summary>
        /// 获取查询条件Json
        /// </summary>
        /// <returns></returns>
        public abstract string GetQueryJson();
    }
}
