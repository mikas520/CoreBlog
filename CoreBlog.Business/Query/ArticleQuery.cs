using CoreBlog.Model.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Business.Query
{
    public class ArticleQuery : BaseQuery
    {
        public long ID { get; set; }
        public long UserID { get; set; }

        public string Title { get; set; }

        public DateTime? CreateOn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetQueryJson()
        {
            string json = "{";
            if (ID>0)
            {
                json += "_id:" + ID + ",";
            }
            if (!string.IsNullOrEmpty(Title))
            {
                json += "title:\""+Title+"\",";   
            }
            if (UserID>0)
            {
                json += "UserID:\"" + UserID + "\",";
            }
            if (CreateOn.HasValue)
            {
                json += "CreateOn:\"" + CreateOn + "\",";
            }

            json += "}";
            return json;            
        }

        /// <summary>
        /// db.user.find().sort({"name":-1,"age":1})
        /// </summary>
        /// <returns></returns>
        //public override string GetSortJson()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
