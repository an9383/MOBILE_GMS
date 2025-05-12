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
    public class ItemLocationSelectController : Controller
    {
        static public ILogger<ItemLocationSelectController> _logger;

        public ItemLocationSelectController(ILogger<ItemLocationSelectController> logger)
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
        /// 제품 별 위치 조회
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ItemLocationSelectSearch([FromBody] ItemLocationSelectModel model)
        {
            ItemLocationSelectService service = new ItemLocationSelectService(_logger);
            List<ItemLocationSelectModel> list = service.ItemLocationSelectSearch(model);
            return Json(list);
        }
         
        /// <summary>
        /// 제품 별 위치 조회( by 바코드[지함])
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ItemLocationSelectBoxSearch([FromBody] ItemLocationSelectModel model)
        {
            ItemLocationSelectService service = new ItemLocationSelectService(_logger);
            List<ItemLocationSelectModel> list = service.ItemLocationSelectBoxSearch(model);
            return Json(list);
        }

        /// <summary>
        /// 제품 별 위치 조회( by 바코드[팩])
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ItemLocationSelectPackSearch([FromBody] ItemLocationSelectModel model)
        {
            ItemLocationSelectService service = new ItemLocationSelectService(_logger);
            List<ItemLocationSelectModel> list = service.ItemLocationSelectPackSearch(model);
            return Json(list);
        }

    }
}