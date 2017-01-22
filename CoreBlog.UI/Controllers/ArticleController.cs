using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreBlog.Model;
using CoreBlog.Business.IClient;
using CoreBlog.Business.Query;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreBlog.UI.Controllers
{
    public class ArticleController : BaseController
    {
        private IArticleClient _articleClient;
        public ArticleController(IArticleClient articleClient)
        {
            _articleClient = articleClient;
        }
        #region 文章编辑

        #region 新增文章

        #endregion

        #region 修改文章
        public IActionResult ArticleOperationView(long id =0)
        {
            Article model = null;
            if (id>0)
            {
               model= _articleClient.FindArticleByID(id);
            }
            return View(model??new Article());
        }
        public IActionResult ArticleOperationSave()
        {
            var article = new Article()
            {
                _id = Convert.ToInt64(Request.Form["_id"]),
                Content = Request.Form["Content"].ToString() ?? string.Empty,
                CreateBy = Request.Form["CreateBy"].ToString() ?? string.Empty,
                Like = 0,
                Tag = Request.Form["Tag"].ToString() ?? string.Empty,
                CreateOn=DateTime.Now,
                Title=Request.Form["Title"].ToString()??string.Empty,
                UnLike=0,
                UserID="",
                Watch=0
            };
            if (article._id > 0)
            {
                _articleClient.UpdateArticle(article);
            }
            else
            {
                _articleClient.InsertArticle(article);
            }
            return RedirectToAction("ArticleListView");
        }
        #endregion

        #endregion

        #region 文章列表
        public IActionResult ArticleListView(int page=1)
        {
            var query = new ArticleQuery() {
                Count = true,
                CreateOn = null,
                PageNum=page,
                Size=10,
                Title="",
                UserID=0,
            };
            var ArticleList= _articleClient.FindArticleByPage(query);
            ViewBag.Count = (ArticleList.Key+ query.Size -1)/ query.Size;
            ViewBag.ArticleList = ArticleList.Value;
            return View();
        }
        #endregion

        #region 文章详情
        public IActionResult ArticleDetailView(long id=0)
        {
            if (id <= 0)
            {
               return View("ArticleListView");
            }
            var article= _articleClient.FindArticleByID(id);
            return View(article);
        }
        #endregion

    }
}
