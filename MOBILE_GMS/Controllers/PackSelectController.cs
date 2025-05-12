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
    public class PackSelectController : Controller
    {
        static public ILogger<PackSelectController> _logger;

        public PackSelectController(ILogger<PackSelectController> logger)
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
            ViewData["module_cd"] = menuModel.module_cd;
            ViewData["barcode"] = menuModel.barcode;

            return View();
        }

        /// <summary>
        /// 팩 정보 호출
        /// </summary>
        /// <param name="packinfo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SelectPack([FromBody] PackModel packModel)
        { 
            //string barcode = packModel.barcode; 

            PackSelectService service = new PackSelectService(_logger);
            PackModel model = service.SelectPack(packModel);

            //PackModel pm = new PackModel();
            //pm.barcode = "xxxx";

            return Json(model);
        }


        //
        /// <summary>
        /// 그리드 조회(팩 사용 히스토리)
        /// </summary>
        /// <param name="packinfo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GridSelectPack([FromBody] PackModel packModel)
        { 
            PackSelectService service = new PackSelectService(_logger);
            List<PackModel> list = service.GridSelectPack(packModel);

            //PackModel pm = new PackModel();
            //pm.barcode = "xxxx";

            return Json(list);
        }
         
        //
        /// <summary>
        /// 팩 피킹 처리
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PickSelectPack([FromBody] PackModel packModel)
        {
            PackSelectService service = new PackSelectService(_logger);
            packModel.gubun = "picking_pack"; 
            packModel.user_cd = HttpContext.Session.GetString("USER_CD");
            _logger.LogInformation("_logger >>>>>>>>>>>>>>>>>>>>>>>> areaModel.user_cd : " + packModel.user_cd);
            string result = service.PickSelectPack(packModel);

            return Json(new { result = result });
        }

        //
        /// <summary>
        /// 지함(box) 피킹 처리
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PickSelectBox([FromBody] PackModel packModel)
        {
            PackSelectService service = new PackSelectService(_logger);
            packModel.gubun = "picking_box";
            packModel.user_cd = HttpContext.Session.GetString("USER_CD");
            _logger.LogInformation("_logger >>>>>>>>>>>>>>>>>>>>>>>> areaModel.user_cd : " + packModel.user_cd);
            string result = service.PickSelectBox(packModel);

            return Json(new { result = result });
        }
    }
}