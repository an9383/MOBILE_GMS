using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using mobile_gms.Libs;
using mobile_gms.Models;
using mobile_gms.Services;

namespace mobile_gms.Controllers
{
    public class PDA_ExamSearch_PMController : Controller
    {

        static public ILogger<PDA_ExamSearch_PMController> _logger;

        public PDA_ExamSearch_PMController(ILogger<PDA_ExamSearch_PMController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string module_cd)
        {
            /*
             * [중요]
             * 역할 : 로그인 체크(시작 action에 반드시 넣어서 로그인 여부를 확인
             * 적용 : Controller의 View시작 acton 상단에 위치하여야 함
             */
            if (!Public_Function.CheckLogin(HttpContext))
            {
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

        /// <summary>
        /// 시험번호 별 위치조회 
        /// </summary>
        /// <returns></returns>
        public JsonResult ExamSearch([FromBody] PackLocationSelectModel model)
        {
            _logger.LogInformation(" [ logger ] :  PDA_ExamSearch_PMController > ExamSearch() Access : " + DateTime.Now);

            PackLocationSelectService service = new PackLocationSelectService(_logger);
            List<PackLocationSelectModel> list = service.ExamSearch(model);

            return Json(list);
        }
    }
}
