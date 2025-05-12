using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mobile_gms.Libs;
using mobile_gms.Models;
using mobile_gms.Services;

namespace mobile_gms.Controllers
{
    public class Product_StackStandby2Controller : Controller
    {
        static public ILogger<Product_StackStandby2Controller> _logger;

        public Product_StackStandby2Controller(ILogger<Product_StackStandby2Controller> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(string module_cd)
        {
            /*
             * [중요]
             * 역할: 로그인 체크(시작 action 에 반드시 넣어서 로그인여부를 확인한다.)
             *적용: Controller의 View 시작 action 상단에 위치해야함.
             */
            if (!Public_Function.CheckLogin(HttpContext))
            {
                // 로그인 세션이 없으면 로그인 페이지로 이동.
                return RedirectToAction("Login", "Login");
            }
            // 메뉴 목록 호출 
            MenuService menuService = new MenuService(_logger);
            // 하위 메뉴 목록 호출
            Public_Function.SubMenu_List = menuService.ListSubMenu(module_cd);
            //ViewBag.User = User;
            ViewData["MenuList"] = Public_Function.Menu_List;
            ViewData["MenuSubList"] = Public_Function.SubMenu_List;

            return View();
        }


        /// <summary>
        /// 제품 이동 적치 조회
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Product_StackStandby2Search([FromBody] Product_StackStandbyModel model)
        {
            Product_StackStandby2Service service = new Product_StackStandby2Service(_logger);
            List<Product_StackStandbyModel> list = service.Product_StackStandby2Search(model);
            return Json(list);
        }


    }
}