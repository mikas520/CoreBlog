using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreBlog.UI.Controllers
{
    public class ArticleController : BaseController
    {
        #region 文章编辑

        #region 新增文章

        #endregion

        #region 修改文章
        public IActionResult ArticleOperationView()
        {
            return View();
        }
        #endregion

        #endregion

        #region 文章列表
        public IActionResult ArticleListView()
        {
            return View();
        }
        #endregion

        #region 文章详情
        public IActionResult ArticleDetailView()
        {
            return View();
        }
        #endregion

    }
}
