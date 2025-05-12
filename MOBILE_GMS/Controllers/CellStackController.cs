using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mobile_gms.Libs;
using mobile_gms.Libs.Database;
using mobile_gms.Models;
using mobile_gms.Services;

namespace mobile_gms.Controllers
{
    public class CellStackController : Controller
    {
        static public ILogger<CellStackController> _logger;
        static CellStackModel cs = new CellStackModel();

        private string _strBarcode = "";     //바코드 변수        
        //public CBScanner BScanner;

        public CellStackController(ILogger<CellStackController> logger)
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

            /*
             * PDA 위치 별 적치 로직
             */

            ViewData["barcode"] = menuModel.cell_cd;
            ViewData["c_barcode"] = menuModel.c_barcode;

            return View();
        }


        [HttpPost]
        public JsonResult fncCellDataSearch([FromBody] CellStackModel CellStackModel)
        {
            //string barcode = packModel.barcode; 
            _strBarcode = CellStackModel.barcode;
            cs.cell_cd = _strBarcode;
            cs.barcode = _strBarcode;
            CellStackService service = new CellStackService(_logger);

            // 위치 별 적치 상세 정보
            CellStackModel CellInfoModel = new CellStackModel();

            if (_strBarcode != "" && _strBarcode.Substring(0, 1).ToString() == Public_Function.BarcodePrefix_Cell)
            {
                CellInfoModel = service.fncCellDataSearch(cs);
            }
            else if (_strBarcode != "" && _strBarcode.Substring(0, 1).ToString() == Public_Function.BarcodePrefix_Zone || _strBarcode.Substring(0, 1).ToString() == Public_Function.BarcodePrefix_Workroom)
            {
                CellInfoModel = service.fncAreaDataSearch(cs);
            }         

            return Json(CellInfoModel);
        }

        [HttpPost]
        public JsonResult fn_callPack_Select([FromBody] CellStackModel CellStackModel)
        {
            CellStackService service = new CellStackService(_logger);
            List<CellStackModel> list = service.fn_callPack_Select(CellStackModel);

            return Json(list);
        }

        /// <summary>
        /// 적치 버튼 클릭 이벤트
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PackStack([FromBody] CellStackModel CellStackModel)
        {
            CellStackService service = new CellStackService(_logger);
            CellStackModel.gubun = "picking_pack";
            CellStackModel.user_id = Public_Function.User_id;

            string result = service.PackStack(CellStackModel);

            return Json(new { result = result });
        }

        /// <summary>
        /// 팩 리스트 추가
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddPack([FromBody] CellStackModel CellStackModel)
        {
            CellStackService service = new CellStackService(_logger);
            List<CellStackModel> list = service.AddPack(CellStackModel);

            return Json(list);
        }

    }
}