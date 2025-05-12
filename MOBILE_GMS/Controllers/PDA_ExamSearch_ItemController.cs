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
    public class PDA_ExamSearch_ItemController : Controller
    {
        static public ILogger<PDA_ExamSearch_ItemController> _logger;

        public PDA_ExamSearch_ItemController(ILogger<PDA_ExamSearch_ItemController> logger)
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

            _logger.LogInformation("_logger >> MainController_DashBoard() Aceess : " + DateTime.Now);

            // 메뉴 목록 호출
            MenuService menuService = new MenuService(_logger);

            Public_Function.SubMenu_List = menuService.ListSubMenu(module_cd);

            ViewData["MenuList"] = Public_Function.Menu_List;
            ViewData["MenuSubList"] = Public_Function.SubMenu_List;

            return View();
        }

        /// <summary>
        /// 제조번호 별 기본테이블 search
        /// </summary>
        /// <returns></returns>
        public JsonResult ExamSelect([FromBody] ItemLocationSelectModel model)
        {
            _logger.LogInformation(" [ logger ] :  PDA_ExamSearch_PMController > ExamSearch() Access : " + DateTime.Now);

            ItemLocationSelectService service = new ItemLocationSelectService(_logger);
            List<ItemLocationSelectModel> list = service.ExamSelect(model);

            return Json(list);
        }

        /// <summary>
        /// 제조번호 별 위치조회
        /// </summary>
        /// <returns></returns>
        public JsonResult ExamSearch([FromBody] ItemLocationSelectModel model)
        {
            _logger.LogInformation(" [ logger ] :  PDA_ExamSearch_PMController > ExamSearch() Access : " + DateTime.Now);

            ItemLocationSelectService service = new ItemLocationSelectService(_logger);
            List<ItemLocationSelectModel> list = service.ExamSearch(model);

            return Json(list);
        }
    }

}
