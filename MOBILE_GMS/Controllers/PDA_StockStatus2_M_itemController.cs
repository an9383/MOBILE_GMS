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
    public class PDA_StockStatus2_M_itemController : Controller
    {
        static public ILogger<PDA_StockStatus2_M_itemController> _logger;

        public PDA_StockStatus2_M_itemController(ILogger<PDA_StockStatus2_M_itemController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index(MenuModel menuModel)
        {
            _logger.LogInformation("_logger >> PDA_StockStatus2_M_itemController Index() Access : " + DateTime.Now);
            /*
             * [중요]
             * 역할: 로그인 체크( 시작 action 에 반드시 넣어서 로그인여부를 확인한다.) 
             * 적용: Controller의 View 시작 action 상단에 위치해야함.
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
            ViewData["module_cd"] = menuModel.module_cd;

            return View();
        }

        /// <summary>
        /// 시험완료품목 이동 대상 조회
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult StockStatus_Search([FromBody] StockStatusModel model)
        {
            PDA_StockStatus2_M_itemService service = new PDA_StockStatus2_M_itemService(_logger);
            List<StockStatusModel> list = service.StockStatus_Search(model);
            return Json(list);
        }

    }
}