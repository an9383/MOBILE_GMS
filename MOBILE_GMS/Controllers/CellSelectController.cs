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
    public class CellSelectController : Controller
    {
        static public ILogger<CellSelectController> _logger;

        public CellSelectController(ILogger<CellSelectController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(MenuModel menuModel)
        {
            _logger.LogInformation("_logger >> CellSelectController Index() Access : " + DateTime.Now);
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
            ViewData["barcode"] = menuModel.barcode;

            return View();
        }

        /// <summary>
        /// 셀 정보 호출
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SelectCell([FromBody] CellSelectModel cellSelectModel)
        {
            //string barcode = packModel.barcode; 

            CellSelectService service = new CellSelectService(_logger);
            CellSelectModel model = service.SelectCell(cellSelectModel);


            return Json(model);
        }

        /// <summary>
        /// 그리드 조회(셀 리스트)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GridSelectCell([FromBody] CellSelectModel cellSelectModel)
        {
            CellSelectService service = new CellSelectService(_logger);
            List<CellSelectModel> list = service.GridSelectCell(cellSelectModel);

            return Json(list);
        }


        public IActionResult detail(string module_cd)
        {
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

            _logger.LogInformation("_logger >> MainController_DashBoard() Access : " + DateTime.Now);

            // 메뉴 목록 호출 
            MenuService menuService = new MenuService(_logger);
            // 하위 메뉴 목록 호출
            Public_Function.SubMenu_List = menuService.ListSubMenu(module_cd);

            //ViewBag.User = User;
            ViewData["MenuList"] = Public_Function.Menu_List;
            ViewData["MenuSubList"] = Public_Function.SubMenu_List;


            return View();
        }

    }
}