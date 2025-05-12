using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using mobile_gms.Controllers;
using mobile_gms.DataContext;
using mobile_gms.Libs;
using mobile_gms.Libs.Database;
using mobile_gms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile_gms.Services
{
    public class LoginService
    {
        static public ILogger<LoginController> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();
        public BIILogin bIILogin = new BIILogin();


        public LoginService (ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        
        public bool Login_Click(Menu_user model)
        {
            _logger.LogInformation("_logger >> LoginService_Login_Click() Access : " + DateTime.Now);
            
            // 로그인 성공 여부 리턴 값
            bool login_success = false;
            
            string SP_name = "SP_Login"; // procedure 명 
            string gubun = "B_Login"; // Gunbun 명

            bIILogin.user_id = model.ID;
            bIILogin.pass = model.pass;


            // Login 성공 여부
            string log = bIILogin.log;

            if (log == "OK")
            {
                login_success = true;
                
                gubun = "UserInfo2";  //사용자 정보
                string[] param = new string[1];
                param[0] = "@user_id:" + model.ID;

                DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

                Public_Function.User_id = model.ID;
                Public_Function.User_id_nm = dt.Rows[0]["user_id_nm"].ToString();
                Public_Function.User_cd = dt.Rows[0]["emp_cd"].ToString();
                Public_Function.User_nm = dt.Rows[0]["user_nm"].ToString();
                Public_Function.Dept_cd = dt.Rows[0]["user_dept_cd"].ToString();
                Public_Function.Dept_nm = dt.Rows[0]["user_dept_nm"].ToString();
                Public_Function.emp_charge = dt.Rows[0]["emp_charge"].ToString();
                Public_Function.NewUser = dt.Rows[0]["new_user"].ToString();

                // 바코드 초기 셋팅
                BarcodePrefix_Set();

            }

            return login_success;
        }

        private void BarcodePrefix_Set()
        {
            string[] param = new string[1];
            param[0] = "@user_id:" + "";

            DataTable dtBarcodePrefix = new DataTable();

            //DB를 변경하는 기능을 지원하기 위해 매번 객체 생성하는 방식으로 변경 2012-05-21 최석중            
            dtBarcodePrefix = _bllSpExecute.SpExecuteTable("SP_Login", "BarcodePrefix_Search", param);            

            // 조회된 데이터가 있을 경우
            if (dtBarcodePrefix.Rows.Count > 0)
            {
                Public_Function.BarcodePrefix_Pack = dtBarcodePrefix.Rows[0]["BarcodePrefix_Pack"].ToString();
                Public_Function.BarcodePrefix_Workroom = dtBarcodePrefix.Rows[0]["BarcodePrefix_Workroom"].ToString();
                Public_Function.BarcodePrefix_Zone = dtBarcodePrefix.Rows[0]["BarcodePrefix_Zone"].ToString();
                Public_Function.BarcodePrefix_Cell = dtBarcodePrefix.Rows[0]["BarcodePrefix_Cell"].ToString();
                Public_Function.BarcodePrefix_Pallet = dtBarcodePrefix.Rows[0]["BarcodePrefix_Pallet"].ToString();
                Public_Function.BarcodePrefix_Bulk = dtBarcodePrefix.Rows[0]["BarcodePrefix_Bulk"].ToString();
                Public_Function.BarcodePrefix_Box = dtBarcodePrefix.Rows[0]["BarcodePrefix_Box"].ToString();
            }
        }
    }
}
