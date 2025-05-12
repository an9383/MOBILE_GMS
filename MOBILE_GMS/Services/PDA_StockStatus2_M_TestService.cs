using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mobile_gms.Libs.Database;
using mobile_gms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Services
{    
    public class PDA_StockStatus2_M_TestService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public PDA_StockStatus2_M_TestService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public List<StockStatusModel> StockStatus_Search(StockStatusModel model)
        {
            _logger.LogInformation(" [ logger ] :  PDA_StockStatus2_M_TestService > StackStandbySearch() Access : " + DateTime.Now);

            List<StockStatusModel> list = new List<StockStatusModel>();

            string SP_name = "SP_StockStatus2"; //  procedure 명 
            string gubun = "Select1";             //  Gunbun 명
            string[] param = new string[6];
            param[0] = "@start_date:" + model.start_date;
            param[1] = "@end_date:" + model.end_date;
            param[2] = "@item:" + model.item;
            param[3] = "@s_gubun:" + model.s_gubun;
            param[4] = "@obtain_status_S:" + model.obtain_status_S;
            param[5] = "@use_ck:" + model.check;

            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            //															
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StockStatusModel sm = new StockStatusModel();
                DataRow row = dt.Rows[i];
                sm.test_no = row["test_no"].ToString();                         // 시험번호
                sm.test_date = row["test_date"].ToString();                     // 입고일자
                sm.receipt_no = row["receipt_no"].ToString();                   // 입고번호
                sm.receipt_id = row["receipt_id"].ToString();                   // 입고순번
                sm.item_cd = row["item_cd"].ToString();                         // 품목 코드
                sm.item_nm = row["item_nm"].ToString();                         // 품목명
                sm.item_unit = row["item_unit"].ToString();                     // 단위
                sm.receipt_qty = row["receipt_qty"].ToString();                 // 입고량
                sm.delivery_qty = row["delivery_qty"].ToString();               // 출고량
                sm.receipt_remain_qty = row["receipt_remain_qty"].ToString();   // 재고량
                sm.receipt_disuse_qty = row["receipt_disuse_qty"].ToString();   // 불용재고
                sm.receipt_bad_qty = row["receipt_bad_qty"].ToString();         // 불량재고
                sm.obtain_status = row["obtain_status"].ToString();             // 조달구분
                sm.receipt_etc_qty = row["receipt_etc_qty"].ToString();         // 기타입고량
                sm.delivery_etc_qty = row["delivery_etc_qty"].ToString();       // 기타출고량
                sm.valid_period = row["valid_period"].ToString();               // 유효기간

                list.Add(sm);
            }
            return list;
        }
    }
}
