using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using mobile_gms.Libs;
using mobile_gms.Models;
using mobile_gms.Services;
using Newtonsoft.Json;

namespace mobile_gms.Controllers
{

    public class LoginController : Controller
    {
        static public ILogger<LoginController> _logger;
        /// <summary>
        /// ASP.NET Core와 메모리 내 캐시
        /// </summary>
        //private IMemoryCache _cache;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            //_cache = memoryCache;
        }

        [HttpGet]
        public IActionResult Login()
        {
            _logger.LogInformation("_logger >> LoginController_Login() Access : " + DateTime.Now);
            return View();
        }

        [HttpPost]
        public IActionResult Login(Menu_user model)
        {
            // 로그인 성공 여부
            bool login_success = true;
            // 공통 코드 추가
            model.sys_plant_cd = "PC001";
            // 로그인 서비스 
            LoginService loginService = new LoginService(_logger);
            // 로그인 성공 시, ture 실패면 false
            login_success = loginService.Login_Click(model);
            
            if (login_success)
            {
                HttpContext.Session.SetString("USER_NAME", Public_Function.User_nm);
                HttpContext.Session.SetString("USER_CD", Public_Function.User_cd);

                // 메뉴 목록 호출 
                MenuService menuService = new MenuService(_logger);
                // 상위 메뉴 목록 호출
                Public_Function.Menu_List = menuService.ListMenu(); 

                //HttpContext.Session.SetComplexData("MENU_LIST", Public_Function.Menu_List );


                // 하위 메뉴 목록 호출(최초)
                string initModuleCd = Public_Function.Menu_List[0].module_cd;

                return RedirectToAction("DashBoard", "Main" , new { module_cd=initModuleCd });
            }
            ModelState.AddModelError(string.Empty, "ID 또는 비밀번호가 올바르지 않습니다.");

            return View(model);
        }

        [Route("Logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_NAME");
            HttpContext.Session.Remove("USER_CD");
            return RedirectToAction("Login");
        }


        /// <summary>
        /// JSON 형변환
        /// </summary>
        public string DataTableToJSONWithStringBuilder(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }
    }
}
