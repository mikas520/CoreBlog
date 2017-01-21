using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Model
{
    public class CollectionCurrentIdentity:BaseModel
    {
        /// <summary>
        /// 集合名称
        /// </summary>
        public string CollectionName { get; set; }
        /// <summary>
        /// 当前ID
        /// </summary>
        public long CurrentID { get; set; }
    }
}
