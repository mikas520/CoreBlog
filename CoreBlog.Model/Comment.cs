using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Model
{
    public class Comment
    {
        /// <summary>
        /// 文章ID
        /// </summary>
        public string ArticleID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set;}

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateOn { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }
    }
}
