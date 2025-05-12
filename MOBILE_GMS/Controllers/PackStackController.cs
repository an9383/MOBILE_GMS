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
    public class PackStackController : Controller
    {
        static public ILogger<PackStackController> _logger;

        public PackStackController(ILogger<PackStackController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(MenuModel menuModel)
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
            Public_Function.SubMenu_List = menuService.ListSubMenu(menuModel.module_cd);
            //ViewBag.User = User;
            ViewData["MenuList"] = Public_Function.Menu_List;
            ViewData["MenuSubList"] = Public_Function.SubMenu_List;

            ViewData["barcode"] = menuModel.barcode;
            ViewData["area_barcode"] = menuModel.area_barcode;
            ViewData["module_cd"] = menuModel.module_cd; 
            
            return View();
        } 
         
        //
        /// <summary>
        /// 적치 위치 호출
        /// </summary> 
        /// <returns></returns>
        [HttpPost]
        public JsonResult SelectArea([FromBody] AreaModel areaModel)
        {
            PackStackService service = new PackStackService(_logger);
            AreaModel model = service.SelectArea(areaModel);
            return Json(model);
        }

        //
        /// <summary>
        /// 팩 적치
        /// </summary> 
        /// <returns></returns>
        [HttpPost]
        public JsonResult StackPack([FromBody] AreaModel areaModel)
        {
            PackStackService service = new PackStackService(_logger);
            areaModel.gubun = "stack_pack";
            string result = service.StackPack(areaModel);
            return Json(new { result = result });
        }


        //
        /// <summary>
        /// 지함 적치
        /// </summary> 
        /// <returns></returns>
        [HttpPost]
        public JsonResult StackBox([FromBody] AreaModel areaModel)
        {
            PackStackService service = new PackStackService(_logger);
            areaModel.gubun = "stack_box";
            areaModel.user_cd = HttpContext.Session.GetString("USER_CD");
            string result = service.StackBox(areaModel);
            return Json(new { result = result });
        }

    }
}