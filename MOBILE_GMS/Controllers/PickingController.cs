using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mobile_gms.Libs;
using mobile_gms.Models;
using mobile_gms.Services;
using Newtonsoft.Json;

namespace mobile_gms.Controllers
{
    public class PickingController : Controller
    {
        static public ILogger<PickingController> _logger;

        public PickingController(ILogger<PickingController> logger)
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

            string barcode = menuModel.barcode;
            ViewData["barcode"] = barcode;

            return View();
        }

        /// <summary>
        /// 피킹-창고상세 정보
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SelectWorkroom([FromBody] AreaModel areaModel)
        {
            PickingService service = new PickingService(_logger);
            DataSet dataSet = service.SelectWorkroom(areaModel);

            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

            return Json(json);
        }

        /// <summary>
        /// 피킹-구역 상세 정보
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SelectZone([FromBody] AreaModel areaModel)
        {
            PickingService service = new PickingService(_logger);
            DataSet dataSet = service.SelectZone(areaModel);

            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

            return Json(json);
        }
        /// <summary>
        /// 피킹-셀 상세 정보
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SelectCell([FromBody] AreaModel areaModel)
        {
            PickingService service = new PickingService(_logger);
            DataSet dataSet = service.SelectCell(areaModel);

            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

            return Json(json);
        }
         
        /// <summary>
        /// 선택한 팩 1개에 대한 상세 정보 호출[팩정보]
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SelectPickPackInfo([FromBody] PackModel packModel)
        {
            PickingService service = new PickingService(_logger);
            PackModel model = service.SelectPickPackInfo(packModel);
            return Json(model);
        }

        /// <summary>
        /// 선택한 지함 1개에 대한 상세 정보 호출[지함 정보]
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SelectPickBoxInfo([FromBody] PackModel packModel)
        {
            PickingService service = new PickingService(_logger);
            PackModel model = service.SelectPickBoxInfo(packModel);
            return Json(model);
        }

        //
        /// <summary>
        /// 팩 피킹 처리
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PickPack([FromBody] PackModel packModel)
        {
            PickingService service = new PickingService(_logger);
            packModel.gubun = "picking_pack";
            packModel.user_cd = HttpContext.Session.GetString("USER_CD");
            string result = service.PickPack(packModel);

            return Json(new { result = result });
        }

        //
        /// <summary>
        /// 지함 피킹 처리
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PickBox([FromBody] PackModel packModel)
        {
            PickingService service = new PickingService(_logger);
            packModel.gubun = "picking_box";
            packModel.user_cd = HttpContext.Session.GetString("USER_CD");
            string result = service.PickBox(packModel);

            return Json(new { result = result });
        }


        /// <summary>
        /// 팔렛트 피킹 처리
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PickPallet([FromBody] PackModel packModel)
        {
            PickingService service = new PickingService(_logger);
            packModel.gubun = "picking_pallet";
            packModel.user_cd = HttpContext.Session.GetString("USER_CD");
            string result = service.PickPallet(packModel);

            return Json(new { result = result });
        }
    }
}