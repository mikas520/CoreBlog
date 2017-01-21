using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreBlog.Model;
using CoreBlog.Business.IClient;

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
            return View("ArticleListView");
        }
        #endregion

        #endregion

        #region 文章列表
        public IActionResult ArticleListView(int page=0)
        {
            var ArticleList= _articleClient.FindArticleByPage(0, 20);
            ViewBag.Count = ArticleList.Key;
            ViewBag.ArticleList = ArticleList.Value;
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
