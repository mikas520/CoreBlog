using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreBlog.UI.Controllers
{
    public class MemberController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        #region 注册
        public IActionResult Register()
        {
            return View();
        }
        #endregion

        #region 个人资料编辑
        public IActionResult UserInformationOperation()
        {
            return View();
        }
        #endregion
    }
}
