using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mobile_gms.Libs;
using mobile_gms.Models;
using mobile_gms.Services;

namespace mobile_gms.Controllers
{
    public class ProductEtcInController : Controller
    {
        static public ILogger<ProductEtcInController> _logger;

        public ProductEtcInController(ILogger<ProductEtcInController> logger)
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
        /// 완제품 기본 정보(by barcode)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ProductEtcInSearch([FromBody] ProductModel pModel)
        {
            ProductEtcInService service = new ProductEtcInService(_logger);
            ProductModel model = service.ProductEtcInSearch(pModel);
            return Json(model);
        }

        /// <summary>
        /// 기타 입고 저장 처리 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveProductEtcIn([FromBody] ProductModel pModel)
        {
            ProductEtcInService service = new ProductEtcInService(_logger);
            pModel.user_cd = HttpContext.Session.GetString("USER_CD");
            string result = service.SaveProductEtcIn(pModel);
            return Json(new { result = result });
        }
    }
}